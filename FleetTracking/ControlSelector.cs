using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FleetTracking
{
    public class ControlSelector : ComboBox
    {
        public IEnumerable<ControlSelectorItem> ControlSelectorItems
        {
            get => Items.OfType<ControlSelectorItem>();
            set
            {
                Items.Clear();
                Items.AddRange(value?.ToArray());
            }
        }

        public ControlSelector()
        {
            DrawMode = DrawMode.OwnerDrawVariable;
            DropDownStyle = ComboBoxStyle.DropDownList;

            DropDown += ControlSelector_DropDown;
        }

        ~ControlSelector()
        {
            DropDown -= ControlSelector_DropDown;
        }

        private void ControlSelector_DropDown(object sender, EventArgs e)
        {
            foreach(ControlSelectorItem item in Items.OfType<ControlSelectorItem>())
            {
                if (DropDownWidth < item.DropDownControl.Width)
                {
                    DropDownWidth = item.DropDownControl.Width;
                }

                if (DropDownWidth < item.ClosedControl.Width)
                {
                    DropDownWidth = item.ClosedControl.Width;
                }
            }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();

            if (e.Index < 0 || e.Index >= Items.Count)
            {
                return;
            }

            object item = Items[e.Index];
            if (!(item is ControlSelectorItem controlSelector))
            {
                e.Graphics.DrawString("Invalid Item", e.Font, new SolidBrush(e.ForeColor), e.Bounds);
                return;
            }

            Control control;
            if (e.State.HasFlag(DrawItemState.ComboBoxEdit))
            {
                control = controlSelector.ClosedControl;
            }
            else
            {
                control = controlSelector.DropDownControl;
            }

            Bitmap bitmap = new Bitmap(control.Bounds.Width, control.Bounds.Height);
            Color background = control.BackColor;
            if (e.State.HasFlag(DrawItemState.Selected))
            {
                control.BackColor = SystemColors.MenuHighlight;
            }
            control.DrawToBitmap(bitmap, control.Bounds);
            control.BackColor = background;
            e.Graphics.DrawImage(bitmap, e.Bounds);
        }

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= Items.Count || !(Items[e.Index] is ControlSelectorItem control))
            {
                e.ItemHeight = Font.Height + 2;
                e.ItemWidth = (int)e.Graphics.MeasureString("Invalid Item", Font).Width;
                return;
            }

            e.ItemHeight = control.DropDownControl.Height + 2;
            e.ItemWidth = control.DropDownControl.Width;
        }

        public class ControlSelectorItem
        {
            public Control DropDownControl;
            public Control ClosedControl;

            public ControlSelectorItem() { }

            public ControlSelectorItem(Control dropDownControl, Control closedControl)
            {
                DropDownControl = dropDownControl;
                ClosedControl = closedControl;
            }
        }
    }
}
