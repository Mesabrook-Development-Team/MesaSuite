using MesaSuite.Common.Data;
using MesaSuite.Models.mesasys;
using ReaLTaiizor.Controls;
using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MesaSuite.NotificationsAndTasks
{
    public partial class DiscordEmbedFieldControl : UserControl
    {
        private static FieldInfo foreverTextBoxTBMemberInfo = null;

        static DiscordEmbedFieldControl()
        {
            foreverTextBoxTBMemberInfo = typeof(ForeverTextBox).GetField("TB", BindingFlags.NonPublic | BindingFlags.Instance);
        }

        private DiscordEmbedField _discordEmbedField = null;
        public DiscordEmbedField DiscordEmbedField
        {
            get => _discordEmbedField;
            set
            {
                _discordEmbedField = value;

                txtName.Text = DiscordEmbedField?.Name;
                txtValue.Text = DiscordEmbedField?.Value;
                chkInline.Checked = DiscordEmbedField?.IsInline ?? false;
            }
        }

        public event EventHandler OnRemoveRequested;
        public event EventHandler<TextBox> OnTextBoxFocused;
        public event EventHandler OnTextBoxValidated;

        public DiscordEmbedFieldControl()
        {
            InitializeComponent();

            if (foreverTextBoxTBMemberInfo != null)
            {
                TextBox backingNameBox = (TextBox)foreverTextBoxTBMemberInfo.GetValue(txtName);
                backingNameBox.GotFocus += (sender, e) => OnTextBoxFocused?.Invoke(sender, backingNameBox);
                backingNameBox.Validated += (sender, e) => OnTextBoxValidated?.Invoke(sender, e);
                TextBox backingValueBox = (TextBox)foreverTextBoxTBMemberInfo.GetValue(txtValue);
                backingValueBox.GotFocus += (sender, e) => OnTextBoxFocused?.Invoke(sender, backingValueBox);
                backingValueBox.Validated += (sender, e) => OnTextBoxValidated?.Invoke(sender, e);
            }

            chkInline.CheckedChanged += (sender) => OnTextBoxValidated?.Invoke(sender, EventArgs.Empty);
        }

        private void DiscordEmbedFieldControl_Load(object sender, EventArgs e)
        {
            if (DiscordEmbedField == null)
            {
                DiscordEmbedField = new DiscordEmbedField();
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            OnRemoveRequested?.Invoke(this, new EventArgs());
        }

        public async Task<string> SaveField(long? embedID)
        {
            DiscordEmbedField newField = new DiscordEmbedField()
            {
                DiscordEmbedFieldID = DiscordEmbedField.DiscordEmbedFieldID,
                DiscordEmbedID = embedID,
                Name = txtName.Text,
                Value = txtValue.Text,
                IsInline = chkInline.Checked
            };

            if (newField.DiscordEmbedFieldID == null)
            {
                PostData post = new PostData(DataAccess.APIs.SystemManagement, "DiscordEmbedField/Post", newField);
                post.SuppressErrors = true;
                newField = await post.Execute<DiscordEmbedField>();
                if (!post.RequestSuccessful)
                {
                    return post.LastError;
                }
            }
            else
            {
                PutData put = new PutData(DataAccess.APIs.SystemManagement, "DiscordEmbedField/Put", newField);
                put.SuppressErrors = true;
                await put.ExecuteNoResult();
                if (!put.RequestSuccessful)
                {
                    return put.LastError;
                }
            }

            DiscordEmbedField = newField;
            return null;
        }
    }
}
