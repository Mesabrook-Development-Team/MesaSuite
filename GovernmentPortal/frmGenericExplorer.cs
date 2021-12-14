using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MesaSuite.Common.Extensions;
using MesaSuite.Common.Utility;
using Pluralize.NET;

namespace GovernmentPortal
{
    public partial class frmGenericExplorer<TModel> : Form
    {
        private ExplorerContext<TModel> explorerContext;
        private IExplorerControl<TModel> shownControl;
        private List<DropDownItem<TModel>> dropDownItems;

        public frmGenericExplorer()
        {
            InitializeComponent();
        }

        internal frmGenericExplorer(ExplorerContext<TModel> explorerContext) : base()
        {
            this.explorerContext = explorerContext;
        }

        private int priorIndex = -1;
        private void listItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (shownControl.IsDirty && WarnDirty() == DialogResult.Cancel)
            {
                lstItems.SelectedIndex = priorIndex;
                return;
            }

            DropDownItem<TModel> dropDownItem = lstItems.SelectedItem as DropDownItem<TModel>;
            if (dropDownItem == null)
            {
                grpContent.Controls.Clear();
            }

            shownControl = explorerContext.GetControlForModel(dropDownItem.Object);
            Control control = (Control)shownControl;
            grpContent.Controls.Add(control);
            control.Dock = DockStyle.Fill;
        }

        private void frmGenericExplorer_Load(object sender, EventArgs e)
        {
            if (explorerContext == null)
            {
                throw new ArgumentNullException("Explorer Content");
            }

            Pluralizer pluralizer = new Pluralizer();
            string pluralizedName = pluralizer.Pluralize(explorerContext.ObjectDisplayName);

            lblTitle.Text = pluralizedName;
            Text = $"{explorerContext.ObjectDisplayName} Explorer";
            cmdNew.Text = $"New {explorerContext.ObjectDisplayName}";
            cmdDelete.Text = $"Delete {explorerContext.ObjectDisplayName}";
            LoadAllItems();
        }
        
        public async void LoadAllItems(bool doFill = false, string selectedTextOverride = null)
        {
            if (shownControl.IsDirty && WarnDirty() == DialogResult.Cancel)
            {
                return;
            }

            dropDownItems = await explorerContext.GetInitialListItems();

            if (doFill)
            {
                FillItems(selectedTextOverride);
            }
        }

        public void FillItems(string selectedTextOverride = null)
        {
            DropDownItem<TModel> currentlySelectedItem = string.IsNullOrEmpty(selectedTextOverride) ? lstItems.Items.OfType<DropDownItem<TModel>>().FirstOrDefault(ddi => ddi.Text == selectedTextOverride) : lstItems.SelectedItem as DropDownItem<TModel>;
            if (currentlySelectedItem != null && currentlySelectedItem.Text.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase) && shownControl.IsDirty && WarnDirty() == DialogResult.Cancel)
            {
                return;
            }

            lstItems.Items.Clear();

            foreach(DropDownItem<TModel> item in dropDownItems.Where(ddi => string.IsNullOrEmpty(txtSearch.Text) ? true : ddi.Text.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase)))
            {
                lstItems.Items.Add(item);
            }

            if (lstItems.Items.Contains(currentlySelectedItem))
            {
                lstItems.SelectedItem = currentlySelectedItem;
            }
        }

        private DialogResult WarnDirty()
        {
            DialogResult result = MessageBox.Show("You have unsaved changes.\r\n\r\nWould you like to save these changes before continuing?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                shownControl.OnSaveClicked();
                shownControl.IsDirty = false;
            }
            else if (result == DialogResult.No)
            {
                shownControl.IsDirty = false;
            }

            return result;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            shownControl.OnSaveClicked();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            shownControl.OnDeleteClicked();
        }

        private void cmdNew_Click(object sender, EventArgs e)
        {
            explorerContext.OnNewClicked();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FillItems();
        }
    }
}
