using ClussPro.Base.Data.Operand;

namespace ClussPro.Base.Data.Query
{
    public class Order
    {
        public Field Field { get; set; }
        public OrderDirections OrderDirection { get; set; } = OrderDirections.Ascending;

        public enum OrderDirections
        {
            Ascending,
            Descending
        }
    }
}
