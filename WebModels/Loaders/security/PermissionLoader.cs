using ClussPro.ObjectBasedFramework.Loader;
using System.Collections.Generic;
using WebModels.security;

namespace WebModels.Loaders.security
{
    public class PermissionLoader : ILoader
    {
        public IEnumerable<LoaderObject> GetLoaderObjects()
        {
            yield return new LoaderObject<Permission>("ABE721D2-4F5B-4557-9C8C-0411D1EF80AD")
            {
                DataObjectValues = p => new Dictionary<object, object>()
                {
                    { p.Name, "View Users & Permission" },
                    { p.Key, "User/User/ViewUsers" }
                }
            };

            yield return new LoaderObject<Permission>("5F026561-9836-4423-8E26-E077BB6F8208")
            {
                DataObjectValues = p => new Dictionary<object, object>()
                {
                    { p.Name, "Manage Users" },
                    { p.Key, "User/User/ManageUsers" }
                }
            };
        }
    }
}
