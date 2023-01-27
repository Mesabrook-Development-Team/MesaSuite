using System;

namespace FleetTracking.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class SecuredControlAttribute : Attribute
    {
        [Flags]
        public enum Permissions
        {
            AllowSetup = 1,
            AllowLeasingManagement = 2,
            IsYardmaster = 4,
            IsTrainCrew = 8,
            AllowLoadUnload = 16
        }

        public Permissions[] OptionalPermissions { get; set; }

        public SecuredControlAttribute(Permissions permission)
        {
            OptionalPermissions = new[] { permission };
        }

        public SecuredControlAttribute(params Permissions[] permissions)
        {
            OptionalPermissions = permissions;
        }
    }
}
