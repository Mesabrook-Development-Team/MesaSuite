using ReleaseUtility.Extensions;
using ReleaseUtility.Steps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ReleaseUtility
{
    public partial class frmMain : Form
    {
        private HashSet<byte[]> warningHash = new HashSet<byte[]>();
        private string saveFileLocation = null;
        private Dictionary<string, Dictionary<string, object>> defaults = new Dictionary<string, Dictionary<string, object>>();
        private bool _pendingChanges;
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Type stepType = typeof(IStep);
            List<Type> types = new List<Type>();
            foreach(Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                try
                {
                    foreach (Type type in assembly.GetTypes().Where(t => t != stepType && stepType.IsAssignableFrom(t)))
                    {
                        types.Add(type);
                    }
                }
                catch { }
            }

            foreach(Type type in types)
            {
                IStep stepInstance = (IStep)Activator.CreateInstance(type);
                ToolStripMenuItem stepMenu = new ToolStripMenuItem(stepInstance.FriendlyName);
                stepMenu.Tag = type;
                stepMenu.Click += AddStepClicked;
                mnuNewStep.DropDownItems.Add(stepMenu);

                ToolStripMenuItem defaultMenu = new ToolStripMenuItem(stepInstance.FriendlyName);
                defaultMenu.Tag = type;
                defaultMenu.Click += DefaultClicked;
                mnuDefaults.DropDownItems.Add(defaultMenu);
            }
        }

        private void AddStepClicked(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            Type stepType = (Type)item.Tag;
            IStep instance = (IStep)Activator.CreateInstance(stepType);

            StepTreeNode node = new StepTreeNode();
            node.Step = instance;
            lstSteps.Nodes.Add(node);
            lstSteps.SelectedNode = node;

            OnChangeMade();

            frmStepProperties properties = new frmStepProperties();
            properties.Step = instance;
            properties.Defaults = defaults.FirstOrDefault(kvp => kvp.Key == stepType.FullName).Value;
            properties.FormClosed += new FormClosedEventHandler((form, args) => { node.RefreshText(); OnChangeMade(); });
            properties.Show();
        }

        private void DefaultClicked(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;
            Type stepType = (Type)menu.Tag;

            IStep instance = (IStep)Activator.CreateInstance(stepType);
            frmStepProperties properties = new frmStepProperties();
            properties.Step = instance;
            properties.Defaults = defaults.FirstOrDefault(kvp => kvp.Key == stepType.FullName).Value; ;
            properties.FormClosed += DefaultPropertiesClosed;
            properties.SkipValidation = true;
            properties.Show();
        }

        private class StepTreeNode : TreeNode
        {
            private IStep _step;
            public IStep Step
            {
                get { return _step; }
                set
                {
                    _step = value;

                    RefreshText();
                }
            }

            public void RefreshText()
            {
                Text = string.IsNullOrEmpty(_step.DisplayName) ? _step.FriendlyName : $"{_step.DisplayName} ({_step.FriendlyName})";
                Nodes.Clear();

                foreach (PropertyInfo prop in _step.GetType().GetProperties().Where(p => !p.GetCustomAttributes<DoNotSetAttribute>().Any()))
                {
                    TreeNode item = new TreeNode();

                    if (prop.PropertyType == typeof(string) || prop.PropertyType == typeof(bool))
                    {
                        item.Text = string.Format("{0}: {1}", prop.Name, prop.GetValue(_step));
                    }
                    else if (prop.PropertyType == typeof(List<string>))
                    {
                        StringBuilder values = new StringBuilder();
                        foreach (string listValue in (List<string>)prop.GetValue(_step))
                        {
                            if (values.Length != 0)
                            {
                                values.Append(", ");
                            }

                            values.Append(listValue);
                        }

                        item.Text = string.Format("{0}: {1}", prop.Name, values.ToString());
                    }
                    else if (prop.PropertyType == typeof(Dictionary<string, string>))
                    {
                        StringBuilder values = new StringBuilder("[");
                        foreach(KeyValuePair<string, string> kvp in (Dictionary<string, string>)prop.GetValue(_step))
                        {
                            if (values.Length > 1)
                            {
                                values.Append(", ");
                            }
                            values.Append($"{kvp.Key}: {kvp.Value}");
                        }

                        values.Append("]");

                        item.Text = string.Format("{0}: {1}", prop.Name, values.ToString());
                    }
                    else
                    {
                        item.Text = string.Format("{0} value not displayable", prop.Name);
                    }

                    Nodes.Add(item);
                }
            }
        }

        private void ctxSteps_Opening(object sender, CancelEventArgs e)
        {
            mnuDeleteSteps.Enabled = lstSteps.SelectedNode != null;
            mnuProperties.Enabled = lstSteps.SelectedNode != null;
        }

        private void mnuProperties_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = lstSteps.SelectedNode;
            if (!(selectedNode is StepTreeNode))
            {
                selectedNode = selectedNode.Parent;
            }

            StepTreeNode stepNode = (StepTreeNode)selectedNode;

            frmStepProperties properties = new frmStepProperties();
            properties.Step = stepNode.Step;
            properties.FormClosed += new FormClosedEventHandler((form, args) => { stepNode.RefreshText(); OnChangeMade(); });
            properties.Show();
        }

        private async void cmdRun_Click(object sender, EventArgs e)
        {
            Enabled = false;

            try
            {
                foreach (StepTreeNode step in lstSteps.Nodes.OfType<StepTreeNode>())
                {
                    ValidationResult validationResult = step.Step.Validate();
                    if (!validationResult.IsValid(warningHash))
                    {
                        StringBuilder messages = new StringBuilder();
                        foreach (string error in validationResult.Errors)
                        {
                            messages.AppendLine($"*   {error}");
                        }

                        if (messages.Length > 0)
                        {
                            MessageBox.Show($"The following errors occurred during {step.Step.DisplayName} ({step.Step.FriendlyName}) step validation:\r\n\r\n" + messages.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        messages = new StringBuilder();
                        foreach (string warning in validationResult.Warnings.Where(kvp => !warningHash.Any(hash => hash.SequenceEqual(kvp.Key))).Select(kvp => kvp.Value))
                        {
                            messages.Append($"*   {warning}");
                        }

                        if (messages.Length > 0)
                        {
                            MessageBox.Show($"The following warnings occurred during {step.Step.DisplayName} ({step.Step.FriendlyName}) step validation:\r\n\r\n" + messages.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            warningHash.AddRange(validationResult.Warnings.Keys);
                        }

                        return;
                    }
                }

                pnlRunning.Visible = true;
                prgStatus.Value = 0;
                prgStatus.Maximum = lstSteps.Nodes.Count;

                foreach (StepTreeNode step in lstSteps.Nodes.OfType<StepTreeNode>())
                {
                    try
                    {
                        prgStatus.Value++;
                        lblRunningStatus.Text = $"{step.Step.DisplayName} ({step.Step.FriendlyName})";
                        await Task.Run(() => step.Step.Execute());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while running {step.Step.FriendlyName}: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                MessageBox.Show("Update complete!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                pnlRunning.Visible = false;
                Enabled = true;
            }
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(saveFileLocation))
            {
                mnuSaveAs_Click(sender, e);
                return;
            }

            Save();
        }

        private void mnuSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Title = "Select Save Location",
                Filter = "XML Files|*.xml",
                DefaultExt = ".xml",
                
            };

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            saveFileLocation = saveFileDialog.FileName;
            Save();
        }

        private void Save()
        {
            XElement steps = new XElement("Steps");
            foreach(StepTreeNode step in lstSteps.Nodes.OfType<StepTreeNode>())
            {
                XElement stepElement = new XElement("Step");
                stepElement.Add(new XAttribute("type", step.Step.GetType().FullName));
                step.Step.WriteXML(stepElement);
                steps.Add(stepElement);
            }

            XDocument document = new XDocument(
                new XElement("ReleaseUtilitySave",
                    new XElement("Defaults", GetDefaultElements()),
                    steps));

            document.Save(saveFileLocation);

            _pendingChanges = false;

            Text = Path.GetFileName(saveFileLocation) + " - MesaSuite Release Utility";
        }

        private void SetDefaultElements(IEnumerable<XElement> elements)
        {
            foreach(XElement element in elements)
            {
                string type = element.Attribute("type").Value;
                defaults[type] = new Dictionary<string, object>();

                foreach(XElement property in element.Elements())
                {
                    if (property.Elements("Value").Any())
                    {
                        List<string> values = new List<string>();
                        Dictionary<string, string> dictionary = new Dictionary<string, string>();
                        foreach(XElement valueElement in property.Elements("Value"))
                        {
                            if (valueElement.Attribute("key") == null)
                            {
                                values.Add(valueElement.Value);
                            }
                            else
                            {
                                dictionary.Add(valueElement.Attribute("key").Value, valueElement.Value);
                            }
                        }

                        if (values.Any())
                        {
                            defaults[type][property.Name.LocalName] = values;
                        }
                        else
                        {
                            defaults[type][property.Name.LocalName] = dictionary;
                        }
                    }
                    else
                    {
                        defaults[type][property.Name.LocalName] = property.Value;
                    }
                }
            }
        }

        private IEnumerable<XElement> GetDefaultElements()
        {
            foreach(KeyValuePair<string, Dictionary<string, object>> kvp in defaults)
            {
                XElement defaultElement = new XElement("Default", new XAttribute("type", kvp.Key));

                foreach(KeyValuePair<string, object> valueKeyPair in kvp.Value)
                {
                    XElement valueElement = new XElement(valueKeyPair.Key);

                    if (valueKeyPair.Value is string stringValue)
                    {
                        valueElement.Value = stringValue;
                    }
                    else if (valueKeyPair.Value is List<string> stringListValue)
                    {
                        foreach(string stringListValueItem in stringListValue)
                        {
                            XElement listItem = new XElement("Value", stringListValueItem);
                            valueElement.Add(listItem);
                        }
                    }
                    else if (valueKeyPair.Value is bool boolValue)
                    {
                        valueElement.Value = boolValue.ToString();
                    }
                    else if (valueKeyPair.Value is Dictionary<string, string> dictionaryValue)
                    {
                        foreach(KeyValuePair<string, string> valueKVP in dictionaryValue)
                        {
                            XElement kvpElement = new XElement("Value", new XAttribute("key", valueKVP.Key), valueKVP.Value);
                            valueElement.Add(kvpElement);
                        }
                    }

                    defaultElement.Add(valueElement);
                }

                yield return defaultElement;
            }
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            if (!CheckPendingChanges())
            {
                return;
            }

            OpenFileDialog openFile = new OpenFileDialog()
            {
                Title = "Open Save",
                Filter = "XML Files|*.xml",
                DefaultExt = ".xml",
                Multiselect = false
            };

            if (openFile.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            saveFileLocation = openFile.FileName;
            lstSteps.Nodes.Clear();

            cmdUp.Enabled = false;
            cmdDown.Enabled = false;

            XDocument document = XDocument.Load(saveFileLocation);
            XElement defaults = document.Root.Element("Defaults");
            SetDefaultElements(defaults.Elements());

            XElement steps = document.Root.Element("Steps");
            foreach (XElement step in steps.Elements("Step"))
            {
                string type = step.Attribute("type").Value;
                Type stepType = Type.GetType(type);
                IStep instance = (IStep)Activator.CreateInstance(stepType);
                instance.ReadXML(step);

                StepTreeNode stepNode = new StepTreeNode();
                stepNode.Step = instance;
                lstSteps.Nodes.Add(stepNode);
            }

            Text = Path.GetFileName(saveFileLocation) + " - MesaSuite Release Utility";
        }

        private void DefaultPropertiesClosed(object sender, FormClosedEventArgs e)
        {
            frmStepProperties properties = (frmStepProperties)sender;

            Type stepType = properties.Step.GetType();
            defaults[stepType.FullName] = new Dictionary<string, object>();

            foreach(PropertyInfo property in stepType.GetProperties().Where(p => p.GetCustomAttribute<DoNotSetAttribute>() == null))
            {
                defaults[stepType.FullName][property.Name] = property.GetValue(properties.Step);
            }

            OnChangeMade();
        }

        private void mnuDeleteSteps_Click(object sender, EventArgs e)
        {
            lstSteps.Nodes.Remove(lstSteps.SelectedNode);

            OnChangeMade();
        }

        private void cmdUp_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = lstSteps.SelectedNode.Parent ?? lstSteps.SelectedNode;
            int index = currentNode.Index;

            lstSteps.Nodes.Remove(currentNode);
            lstSteps.Nodes.Insert(index - 1, currentNode);
            lstSteps.SelectedNode = currentNode;
            lstSteps.Focus();

            OnChangeMade();
        }

        private void cmdDown_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = lstSteps.SelectedNode.Parent ?? lstSteps.SelectedNode;
            int index = currentNode.Index;

            lstSteps.Nodes.Remove(currentNode);
            lstSteps.Nodes.Insert(index + 1, currentNode);
            lstSteps.SelectedNode = currentNode;
            lstSteps.Focus();

            OnChangeMade();
        }

        private void lstSteps_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node.Parent ?? e.Node;
            cmdUp.Enabled = node.Index != 0;
            cmdDown.Enabled = node.Index != lstSteps.Nodes.Count - 1;
        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            if (!CheckPendingChanges())
            {
                return;
            }

            lstSteps.Nodes.Clear();
            defaults = new Dictionary<string, Dictionary<string, object>>();
            saveFileLocation = null;

            Text = "untitled - MesaSuite Release Utility";
        }

        private void OnChangeMade()
        {
            string loadedName = string.IsNullOrEmpty(saveFileLocation) ? "untitled" : Path.GetFileName(saveFileLocation);

            Text = $"*{loadedName} - MesaSuite Release Utility";

            _pendingChanges = true;
        }

        private bool CheckPendingChanges()
        {
            if (!_pendingChanges)
            {
                return true;
            }

            DialogResult result = MessageBox.Show("You have pending changes.  Do you want to save them now?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Cancel)
            {
                return false;
            }
            else if (result == DialogResult.Yes)
            {
                mnuSave_Click(this, new EventArgs());
            }

            _pendingChanges = false;
            return true;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CheckPendingChanges())
            {
                e.Cancel = true;
            }
        }
    }
}
