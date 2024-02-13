using MesaSuite.Common.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MesaSuite.Common.Extensions
{
    public static class ListBoxDrawItemEventArgsExtensions
    {
        public static void DrawDropDownItems<TDropDownItemType>(this DrawItemEventArgs e, ListBox listBox)
        {
            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

            if (e.Index >= 0 && e.Index < listBox.Items.Count)
            {
                DropDownItem<TDropDownItemType> item = (DropDownItem<TDropDownItemType>)listBox.Items[e.Index];
                Graphics graphics = e.Graphics;

                if (!selected && item.BackgroundColor != null)
                {
                    SolidBrush backgroundBrush = new SolidBrush(item.BackgroundColor.Value);
                    graphics.FillRectangle(backgroundBrush, e.Bounds);
                }
                else
                {
                    e.DrawBackground();
                }

                Font font = item.FontStyle != null ? new Font(listBox.Font, item.FontStyle.Value) : listBox.Font;
                SolidBrush textBrush = selected ?
                                            new SolidBrush(Color.White) :
                                            item.FontColor != null ?
                                                new SolidBrush(item.FontColor.Value) :
                                                new SolidBrush(listBox.ForeColor);
                graphics.DrawString(item.Text, font, textBrush, listBox.GetItemRectangle(e.Index));
            }

            e.DrawFocusRectangle();
        }
    }
}
