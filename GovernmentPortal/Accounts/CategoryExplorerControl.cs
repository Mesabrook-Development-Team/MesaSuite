using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using GovernmentPortal.Extensions;
using GovernmentPortal.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;

namespace GovernmentPortal.Accounts
{
    public partial class CategoryExplorerControl : UserControl, IExplorerControl<Category>
    {
        public event EventHandler IsDirtyChanged;
        private long _governmentID;
        public CategoryExplorerControl()
        {
            InitializeComponent();
        }

        public CategoryExplorerControl(long governmentID) : this()
        {
            _governmentID = governmentID;
        }

        private bool _isDirty;
        public bool IsDirty 
        {
            get => _isDirty;
            set
            {
                _isDirty = value;
                IsDirtyChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public Category Model { get; set; }
        private frmGenericExplorer<Category> _explorer;
        public frmGenericExplorer<Category> Explorer { set => _explorer = value; }

        public async void OnDeleteClicked()
        {
            if (Model == null)
            {
                this.ShowError("Cannot delete unsaved Category");
                return;
            }

            if (!this.Confirm("Are you sure you want to delete this Category?"))
            {
                return;
            }

            loader.BringToFront();
            loader.Visible = true;

            DeleteData delete = new DeleteData(DataAccess.APIs.GovernmentPortal, $"Category/Delete/{Model.CategoryID}");
            delete.AddGovHeader(_governmentID);
            await delete.Execute();

            if (delete.RequestSuccessful)
            {
                IsDirty = false;
                _explorer.LoadAllItems(true);
                Dispose();
                return;
            }

            loader.Visible = false;
        }

        public async void OnSaveClicked()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                this.ShowError("Name is a required field");
                return;
            }

            Category modelToSave = Model;
            if (modelToSave == null)
            {
                modelToSave = new Category()
                {
                    GovernmentID = _governmentID,
                    Name = txtName.Text
                };
            };

            loader.BringToFront();
            loader.Visible = true;
            if (modelToSave.CategoryID == default)
            {
                PostData post = new PostData(DataAccess.APIs.GovernmentPortal, "Category/Post", modelToSave);
                post.AddGovHeader(_governmentID);
                modelToSave = await post.Execute<Category>();
                if (post.RequestSuccessful)
                {
                    IsDirty = false;
                    _explorer.LoadAllItems(true, modelToSave.Name);
                    Dispose();
                    return;
                }
            }
            else
            {
                PutData put = new PutData(DataAccess.APIs.GovernmentPortal, "Category/Put", modelToSave);
                put.AddGovHeader(_governmentID);
                modelToSave = await put.Execute<Category>();
                if (put.RequestSuccessful)
                {
                    IsDirty = false;
                    _explorer.LoadAllItems(true, modelToSave.Name);
                    Dispose();
                    return;
                }
            }

            loader.Visible = false;
        }

        private async void CategoryExplorerControl_Load(object sender, EventArgs e)
        {
            txtName.Text = Model?.Name;
            IsDirty = false;

            if (Model != null)
            {
                loader.BringToFront();
                loader.Visible = true;

                GetData get = new GetData(DataAccess.APIs.GovernmentPortal, $"Account/GetAllForCategoryID/{Model.CategoryID}");
                get.AddGovHeader(_governmentID);
                List<Account> accounts = await get.GetObject<List<Account>>();
                if (get.RequestSuccessful)
                {
                    lstAccounts.Items.AddRange(accounts.Select(a => $"{a.AccountNumber} ({a.Description})").ToArray());

                    if (lstAccounts.Items.Count <= 0)
                    {
                        lstAccounts.Items.Add("[No Accounts]");
                    }
                }

                loader.Visible = false;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            IsDirty = true;
        }
    }
}
