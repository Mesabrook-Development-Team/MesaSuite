using ReleaseUtility.Extensions;
using ReleaseUtility.Steps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReleaseUtility
{
    public partial class frmStepProperties : Form
    {
        internal IStep Step { get; set; }
        internal IReadOnlyDictionary<string, object> Defaults { private get; set; }
        internal bool SkipValidation { get; set; }
        private HashSet<byte[]> warningHashes = new HashSet<byte[]>();

        public frmStepProperties()
        {
            InitializeComponent();
        }

        private void frmStepProperties_Load(object sender, EventArgs e)
        {
            lblName.Text = Step.FriendlyName;
            layout.RowStyles.Clear();
            foreach(PropertyInfo property in Step.GetType().GetProperties())
            {
                if (property.GetCustomAttribute<DoNotSetAttribute>() != null)
                {
                    continue;
                }

                Label label = new Label()
                {
                    Text = property.Name,
                    AutoSize = false,
                    Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom
                };

                Control value = null;
                if (property.PropertyType == typeof(string))
                {
                    TextBox text = new TextBox();
                    text.Text = property.GetValue(Step) as string;
                    text.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                    value = text;

                    if (string.IsNullOrEmpty(text.Text) && Defaults != null && Defaults.ContainsKey(property.Name))
                    {
                        text.Text = Defaults[property.Name] as string;
                    }
                }
                else if (property.PropertyType == typeof(List<string>))
                {
                    DataGridView dgv = new DataGridView();
                    dgv.RowHeadersVisible = false;
                    dgv.Columns.Add("colValue", "Value");

                    if (property.GetValue(Step) != null)
                    {
                        foreach (string propertyValue in (List<string>)property.GetValue(Step))
                        {
                            dgv.Rows.Add(propertyValue);
                        }
                    }

                    if (dgv.Rows.Count == 1 && Defaults != null && Defaults.ContainsKey(property.Name) && !(Defaults[property.Name] is string))
                    {
                        List<string> listValues = Defaults[property.Name] as List<string>;
                        foreach(string listValue in listValues)
                        {
                            dgv.Rows.Add(listValue);
                        }
                    }

                    value = dgv;
                }
                else if (property.PropertyType == typeof(bool))
                {
                    CheckBox checkBox = new CheckBox();
                    checkBox.Checked = (bool)property.GetValue(Step);

                    if (!checkBox.Checked && Defaults != null && Defaults.ContainsKey(property.Name))
                    {
                        checkBox.Checked = bool.Parse(Defaults[property.Name].ToString());
                    }

                    value = checkBox;
                }
                else if (property.PropertyType == typeof(Dictionary<string, string>))
                {
                    DataGridView dgv = new DataGridView();
                    dgv.RowHeadersVisible = false;
                    dgv.Columns.Add("colKey", "Key");
                    dgv.Columns.Add("colValue", "Value");

                    if (property.GetValue(Step) != null)
                    {
                        foreach (KeyValuePair<string, string> propertyValue in (Dictionary<string, string>)property.GetValue(Step))
                        {
                            dgv.Rows.Add(propertyValue.Key, propertyValue.Value);
                        }
                    }

                    if (dgv.Rows.Count == 1 && Defaults != null && Defaults.ContainsKey(property.Name) && !(Defaults[property.Name] is string))
                    {
                        Dictionary<string, string> listValues = Defaults[property.Name] as Dictionary<string, string>;
                        foreach (KeyValuePair<string, string> kvpValue in listValues)
                        {
                            dgv.Rows.Add(kvpValue.Key, kvpValue.Value);
                        }
                    }

                    value = dgv;
                }

                value.Tag = property;
                layout.RowCount++;
                layout.Controls.Add(label);
                layout.Controls.Add(value);
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < layout.RowCount; i++)
            {
                Control value = layout.GetControlFromPosition(1, i);
                if (value == null)
                {
                    continue;
                }

                PropertyInfo property = (PropertyInfo)value.Tag;

                if (value is TextBox txtValue)
                {
                    property.SetValue(Step, txtValue.Text);
                }
                else if (value is DataGridView dgvValue)
                {
                    if (property.PropertyType == typeof(List<string>))
                    {
                        List<string> newValue = new List<string>();
                        foreach (DataGridViewRow row in dgvValue.Rows)
                        {
                            newValue.Add(row.Cells[0].Value.ToString());
                        }

                        property.SetValue(Step, newValue);
                    }
                    else
                    {
                        Dictionary<string, string> values = new Dictionary<string, string>();
                        foreach(DataGridViewRow row in dgvValue.Rows)
                        {
                            if (row.Cells[0].Value == null)
                            {
                                continue;
                            }
                            values.Add(row.Cells[0].Value.ToString(), row.Cells[1].Value?.ToString() ?? "");
                        }

                        property.SetValue(Step, values);
                    }
                }
                else if (value is CheckBox chkValue)
                {
                    property.SetValue(Step, chkValue.Checked);
                }
            }

            if (!SkipValidation)
            {
                ValidationResult validationResult = Step.Validate();
                if (!validationResult.IsValid(warningHashes))
                {
                    StringBuilder messages = new StringBuilder();
                    foreach (string error in validationResult.Errors)
                    {
                        messages.AppendLine($"*   {error}");
                    }

                    if (messages.Length > 0)
                    {
                        MessageBox.Show("The following errors occurred during step validation:\r\n\r\n" + messages.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    messages = new StringBuilder();
                    foreach (string warning in validationResult.Warnings.Where(kvp => !warningHashes.Any(hash => hash.SequenceEqual(kvp.Key))).Select(kvp => kvp.Value))
                    {
                        messages.Append($"*   {warning}");
                    }

                    if (messages.Length > 0)
                    {
                        MessageBox.Show("The following warnings occurred during step validation:\r\n\r\n" + messages.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        warningHashes.AddRange(validationResult.Warnings.Keys);
                    }

                    return;
                }
            }

            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
