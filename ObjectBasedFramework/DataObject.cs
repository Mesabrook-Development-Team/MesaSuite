﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Conditions;
using ClussPro.Base.Data.Operand;
using ClussPro.Base.Data.Query;
using ClussPro.Base.Extensions;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema;
using ClussPro.ObjectBasedFramework.Validation;
using Newtonsoft.Json;

namespace ClussPro.ObjectBasedFramework
{
    public class DataObject
    {
        private bool isEditable;
        private bool isInsert;

        protected bool IsEditable => isEditable;
        protected bool IsInsert => isInsert;

        private HashSet<string> retrievedPaths = new HashSet<string>();

        [JsonIgnore]
        public Errors Errors { get; } = new Errors();

        private List<FKConstraintConflict> fKConstraintConflicts = new List<FKConstraintConflict>();
        [JsonIgnore]
        public IReadOnlyCollection<FKConstraintConflict> ForeignKeyConstraintConflicts => fKConstraintConflicts;

        private Dictionary<string, object> originalValues = new Dictionary<string, object>();

        protected DataObject()
        {
            isEditable = true;
            isInsert = true;
        }

        private DataObject(bool isEditable, bool isInsert)
        {
            this.isEditable = isEditable;
            this.isInsert = isInsert;
        }

        public bool Save(ITransaction transaction = null, List<Guid> saveFlags = null)
        {
            if (!isEditable)
            {
                throw new System.Data.ReadOnlyException("Attempt to call Save on a Read Only Data Object");
            }

            PreValidate();
            Validate(isInsert ? Validator.SaveModes.Insert : Validator.SaveModes.Update, saveFlags);

            if (Errors.Any())
            {
                return false;
            }

            ITransaction localTransaction = transaction == null ? SQLProviderFactory.GenerateTransaction() : transaction;
            try
            {
                if (!PreSave(localTransaction))
                {
                    return false;
                }

                if (!(isInsert ? SaveInsert(localTransaction) : SaveUpdate(localTransaction)))
                {
                    return false;
                }

                if (!PostSave(localTransaction))
                {
                    return false;
                }
                isInsert = false;

                foreach (Schema.Field field in Schema.Schema.GetSchemaObject(GetType()).GetFields())
                {
                    originalValues[field.FieldName] = field.GetValue(this);
                }

                if (transaction == null)
                {
                    localTransaction.Commit();
                }
            }
            finally
            {
                if (transaction == null && localTransaction.IsActive)
                {
                    localTransaction.Rollback();
                }
            }

            return true;
        }

        public bool Delete(ITransaction transaction = null, List<Guid> saveFlags = null)
        {
            ITransaction localTransaction = transaction == null ? SQLProviderFactory.GenerateTransaction() : transaction;

            try
            {
                if (!isEditable)
                {
                    throw new System.Data.ReadOnlyException("Attempt to call Delete on a Read Only Data Object");
                }

                PreValidate();
                Validate(Validator.SaveModes.Delete, saveFlags);

                if (Errors.Any())
                {
                    return false;
                }

                fKConstraintConflicts = GetFKConstraintConflicts(localTransaction);
                if (fKConstraintConflicts.Any())
                {
                    HandleFKConstraintConflicts(fKConstraintConflicts, localTransaction);
                    if (fKConstraintConflicts.Any())
                    {
                        return false;
                    }
                }

                if (!PreDelete(localTransaction))
                {
                    return false;
                }

                SchemaObject schemaObject = Schema.Schema.GetSchemaObject(GetType());

                IDeleteQuery deleteQuery = SQLProviderFactory.GetDeleteQuery();
                deleteQuery.Table = new Table(schemaObject.SchemaName, schemaObject.ObjectName);
                deleteQuery.Condition = new Condition()
                {
                    Left = (Base.Data.Operand.Field)schemaObject.PrimaryKeyField.FieldName,
                    ConditionType = Condition.ConditionTypes.Equal,
                    Right = new Literal(schemaObject.PrimaryKeyField.GetValue(this))
                };

                deleteQuery.Execute(localTransaction);

                if (!PostDelete(localTransaction))
                {
                    return false;
                }

                if (transaction == null)
                {
                    localTransaction.Commit();
                }
            }
            finally
            {
                if (transaction == null && localTransaction.IsActive)
                {
                    localTransaction.Rollback();
                }
            }

            return true;
        }

        protected virtual List<FKConstraintConflict> GetFKConstraintConflicts(ITransaction transaction)
        {
            List<FKConstraintConflict> fKConstraintConflicts = new List<FKConstraintConflict>();
            SchemaObject mySchemaObject = Schema.Schema.GetSchemaObject(GetType());
            Schema.Field primaryKeyField = mySchemaObject.PrimaryKeyField;

            foreach(RelationshipList relationshipList in Schema.Schema.GetSchemaObject(GetType()).GetRelationshipLists())
            {
                SchemaObject relatedSchemaObject = Schema.Schema.GetSchemaObject(relationshipList.RelatedObjectType);
                Schema.Field relatedField = relatedSchemaObject.GetField(relationshipList.ForeignKeyName);

                ISelectQuery relationshipListQuery = SQLProviderFactory.GetSelectQuery();
                relationshipListQuery.SelectList.Add(relatedSchemaObject.PrimaryKeyField.FieldName);
                relationshipListQuery.Table = new Table(relatedSchemaObject.SchemaName, relatedSchemaObject.ObjectName);
                relationshipListQuery.WhereCondition = new Condition()
                {
                    Left = (Base.Data.Operand.Field)relatedField.FieldName,
                    ConditionType = Condition.ConditionTypes.Equal,
                    Right = new Literal(primaryKeyField.GetValue(this))
                };

                DataTable results = relationshipListQuery.Execute(transaction);
                foreach(DataRow row in results.Rows)
                {
                    FKConstraintConflict fKConstraintConflict = new FKConstraintConflict();
                    fKConstraintConflict.ConflictType = relationshipList.RelatedObjectType;
                    fKConstraintConflict.ForeignKey = row[relatedSchemaObject.PrimaryKeyField.FieldName] as long?;
                    fKConstraintConflict.ForeignKeyName = relatedField.FieldName;
                    fKConstraintConflict.ActionType = relationshipList.AutoDeleteReferences ?
                                                        FKConstraintConflict.ActionTypes.AutoDeleteReference :
                                                        relationshipList.AutoRemoveReferences ?
                                                            FKConstraintConflict.ActionTypes.AutoRemoveReference :
                                                            FKConstraintConflict.ActionTypes.Conflict;

                    fKConstraintConflicts.Add(fKConstraintConflict);
                }
            }

            return fKConstraintConflicts;
        }

        private void HandleFKConstraintConflicts(List<FKConstraintConflict> conflicts, ITransaction transaction)
        {
            HashSet<FKConstraintConflict> handled = new HashSet<FKConstraintConflict>();
            IEnumerable<IGrouping<Type, FKConstraintConflict>> constraintsByType = conflicts.GroupBy(conf => conf.ConflictType);

            foreach(IGrouping<Type, FKConstraintConflict> constraintGroup in constraintsByType)
            {
                SchemaObject foreignSchemaObject = Schema.Schema.GetSchemaObject(constraintGroup.Key);
                foreach (IGrouping<string, FKConstraintConflict> constraintGroupByField in constraintGroup.GroupBy(fk => fk.ForeignKeyName))
                {
                    List<long> autoDeleteReferenceKeys = new List<long>();
                    List<long> autoRemoveReferenceKeys = new List<long>();

                    foreach (FKConstraintConflict fKConstraintConflict in constraintGroup)
                    {
                        switch (fKConstraintConflict.ActionType)
                        {
                            case FKConstraintConflict.ActionTypes.AutoDeleteReference:
                                autoDeleteReferenceKeys.Add(fKConstraintConflict.ForeignKey.Value);
                                handled.Add(fKConstraintConflict);
                                break;
                            case FKConstraintConflict.ActionTypes.AutoRemoveReference:
                                autoRemoveReferenceKeys.Add(fKConstraintConflict.ForeignKey.Value);
                                handled.Add(fKConstraintConflict);
                                break;
                        }
                    }

                    if (autoDeleteReferenceKeys.Any())
                    {
                        IDeleteQuery deleteQuery = SQLProviderFactory.GetDeleteQuery();
                        deleteQuery.Table = new Table(foreignSchemaObject.SchemaName, foreignSchemaObject.ObjectName);
                        deleteQuery.Condition = new Condition()
                        {
                            Left = (Base.Data.Operand.Field)foreignSchemaObject.PrimaryKeyField.FieldName,
                            ConditionType = Condition.ConditionTypes.List,
                            Right = (CSV<long>)autoDeleteReferenceKeys
                        };

                        deleteQuery.Execute(transaction);
                    }

                    if (autoRemoveReferenceKeys.Any())
                    {
                        IUpdateQuery updateQuery = SQLProviderFactory.GetUpdateQuery();
                        updateQuery.Table = new Table(foreignSchemaObject.SchemaName, foreignSchemaObject.ObjectName);
                        updateQuery.FieldValueList.Add(new FieldValue()
                        {
                            FieldName = constraintGroupByField.Key,
                            Value = null
                        });
                        updateQuery.Condition = new Condition()
                        {
                            Left = (Base.Data.Operand.Field)foreignSchemaObject.PrimaryKeyField.FieldName,
                            ConditionType = Condition.ConditionTypes.List,
                            Right = (CSV<long>)autoRemoveReferenceKeys
                        };

                        updateQuery.Execute(transaction);
                    }
                }
            }

            conflicts.RemoveAll(fk => handled.Contains(fk));
        }

        public bool Validate(Validator.SaveModes saveMode, List<Guid> saveFlags = null)
        {
            return Validator.Validate(this, saveMode, saveFlags);
        }

        private bool SaveInsert(ITransaction transaction)
        {
            SchemaObject schemaObject = Schema.Schema.GetSchemaObject(GetType());

            IInsertQuery insertQuery = SQLProviderFactory.GetInsertQuery();
            insertQuery.Table = new Table(schemaObject.SchemaName, schemaObject.ObjectName);
            
            foreach(Schema.Field field in schemaObject.GetFields())
            {
                if (field == schemaObject.PrimaryKeyField) { continue; }

                FieldValue fieldValue = new FieldValue();
                fieldValue.FieldName = field.FieldName;
                fieldValue.Value = field.GetValue(this);
                insertQuery.FieldValueList.Add(fieldValue);
            }

            long? primaryKey = insertQuery.Execute(transaction);
            if (primaryKey != null)
            {
                schemaObject.PrimaryKeyField.SetPrivateDataCallback(this, primaryKey);
                return true;
            }

            return false;
        }

        private bool SaveUpdate(ITransaction transaction)
        {
            SchemaObject schemaObject = Schema.Schema.GetSchemaObject(GetType());

            IUpdateQuery updateQuery = SQLProviderFactory.GetUpdateQuery();
            updateQuery.Table = new Table(schemaObject.SchemaName, schemaObject.ObjectName);

            foreach(Schema.Field field in schemaObject.GetFields().Where(f => f != schemaObject.PrimaryKeyField))
            {
                FieldValue fieldValue = new FieldValue();
                fieldValue.FieldName = field.FieldName;
                fieldValue.Value = field.GetValue(this);
                updateQuery.FieldValueList.Add(fieldValue);
            }

            updateQuery.Condition = new Condition()
            {
                Left = (Base.Data.Operand.Field)schemaObject.PrimaryKeyField.FieldName,
                ConditionType = Condition.ConditionTypes.Equal,
                Right = new Literal(schemaObject.PrimaryKeyField.GetValue(this))
            };

            updateQuery.Execute(transaction);

            return true;
        }

        protected virtual void PreValidate() { }
        protected virtual bool PreSave(ITransaction transaction) { return true; }
        protected virtual bool PostSave(ITransaction transaction) { return true; }
        protected virtual bool PreDelete(ITransaction transaction) { return true; }
        protected virtual bool PostDelete(ITransaction transaction) { return true; }

        public static TDataObject GetReadOnlyByPrimaryKey<TDataObject>(long? primaryKey, ITransaction transaction, IEnumerable<string> fields) where TDataObject: DataObject
        {
            //DataObject dataObject = Activator.CreateInstance<TDataObject>();
            //dataObject.isEditable = false;

            //SchemaObject thisSchemaObject = Schema.Schema.GetSchemaObject<TDataObject>();

            //IOrderedEnumerable<string> sortedFields = fields.Where(f => f.Contains(".")).OrderBy(str => str);
            //Dictionary<string, string> tableAliasesForFieldPath = new Dictionary<string, string>()
            //{
            //    { "", "table000" }
            //};
            //int tableAliasCounter = 1;

            //List<Join> joinList = new List<Join>();
            //foreach (string fieldPath in sortedFields.Where(f => f.Contains(".")).Select(f => f.Substring(0, f.LastIndexOf("."))))
            //{
            //    string[] fieldPathParts = fieldPath.Split('.');

            //    string checkedFieldPath = "";
            //    DataObject lastObject = dataObject;
            //    SchemaObject lastSchemaObject = thisSchemaObject;
            //    for(int i = 0; i < fieldPathParts.Length - 1; i++)
            //    {
            //        string myAlias = tableAliasesForFieldPath[checkedFieldPath];

            //        if (!string.IsNullOrEmpty(checkedFieldPath))
            //        {
            //            checkedFieldPath += ".";
            //        }

            //        checkedFieldPath += fieldPathParts[i];

            //        if (tableAliasesForFieldPath.ContainsKey(checkedFieldPath))
            //        {
            //            continue;
            //        }

            //        Relationship relationship = lastSchemaObject.GetRelationship(checkedFieldPath);
            //        SchemaObject relatedSchemaObject = relationship.RelatedSchemaObject;

            //        DataObject relatedDataObject = relationship.GetValue(lastObject);
            //        if (relatedDataObject == null)
            //        {
            //            relatedDataObject = (DataObject)Activator.CreateInstance(relationship.RelatedObjectType);
            //            relatedDataObject.isEditable = false;
            //            relationship.SetPrivateDataCallback(lastObject, relatedDataObject);
            //        }

            //        tableAliasCounter++;
            //        string otherAlias = $"table{tableAliasCounter.ToString("D3")}";
            //        tableAliasesForFieldPath.Add(checkedFieldPath, otherAlias);

            //        Join join = new Join();
            //        join.Table = new Table(relatedSchemaObject.SchemaName, relatedSchemaObject.ObjectName, otherAlias);
            //        join.JoinType = Join.JoinTypes.Left;
            //        join.Condition = lastObject.GetRelationshipCondition(relationship, myAlias, otherAlias);

            //        lastObject = relatedDataObject;
            //        lastSchemaObject = relatedSchemaObject;
            //    }
            //}

            //ISelectQuery selectQuery = SQLProviderFactory.GetSelectQuery();
            //selectQuery.JoinList = joinList;

            //foreach(string field in sortedFields)
            //{
            //    string path = "";
            //    string fieldName = "";
            //    if (field.Contains('.'))
            //    {
            //        path = field.Substring(0, field.LastIndexOf('.'));
            //        fieldName = field.Substring(field.LastIndexOf('.') + 1);
            //    }
            //    else
            //    {
            //        fieldName = field;
            //    }

            //    string alias = tableAliasesForFieldPath[path];

            //    Select select = new Select() { SelectOperand = (Base.Data.Operand.Field)$"{alias}.{fieldName}", Alias = $"{alias}_{fieldName}" };
            //    selectQuery.SelectList.Add(select);
            //}

            //selectQuery.WhereCondition = new Condition()
            //{
            //    Left = (Base.Data.Operand.Field)("table000_" + thisSchemaObject.PrimaryKeyField.FieldName),
            //    ConditionType = Condition.ConditionTypes.Equal,
            //    Right = new Literal(primaryKey)
            //};

            //DataTable dataTable = selectQuery.Execute(transaction);
            //if (dataTable.Rows.Count <= 0)
            //{
            //    return null;
            //}

            //DataRow row = dataTable.Rows[0];
            //foreach(string field in sortedFields)
            //{
            //    DataObject lastObject = dataObject;
            //    SchemaObject lastSchemaObject = thisSchemaObject;
            //    if (field.Contains('.'))
            //    {
            //        string[] parts = field.Split('.');
            //        for(int i = 0; i < parts.Length - 1; i++)
            //        {
            //            lastObject.retrievedPaths.Add(parts[i]);
            //            Relationship relationship = lastSchemaObject.GetRelationship(parts[i]);

            //            lastObject = relationship.GetValue(lastObject);
            //            lastSchemaObject = relationship.RelatedSchemaObject;
            //        }
            //    }

            //    string path = "";
            //    string pathField = "";
            //    if (field.Contains('.'))
            //    {
            //        path = field.Substring(0, field.LastIndexOf('.'));
            //        pathField = field.Substring(field.LastIndexOf('.'));
            //    }
            //    else
            //    {
            //        pathField = field;
            //    }

            //    string alias = tableAliasesForFieldPath[path];
            //    object value = row[$"{alias}_{pathField}"];
            //    lastSchemaObject.GetField(pathField).SetPrivateDataCallback(lastObject, value);
            //    lastObject.retrievedPaths.Add(pathField);
            //}

            //return (TDataObject)dataObject;

            SchemaObject searchSchemaObject = Schema.Schema.GetSchemaObject<TDataObject>();
            Search<TDataObject> search = new Search<TDataObject>(new LongSearchCondition<TDataObject>()
            {
                Field = searchSchemaObject.PrimaryKeyField.FieldName,
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = primaryKey
            });

            return search.GetReadOnly(transaction, fields);
        }

        public static DataObject GetEditableByPrimaryKey(Type dataObjectType, long? primaryKey, ITransaction transaction = null, IEnumerable<string> readOnlyFields = null)
        {
            SchemaObject schemaObject = Schema.Schema.GetSchemaObject(dataObjectType);
            Search editableSearch = new Search(dataObjectType, new LongSearchCondition(dataObjectType)
            {
                Field = schemaObject.PrimaryKeyField.FieldName,
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = primaryKey
            });

            return editableSearch.GetUntypedEditable(transaction, readOnlyFields);
        }

        public static TDataObject GetEditableByPrimaryKey<TDataObject>(long? primaryKey, ITransaction transaction, IEnumerable<string> readOnlyFields) where TDataObject:DataObject
        {
            return (TDataObject)GetEditableByPrimaryKey(typeof(TDataObject), primaryKey, transaction, readOnlyFields);
        }


        public virtual ICondition GetRelationshipCondition(Relationship relationship, string myAlias, string otherAlias)
        {
            return new Condition()
            {
                Left = (Base.Data.Operand.Field)$"{myAlias}.{relationship.ForeignKeyField.FieldName}",
                ConditionType = Condition.ConditionTypes.Equal,
                Right = (Base.Data.Operand.Field)$"{otherAlias}.{relationship.RelatedSchemaObject.PrimaryKeyField.FieldName}"
            };
        }

        //public void SetData(IEnumerable<string> fieldsToSet, Dictionary<string, Tuple<ISelectQuery, Dictionary<string, string>>> queries, DataRow row)
        //{
        //    if (!IsEditable)
        //    {
        //        throw new ReadOnlyException("Cannot call SetData on a read-only Data Object");
        //    }

        //    SchemaObject schemaObject = Schema.Schema.GetSchemaObject(GetType());

        //    foreach (IGrouping<string, string> fieldByPath in fieldsToSet.GroupBy(field =>
        //                                                        {
        //                                                            if (field.Contains("."))
        //                                                            {
        //                                                                return field.Substring(0, field.LastIndexOf('.'));
        //                                                            }

        //                                                            return string.Empty;
        //                                                        }))
        //    {
        //        DataObject objectToSetValueOn = this;
        //        if (fieldByPath.Key.Contains("."))
        //        {
        //            string[] parts = fieldByPath.Key.Split('.');

        //            SchemaObject lastSchemaObject = schemaObject;
        //            for (int i = 0; i < parts.Length - 1; i++)
        //            {
        //                Relationship relationship = lastSchemaObject.GetRelationship(parts[i]);

        //                if (relationship != null)
        //                {
        //                    DataObject relatedDataObject = relationship.GetValue(objectToSetValueOn);

        //                    if (relatedDataObject == null)
        //                    {
        //                        relatedDataObject = (DataObject)Activator.CreateInstance(relationship.RelatedObjectType);
        //                        relationship.SetPrivateDataCallback(objectToSetValueOn, relatedDataObject);
        //                    }

        //                    objectToSetValueOn = relatedDataObject;
        //                    lastSchemaObject = relationship.RelatedSchemaObject;
        //                }
        //                else if (lastSchemaObject.GetRelationshipList(parts[i]) != null)
        //                {
        //                    break;
        //                }
        //            }
        //        }

        //        string fieldAlias = tableAliasesByFieldPath[fieldByPath.Key];
        //        foreach (string field in fieldByPath)
        //        {
        //            string fieldName = field;
        //            if (fieldName.Contains('.'))
        //            {
        //                fieldName = fieldName.Substring(fieldName.LastIndexOf('.') + 1);
        //            }

        //            string columnName = $"{fieldAlias}_{fieldName}";
        //            object databaseValue = row[columnName];
        //            databaseValue = databaseValue == DBNull.Value ? null : databaseValue;

        //            Schema.Field schemaField = schemaObject.GetField(field);
        //            schemaField.SetPrivateDataCallback(objectToSetValueOn, databaseValue);
        //        }
        //    }
        //}

        public void SetData(IEnumerable<string> fieldsToSet, Dictionary<string, Tuple<ISelectQuery, Dictionary<string, string>>> queries, DataRow outerObjectRow)
        {
            IEnumerable<string> fieldsWeCanDoSomethingAbout = fieldsToSet.Where(field => !queries.Keys.Where(k => !string.IsNullOrEmpty(k)).Any(reverseFieldPath => field.StartsWith(reverseFieldPath)));

            IEnumerable<IGrouping<string, string>> fieldsByFieldPath = fieldsWeCanDoSomethingAbout.OrderBy(field => field).GroupBy(field => field.Contains('.') ? field.Substring(0, field.LastIndexOf('.')) : "");

            // Load in all parent relationships
            foreach(IGrouping<string, string> fieldGroup in fieldsByFieldPath.Where(group => !string.IsNullOrEmpty(group.Key)))
            {
                SchemaObject currentSchemaObject = Schema.Schema.GetSchemaObject(GetType());
                DataObject currentObject = this;
                string[] fieldPathParts = fieldGroup.Key.Split('.');
                for(int i = 0; i < fieldPathParts.Length; i++)
                {
                    Relationship relationship = currentSchemaObject.GetRelationship(fieldPathParts[i]);
                    DataObject relatedObject = relationship.GetValue(this);

                    if (relatedObject == null)
                    {
                        relatedObject = DataObjectFactory.Create(relationship.RelatedObjectType);
                        relatedObject.isEditable = false;
                        relationship.SetPrivateDataCallback(currentObject, relatedObject);
                    }

                    currentSchemaObject = relationship.RelatedSchemaObject;
                    currentObject = relatedObject;
                }
            }

            Dictionary<string, string> tableAliasesForOuterRow = queries[""].Item2;
            // Set data on this object or parent objects
            foreach(IGrouping<string, string> fieldGroup in fieldsByFieldPath)
            {
                string tableAlias = tableAliasesForOuterRow[fieldGroup.Key];
                DataObject dataObjectToSet = this;
                SchemaObject schemaObjectToSet = Schema.Schema.GetSchemaObject(GetType());
                if (!string.IsNullOrEmpty(fieldGroup.Key))
                {
                    string[] fieldPathParts = fieldGroup.Key.Split('.');
                    for(int i = 0; i < fieldPathParts.Length; i++)
                    {
                        Relationship relationship = schemaObjectToSet.GetRelationship(fieldPathParts[i]);
                        dataObjectToSet = relationship.GetValue(dataObjectToSet);
                        schemaObjectToSet = Schema.Schema.GetSchemaObject(dataObjectToSet.GetType());
                    }
                }

                foreach(string field in fieldGroup)
                {
                    string fieldToSet = field;
                    if (fieldToSet.Contains('.'))
                    {
                        fieldToSet = fieldToSet.Substring(fieldToSet.LastIndexOf('.') + 1);
                    }
                    object value = outerObjectRow[$"{tableAlias}_{fieldToSet}"];
                    Schema.Field schemaField = schemaObjectToSet.GetField(fieldToSet);
                    schemaField.SetPrivateDataCallback(dataObjectToSet, value);
                }
            }

            // Set data for reverse relationships
            HashSet<string> handledReverseRelationships = new HashSet<string>();
            foreach(string reverseRelationship in queries.Keys.Where(key => !string.IsNullOrEmpty(key)))
            {
                string[] reverseRelationshipParts = reverseRelationship.Split('.');
                DataObject parentObject = this;
                SchemaObject parentSchemaObject = Schema.Schema.GetSchemaObject(GetType());

                string reverseRelationshipWeCanDoSomethingAbout = "";
                RelationshipList relationshipList = null;
                for(int i = 0; i < reverseRelationshipParts.Length; i++)
                {
                    Relationship relationship = parentSchemaObject.GetRelationship(reverseRelationshipParts[i]);
                    if (relationship != null)
                    {
                        parentObject = relationship.GetValue(parentObject);
                        parentSchemaObject = relationship.RelatedSchemaObject;
                        reverseRelationshipWeCanDoSomethingAbout += relationship.RelatedSchemaObject.ObjectName + ".";
                    }
                    else
                    {
                        relationshipList = parentSchemaObject.GetRelationshipList(reverseRelationshipParts[i]);
                        reverseRelationshipWeCanDoSomethingAbout += relationshipList.RelationshipListName + ".";
                        break;
                    }
                }

                if (!handledReverseRelationships.Add(reverseRelationshipWeCanDoSomethingAbout))
                {
                    continue;
                }

                long? primaryKey = parentObject.PrimaryKeyField.GetValue(parentObject) as long?;
                ISelectQuery query = queries[reverseRelationshipWeCanDoSomethingAbout].Item1;
                Condition primaryKeyCondition = new Condition()
                {
                    Left = (Base.Data.Operand.Field)relationshipList.ForeignKeyName,
                    ConditionType = Condition.ConditionTypes.Equal,
                    Right = new Literal(primaryKey)
                };

                ICondition previousQueryCondition = query.WhereCondition;
                if (query.WhereCondition != null)
                {
                    ConditionGroup conditionGroup = new ConditionGroup()
                    {
                        ConditionGroupType = ConditionGroup.ConditionGroupTypes.And,
                        Conditions = new List<ICondition>() { query.WhereCondition, primaryKeyCondition }
                    };
                    query.WhereCondition = conditionGroup;
                }
                else
                {
                    query.WhereCondition = primaryKeyCondition;
                }

                HashSet<string> childFieldsToSet = fieldsToSet.Where(f => f.StartsWith(reverseRelationshipWeCanDoSomethingAbout)).Select(f => f.Replace(reverseRelationshipWeCanDoSomethingAbout, "")).ToHashSet();
                childFieldsToSet.Add(relationshipList.RelatedSchemaObject.PrimaryKeyField.FieldName);
                Dictionary<string, Tuple<ISelectQuery, Dictionary<string, string>>> childQueries = new Dictionary<string, Tuple<ISelectQuery, Dictionary<string, string>>>();
                foreach(KeyValuePair<string, Tuple<ISelectQuery, Dictionary<string, string>>> childQuery in queries.Where(kvp => kvp.Key.StartsWith(reverseRelationshipWeCanDoSomethingAbout)))
                {
                    childQueries.Add(childQuery.Key.Replace(reverseRelationshipWeCanDoSomethingAbout, ""), childQuery.Value);
                }

                object reverseRelationshipList = relationshipList.GetPrivateDataCallback(parentObject);
                MethodInfo addMethod = reverseRelationshipList.GetType().GetMethod("Add", new Type[] { relationshipList.RelatedObjectType });

                DataTable results = query.Execute(null);
                query.WhereCondition = previousQueryCondition;
                foreach(DataRow row in results.Rows)
                {
                    DataObject childObject = DataObjectFactory.Create(relationshipList.RelatedObjectType);
                    childObject.isEditable = false;
                    childObject.SetData(childFieldsToSet, childQueries, row);
                    addMethod.Invoke(reverseRelationshipList, new object[] { childObject });
                }
                parentObject.retrievedPaths.Add(relationshipList.RelationshipListName);
            }
        }

        public void Copy(DataObject destination)
        {
            if (!GetType().IsAssignableFrom(destination.GetType()))
            {
                throw new InvalidOperationException("Cannot copy to Data Object of different type");
            }

            SchemaObject schemaObject = Schema.Schema.GetSchemaObject(GetType());

            Dictionary<string, object> destinationOriginalValues = destination.originalValues.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            foreach(Schema.Field field in schemaObject.GetFields().Where(f => f != schemaObject.PrimaryKeyField))
            {
                field.SetPrivateDataCallback(destination, field.GetPrivateDataCallback(this));
            }

            // Restore destination original values, a Copy means we're changing things
            destination.originalValues = destinationOriginalValues;
        }

        public Schema.Field GetField(string fieldName)
        {
            return Schema.Schema.GetSchemaObject(GetType()).GetField(fieldName);
        }

        [JsonIgnore]
        public Schema.Field PrimaryKeyField
        {
            get
            {
                return Schema.Schema.GetSchemaObject(GetType()).PrimaryKeyField;
            }
        }

        protected void CheckGet([CallerMemberName]string fieldName = "")
        {
            if (string.IsNullOrEmpty(fieldName))
            {
                throw new ArgumentNullException("Could not determine field name for get validation");
            }

            if (!isEditable && !retrievedPaths.Contains(fieldName))
            {
                throw new InvalidOperationException($"The field {fieldName} was not retrieved");
            }
        }

        protected void CheckSet([CallerMemberName]string fieldName = "")
        {
            if (!isEditable)
            {
                throw new InvalidOperationException($"Cannot call set on field {fieldName} - this is not an editable data object");
            }
        }

        public bool IsFieldDirty(string fieldName)
        {
            Schema.Field field = GetField(fieldName);

            object currentValue = field.GetValue(this);
            object dirtyValue = GetDirtyValue(fieldName);

            if (currentValue == null && dirtyValue == null)
            {
                return false;
            }

            return currentValue == null ? !dirtyValue.Equals(currentValue) : !currentValue.Equals(dirtyValue);
        }

        public object GetDirtyValue(string fieldName)
        {
            return originalValues.GetOrDefault(fieldName);
        }

        public class FKConstraintConflict
        {
            public long? ForeignKey { get; set; }
            public Type ConflictType { get; set; }
            public string ForeignKeyName { get; set; }

            public ActionTypes ActionType { get; set; } = ActionTypes.Conflict;

            public enum ActionTypes
            {
                AutoRemoveReference,
                AutoDeleteReference,
                Conflict
            }
        }
    }
}