using ClussPro.Base.Extensions;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClussPro.ObjectBasedFramework.Loader
{
    public class LoaderController
    {
        Dictionary<Type, Dictionary<Guid, LoaderObject>> loaderObjectsByIDByType = new Dictionary<Type, Dictionary<Guid, LoaderObject>>();
        Dictionary<Type, Dictionary<Guid, ISystemLoaded>> objectsInDatabaseByIDByType = new Dictionary<Type, Dictionary<Guid, ISystemLoaded>>();
        public void Initialize()
        {
            List<ILoader> loaders = new List<ILoader>();
            foreach(Type type in AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes().Where(t => t != typeof(ILoader) && typeof(ILoader).IsAssignableFrom(t))))
            {
                ILoader loader = (ILoader)Activator.CreateInstance(type);
                loaders.Add(loader);
            }

            IEnumerable<IGrouping<Type, LoaderObject>> loaderObjectsByType = loaders.SelectMany(l => l.GetLoaderObjects()).GroupBy(lo => lo.DataObjectType);

            // Create repos for each loaded type
            foreach (IGrouping<Type, LoaderObject> grouping in loaderObjectsByType)
            {
                loaderObjectsByIDByType[grouping.Key] = new Dictionary<Guid, LoaderObject>();
                objectsInDatabaseByIDByType[grouping.Key] = new Dictionary<Guid, ISystemLoaded>();

                foreach (LoaderObject loaderObject in grouping)
                {
                    loaderObjectsByIDByType[grouping.Key][loaderObject.SystemID] = loaderObject;
                }

                Search dataSearch = new Search(grouping.Key, new GuidSearchCondition(grouping.Key) { Field = "SystemID", SearchConditionType = SearchCondition.SearchConditionTypes.NotNull });
                foreach (ISystemLoaded systemLoaded in dataSearch.GetUntypedEditableReader(null).Cast<ISystemLoaded>())
                {
                    objectsInDatabaseByIDByType[grouping.Key][systemLoaded.SystemID.Value] = systemLoaded;
                }
            }
        }

        public void Process()
        {
            Dictionary<Type, List<LoaderObject>> objectsToAddByType = new Dictionary<Type, List<LoaderObject>>();
            Dictionary<Type, List<ISystemLoaded>> objectsToUpdate = new Dictionary<Type, List<ISystemLoaded>>();
            Dictionary<Type, List<ISystemLoaded>> objectsToDelete = new Dictionary<Type, List<ISystemLoaded>>();

            // Determine objects to add
            foreach(KeyValuePair<Type, Dictionary<Guid, LoaderObject>> kvp in loaderObjectsByIDByType)
            {
                if (!objectsInDatabaseByIDByType.ContainsKey(kvp.Key))
                {
                    objectsToAddByType.GetOrSet(kvp.Key, () => new List<LoaderObject>());

                    objectsToAddByType[kvp.Key].AddRange(kvp.Value.Values);
                }
                else
                {
                    foreach(KeyValuePair<Guid, LoaderObject> innerKvp in kvp.Value)
                    {
                        if (!objectsInDatabaseByIDByType[kvp.Key].ContainsKey(innerKvp.Key))
                        {
                            objectsToAddByType.GetOrSet(kvp.Key, () => new List<LoaderObject>());

                            objectsToAddByType[kvp.Key].Add(innerKvp.Value);
                        }
                    }
                }
            }

            // Determine objects to update
            foreach(KeyValuePair<Type, Dictionary<Guid, LoaderObject>> kvp in loaderObjectsByIDByType)
            {
                if (!objectsInDatabaseByIDByType.ContainsKey(kvp.Key))
                {
                    continue;
                }

                foreach(KeyValuePair<Guid, LoaderObject> innerKvp in kvp.Value)
                {
                    if (!objectsInDatabaseByIDByType[kvp.Key].ContainsKey(innerKvp.Key))
                    {
                        continue;
                    }

                    if (!objectsInDatabaseByIDByType[kvp.Key][innerKvp.Key].SystemHash.SequenceEqual(innerKvp.Value.CalculateHash()))
                    {
                        objectsToUpdate.GetOrSet(kvp.Key, () => new List<ISystemLoaded>());
                        objectsToUpdate[kvp.Key].Add(objectsInDatabaseByIDByType[kvp.Key][innerKvp.Key]);
                    }
                }
            }

            // Determine objects to delete
            foreach (KeyValuePair<Type, Dictionary<Guid, ISystemLoaded>> kvp in objectsInDatabaseByIDByType)
            {
                if (!loaderObjectsByIDByType.ContainsKey(kvp.Key))
                {
                    objectsToDelete.GetOrSet(kvp.Key, () => new List<ISystemLoaded>());

                    objectsToDelete[kvp.Key].AddRange(kvp.Value.Values);
                }
                else
                {
                    foreach(KeyValuePair<Guid, ISystemLoaded> innerKvp in kvp.Value)
                    {
                        if (!loaderObjectsByIDByType[kvp.Key].ContainsKey(innerKvp.Key))
                        {
                            objectsToDelete.GetOrSet(kvp.Key, () => new List<ISystemLoaded>());

                            objectsToDelete[kvp.Key].Add(innerKvp.Value);
                        }
                    }
                }
            }

            // Perform processing
            // Add objects
            foreach(LoaderObject loaderObject in objectsToAddByType.Values.SelectMany(l => l))
            {
                DataObject dataObject = DataObjectFactory.Create(loaderObject.DataObjectType);
                SchemaObject schemaObject = Schema.Schema.GetSchemaObject(loaderObject.DataObjectType);
                foreach (KeyValuePair<string, object> valueByField in loaderObject.GetValuesByField())
                {
                    schemaObject.GetField(valueByField.Key).SetPrivateDataCallback(dataObject, valueByField.Value);
                }

                ISystemLoaded systemLoadedDataObject = (ISystemLoaded)dataObject;
                systemLoadedDataObject.SystemID = loaderObject.SystemID;
                systemLoadedDataObject.SystemHash = loaderObject.CalculateHash();

                dataObject.Save();
            }

            // Update objects
            foreach(KeyValuePair<Type, List<ISystemLoaded>> kvp in objectsToUpdate)
            {
                foreach(ISystemLoaded systemLoaded in kvp.Value.Select(l => l))
                {
                    DataObject dataObject = (DataObject)systemLoaded;
                    SchemaObject schemaObject = Schema.Schema.GetSchemaObject(kvp.Key);
                    LoaderObject loaderObject = loaderObjectsByIDByType[kvp.Key][systemLoaded.SystemID.Value];

                    foreach(KeyValuePair<string, object> valueByField in loaderObject.GetValuesByField())
                    {
                        schemaObject.GetField(valueByField.Key).SetPrivateDataCallback(dataObject, valueByField.Value);
                    }

                    systemLoaded.SystemHash = loaderObject.CalculateHash();
                    dataObject.Save();
                }
            }

            // Delete objects
            foreach(ISystemLoaded systemLoaded in objectsToDelete.Values.SelectMany(l => l))
            {
                DataObject dataObject = (DataObject)systemLoaded;
                dataObject.Delete();
            }
        }
    }
}
