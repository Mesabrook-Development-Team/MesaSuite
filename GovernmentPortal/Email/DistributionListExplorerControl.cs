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
    public partial class DistributionListExplorerControl : UserControl, IExplorerControl<DistributionList>
    {
        public event EventHandler IsDirtyChanged;
        private long _governmentID;
        public DistributionListExplorerControl()
        {
            InitializeComponent();
        }

        public DistributionListExplorerControl(long governmentID) : this()
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
                IsDirtyChanged?.Invoke(this, new EventArgs());
            }
        }
        public DistributionList Model { get; set; }

        private frmGenericExplorer<DistributionList> _explorer;
        public frmGenericExplorer<DistributionList> Explorer { set => _explorer = value; }


        public async void OnDeleteClicked()
        {
            if (Model == null)
            {
                this.ShowError("You cannot delete an unsaved Distribution List");
                return;
            }

            if (!this.Confirm("Are you sure you want to delete this Distribution List?"))
            {
                return;
            }

            loader.BringToFront();
            loader.Visible = true;

            DeleteData delete = new DeleteData(DataAccess.APIs.GovernmentPortal, $"DistributionList/Delete/{Model.DistributionListID}");
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
            DistributionList listToSave = Model;
            if (listToSave == null)
            {
                listToSave = new DistributionList();

                loader.BringToFront();
                loader.Visible = true;

                GetData getDomain = new GetData(DataAccess.APIs.GovernmentPortal, "Domain/GetForGovernment");
                getDomain.AddGovHeader(_governmentID);
                Domain domain = await getDomain.GetObject<Domain>();
                listToSave.DistributionListDomainID = domain.DomainID;
            }

            listToSave.DistributionListAddress = txtAddress.Text;
            listToSave.DistributionListMode = rdoPublic.Checked ? (byte)0 :
                                              rdoMembers.Checked ? (byte)1 :
                                              (byte)2;
            listToSave.DistributionListRequireAddress = txtSpecific.Text;

            bool listSaveSuccess = false;
            if (Model == null)
            {
                PostData post = new PostData(DataAccess.APIs.GovernmentPortal, "DistributionList/Post", listToSave);
                post.AddGovHeader(_governmentID);
                listToSave = await post.Execute<DistributionList>();
                if (post.RequestSuccessful)
                {
                    Model = listToSave;
                    listSaveSuccess = true;
                }
            }
            else
            {
                PutData put = new PutData(DataAccess.APIs.GovernmentPortal, "DistributionList/Put", listToSave);
                put.AddGovHeader(_governmentID);
                listToSave = await put.Execute<DistributionList>();
                if (put.RequestSuccessful)
                {
                    Model = listToSave;
                    listSaveSuccess = true;
                }
            }


            bool recipientsSaveSuccess = true;
            if (listSaveSuccess)
            {
                GetData get = new GetData(DataAccess.APIs.GovernmentPortal, $"DistributionListRecipient/GetByDistributionListID/{Model.DistributionListID}");
                get.AddGovHeader(_governmentID);

                List<DistributionListRecipient> existingRecipients = await get.GetObject<List<DistributionListRecipient>>() ?? new List<DistributionListRecipient>();
                HashSet<DistributionListRecipient> handledRecipients = new HashSet<DistributionListRecipient>();

                foreach(ListViewItem item in lstRecipients.Items)
                {
                    if (item.Tag == null)
                    {
                        DistributionListRecipient distributionListRecipient = new DistributionListRecipient();
                        distributionListRecipient.DistributionListRecipientListID = Model.DistributionListID;
                        distributionListRecipient.DistributionListRecipientAddress = item.Text;
                        
                        PostData post = new PostData(DataAccess.APIs.GovernmentPortal, "DistributionListRecipient/Post", distributionListRecipient);
                        post.AddGovHeader(_governmentID);
                        await post.ExecuteNoResult();
                        recipientsSaveSuccess = recipientsSaveSuccess && post.RequestSuccessful;
                    }
                    else if (item.Tag is DistributionListRecipient existingDistributionListReceipient)
                    {
                        if (!string.Equals(existingDistributionListReceipient.DistributionListRecipientAddress, item.Text))
                        {
                            existingDistributionListReceipient.DistributionListRecipientAddress = item.Text;

                            PutData put = new PutData(DataAccess.APIs.GovernmentPortal, "DistributionListRecipient/Put", existingDistributionListReceipient);
                            put.AddGovHeader(_governmentID);
                            await put.ExecuteNoResult();
                            recipientsSaveSuccess = recipientsSaveSuccess && put.RequestSuccessful;
                        }

                        DistributionListRecipient dbRecipient = existingRecipients.FirstOrDefault(dlr => dlr.DistributionListRecipientAddress.Equals(existingDistributionListReceipient.DistributionListRecipientAddress, StringComparison.OrdinalIgnoreCase));
                        if (dbRecipient != null)
                        {
                            handledRecipients.Add(dbRecipient);
                        }
                    }
                }

                foreach(DistributionListRecipient missingRecipient in existingRecipients.Except(handledRecipients))
                {
                    DeleteData delete = new DeleteData(DataAccess.APIs.GovernmentPortal, $"DistributionListRecipient/Delete/{missingRecipient.DistributionListRecipientID}");
                    delete.AddGovHeader(_governmentID);
                    await delete.Execute();
                    recipientsSaveSuccess = recipientsSaveSuccess && delete.RequestSuccessful;
                }

                IsDirty = false;
            }

            if (listSaveSuccess && !recipientsSaveSuccess)
            {
                this.ShowError("The Distribution List saved successfully, however, at least one Recipient did not save successfully.  Please reselect this Distribution List and check your entries.");
            }

            if (listSaveSuccess && recipientsSaveSuccess)
            {
                _explorer.LoadAllItems(true, Model.DistributionListAddress);
                Dispose();
                return;
            }

            loader.Visible = false;
        }

        private async void DistributionListExplorerControl_Load(object sender, EventArgs e)
        {
            suppressDirtyChange = true;
            txtAddress.Text = Model?.DistributionListAddress;
            txtSpecific.Text = Model?.DistributionListRequireAddress;
            
            if (Model != null)
            {
                rdoPublic.Checked = Model.DistributionListMode == 0;
                rdoMembers.Checked = Model.DistributionListMode == 1;
                rdoSpecific.Checked = Model.DistributionListMode == 2;
            }

            await LoadDistributionListRecipients();

            TryAddNewRecipientItem();
        }

        private async Task LoadDistributionListRecipients()
        {
            if (Model == null)
            {
                return;
            }

            loader.BringToFront();
            loader.Visible = true;

            GetData getRecipients = new GetData(DataAccess.APIs.GovernmentPortal, $"DistributionListRecipient/GetByDistributionListID/{Model.DistributionListID}");
            getRecipients.AddGovHeader(_governmentID);
            List<DistributionListRecipient> distributionListRecipients = await getRecipients.GetObject<List<DistributionListRecipient>>();
            foreach (DistributionListRecipient distributionListRecipient in distributionListRecipients)
            {
                ListViewItem item = new ListViewItem(distributionListRecipient.DistributionListRecipientAddress);
                item.Tag = distributionListRecipient;
                lstRecipients.Items.Add(item);
            }

            TryAddNewRecipientItem();

            loader.Visible = false;
        }

        private void TryAddNewRecipientItem()
        {
            if (!lstRecipients.Items.Any(lvi => "add".Equals(lvi.Tag)))
            {
                ListViewItem addItem = new ListViewItem()
                {
                    Text = "Click to add recipient"
                };
                addItem.Font = new Font(addItem.Font, FontStyle.Italic);
                addItem.Tag = "add";

                lstRecipients.Items.Add(addItem);
            }
        }

        private bool suppressDirtyChange = false;
        private void FieldValueChanged(object sender, EventArgs e)
        {
            if (suppressDirtyChange)
            {
                return;
            }

            IsDirty = true;
        }

        private void lstRecipients_Click(object sender, EventArgs e)
        {
            if (lstRecipients.SelectedItems.Count == 1 && "add".Equals(lstRecipients.SelectedItems[0].Tag))
            {
                ListViewItem item = lstRecipients.SelectedItems[0];
                item.Text = string.Empty;
                item.BeginEdit();
            }
        }

        private void lstRecipients_BeforeLabelEdit(object sender, LabelEditEventArgs e)
        {
            ListViewItem item = lstRecipients.Items[e.Item];
            if (!"add".Equals(item.Tag))
            {
                e.CancelEdit = true;
            }
        }

        private void lstRecipients_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            ListViewItem item = lstRecipients.Items[e.Item];
            if (string.IsNullOrEmpty(e.Label))
            {
                item.Text = "Click to add recipient";
            }
            else
            {
                item.Tag = null;
                item.Font = new Font(item.Font, FontStyle.Regular);

                ListViewItem newAddItem = new ListViewItem("Click to add recipient");
                newAddItem.Tag = "add";
                newAddItem.Font = new Font(newAddItem.Font, FontStyle.Italic);
                lstRecipients.Items.Add(newAddItem);
            }

            IsDirty = true;
        }

        private void lstRecipients_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                List<ListViewItem> listViewItems = lstRecipients.SelectedItems.Where(lvi => !"add".Equals(lvi.Tag)).ToList();

                foreach (ListViewItem lvi in listViewItems)
                {
                    lstRecipients.Items.Remove(lvi);
                }

                IsDirty = true;
            }
        }

        private void Mode_CheckedChanged(object sender, EventArgs e)
        {
            txtSpecific.Enabled = rdoSpecific.Checked;
            IsDirty = true;
        }
    }
}
