namespace ClussPro.Base.Data
{
    public class TableAlias : ISelectable
    {
        public string AliasName { get; set; }

        public TableAlias() { }

        public TableAlias(string aliasName)
        {
            AliasName = aliasName;
        }
    }
}
