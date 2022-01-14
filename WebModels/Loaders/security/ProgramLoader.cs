using ClussPro.ObjectBasedFramework.Loader;
using System.Collections.Generic;
using WebModels.security;

namespace WebModels.Loaders.security
{
    public class ProgramLoader : ILoader
    {
        public IEnumerable<LoaderObject> GetLoaderObjects()
        {
            yield return new LoaderObject<Program>("7C599D63-CB43-4D16-AEC0-1FEE4AB9A481")
            {
                DataObjectValues = p => new Dictionary<object, object>()
                {
                    { p.Key, "system" },
                    { p.Name, "System Management" }
                }
            };

            yield return new LoaderObject<Program>("F06FD848-0816-48CE-9080-E5E316215709")
            {
                DataObjectValues = p => new Dictionary<object, object>()
                {
                    { p.Key, "company" },
                    { p.Name, "Company Studio" }
                }
            };

            yield return new LoaderObject<Program>("B6603228-07E3-41C2-B74F-D7203698176A")
            {
                DataObjectValues = p => new Dictionary<object, object>()
                {
                    { p.Key, "gov" },
                    { p.Name, "Government Portal" }
                }
            };
        }
    }
}
