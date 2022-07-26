using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompanyStudio.Extensions;
using CompanyStudio.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using WeifenLuo.WinFormsUI.Docking;

namespace CompanyStudio
{
    public partial class frmEmailEditor : Form
    {
        public long? CompanyID { get; set; }
        public long? LocationID { get; set; }
        public string EmailName { get; set; }
        public long? EmailImplementationID { get; set; }
        public ThemeBase Theme { get; set; }

        private EmailTemplate _emailTemplate = null;

        public frmEmailEditor()
        {
            InitializeComponent();
        }

        private async void frmEmailEditor_Load(object sender, EventArgs e)
        {
            studioFormExtender.ApplyStyle(this, Theme);

            loader.BringToFront();
            loader.Visible = true;

            GetData getTemplate = new GetData(DataAccess.APIs.CompanyStudio, "EmailTemplate/GetByName");
            getTemplate.AddLocationHeader(CompanyID, LocationID);
            getTemplate.QueryString.Add("name", EmailName);
            _emailTemplate = await getTemplate.GetObject<EmailTemplate>();
            if (_emailTemplate == null)
            {
                Dispose();
                return;
            }

            txtEmailName.Text = _emailTemplate.Name;
            string[] splitFields = _emailTemplate.AllowedFields.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> fields = splitFields.Where(field => !field.Contains(".")).OrderBy(field => field).ToList();
            fields.AddRange(splitFields.Where(field => field.Contains(".")).OrderBy(field => field));
            
            foreach(string field in fields)
            {
                if (field.Contains("."))
                {
                    string relationshipPath = field.Substring(0, field.LastIndexOf('.'));
                    string[] relationshipPathParts = relationshipPath.Split('.');
                    TreeNode parentNode = null;
                    for(int i = 0; i < relationshipPathParts.Length; i++)
                    {
                        if (parentNode == null)
                        {
                            TreeNode rootNode = treFields.Nodes.Find(relationshipPathParts[i], false).FirstOrDefault();
                            if (rootNode == null)
                            {
                                rootNode = new TreeNode(relationshipPathParts[i]);
                                treFields.Nodes.Add(rootNode);
                            }
                            parentNode = rootNode;
                        }
                        else
                        {
                            TreeNode childNode = parentNode.Nodes.Find(relationshipPathParts[i], false).FirstOrDefault();
                            if (childNode == null)
                            {
                                childNode = new TreeNode(relationshipPathParts[i]);
                                parentNode.Nodes.Add(childNode);
                            }
                            parentNode = childNode;
                        }
                    }

                    string finalField = field.Substring(field.LastIndexOf(".") + 1);
                    parentNode.Nodes.Add(finalField);
                }
                else
                {
                    treFields.Nodes.Add(field);
                }
            }

            if (EmailImplementationID != null)
            {
                chkEnabled.Checked = true;
                getTemplate.Resource = $"EmailImplementation/Get/{EmailImplementationID}";
                EmailImplementation implementation = await getTemplate.GetObject<EmailImplementation>();

                if (implementation != null)
                {
                    txtFromName.Text = implementation.FromName;
                    txtFromEmail.Text = implementation.FromEmail;
                    txtToEmail.Text = implementation.To;
                    txtSubject.Text = implementation.Subject;
                    txtBody.Text = implementation.Body;
                }
            }
            else
            {
                chkEnabled.Checked = false;
                ResetToDefault();
            }

            chkEnabled_CheckedChanged(this, EventArgs.Empty);
            loader.Visible = false;
        }

        private void ResetToDefault()
        {
            txtFromName.Clear();
            txtFromEmail.Clear();
            txtToEmail.Clear();
            txtSubject.Text = _emailTemplate.Name;
            txtBody.Text = _emailTemplate.Template;
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            ResetToDefault();
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            if (!chkEnabled.Checked)
            {
                EmailImplementationID = null;
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            if (string.IsNullOrEmpty(txtFromEmail.Text) ||
                string.IsNullOrEmpty(txtFromName.Text) ||
                string.IsNullOrEmpty(txtToEmail.Text) ||
                string.IsNullOrEmpty(txtSubject.Text) ||
                string.IsNullOrEmpty(txtBody.Text))
            {
                this.ShowError("All fields are required.");
                return;
            }

            if (!VerifyBindings())
            {
                this.ShowError("Body contains some invalid fields.");
                return;
            }

            PostData post = new PostData(DataAccess.APIs.CompanyStudio, "EmailImplementation/Post", new EmailImplementation()
            {
                EmailTemplateID = _emailTemplate.EmailTemplateID,
                FromName = txtFromName.Text,
                FromEmail = txtFromEmail.Text,
                To = txtToEmail.Text,
                Subject = txtSubject.Text,
                Body = txtBody.Text
            });
            post.AddLocationHeader(CompanyID, LocationID);
            EmailImplementation emailImplementation = await post.Execute<EmailImplementation>();
            if (post.RequestSuccessful)
            {
                DialogResult = DialogResult.OK;

                EmailImplementationID = emailImplementation.EmailImplementationID;
                Close();
            }
        }

        private bool VerifyBindings()
        {
            string bodyString = txtBody.Text;
            string[] allowedBindings = _emailTemplate.AllowedFields.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            while(bodyString.Contains('{'))
            {
                bodyString = bodyString.Substring(bodyString.IndexOf('{') + 1);
                if (!bodyString.Contains('}'))
                {
                    return false;
                }

                string binding = bodyString.Substring(0, bodyString.IndexOf('}'));
                if (!allowedBindings.Contains(binding))
                {
                    return false;
                }
            }

            return true;
        }

        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            txtFromName.Enabled = chkEnabled.Checked;
            txtFromEmail.Enabled = chkEnabled.Checked;
            txtToEmail.Enabled = chkEnabled.Checked;
            txtSubject.Enabled = chkEnabled.Checked;
            txtBody.Enabled = chkEnabled.Checked;
            treFields.Enabled = chkEnabled.Checked;
            cmdReset.Enabled = chkEnabled.Checked;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void treFields_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Nodes.Count > 0)
            {
                return;
            }

            TreeNode node = e.Node;
            StringBuilder bindingBuilder = new StringBuilder(node.Text);
            while(node.Parent != null)
            {
                bindingBuilder.Insert(0, node.Parent.Text + ".");
                node = node.Parent;
            }

            int selectionStart = txtBody.SelectionStart;
            txtBody.Text = txtBody.Text.Insert(txtBody.SelectionStart, $"{{{bindingBuilder.ToString()}}}");
            txtBody.Select(selectionStart + bindingBuilder.Length + 2, 0);
        }
    }
}
