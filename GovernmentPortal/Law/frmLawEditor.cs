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

namespace GovernmentPortal.Law
{
    public partial class frmLawEditor : Form
    {
        public long? GovernmentID { get; set; }
        private bool _dirty = false;
        public frmLawEditor()
        {
            InitializeComponent();
        }

        private async void frmLawEditor_Load(object sender, EventArgs e)
        {
            await LoadTreeView();
        }

        private async Task LoadTreeView(long? selectedLawID = null, long? selectedSectionID = null)
        {
            pnlSection.Visible = false;
            _dirty = false;
            treLaws.Nodes.Clear();

            try
            {
                loaderLaws.BringToFront();
                loaderLaws.Visible = true;

                GetData get = new GetData(DataAccess.APIs.GovernmentPortal, "Law/GetForGovernment");
                get.AddGovHeader(GovernmentID.Value);
                List<Models.Law> laws = await get.GetObject<List<Models.Law>>() ?? new List<Models.Law>();
                foreach (Models.Law law in laws.OrderBy(l => l.DisplayOrder))
                {
                    TreeNode lawNode = new TreeNode(law.Name);
                    lawNode.Tag = law;

                    foreach (LawSection section in (law.LawSections ?? new List<LawSection>()).OrderBy(ls => ls.DisplayOrder))
                    {
                        TreeNode sectionNode = new TreeNode(section.Title);
                        sectionNode.Tag = section;
                        lawNode.Nodes.Add(sectionNode);
                    }

                    treLaws.Nodes.Add(lawNode);
                }

                if (selectedLawID != null)
                {
                    TreeNode nodeToSelect = treLaws.Nodes.OfType<TreeNode>().FirstOrDefault(tn => tn.Tag is Models.Law law && law.LawID == selectedLawID);
                    if (nodeToSelect != null)
                    {
                        treLaws.SelectedNode = nodeToSelect;
                    }
                }

                if (selectedSectionID != null)
                {
                    TreeNode nodeToSelect = treLaws.Nodes.OfType<TreeNode>().SelectMany(n => n.Nodes.OfType<TreeNode>()).FirstOrDefault(tn => tn.Tag is LawSection section && section.LawSectionID == selectedSectionID);
                    if (nodeToSelect != null)
                    {
                        treLaws.SelectedNode = nodeToSelect;
                    }
                }
            }
            finally
            {
                loaderLaws.Visible = false;
            }
        }

        private async void addLawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                loaderLaws.BringToFront();
                loaderLaws.Visible = true;

                Models.Law newLaw = new Models.Law()
                {
                    GovernmentID = GovernmentID,
                    Name = "[New Law]"
                };

                PostData post = new PostData(DataAccess.APIs.GovernmentPortal, "Law/Post", newLaw);
                post.AddGovHeader(GovernmentID.Value);
                newLaw = await post.Execute<Models.Law>();
                if (post.RequestSuccessful)
                {
                    await LoadTreeView(newLaw.LawID);
                }
            }
            finally
            {
                loaderLaws.Visible = false;
            }
        }

        private async void treLaws_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Label) || !(e.Node.Tag is Models.Law law))
            {
                return;
            }

            try
            {
                loaderLaws.BringToFront();
                loaderLaws.Visible = true;

                law.Name = e.Label;

                PutData put = new PutData(DataAccess.APIs.GovernmentPortal, "Law/Put", law);
                put.AddGovHeader(GovernmentID.Value);
                await put.ExecuteNoResult();
                e.CancelEdit = !put.RequestSuccessful;
            }
            finally
            {
                loaderLaws.Visible = false;
            }
        }

        private void treLaws_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            e.CancelEdit = !(e.Node.Tag is Models.Law);
        }

        private void ctxLaws_Opening(object sender, CancelEventArgs e)
        {
            TreeNode selectedNode = treLaws.SelectedNode;

            bool isSectionEnabled = selectedNode != null;
            addSectionToolStripMenuItem.Enabled = isSectionEnabled;
            deleteSectionsToolStripMenuItem.Enabled = isSectionEnabled;
        }

        private async void deleteLawsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treLaws.SelectedNode == null)
            {
                return;
            }

            TreeNode lawNode;
            if (treLaws.SelectedNode.Tag is Models.Law)
            {
                lawNode = treLaws.SelectedNode;
            }
            else
            {
                lawNode = treLaws.SelectedNode.Parent;
            }

            Models.Law law = lawNode.Tag as Models.Law;
            DeleteData deleteLaw = new DeleteData(DataAccess.APIs.GovernmentPortal, $"Law/Delete/{law.LawID}");
            deleteLaw.AddGovHeader(GovernmentID.Value);

            try
            {
                loaderLaws.BringToFront();
                loaderLaws.Visible = true;
                await deleteLaw.Execute();
                if (deleteLaw.RequestSuccessful)
                {
                    await LoadTreeView();
                }
            }
            finally
            {
                loaderLaws.Visible = false;
            }
        }

        private async void addSectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode lawNode = treLaws.SelectedNode;
            if (lawNode == null)
            {
                return;
            }

            if (lawNode.Tag is LawSection)
            {
                lawNode = lawNode.Parent;
            }

            Models.Law law = lawNode.Tag as Models.Law;

            LawSection newSection = new LawSection()
            {
                LawID = law.LawID,
                Title = "[New Section]",
                Detail = "[Law Detail]"
            };

            PostData post = new PostData(DataAccess.APIs.GovernmentPortal, "LawSection/Post", newSection);
            post.AddGovHeader(GovernmentID.Value);

            try
            {
                loaderLaws.BringToFront();
                loaderLaws.Visible = true;

                newSection = await post.Execute<LawSection>();
                if (post.RequestSuccessful)
                {
                    await LoadTreeView(selectedSectionID: newSection.LawSectionID);
                }
            }
            finally
            {
                loaderLaws.Visible = false;
            }
        }

        private async void deleteSectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(treLaws.SelectedNode?.Tag is LawSection lawSection))
            {
                return;
            }

            DeleteData delete = new DeleteData(DataAccess.APIs.GovernmentPortal, $"LawSection/Delete/{lawSection.LawSectionID}");
            delete.AddGovHeader(GovernmentID.Value);

            try
            {
                loaderLaws.BringToFront();
                loaderLaws.Visible = true;

                await delete.Execute();
                if (delete.RequestSuccessful)
                {
                    await LoadTreeView(lawSection.LawID);
                }
            }
            finally
            {
                loaderLaws.Visible = false;
            }
        }

        private async void treLaws_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null || !(e.Node.Tag is LawSection lawSection))
            {
                pnlSection.Visible = false;
                return;
            }

            loaderSection.BringToFront();
            loaderSection.Visible = true;
            pnlSection.Visible = true;

            try
            {
                GetData get = new GetData(DataAccess.APIs.GovernmentPortal, $"LawSection/Get/{lawSection.LawSectionID}");
                get.RequireAuthentication = false;
                lawSection = await get.GetObject<LawSection>();
                if (lawSection == null)
                {
                    pnlSection.Visible = false;
                }

                pnlSection.Tag = lawSection;
                txtTitle.Text = lawSection.Title;
                txtDetails.Text = lawSection.Detail;
            }
            finally
            {
                loaderSection.Visible = false;
            }
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            if (!pnlSection.Visible) return;
            await SaveSectionData();
        }

        private async Task SaveSectionData()
        {
            LawSection lawSection = pnlSection.Tag as LawSection;
            lawSection.Title = txtTitle.Text;
            lawSection.Detail = txtDetails.Text;

            PutData put = new PutData(DataAccess.APIs.GovernmentPortal, "LawSection/Put", lawSection);
            put.AddGovHeader(GovernmentID.Value);

            try
            {
                loaderSection.BringToFront();
                loaderSection.Visible = true;
                lawSection = await put.Execute<LawSection>();
                if (put.RequestSuccessful)
                {
                    _dirty = false;
                    await LoadTreeView(selectedSectionID: lawSection.LawSectionID);
                }
            }
            finally
            {
                loaderSection.Visible = false;
            }
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            if (!pnlSection.Visible) return;

            _dirty = false;
            LawSection lawSection = pnlSection.Tag as LawSection;
            txtTitle.Text = lawSection.Title;
            txtDetails.Text = lawSection.Detail;
        }

        private void SectionDataChanged(object sender, EventArgs e)
        {
            _dirty = true;
        }

        private async void cmdMoveUp_Click(object sender, EventArgs e)
        {
            TreeNode node = await CheckAndPromptDirty();

            try
            {
                loaderLaws.BringToFront();
                loaderLaws.Visible = true;

                if (node.Tag is Models.Law law)
                {
                    if (law.DisplayOrder > 1)
                    {
                        law.DisplayOrder--;

                        PutData put = new PutData(DataAccess.APIs.GovernmentPortal, $"Law/Put", law);
                        put.AddGovHeader(GovernmentID.Value);
                        await put.ExecuteNoResult();
                        if (put.RequestSuccessful)
                        {
                            await LoadTreeView(law.LawID);
                        }
                    }
                }
                else if (node.Tag is LawSection section)
                {
                    if (section.DisplayOrder > 1)
                    {
                        section.DisplayOrder--;
                        PutData put = new PutData(DataAccess.APIs.GovernmentPortal, "LawSection/Put", section);
                        put.AddGovHeader(GovernmentID.Value);
                        await put.ExecuteNoResult();
                        if (put.RequestSuccessful)
                        {
                            await LoadTreeView(selectedSectionID: section.LawSectionID);
                        }
                    }
                }
            }
            finally
            {
                loaderLaws.Visible = false;
            }
        }

        private async Task<TreeNode> CheckAndPromptDirty()
        {
            TreeNode node = treLaws.SelectedNode;
            if (node == null)
            {
                return null;
            }

            if (_dirty)
            {
                DialogResult res = MessageBox.Show("Changing the display order will reset Section data.\r\n\r\nDo you want to save the Section data?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (res == DialogResult.Cancel)
                {
                    return null;
                }

                if (res == DialogResult.Yes)
                {
                    await SaveSectionData();
                }

                _dirty = false;
            }

            return node;
        }

        private async void cmdMoveDown_Click(object sender, EventArgs e)
        {
            TreeNode node = await CheckAndPromptDirty();
            if (node == null)
            {
                return;
            }

            try
            {
                loaderLaws.BringToFront();
                loaderLaws.Visible = true;

                if (node.Tag is Models.Law law)
                {
                    if (node.Index < treLaws.Nodes.Count - 1)
                    {
                        law.DisplayOrder++;

                        PutData put = new PutData(DataAccess.APIs.GovernmentPortal, $"Law/Put", law);
                        put.AddGovHeader(GovernmentID.Value);
                        await put.ExecuteNoResult();
                        if (put.RequestSuccessful)
                        {
                            await LoadTreeView(law.LawID);
                        }
                    }
                }
                else if (node.Tag is LawSection section)
                {
                    if (node.Index < node.Parent.Nodes.Count - 1)
                    {
                        section.DisplayOrder++;
                        PutData put = new PutData(DataAccess.APIs.GovernmentPortal, "LawSection/Put", section);
                        put.AddGovHeader(GovernmentID.Value);
                        await put.ExecuteNoResult();
                        if (put.RequestSuccessful)
                        {
                            await LoadTreeView(selectedSectionID: section.LawSectionID);
                        }
                    }
                }
            }
            finally
            {
                loaderLaws.Visible = false;
            }
        }
    }
}
