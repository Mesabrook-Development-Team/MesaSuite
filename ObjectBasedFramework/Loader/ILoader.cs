using System.Collections.Generic;

namespace ClussPro.ObjectBasedFramework.Loader
{
    public interface ILoader
    {
        IEnumerable<LoaderObject> GetLoaderObjects();
    }
}
