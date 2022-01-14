using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GovernmentPortal.Extensions;
using GovernmentPortal.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;

namespace GovernmentPortal.Email
{
    public partial class AliasExplorerControl : UserControl, IExplorerControl<Alias>
    {
        public event EventHandler IsDirtyChanged;
        private int _domainID;
        private long _governmentID;

        public AliasExplorerControl()
        {
            InitializeComponent();
        }

        public AliasExplorerControl(int domainID, long governmentID) : this()
        {
            _domainID = domainID;
            _governmentID = governmentID;
        }

        private bool _isDirty;
        public bool IsDirty
        {
            get => _isDirty;
            set
            {
                _isDirty = value;
                IsDirtyChanged?.Invoke(this, new EventArgs());
            }
        }

        public Alias Model { get; set; }

        private frmGenericExplorer<Alias> _explorer;
        public frmGenericExplorer<Alias> Explorer { set => _explorer = value; }


        public async void OnDeleteClicked()
        {
            if (Model == null)
            {
                this.ShowError("Cannot delete an unsaved Alias.");
                return;
            }

            if (!this.Confirm("Are you sure you want to delete this Alias?"))
            {
                return;
            }

            loader.BringToFront();
            loader.Visible = true;

            DeleteData delete = new DeleteData(DataAccess.APIs.GovernmentPortal, $"Alias/Delete/{Model.AliasID}");
            delete.AddGovHeader(_governmentID);
            await delete.Execute();
            if (delete.RequestSuccessful)
            {
                Dispose();
                IsDirty = false;
                _explorer.LoadAllItems(true);
                return;
            }

            loader.Visible = false;
        }

        public async void OnSaveClicked()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                this.ShowError("Alias Name is a required field.");
                return;
            }

            if (string.IsNullOrEmpty(txtValue.Text))
            {
                this.ShowError("Alias Value is a required field.");
                return;
            }

            Alias savingModel = Model;
            if (savingModel == null)
            {
                savingModel = new Alias();
                savingModel.AliasDomainID = _domainID;
            }

            savingModel.AliasName = txtName.Text;
            savingModel.AliasValue = txtValue.Text;

            loader.BringToFront();
            loader.Visible = true;

            if (Model == null)
            {
                PostData post = new PostData(DataAccess.APIs.GovernmentPortal, "Alias/Post", savingModel);
                post.AddGovHeader(_governmentID);
                savingModel = await post.Execute<Alias>();
                if (post.RequestSuccessful)
                {
                    Model = savingModel;
                    IsDirty = false;
                    _explorer.LoadAllItems(true, savingModel.AliasName);
                }
            }
            else
            {
                PutData put = new PutData(DataAccess.APIs.GovernmentPortal, "Alias/Put", savingModel);
                put.AddGovHeader(_governmentID);
                savingModel = await put.Execute<Alias>();
                if (put.RequestSuccessful)
                {
                    Model = savingModel;
                    IsDirty = false;
                    _explorer.LoadAllItems(true);
                }
            }

            loader.Visible = false;
        }

        private void AliasExplorerControl_Load(object sender, EventArgs e)
        {
            if (_domainID == default(int))
            {
                this.ShowError("A domain name must be assigned to this Government before you can manage emails.");
                Dispose();
                return;
            }
            suppressDirtyChange = true;
            txtName.Text = Model?.AliasName;
            txtValue.Text = Model?.AliasValue;
            suppressDirtyChange = false;
        }

        bool suppressDirtyChange = false;
        private void DirtyTextChanged(object sender, EventArgs e)
        {
            if (suppressDirtyChange)
            {
                return;
            }

            IsDirty = true;
        }
    }
}
