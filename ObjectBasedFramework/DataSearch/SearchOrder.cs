using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClussPro.ObjectBasedFramework.DataSearch
{
    public class SearchOrder
    {
        public string OrderField { get; set; }
        public OrderDirections OrderDirection { get; set; }
        public enum OrderDirections
        {
            Ascending,
            Descending
        }
    }
}
