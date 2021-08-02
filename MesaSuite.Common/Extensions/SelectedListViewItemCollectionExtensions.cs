using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;

namespace MesaSuite.Common.Extensions
{
    public static class SelectedListViewItemCollectionExtensions
    {
        public static bool Any(this SelectedListViewItemCollection collection, Func<ListViewItem, bool> condition)
        {
            foreach(ListViewItem item in collection)
            {
                if (condition(item))
                {
                    return true;
                }
            }

            return false;
        }

        public static List<ListViewItem> ToList(this SelectedListViewItemCollection collection)
        {
            List<ListViewItem> returnVal = new List<ListViewItem>();
            foreach(ListViewItem item in collection)
            {
                returnVal.Add(item);
            }

            return returnVal;
        }

        public static IEnumerable<ListViewItem> Where(this SelectedListViewItemCollection collection, Func<ListViewItem, bool> condition)
        {
            foreach(ListViewItem item in collection)
            {
                if (condition(item))
                {
                    yield return item;
                }
            }
        }
    }
}
