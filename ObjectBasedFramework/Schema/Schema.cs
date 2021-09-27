using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using ClussPro.Base.Extensions;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClussPro.ObjectBasedFramework.Schema
{
    public class Schema
    {
        private static Schema instance;
        internal static Schema Instance
        {
            get
            {
                if (instance == null)
                {
                    if (schemaLoading)
                    {
                        while (schemaLoading) { Thread.Sleep(50); }
                    }
                    else
                    {
                        instance = new Schema();
                    }
                }

                return instance;
            }
        }
        private static bool schemaLoading = false;

        private List<SchemaObject> schemaObjects = new List<SchemaObject>();
        private Dictionary<Type, SchemaObject> schemaObjectsByType = new Dictionary<Type, SchemaObject>();
        private Dictionary<string, Dictionary<string, SchemaObject>> schemaObjectsBySchemaObjectNames = new Dictionary<string, Dictionary<string, SchemaObject>>();

        private Schema()
        {
            schemaLoading = true;
            // Discover all top-level data objects (those that contain the Table attribute)
            Dictionary<Type, Tuple<int, Type>> depthAndSubTypesByTableType = new Dictionary<Type, Tuple<int, Type>>();
            foreach(Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                try
                {
                    foreach (Type type in assembly.GetTypes().Where(t => t.GetCustomAttribute<TableAttribute>(false) != null))
                    {
                        depthAndSubTypesByTableType[type] = new Tuple<int, Type>(0, type);
                    }
                }
                catch { }
            }

            foreach(Type mainTableType in depthAndSubTypesByTableType.Keys.ToList())
            {
                foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    try
                    {
                        foreach (Type derivedType in assembly.GetTypes().Where(t => t != mainTableType && mainTableType.IsAssignableFrom(t)))
                        {
                            int hops = 0;
                            Type workingType = derivedType;
                            while (workingType != mainTableType)
                            {
                                hops++;
                                workingType = workingType.BaseType;
                            }

                            int oldHops = depthAndSubTypesByTableType[mainTableType].Item1;
                            if (hops > oldHops)
                            {
                                depthAndSubTypesByTableType[mainTableType] = new Tuple<int, Type>(hops, derivedType);
                            }
                        }
                    }
                    catch { }
                }
            }

            foreach (KeyValuePair<Type, Tuple<int, Type>> kvp in depthAndSubTypesByTableType)
            {
                SchemaObject newSchemaObject = new SchemaObject(kvp.Value.Item2);

                schemaObjects.Add(newSchemaObject);
                schemaObjectsByType.Add(kvp.Value.Item2, newSchemaObject);
                if (!schemaObjectsByType.ContainsKey(kvp.Key))
                {
                    schemaObjectsByType.Add(kvp.Key, newSchemaObject);
                }
                schemaObjectsBySchemaObjectNames.GetOrSet(newSchemaObject.SchemaName, () => new Dictionary<string, SchemaObject>()).GetOrSet(newSchemaObject.ObjectName, () => newSchemaObject);
            }

            foreach(SchemaObject schemaObject in schemaObjects)
            {
                foreach(Relationship relationship in schemaObject.GetRelationships())
                {
                    relationship.RelatedSchemaObject = schemaObjectsByType[relationship.RelatedObjectType];
                    relationship.ParentKeyField = relationship.RelatedSchemaObject.GetField(relationship.RelationshipAttribute.ParentKeyField) ?? relationship.RelatedSchemaObject.PrimaryKeyField;
                }

                foreach(RelationshipList relationshipList in schemaObject.GetRelationshipLists())
                {
                    relationshipList.RelatedSchemaObject = schemaObjectsByType[relationshipList.RelatedObjectType];
                }
            }

            schemaLoading = false;
        }

        public static SchemaObject GetSchemaObject<T>()
        {
            return GetSchemaObject(typeof(T));
        }

        public static SchemaObject GetSchemaObject(Type type)
        {
            if (!Instance.schemaObjectsByType.ContainsKey(type))
            {
                return null;
            }

            return Instance.schemaObjectsByType[type];
        }

        public static SchemaObject GetSchemaObject(string schema, string objectName)
        {
            if (!Instance.schemaObjectsBySchemaObjectNames.ContainsKey(schema))
            {
                return null;
            }

            if (!Instance.schemaObjectsBySchemaObjectNames[schema].ContainsKey(objectName))
            {
                return null;
            }

            return Instance.schemaObjectsBySchemaObjectNames[schema][objectName];
        }

        public static IReadOnlyCollection<SchemaObject> GetAllSchemaObjects()
        {
            return Instance.schemaObjects;
        }

        public static void Deploy()
        {
            foreach (IGrouping<string, SchemaObject> schemaObjectsByConnectionName in Instance.schemaObjects.GroupBy(so => so.ConnectionName))
            {
                ITransaction deploymentTransaction = SQLProviderFactory.GenerateTransaction(schemaObjectsByConnectionName.Key ?? "_default");

                try
                {
                    HashSet<string> schemas = schemaObjectsByConnectionName.Select(schemaObject => schemaObject.SchemaName).ToHashSet();

                    foreach (string schema in schemas)
                    {
                        ICreateSchema createSchema = SQLProviderFactory.GetCreateSchemaQuery();
                        createSchema.SchemaName = schema;
                        createSchema.Execute(deploymentTransaction);
                    }

                    foreach (SchemaObject schemaObject in schemaObjectsByConnectionName)
                    {
                        ICreateTable createTable = SQLProviderFactory.GetCreateTableQuery();
                        createTable.SchemaName = schemaObject.SchemaName;
                        createTable.TableName = schemaObject.ObjectName;

                        foreach (Field field in schemaObject.GetFields().Where(f => !f.HasOperation))
                        {
                            FieldSpecification fieldSpec = new FieldSpecification(field.FieldType, field.DataSize, field.DataScale);
                            if (field == schemaObject.PrimaryKeyField)
                            {
                                fieldSpec.IsPrimary = true;
                            }

                            createTable.Columns.Add(field.FieldName, fieldSpec);
                        }

                        createTable.Execute(deploymentTransaction);
                    }

                    foreach (Relationship relationship in schemaObjectsByConnectionName.SelectMany(so => so.GetRelationships()))
                    {
                        string fkName = $"FK{relationship.ParentSchemaObject.ObjectName}_{relationship.RelatedSchemaObject.ObjectName}_{relationship.ForeignKeyField.FieldName}";
                        IAlterTable alterTableQuery = SQLProviderFactory.GetAlterTableQuery();
                        alterTableQuery.Schema = relationship.ParentSchemaObject.SchemaName;
                        alterTableQuery.Table = relationship.ParentSchemaObject.ObjectName;
                        alterTableQuery.AddForeignKey(fkName, relationship.ForeignKeyField.FieldName, relationship.RelatedSchemaObject.SchemaName, relationship.RelatedSchemaObject.ObjectName, relationship.ParentKeyField.FieldName, deploymentTransaction);
                    }

                    deploymentTransaction.Commit();
                }
                finally
                {
                    if (deploymentTransaction.IsActive)
                    {
                        deploymentTransaction.Rollback();
                    }
                }
            }
        }

        public static void UnDeploy()
        {
            ITransaction undeploymentTransaction = null;

            foreach (IGrouping<string, SchemaObject> schemaObjectsByConnectionName in Instance.schemaObjects.GroupBy(so => so.ConnectionName))
            {
                try
                {
                    undeploymentTransaction = SQLProviderFactory.GenerateTransaction(schemaObjectsByConnectionName.Key ?? "_default");

                    foreach (Relationship relationship in schemaObjectsByConnectionName.SelectMany(so => so.GetRelationships()))
                    {
                        string fkName = $"FK{relationship.ParentSchemaObject.ObjectName}_{relationship.RelatedSchemaObject.ObjectName}_{relationship.ForeignKeyField.FieldName}";
                        IAlterTable alterTableQuery = SQLProviderFactory.GetAlterTableQuery();
                        alterTableQuery.Schema = relationship.ParentSchemaObject.SchemaName;
                        alterTableQuery.Table = relationship.ParentSchemaObject.ObjectName;
                        alterTableQuery.DropConstraint(fkName, undeploymentTransaction);
                    }

                    foreach (SchemaObject schemaObject in schemaObjectsByConnectionName)
                    {
                        IDropTable dropTable = SQLProviderFactory.GetDropTableQuery();
                        dropTable.Schema = schemaObject.SchemaName;
                        dropTable.Table = schemaObject.ObjectName;
                        dropTable.Execute(undeploymentTransaction);
                    }

                    HashSet<string> schemas = schemaObjectsByConnectionName.Select(so => so.SchemaName).ToHashSet();
                    foreach (string schema in schemas)
                    {
                        IDropSchema dropSchema = SQLProviderFactory.GetDropSchemaQuery();
                        dropSchema.Schema = schema;
                        dropSchema.Execute(undeploymentTransaction);
                    }

                    undeploymentTransaction.Commit();
                }
                finally
                {
                    if (undeploymentTransaction != null && undeploymentTransaction.IsActive)
                    {
                        undeploymentTransaction.Rollback();
                    }
                }
            }
        }
    }
}
