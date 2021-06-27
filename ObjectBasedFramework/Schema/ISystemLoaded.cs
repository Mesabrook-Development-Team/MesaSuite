using System;

namespace ClussPro.ObjectBasedFramework.Schema
{
    public interface ISystemLoaded
    {
        Guid? SystemID { get; set; }
        byte[] SystemHash { get; set; }
    }
}
