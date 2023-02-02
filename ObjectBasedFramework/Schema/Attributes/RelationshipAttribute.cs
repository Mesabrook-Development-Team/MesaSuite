using System;

namespace ClussPro.ObjectBasedFramework.Schema.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RelationshipAttribute : Attribute
    {
        public Guid RelationshipID { get; set; }
        public string ForeignKeyField { get; set; }
        public string ParentKeyField { get; set; }
        public bool HasForeignKey { get; set; } = true;
        public bool OneToOneByForeignKey { get; set; }
        public string OneToOneForeignKey { get; set; }

        public RelationshipAttribute(string RelationshipID)
        {
            this.RelationshipID = new Guid(RelationshipID);
        }
    }
}
