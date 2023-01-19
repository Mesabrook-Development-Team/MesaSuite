using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FleetTracking.Interop;
using FleetTracking.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using MesaSuite.Common.Utility;

namespace FleetTracking.Roster
{
    public partial class MassAddStockInput : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public event EventHandler<string> ModelNameChanged;

        private Dictionary<long?, Models.RailcarModel> _railcarModelsByID = new Dictionary<long?, Models.RailcarModel>();
        private Dictionary<long?, Models.LocomotiveModel> _locomotiveModelsByID = new Dictionary<long?, Models.LocomotiveModel>();

        public MassAddStockInput()
        {
            InitializeComponent();
            colCheck.ValueType = typeof(bool?);
            colReportingNumber.ValueType = typeof(int?);

            colOwner.ValueType = typeof(object);
            colOwner.ValueMember = "Object";
            colOwner.DisplayMember = nameof(DropDownItem.Text);

            colReleasedTo.ValueType = typeof(object);
            colReleasedTo.ValueMember = "Object";
            colReleasedTo.DisplayMember = nameof(DropDownItem.Text);

            colLocation.ValueType = typeof(object);
            colLocation.ValueMember = "Object";
            colLocation.DisplayMember = nameof(DropDownItem.Text);

            dataGridViewStylizer.ApplyStyle(dgvStock);
            dgvStock.ReadOnly = false;
            dgvStock.AllowUserToAddRows = true;
            dgvStock.AllowUserToDeleteRows = true;
            dgvStock.RowHeadersVisible = true;
        }

        private async void MassAddStockInput_Load(object sender, EventArgs e)
        {
            GetData get = _application.GetAccess<GetData>();
            get.API = DataAccess.APIs.FleetTracking;
            get.Resource = "LocomotiveModel/GetAll";
            List<Models.LocomotiveModel> locoModels = await get.GetObject<List<Models.LocomotiveModel>>() ?? new List<Models.LocomotiveModel>();
            foreach(Models.LocomotiveModel model in locoModels)
            {
                LocomotiveModel.LocomotiveModelDropDownItem ddi = new LocomotiveModel.LocomotiveModelDropDownItem()
                {
                    Application = _application,
                    LocomotiveModelID = model.LocomotiveModelID,
                };

                Label closedControl = new Label()
                {
                    Text = model.Name
                };
                closedControl.Size = TextRenderer.MeasureText(closedControl.Text, closedControl.Font);
                ControlSelector.ControlSelectorItem item = new ControlSelector.ControlSelectorItem(ddi, closedControl);
                cboLocomotiveModel.Items.Add(item);

                _locomotiveModelsByID.Add(model.LocomotiveModelID, model);
            }

            get.Resource = "RailcarModel/GetAll";
            List<Models.RailcarModel> railcarModels = await get.GetObject<List<Models.RailcarModel>>() ?? new List<Models.RailcarModel>();
            foreach(Models.RailcarModel railcarModel in railcarModels)
            {
                RailcarModel.RailcarModelDropDownItem ddi = new RailcarModel.RailcarModelDropDownItem()
                {
                    Application = _application,
                    RailcarModelID = railcarModel.RailcarModelID,
                };
                Label closedControl = new Label()
                {
                    Text = railcarModel.Name
                };
                closedControl.Size = TextRenderer.MeasureText(closedControl.Text, closedControl.Font);
                ControlSelector.ControlSelectorItem item = new ControlSelector.ControlSelectorItem(ddi, closedControl);
                cboRailcarModel.Items.Add(item);

                _railcarModelsByID.Add(railcarModel.RailcarModelID, railcarModel);
            }

            get.Resource = "Company/GetAll";
            List<Company> companies = await get.GetObject<List<Company>>() ?? new List<Company>();
            foreach(Company company in companies)
            {
                DropDownItem<Company> ddi = new DropDownItem<Company>(company, company.Name);
                cboOwner.Items.Add(ddi);

                ddi = ddi.CreateCopy();
                cboReleasedTo.Items.Add(ddi);

                ddi = ddi.CreateCopy();
                colOwner.Items.Add(ddi);

                ddi = ddi.CreateCopy();
                colReleasedTo.Items.Add(ddi);
            }

            get.Resource = "Government/GetAll";
            List<Government> governments = await get.GetObject<List<Government>>() ?? new List<Government>();
            foreach(Government government in governments)
            {
                DropDownItem<Government> ddi = new DropDownItem<Government>(government, government.Name);
                cboOwner.Items.Add(ddi);

                ddi = ddi.CreateCopy();
                cboReleasedTo.Items.Add(ddi);

                ddi = ddi.CreateCopy();
                colOwner.Items.Add(ddi);

                ddi = ddi.CreateCopy();
                colReleasedTo.Items.Add(ddi);
            }

            get.Resource = "Track/GetAll";
            List<Track> tracks = await get.GetObject<List<Track>>() ?? new List<Track>();
            foreach(Track track in tracks)
            {
                DropDownItem<Track> ddi = new DropDownItem<Track>(track, track.Name);
                cboLocation.Items.Add(ddi);

                ddi = ddi.CreateCopy();
                colLocation.Items.Add(ddi);
            }
        }

        private void rdoRailcarModel_CheckedChanged(object sender, EventArgs e)
        {
            cboRailcarModel.Enabled = rdoRailcarModel.Checked;
            FireModelNameChangeEvent();
        }

        private void rdoLocomotiveModel_CheckedChanged(object sender, EventArgs e)
        {
            cboLocomotiveModel.Enabled = rdoLocomotiveModel.Checked;
            FireModelNameChangeEvent();
        }

        private void FireModelNameChangeEvent()
        {
            if (rdoRailcarModel.Checked && cboRailcarModel.SelectedItem != null)
            {
                RailcarModel.RailcarModelDropDownItem ddi = (cboRailcarModel.SelectedItem as ControlSelector.ControlSelectorItem)?.DropDownControl as RailcarModel.RailcarModelDropDownItem;

                if (ddi != null)
                {
                    ModelNameChanged?.Invoke(this, _railcarModelsByID[ddi.RailcarModelID].Name);
                    return;
                }
            }
            else if (rdoLocomotiveModel.Checked && cboLocomotiveModel.SelectedItem != null)
            {
                LocomotiveModel.LocomotiveModelDropDownItem ddi = (cboLocomotiveModel.SelectedItem as ControlSelector.ControlSelectorItem)?.DropDownControl as LocomotiveModel.LocomotiveModelDropDownItem;

                if (ddi != null)
                {
                    ModelNameChanged?.Invoke(this, _locomotiveModelsByID[ddi.LocomotiveModelID].Name);
                    return;
                }
            }

            ModelNameChanged?.Invoke(this, string.Empty);
        }

        private void cboLocomotiveModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            FireModelNameChangeEvent();
        }

        private void cboRailcarModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            FireModelNameChangeEvent();
        }

        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvStock.Rows.OfType<DataGridViewRow>().Where(dgvr => !dgvr.IsNewRow).Count())
            {
                return;
            }

            if (e.ColumnIndex == colCheck.Index)
            {
                dgvStock[e.ColumnIndex, e.RowIndex].Value = !((dgvStock[e.ColumnIndex, e.RowIndex].Value as bool?) ?? false);
            }
        }

        private void toolCheckAll_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dgvStock.Rows.OfType<DataGridViewRow>().Where(dgvr => !dgvr.IsNewRow))
            {
                row.Cells[colCheck.Name].Value = true;
            }
        }

        private void toolUncheckAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvStock.Rows.OfType<DataGridViewRow>().Where(dgvr => !dgvr.IsNewRow))
            {
                row.Cells[colCheck.Name].Value = false;
            }
        }

        private void chkOwner_CheckedChanged(object sender, EventArgs e)
        {
            cboOwner.Enabled = chkOwner.Checked;
        }

        private void chkReleasedTo_CheckedChanged(object sender, EventArgs e)
        {
            cboReleasedTo.Enabled = chkReleasedTo.Checked;
        }

        private void chkLocation_CheckedChanged(object sender, EventArgs e)
        {
            cboLocation.Enabled = chkLocation.Checked;
        }

        private void cmdApplyFields_Click(object sender, EventArgs e)
        {
            IEnumerable<DataGridViewRow> rowsToApply = dgvStock.Rows.Cast<DataGridViewRow>().Where(dgvr => !dgvr.IsNewRow && (dgvr.Cells[colCheck.Name].Value as bool? ?? false));
            
            foreach(DataGridViewRow row in rowsToApply)
            {
                if (chkOwner.Checked)
                {
                    DropDownItem<Company> companyDDI = cboOwner.SelectedItem.Cast<DropDownItem<Company>>();
                    DropDownItem<Government> governmentDDI = cboOwner.SelectedItem.Cast<DropDownItem<Government>>();

                    if (companyDDI == null && governmentDDI == null)
                    {
                        row.Cells[colOwner.Name].Value = null;
                    }
                    else if (companyDDI != null)
                    {
                        row.Cells[colOwner.Name].Value = colOwner.Items.OfType<DropDownItem<Company>>().Where(ddi => ddi.Object.CompanyID == companyDDI.Object.CompanyID).FirstOrDefault()?.Object;
                    }
                    else if (governmentDDI != null)
                    {
                        row.Cells[colOwner.Name].Value = colOwner.Items.OfType<DropDownItem<Government>>().Where(ddi => ddi.Object.GovernmentID == governmentDDI.Object.GovernmentID).FirstOrDefault()?.Object;
                    }
                }

                if (chkReleasedTo.Checked)
                {
                    DropDownItem<Company> companyDDI = cboReleasedTo.SelectedItem.Cast<DropDownItem<Company>>();
                    DropDownItem<Government> governmentDDI = cboReleasedTo.SelectedItem.Cast<DropDownItem<Government>>();

                    if (companyDDI == null && governmentDDI == null)
                    {
                        row.Cells[colReleasedTo.Name].Value = null;
                    }
                    else if (companyDDI != null)
                    {
                        row.Cells[colReleasedTo.Name].Value = colReleasedTo.Items.OfType<DropDownItem<Company>>().FirstOrDefault(ddi => ddi.Object.CompanyID == companyDDI.Object.CompanyID)?.Object;
                    }
                    else if (governmentDDI != null)
                    {
                        row.Cells[colReleasedTo.Name].Value = colReleasedTo.Items.OfType<DropDownItem<Government>>().FirstOrDefault(ddi => ddi.Object.GovernmentID == governmentDDI.Object.GovernmentID)?.Object;
                    }
                }

                if (chkLocation.Checked)
                {
                    DropDownItem<Track> track = cboLocation.SelectedItem.Cast<DropDownItem<Track>>();
                    if (track == null)
                    {
                        row.Cells[colLocation.Name].Value = null;
                    }
                    else
                    {
                        row.Cells[colLocation.Name].Value = colLocation.Items.OfType<DropDownItem<Track>>().FirstOrDefault(ddi => ddi.Object.TrackID == track.Object.TrackID)?.Object;
                    }
                }
            }
        }

        public string GetEntryErrors()
        {
            StringBuilder errors = new StringBuilder();
            if (cboLocomotiveModel.SelectedItem == null && cboRailcarModel.SelectedItem == null)
            {
                errors.AppendLine("No Railcar/Locomotive Model selected");
            }

            for(int i = 0; i < dgvStock.Rows.Count; i++)
            {
                DataGridViewRow row = dgvStock.Rows[i];
                if (row.IsNewRow)
                {
                    continue;
                }

                if (string.IsNullOrEmpty(row.Cells[colReportingMark.Name].Value as string))
                {
                    errors.AppendLine($"Line {i + 1}: Missing Reporting Mark");
                }

                if (row.Cells[colReportingNumber.Name].Value == null)
                {
                    errors.AppendLine($"Line {i + 1}: Missing Reporting Number");
                }

                if (row.Cells[colOwner.Name].Value == null)
                {
                    errors.AppendLine($"Line {i + 1}: Missing Owner");
                }

                if (row.Cells[colReleasedTo.Name].Value == null)
                {
                    errors.AppendLine($"Line {i + 1}: Missing Released To");
                }

                if (row.Cells[colLocation.Name].Value == null)
                {
                    errors.AppendLine($"Line {i + 1}: Missing Location");
                }
            }

            return errors.ToString();
        }

        public IEnumerable<Railcar> GetRailcars()
        {
            if (!rdoRailcarModel.Checked || cboRailcarModel.SelectedItem == null)
            {
                yield break;
            }

            long? railcarModelID = ((cboRailcarModel.SelectedItem as ControlSelector.ControlSelectorItem).DropDownControl as RailcarModel.RailcarModelDropDownItem).RailcarModelID;

            foreach(DataGridViewRow row in dgvStock.Rows.OfType<DataGridViewRow>().Where(dgvr => !dgvr.IsNewRow))
            {
                yield return new Railcar()
                {
                    RailcarModelID = railcarModelID,
                    ReportingMark = row.Cells[colReportingMark.Name].Value as string,
                    ReportingNumber = row.Cells[colReportingNumber.Name].Value as int?,
                    CompanyIDOwner = row.Cells[colOwner.Name].Value.Cast<Company>()?.CompanyID,
                    GovernmentIDOwner = row.Cells[colOwner.Name].Value.Cast<Government>()?.GovernmentID,
                    CompanyIDPossessor = row.Cells[colReleasedTo.Name].Value.Cast<Company>()?.CompanyID,
                    GovernmentIDPossessor = row.Cells[colReleasedTo.Name].Value.Cast<Government>()?.GovernmentID,
                    RailLocation = new RailLocation()
                    {
                        TrackID = row.Cells[colLocation.Name].Value.Cast<Track>()?.TrackID
                    }
                };
            }
        }

        public IEnumerable<Locomotive> GetLocomotives()
        {
            if (!rdoLocomotiveModel.Checked || cboLocomotiveModel.SelectedItem == null)
            {
                yield break;
            }

            long? locomotiveModelID = ((cboLocomotiveModel.SelectedItem as ControlSelector.ControlSelectorItem).DropDownControl as LocomotiveModel.LocomotiveModelDropDownItem).LocomotiveModelID;

            foreach (DataGridViewRow row in dgvStock.Rows.OfType<DataGridViewRow>().Where(dgvr => !dgvr.IsNewRow))
            {
                yield return new Locomotive()
                {
                    LocomotiveModelID = locomotiveModelID,
                    ReportingMark = row.Cells[colReportingMark.Name].Value as string,
                    ReportingNumber = row.Cells[colReportingNumber.Name].Value as int?,
                    CompanyIDOwner = row.Cells[colOwner.Name].Value.Cast<Company>()?.CompanyID,
                    GovernmentIDOwner = row.Cells[colOwner.Name].Value.Cast<Government>()?.GovernmentID,
                    CompanyIDPossessor = row.Cells[colReleasedTo.Name].Value.Cast<Company>()?.CompanyID,
                    GovernmentIDPossessor = row.Cells[colReleasedTo.Name].Value.Cast<Government>()?.GovernmentID,
                    RailLocation = new RailLocation()
                    {
                        TrackID = row.Cells[colLocation.Name].Value.Cast<Track>()?.TrackID
                    }
                };
            }
        }
    }
}
