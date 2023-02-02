namespace ClussPro.Base.Data
{
    public class FieldValue
    {
        public string FieldName { get; set; }
        public FieldSpecification.FieldTypes FieldType { get; set; }
        public object Value { get; set; }
    }
}
