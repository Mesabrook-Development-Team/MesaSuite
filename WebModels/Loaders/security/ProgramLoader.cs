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
        }
    }
}
