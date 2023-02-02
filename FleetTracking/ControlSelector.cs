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
            DropDownWidth = 1;
            foreach (ControlSelectorItem item in Items.OfType<ControlSelectorItem>())
            {
                if (DropDownWidth < item.DropDownControl.Width)
                {
                    DropDownWidth = item.DropDownControl.Width;
                }

                if (DropDownWidth < item.ClosedControl.Width)
                {
                    DropDownWidth = item.ClosedControl.Width;
                }

                item.Refresh += ItemTriggeredRefresh;
            }

            DropDownHeight = 1;
            foreach (ControlSelectorItem item in Items.OfType<ControlSelectorItem>().Take(MaxDropDownItems))
            {
                if (DropDownHeight < item.DropDownControl.Height)
                {
                    DropDownHeight = item.DropDownControl.Height;
                }

                if (DropDownHeight < item.ClosedControl.Height)
                {
                    DropDownHeight = item.ClosedControl.Height;
                }

                item.Refresh += ItemTriggeredRefresh;
            }

            DropDownHeight *= MaxDropDownItems;
        }

        private void ItemTriggeredRefresh(object sender, EventArgs e)
        {
            if (IsHandleCreated)
            {
                RefreshItems();
            }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index < 0 || e.Index >= Items.Count)
            {
                return;
            }

            object item = Items[e.Index];
            if (!(item is ControlSelectorItem controlSelector))
            {
                e.Graphics.DrawString("Invalid Item", e.Font, new SolidBrush(e.ForeColor), e.Bounds);
                e.DrawFocusRectangle();
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
                control.BackColor = SystemColors.Highlight;
            }
            else
            {
                control.BackColor = BackColor;
            }
            control.DrawToBitmap(bitmap, control.Bounds);
            control.BackColor = background;

            Rectangle boundingRectangle = e.Bounds;
            decimal widthScaleFactor = e.Bounds.Width / (decimal)control.Bounds.Width;
            decimal heightScaleFactor = e.Bounds.Height / (decimal)control.Bounds.Height;

            decimal scaleFactor = widthScaleFactor < heightScaleFactor ? widthScaleFactor : heightScaleFactor;
            decimal newWidth = control.Bounds.Width * scaleFactor;
            decimal newHeight = control.Bounds.Height * scaleFactor;
            boundingRectangle = new Rectangle((int)(e.Bounds.X + ((control.Bounds.Width - newWidth) / 2)), /*(int)(e.Bounds.Y + ((control.Bounds.Height - newHeight) / 2))*/e.Bounds.Y, (int)newWidth, (int)newHeight);

            e.Graphics.DrawImage(bitmap, boundingRectangle);

            e.DrawFocusRectangle();
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
            public event EventHandler Refresh;


            private Control _dropDownControl;
            public Control DropDownControl
            {
                get => _dropDownControl;
                set
                {
                    _dropDownControl = value;
                    if (_dropDownControl is IRefreshable refreshable)
                    {
                        refreshable.ContentLoaded += ItemTriggeredRefresh;
                    }
                }
            }

            private Control _closedControl;
            public Control ClosedControl
            {
                get => _closedControl;
                set
                {
                    _closedControl = value;
                    if (_closedControl is IRefreshable refreshable)
                    {
                        refreshable.ContentLoaded += ItemTriggeredRefresh;
                    }
                }
            }

            public ControlSelectorItem() { }

            public ControlSelectorItem(Control dropDownControl, Control closedControl)
            {
                DropDownControl = dropDownControl;
                ClosedControl = closedControl;
            }

            private void ItemTriggeredRefresh(object sender, EventArgs e)
            {
                Refresh?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
