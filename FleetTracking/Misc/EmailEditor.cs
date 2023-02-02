using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FleetTracking.Attributes;
using FleetTracking.Interop;
using FleetTracking.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;

namespace FleetTracking.Misc
{
    [SecuredControl(SecuredControlAttribute.Permissions.AllowSetup)]
    public partial class EmailEditor : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }
        public string EmailName { get; set; }
        public long? EmailImplementationID { get; set; }

        private EmailTemplate _emailTemplate = null;

        public EmailEditor()
        {
            InitializeComponent();
        }

        private async void frmEmailEditor_Load(object sender, EventArgs e)
        {
            loader.BringToFront();
            loader.Visible = true;
            ParentForm.Text = "Edit Email";

            GetData getTemplate = _application.GetAccess<GetData>();
            getTemplate.API = DataAccess.APIs.FleetTracking;
            getTemplate.Resource = "EmailTemplate/GetByName";
            getTemplate.QueryString.Add("name", EmailName);
            _emailTemplate = await getTemplate.GetObject<EmailTemplate>();
            if (_emailTemplate == null)
            {
                this.ShowError("No email template by the name " + EmailName + " exists");
                ParentForm.Close();
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
                            TreeNode rootNode = treFields.Nodes.OfType<TreeNode>().FirstOrDefault(tn => tn.Text == relationshipPathParts[i]);
                            if (rootNode == null)
                            {
                                rootNode = new TreeNode(relationshipPathParts[i]);
                                treFields.Nodes.Add(rootNode);
                            }
                            parentNode = rootNode;
                        }
                        else
                        {
                            TreeNode childNode = parentNode.Nodes.OfType<TreeNode>().FirstOrDefault(tn => tn.Text == relationshipPathParts[i]);
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
                ResetToDefault();
            }

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

            PostData post = _application.GetAccess<PostData>();
            post.API = DataAccess.APIs.FleetTracking;
            post.Resource = "EmailImplementation/Post";
            post.ObjectToPost = new EmailImplementation()
            {
                EmailTemplateID = _emailTemplate.EmailTemplateID,
                FromName = txtFromName.Text,
                FromEmail = txtFromEmail.Text,
                To = txtToEmail.Text,
                Subject = txtSubject.Text,
                Body = txtBody.Text
            };
            EmailImplementation emailImplementation = await post.Execute<EmailImplementation>();
            if (post.RequestSuccessful)
            {
                ParentForm.DialogResult = DialogResult.OK;

                EmailImplementationID = emailImplementation.EmailImplementationID;
                ParentForm.Close();
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

                if (binding.Contains(":"))
                {
                    binding = binding.Substring(0, binding.IndexOf(":"));
                }

                if (!allowedBindings.Contains(binding))
                {
                    return false;
                }
            }

            return true;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            ParentForm.DialogResult = DialogResult.Cancel;
            ParentForm.Close();
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
