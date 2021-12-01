using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MesaSuite.Common.Extensions
{
    public static class TreeViewExtensions
    {
        public static TreeNode FindByPath(this TreeNodeCollection nodes, string path)
        {
            foreach(TreeNode childNode in nodes)
            {
                if (childNode.FullPath == path)
                {
                    return childNode;
                }
                else
                {
                    TreeNode foundNode = FindByPath(childNode.Nodes, path);
                    if (foundNode != null)
                    {
                        return foundNode;
                    }
                }
            }

            return null;
        }
    }
}
