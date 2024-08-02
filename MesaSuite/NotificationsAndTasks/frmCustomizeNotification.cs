using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using MesaSuite.Models.mesasys;
using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Channels;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MesaSuite.NotificationsAndTasks
{
    public partial class frmCustomizeNotification : Form
    {
        private static FieldInfo foreverTextBoxTBMemberInfo = null;

        static frmCustomizeNotification()
        {
            foreverTextBoxTBMemberInfo = typeof(ForeverTextBox).GetField("TB", BindingFlags.NonPublic | BindingFlags.Instance);
        }

        public frmCustomizeNotification()
        {
            InitializeComponent();

            parameterImages.Images.Add("folder", Properties.Resources.folder);
            parameterImages.Images.Add("style", Properties.Resources.style);

            AddForeverTextBoxFocusEventHandler(txtEmbeddedAuthorName, EmbeddedMessageTextBox_GotFocus);
            AddForeverTextBoxFocusEventHandler(txtEmbeddedAuthorIconURL, EmbeddedMessageTextBox_GotFocus);
            AddForeverTextBoxFocusEventHandler(txtEmbeddedAuthorURL, EmbeddedMessageTextBox_GotFocus);
            AddForeverTextBoxFocusEventHandler(txtEmbeddedDescription, EmbeddedMessageTextBox_GotFocus);
            AddForeverTextBoxFocusEventHandler(txtEmbeddedFooterIconURL, EmbeddedMessageTextBox_GotFocus);
            AddForeverTextBoxFocusEventHandler(txtEmbeddedFooterText, EmbeddedMessageTextBox_GotFocus);
            AddForeverTextBoxFocusEventHandler(txtEmbeddedImageURL, EmbeddedMessageTextBox_GotFocus);
            AddForeverTextBoxFocusEventHandler(txtEmbeddedThumbnailURL, EmbeddedMessageTextBox_GotFocus);
            AddForeverTextBoxFocusEventHandler(txtEmbeddedTitle, EmbeddedMessageTextBox_GotFocus);
            AddForeverTextBoxFocusEventHandler(txtEmbeddedURL, EmbeddedMessageTextBox_GotFocus);

            AddForeverTextBoxFocusEventHandler(txtEmailFromEmail, EmailTextBox_GotFocus);
            AddForeverTextBoxFocusEventHandler(txtEmailFromName, EmailTextBox_GotFocus);
            AddForeverTextBoxFocusEventHandler(txtEmailToEmail, EmailTextBox_GotFocus);
            AddForeverTextBoxFocusEventHandler(txtEmailSubject, EmailTextBox_GotFocus);
            txtEmailBody.GotFocus += EmailTextBox_GotFocus;

            AddValidatedEventHandlerRecursive(this);
        }

        private void AddForeverTextBoxFocusEventHandler(ForeverTextBox foreverTextBox, EventHandler eventHandler)
        {
            if (foreverTextBoxTBMemberInfo == null)
            {
                return;
            }

            TextBox textBox = (TextBox)foreverTextBoxTBMemberInfo.GetValue(foreverTextBox);
            textBox.GotFocus += eventHandler;
        }

        private void AddValidatedEventHandlerRecursive(Control control)
        {
            foreach (Control c in control.Controls)
            {
                c.Validated += Control_Validated;
                if (c is ForeverCheckBox foreverCheckBox)
                {
                    foreverCheckBox.CheckedChanged += delegate { Control_Validated(foreverCheckBox, EventArgs.Empty); };
                }
                AddValidatedEventHandlerRecursive(c);
            }
        }

        public NotificationEvent NotificationEvent { get; set; }
        public NotificationSubscriber NotificationSubscriber { get; set; }

        private void frmCustomizeNotification_Load(object sender, EventArgs e)
        {
            txtNotificationText.Text = NotificationSubscriber.NotificationText;
            chkInGameChat.Checked = NotificationSubscriber.IsReportableInGame;
            chkMarkDelivered.Checked = NotificationSubscriber.MarkReadAfterDelivery;
            chkUseDiscord.Checked = NotificationSubscriber.UseDiscord;
            pnlUseDiscord.Enabled = chkUseDiscord.Checked;
            txtUserIDDM.Text = NotificationSubscriber.DiscordDMUserID;
            txtChannelIDDM.Text = NotificationSubscriber.DiscordChannelID;
            txtUserIDPing.Text = NotificationSubscriber.DiscordPingUserID;
            txtRoleIDPing.Text = NotificationSubscriber.DiscordPingRoleID;
            txtDiscordMessageContent.Text = NotificationSubscriber.DiscordContent;
            chkUseEmbeddedMessage.Checked = NotificationSubscriber.DiscordEmbedID != null;
            cntUseEmbed.Enabled = chkUseEmbeddedMessage.Checked;
            txtEmbeddedDescription.Text = NotificationSubscriber.DiscordEmbed?.Description;
            txtEmbeddedURL.Text = NotificationSubscriber.DiscordEmbed?.URL;
            txtEmbeddedAuthorName.Text = NotificationSubscriber.DiscordEmbed?.AuthorName;
            txtEmbeddedAuthorURL.Text = NotificationSubscriber.DiscordEmbed?.AuthorURL;
            txtEmbeddedAuthorIconURL.Text = NotificationSubscriber.DiscordEmbed?.AuthorIconURL;
            txtEmbeddedThumbnailURL.Text = NotificationSubscriber.DiscordEmbed?.ThumbnailURL;
            txtEmbeddedImageURL.Text = NotificationSubscriber.DiscordEmbed?.ImageURL;
            txtEmbeddedFooterText.Text = NotificationSubscriber.DiscordEmbed?.FooterText;
            txtEmbeddedFooterIconURL.Text = NotificationSubscriber.DiscordEmbed?.FooterIconURL;
            txtEmbeddedTitle.Text = NotificationSubscriber.DiscordEmbed?.Title;
            chkUseEmail.Checked = NotificationSubscriber.UseEmail;
            txtEmailFromEmail.Text = NotificationSubscriber.EmailFromEmail;
            txtEmailFromName.Text = NotificationSubscriber.EmailFromName;
            txtEmailToEmail.Text = NotificationSubscriber.EmailTo;
            txtEmailSubject.Text = NotificationSubscriber.EmailSubject;
            txtEmailBody.Text = NotificationSubscriber.EmailBody;

            if (NotificationSubscriber.DiscordEmbed?.DiscordEmbedFields != null)
            {
                foreach (DiscordEmbedField field in NotificationSubscriber.DiscordEmbed.DiscordEmbedFields)
                {
                    AddDiscordEmbedFieldControl(field);
                }
            }

            SetupParameterForTreeView(treNotificationTextParameters);
            SetupParameterForTreeView(treDiscordContentParameters);
            SetupParameterForTreeView(treDiscordEmbeddedParameters);
            SetupParameterForTreeView(treEmailParameters);
        }

        private void SetupParameterForTreeView(TreeView treeView)
        {
            foreach (string parameter in NotificationEvent.ParametersArray.OrderBy(p => p))
            {
                TreeNodeCollection collection = treeView.Nodes;
                string workingParameterName = parameter;
                while (workingParameterName.Contains('.'))
                {
                    string rootParameter = workingParameterName.Substring(0, workingParameterName.IndexOf('.'));
                    TreeNode foundNode = collection.OfType<TreeNode>().FirstOrDefault(n => n.Text.Equals(rootParameter, StringComparison.OrdinalIgnoreCase));
                    if (foundNode == null)
                    {
                        foundNode = new TreeNode(rootParameter) { ImageKey = "folder", SelectedImageKey = "folder" };
                        collection.Add(foundNode);
                    }

                    collection = foundNode.Nodes;
                    workingParameterName = workingParameterName.Substring(workingParameterName.IndexOf('.') + 1);
                }

                TreeNode parameterNode = new TreeNode(workingParameterName) { ImageKey = "style", SelectedImageKey = "style" };
                collection.Add(parameterNode);
            }
        }

        private void WhatsThis_MouseMove(object sender, MouseEventArgs e)
        {
            Point newPoint = PointToClient(((Control)sender).PointToScreen(e.Location));
            newPoint.Y += Cursor.Size.Height / 2;
            newPoint.X -= 30 + (newPoint.X + grpParameters.Width - 30 > tabPage1.Width ? newPoint.X + grpParameters.Width - 30 - tabPage1.Width : 0);

            grpParameters.Location = newPoint;
            grpParameters.BringToFront();
            grpParameters.Visible = true;
            grpParameters.Refresh();
        }

        private void WhatsThis_MouseLeave(object sender, EventArgs e)
        {
            grpParameters.Visible = false;
        }

        private void treNotificationTextParameters_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            AddBindingToTextBox(e.Node, txtNotificationText);
        }

        private void AddBindingToTextBox(TreeNode clickedNode, Control textBox)
        {
            if (clickedNode.Nodes.Count > 0)
            {
                return;
            }

            string bindingToInsert = clickedNode.Text;
            TreeNode parentNode = clickedNode.Parent;
            while (parentNode != null)
            {
                bindingToInsert = parentNode.Text + "." + bindingToInsert;
                parentNode = parentNode.Parent;
            }

            TextBox actualTextBox = null;
            if (textBox is TextBox)
            {
                actualTextBox = (TextBox)textBox;
            }

            int selectionStart = actualTextBox != null ? actualTextBox.SelectionStart : textBox.Text.Length;
            textBox.Text = textBox.Text.Insert(selectionStart, $"{{{bindingToInsert}}}");
            if (actualTextBox != null)
            {
                actualTextBox.Select(selectionStart + bindingToInsert.Length + 2, 0);
            }
            textBox.Focus();
        }

        private void cmdAddField_Click(object sender, EventArgs e)
        {
            AddDiscordEmbedFieldControl();
        }

        private void AddDiscordEmbedFieldControl(DiscordEmbedField field = null)
        {
            DiscordEmbedFieldControl discordEmbedFieldControl = new DiscordEmbedFieldControl();
            discordEmbedFieldControl.DiscordEmbedField = field;
            discordEmbedFieldControl.OnRemoveRequested += delegate
            {
                tblDiscordFields.Controls.Remove(discordEmbedFieldControl);
                discordEmbedFieldControl.Dispose();
                Control_Validated(discordEmbedFieldControl, EventArgs.Empty);
            };
            discordEmbedFieldControl.OnTextBoxValidated += Control_Validated;
            discordEmbedFieldControl.OnTextBoxFocused += (_, txt) => txtEmbeddedLastSelected = txt;
            discordEmbedFieldControl.Width = tblDiscordFields.GetColumnWidths()[0];
            tblDiscordFields.Controls.Add(discordEmbedFieldControl);
            discordEmbedFieldControl.CreateControl();
        }

        private void tblDiscordFields_ClientSizeChanged(object sender, EventArgs e)
        {
            foreach(Control ctrl in tblDiscordFields.Controls)
            {
                ctrl.Width = tblDiscordFields.GetColumnWidths()[0];
            }
        }

        private void chkUseDiscord_CheckedChanged(object sender)
        {
            pnlUseDiscord.Enabled = chkUseDiscord.Checked;
        }

        private void chkUseEmbeddedMessage_CheckedChanged(object sender)
        {
            cntUseEmbed.Enabled = chkUseEmbeddedMessage.Checked;
        }

        private void treDiscordContentParameters_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            AddBindingToTextBox(e.Node, txtDiscordMessageContent);
        }

        TextBox txtEmbeddedLastSelected = null;
        private void EmbeddedMessageTextBox_GotFocus(object sender, EventArgs e)
        {
            txtEmbeddedLastSelected = (TextBox)sender;
        }

        private void treDiscordEmbeddedParameters_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (txtEmbeddedLastSelected != null)
            {
                AddBindingToTextBox(e.Node, txtEmbeddedLastSelected);
            }
        }

        TextBox txtEmailLastSelected = null;
        private void EmailTextBox_GotFocus(object sender, EventArgs e)
        {
            txtEmailLastSelected = (TextBox)sender;
        }

        private void treEmailParameters_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (txtEmailLastSelected != null)
            {
                AddBindingToTextBox(e.Node, txtEmailLastSelected);
            }
        }

        private void chkUseEmail_CheckedChanged(object sender)
        {
            cntEmail.Enabled = chkUseEmail.Checked;
        }

        bool hasChanges = false;
        bool changesSaving = false;
        private void Control_Validated(object sender, EventArgs e)
        {
            hasChanges = true;

            if (!changesSaving)
            {
                SetStatusText("Changes Pending");
            }
        }

        private async void tmrSaver_Tick(object sender, EventArgs e)
        {
            if (!hasChanges)
            {
                return;
            }

            try
            {
                tmrSaver.Enabled = false;
                await SaveNotificationSubscriber();
            }
            finally
            {
                changesSaving = false;
                tmrSaver.Enabled = true;
            }
        }

        private async Task SaveNotificationSubscriber()
        {
            changesSaving = true;
            hasChanges = false;

            SetStatusText("Saving...");

            DiscordEmbed embed = null;

            if (chkUseEmbeddedMessage.Checked)
            {
                embed = new DiscordEmbed()
                {
                    DiscordEmbedID = NotificationSubscriber.DiscordEmbedID,
                    Description = txtEmbeddedDescription.Text,
                    URL = txtEmbeddedURL.Text,
                    AuthorName = txtEmbeddedAuthorName.Text,
                    AuthorURL = txtEmbeddedAuthorURL.Text,
                    AuthorIconURL = txtEmbeddedAuthorIconURL.Text,
                    ThumbnailURL = txtEmbeddedThumbnailURL.Text,
                    ImageURL = txtEmbeddedImageURL.Text,
                    FooterText = txtEmbeddedFooterText.Text,
                    FooterIconURL = txtEmbeddedFooterIconURL.Text,
                    Title = txtEmbeddedTitle.Text
                };

                if (embed.DiscordEmbedID == null)
                {
                    PostData post = new PostData(DataAccess.APIs.SystemManagement, "DiscordEmbed/Post", embed);
                    post.SuppressErrors = true;
                    embed = await post.Execute<DiscordEmbed>();
                    if (!post.RequestSuccessful)
                    {
                        SetStatusText("One or more errors occurred", post.LastError);
                        return;
                    }
                }
                else
                {
                    PutData putEmbed = new PutData(DataAccess.APIs.SystemManagement, "DiscordEmbed/Put", embed);
                    putEmbed.SuppressErrors = true;
                    await putEmbed.ExecuteNoResult();
                    if (!putEmbed.RequestSuccessful)
                    {
                        SetStatusText("One or more errors occurred", putEmbed.LastError);
                        return;
                    }
                }

                HashSet<long?> handledFieldIDs = new HashSet<long?>();
                foreach (DiscordEmbedFieldControl discordEmbedFieldControl in tblDiscordFields.Controls.OfType<DiscordEmbedFieldControl>())
                {
                    string fieldSaveError = await discordEmbedFieldControl.SaveField(embed.DiscordEmbedID);
                    if (!string.IsNullOrEmpty(fieldSaveError))
                    {
                        SetStatusText("One or more errors occurred", fieldSaveError);
                        return;
                    }

                    handledFieldIDs.Add(discordEmbedFieldControl.DiscordEmbedField.DiscordEmbedFieldID);
                }

                foreach (DiscordEmbedField deletedEmbedField in NotificationSubscriber.DiscordEmbed.DiscordEmbedFields.Where(x => !handledFieldIDs.Contains(x.DiscordEmbedFieldID)))
                {
                    DeleteData delete = new DeleteData(DataAccess.APIs.SystemManagement, "DiscordEmbedField/Delete/" + deletedEmbedField.DiscordEmbedFieldID);
                    delete.SuppressErrors = true;
                    await delete.Execute();
                    if (!delete.RequestSuccessful)
                    {
                        SetStatusText("One or more errors occurred", delete.LastError);
                        return;
                    }
                }
            }

            NotificationSubscriber.NotificationText = txtNotificationText.Text;
            NotificationSubscriber.IsReportableInGame = chkInGameChat.Checked;
            NotificationSubscriber.MarkReadAfterDelivery = chkMarkDelivered.Checked;
            NotificationSubscriber.UseDiscord = chkUseDiscord.Checked;
            NotificationSubscriber.DiscordDMUserID = txtUserIDDM.Text;
            NotificationSubscriber.DiscordChannelID = txtChannelIDDM.Text;
            NotificationSubscriber.DiscordPingUserID = txtUserIDPing.Text;
            NotificationSubscriber.DiscordPingRoleID = txtRoleIDPing.Text;
            NotificationSubscriber.DiscordContent = txtDiscordMessageContent.Text;
            NotificationSubscriber.DiscordEmbedID = chkUseEmbeddedMessage.Checked ? embed.DiscordEmbedID : null;
            NotificationSubscriber.UseEmail = chkUseEmail.Checked;
            NotificationSubscriber.EmailFromEmail = txtEmailFromEmail.Text;
            NotificationSubscriber.EmailFromName = txtEmailFromName.Text;
            NotificationSubscriber.EmailTo = txtEmailToEmail.Text;
            NotificationSubscriber.EmailSubject = txtEmailSubject.Text;
            NotificationSubscriber.EmailBody = txtEmailBody.Text;

            PutData put = new PutData(DataAccess.APIs.SystemManagement, "NotificationSubscriber/Put", NotificationSubscriber);
            put.SuppressErrors = true;
            NotificationSubscriber notificationSubscriber = await put.Execute<NotificationSubscriber>();
            if (!put.RequestSuccessful)
            {
                SetStatusText("One or more errors occurred", put.LastError);
                return;
            }

            NotificationSubscriber = notificationSubscriber;

            changesSaving = false;

            SetStatusText(hasChanges ? "Changes Pending" : "Changes Saved");
        }

        private void SetStatusText(string text, string errors = null)
        {
            statusBar.Text = text;

            if (!string.IsNullOrEmpty(errors))
            {
                statusBar.TextColor = Color.Red;
                statusBar.Font = new Font(statusBar.Font, FontStyle.Underline);
                statusBar.Cursor = Cursors.Hand;
            }
            else
            {
                statusBar.TextColor = Color.White;
                statusBar.Font = new Font(statusBar.Font, FontStyle.Regular);
                statusBar.Cursor = Cursors.Default;
            }

            statusBar.Tag = errors;
        }

        private void statusBar_Click(object sender, EventArgs e)
        {
            if (statusBar.Tag != null && statusBar.Tag is string errorString && !string.IsNullOrEmpty(errorString))
            {
                this.ShowInformation(errorString);
            }
        }

        private bool _allowClose = false;
        private async void frmCustomizeNotification_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_allowClose)
            {
                return;
            }

            tmrSaver.Enabled = false;
            e.Cancel = true;

            if (changesSaving)
            {
                cmdClose.Enabled = false;
                cmdMaximize.Enabled = false;
                cmdMinimize.Enabled = false;
                foreverTabPage1.Enabled = false;
                statusBar.Enabled = false;
                progressSaveBeforeClose.BringToFront();
                progressSaveBeforeClose.Visible = true;

                while (changesSaving)
                {
                    await Task.Delay(50);
                }
            }

            if (hasChanges)
            {
                cmdClose.Enabled = false;
                cmdMaximize.Enabled = false;
                cmdMinimize.Enabled = false;
                foreverTabPage1.Enabled = false;
                statusBar.Enabled = false;
                progressSaveBeforeClose.BringToFront();
                progressSaveBeforeClose.Visible = true;

                await SaveNotificationSubscriber();
                hasChanges = false;
                changesSaving = false;
            }

            if (statusBar.Tag != null && statusBar.Tag is string errorMessage && !string.IsNullOrEmpty(errorMessage) && 
                this.Confirm(errorMessage + "\r\n\r\nClosing without successfully saving will discard most, or all, changes.\r\n\r\nDo you want to make changes before closing?"))
            {
                cmdClose.Enabled = true;
                cmdMaximize.Enabled = true;
                cmdMinimize.Enabled = true;
                foreverTabPage1.Enabled = true;
                statusBar.Enabled = true;
                progressSaveBeforeClose.Visible = false;
                return;
            }

            _allowClose = true;
            Close();
        }
    }
}
