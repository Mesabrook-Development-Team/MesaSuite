﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FleetTracking.Attributes;
using FleetTracking.Interop;
using FleetTracking.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using MesaSuite.Common.Utility;

namespace FleetTracking.Utilities
{
    [SecuredControl(SecuredControlAttribute.Permissions.AllowLoadUnload, SecuredControlAttribute.Permissions.IsTrainCrew, SecuredControlAttribute.Permissions.IsYardmaster)]
    public partial class MassUpdateEquipment : UserControl, IFleetTrackingControl
    {
        public bool DefaultSetRelease { get; set; }

        public MassUpdateEquipment()
        {
            InitializeComponent();

            dataGridViewStylizer.ApplyStyle(dgvEquipment);
            dgvEquipment.ReadOnly = false;
            colReportingMark.ReadOnly = true;
            colReleaseToCurrent.ReadOnly = true;
            colDestinationCurrent.ReadOnly = true;
            colStrategicTrackCurrent.ReadOnly = true;

            colReleaseTo.ValueType = typeof(object);
            colDestination.ValueType = typeof(object);
            colStrategic.ValueType = typeof(object);

            colReleaseTo.ValueMember = "Object";
            colDestination.ValueMember = "Object";
            colStrategic.ValueMember = "Object";

            colReleaseTo.DisplayMember = nameof(DropDownItem.Text);
            colDestination.DisplayMember = nameof(DropDownItem.Text);
            colStrategic.DisplayMember = nameof(DropDownItem.Text);
        }

        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        private Dictionary<long?, ModifiedRailLocationData> modifiedRailLocationsByID = new Dictionary<long?, ModifiedRailLocationData>();

        private async void MassUpdateRailcars_Load(object sender, EventArgs e)
        {
            try
            {
                loader.BringToFront();
                loader.Visible = true;

                chkReleasedTo.Checked = DefaultSetRelease;
                cboReleasedTo.Enabled = DefaultSetRelease;

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;

                get.Resource = "Track/GetAll";
                List<Track> tracks = (await get.GetObject<List<Track>>() ?? new List<Track>()).OrderBy(t => t.Name).ToList();
                foreach(Track track in tracks)
                {
                    DropDownItem<Track> ddi = new DropDownItem<Track>(track, track?.Name ?? "");
                    cboTrackTrain.Items.Add(ddi);

                    ddi = ddi.CreateCopy();
                    cboDestination.Items.Add(ddi);

                    ddi = ddi.CreateCopy();
                    cboStrategicTrack.Items.Add(ddi);

                    ddi = ddi.CreateCopy();
                    colDestination.Items.Add(ddi);

                    ddi = ddi.CreateCopy();
                    colStrategic.Items.Add(ddi);
                }

                get.Resource = "Train/GetFiltered";
                get.QueryString.Add("operableonly", "false");
                var filteredResponse = new
                {
                    maxItems = 0L,
                    trains = new List<Models.Train>()
                };
                filteredResponse = await get.GetAnonymousObject(filteredResponse);
                if (filteredResponse == null)
                {
                    return;
                }

                List<Models.Train> trains = filteredResponse.trains;
                foreach (Models.Train train in trains.OrderBy(t => t.TrainSymbol.Name).ThenBy(t => t.TimeOnDuty))
                {
                    DropDownItem<Models.Train> ddi = new DropDownItem<Models.Train>(train, $"{train.TrainSymbol.Name}: {train.TimeOnDuty?.ToString("MM/dd/yyyy HH:mm") ?? "--/--/---- --:--"}");
                    cboTrackTrain.Items.Add(ddi);
                }

                get.QueryString.Clear();
                get.Resource = "Company/GetAll";
                List<Company> companies = await get.GetObject<List<Company>>() ?? new List<Company>();
                foreach(Company company in companies)
                {
                    DropDownItem<Company> ddi = new DropDownItem<Company>(company, company.Name);
                    cboReleasedTo.Items.Add(ddi);

                    ddi = ddi.CreateCopy();
                    colReleaseTo.Items.Add(ddi);
                }

                get.Resource = "Government/GetAll";
                List<Government> governments = await get.GetObject<List<Government>>() ?? new List<Government>();
                foreach(Government government in governments)
                {
                    DropDownItem<Government> ddi = new DropDownItem<Government>(government, government.Name);
                    cboReleasedTo.Items.Add(ddi);

                    ddi = ddi.CreateCopy();
                    colReleaseTo.Items.Add(ddi);
                }
            }
            finally
            {
                loader.Visible = false;
            }
        }

        private void cboTrackTrain_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private bool _gridLoading = false;
        private async void PopulateGrid()
        {
            try
            {
                _gridLoading = true;
                loader.BringToFront();
                loader.Visible = true;

                dgvEquipment.Rows.Clear();

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;

                DropDownItem<Models.Train> trainDDI = null;
                DropDownItem<Track> trackDDI = null;
                if (cboTrackTrain.SelectedItem is DropDownItem<Models.Train>)
                {
                    trainDDI = cboTrackTrain.SelectedItem as DropDownItem<Models.Train>;
                    get.Resource = $"RailLocation/GetByTrain/{trainDDI.Object.TrainID}";
                }
                else if (cboTrackTrain.SelectedItem is DropDownItem<Track>)
                {
                    trackDDI = cboTrackTrain.SelectedItem as DropDownItem<Track>;
                    get.Resource = $"RailLocation/GetByTrack/{trackDDI.Object.TrackID}";
                }
                else
                {
                    return;
                }

                List<RailLocation> railLocations = await get.GetObject<List<RailLocation>>() ?? new List<RailLocation>();
                railLocations = railLocations.OrderBy(rl => rl.Position).ToList();
                foreach (RailLocation railLocation in railLocations)
                {
                    int rowIndex = dgvEquipment.Rows.Add();
                    DataGridViewRow row = dgvEquipment.Rows[rowIndex];

                    if (railLocation.RailcarID != null)
                    {
                        Railcar railcar = railLocation.Railcar;
                        row.Cells[colReportingMark.Name].Value = railcar.FormattedReportingMark;
                        row.Cells[colReleaseToCurrent.Name].Value = railcar.CompanyPossessor?.Name ?? railcar.GovernmentPossessor?.Name;
                        row.Cells[colDestinationCurrent.Name].Value = railcar.TrackDestination?.Name;
                        row.Cells[colStrategicTrackCurrent.Name].Value = railcar.TrackStrategic?.Name;

                        row.Cells[colReleaseTo.Name].ReadOnly = !_application.IsCurrentEntity(railcar.CompanyIDPossessor, railcar.GovernmentIDPossessor);
                        row.Cells[colDestination.Name].ReadOnly = railcar.CompanyLeasedTo?.CompanyID == null && railcar.GovernmentLeasedTo?.GovernmentID == null ? !_application.IsCurrentEntity(railcar.CompanyIDOwner, railcar.GovernmentIDOwner) : !_application.IsCurrentEntity(railcar.CompanyLeasedTo?.CompanyID, railcar.GovernmentLeasedTo?.GovernmentID);
                        row.Cells[colStrategic.Name].ReadOnly = !_application.IsCurrentEntity(trainDDI?.Object.TrainSymbol.CompanyIDOperator ?? trackDDI?.Object.RailDistrict?.CompanyIDOperator, trainDDI?.Object.TrainSymbol.GovernmentIDOperator ?? trackDDI?.Object.RailDistrict?.GovernmentIDOperator);
                    }
                    else if (railLocation.LocomotiveID != null)
                    {
                        Locomotive locomotive = railLocation.Locomotive;
                        row.Cells[colReportingMark.Name].Value = locomotive.FormattedReportingMark;
                        row.Cells[colReleaseToCurrent.Name].Value = locomotive.CompanyPossessor?.Name ?? locomotive.GovernmentPossessor?.Name;

                        row.Cells[colReleaseTo.Name].ReadOnly = !_application.IsCurrentEntity(locomotive.CompanyIDPossessor, locomotive.GovernmentIDPossessor);
                        row.Cells[colDestination.Name].ReadOnly = true;
                        row.Cells[colStrategic.Name].ReadOnly = true;
                    }

                    row.Tag = railLocation;

                    if (modifiedRailLocationsByID.ContainsKey(railLocation.RailLocationID))
                    {
                        ModifiedRailLocationData modifiedData = modifiedRailLocationsByID[railLocation.RailLocationID];
                        if (modifiedData.ReleasedToIDCompanyNew != null)
                        {
                            DropDownItem<Company> rowCompany = ((DataGridViewComboBoxCell)row.Cells[colReleaseTo.Name]).Items.OfType<DropDownItem<Company>>().FirstOrDefault(ddi => ddi.Object?.CompanyID == modifiedData.ReleasedToIDCompanyNew);
                            row.Cells[colReleaseTo.Name].Value = rowCompany;
                        }

                        if (modifiedData.ReleasedToIDGovernmentNew != null)
                        {
                            DropDownItem<Government> rowGovernment = ((DataGridViewComboBoxCell)row.Cells[colReleaseTo.Name]).Items.OfType<DropDownItem<Government>>().FirstOrDefault(ddi => ddi.Object?.GovernmentID == modifiedData.ReleasedToIDGovernmentNew);
                            row.Cells[colReleaseTo.Name].Value = rowGovernment;
                        }

                        if (modifiedData.TrackIDDestinationNew != null)
                        {
                            DropDownItem<Track> rowDestination = ((DataGridViewComboBoxCell)row.Cells[colDestination.Name]).Items.OfType<DropDownItem<Track>>().FirstOrDefault(ddi => ddi.Object?.TrackID == modifiedData.TrackIDDestinationNew);
                            row.Cells[colDestination.Name].Value = rowDestination;
                        }

                        if (modifiedData.TrackIDStrategicNew != null)
                        {
                            DropDownItem<Track> rowStrategic = ((DataGridViewComboBoxCell)row.Cells[colStrategic.Name]).Items.OfType<DropDownItem<Track>>().FirstOrDefault(ddi => ddi.Object?.TrackID == modifiedData.TrackIDStrategicNew);
                            row.Cells[colStrategic.Name].Value = rowStrategic;
                        }
                    }
                }
            }
            finally
            {
                loader.Visible = false;
                _gridLoading = false;
            }

            try
            {
                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;

                foreach(DataGridViewRow row in dgvEquipment.Rows)
                {
                    byte[] imageData = null;
                    RailLocation location = row.Tag as RailLocation;
                    if (location == null)
                    {
                        continue;
                    }

                    if (location.RailcarID != null)
                    {
                        get.Resource = $"Railcar/GetImageThumbnail/{location.RailcarID}";
                        imageData = await get.GetObject<byte[]>();
                    }
                    else if (location.LocomotiveID != null)
                    {
                        get.Resource = $"Locomotive/GetImageThumbnail/{location.LocomotiveID}";
                        imageData = await get.GetObject<byte[]>();
                    }

                    if (imageData != null)
                    {
                        using (MemoryStream stream = new MemoryStream(imageData))
                        {
                            row.Cells[colImage.Name].Value = Image.FromStream(stream);
                        }
                    }
                    continue;
                }
            }
            catch { }
        }

        private void toolCheckAll_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dgvEquipment.Rows)
            {
                row.Cells[colCheck.Name].Value = true;
            }
        }

        private void toolUncheckAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvEquipment.Rows)
            {
                row.Cells[colCheck.Name].Value = false;
            }
        }

        private void chkReleasedTo_CheckedChanged(object sender, EventArgs e)
        {
            cboReleasedTo.Enabled = chkReleasedTo.Checked;
        }

        private void chkDestination_CheckedChanged(object sender, EventArgs e)
        {
            cboDestination.Enabled = chkDestination.Checked;
        }

        private void chkStrategicTrack_CheckedChanged(object sender, EventArgs e)
        {
            cboStrategicTrack.Enabled = chkStrategicTrack.Checked;
        }

        private void cmdApply_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dgvEquipment.Rows)
            {
                bool isChecked = (row.Cells[colCheck.Name].Value as bool?) ?? false;
                if (!isChecked)
                {
                    continue;
                }

                bool valueChanged = false;
                if (chkReleasedTo.Checked && !row.Cells[colReleaseTo.Name].ReadOnly)
                {
                    if (cboReleasedTo.SelectedItem == null)
                    {
                        row.Cells[colReleaseTo.Name].Value = null;
                        valueChanged = true;
                    }
                    else
                    {
                        if (cboReleasedTo.SelectedItem is DropDownItem<Company> massCompany)
                        {
                            DropDownItem<Company> rowDDI = ((DataGridViewComboBoxCell)row.Cells[colReleaseTo.Name]).Items.OfType<DropDownItem<Company>>().FirstOrDefault(ddi => ddi.Object?.CompanyID == massCompany.Object.CompanyID);
                            row.Cells[colReleaseTo.Name].Value = rowDDI;
                            valueChanged = true;
                        }
                        else if (cboReleasedTo.SelectedItem is DropDownItem<Government> massGovernment)
                        {
                            DropDownItem<Government> rowDDI = ((DataGridViewComboBoxCell)row.Cells[colReleaseTo.Name]).Items.OfType<DropDownItem<Government>>().FirstOrDefault(ddi => ddi.Object?.GovernmentID == massGovernment.Object.GovernmentID);
                            row.Cells[colReleaseTo.Name].Value = rowDDI;
                            valueChanged = true;
                        }
                    }
                }

                if (chkDestination.Checked && !row.Cells[colDestination.Name].ReadOnly)
                {
                    if (cboDestination.SelectedItem == null)
                    {
                        row.Cells[colDestination.Name].Value = null;
                        valueChanged = true;
                    }
                    else
                    {
                        DropDownItem<Track> massTrack = cboDestination.SelectedItem as DropDownItem<Track>;
                        DropDownItem<Track> rowDDI = ((DataGridViewComboBoxCell)row.Cells[colDestination.Name]).Items.OfType<DropDownItem<Track>>().FirstOrDefault(ddi => ddi.Object?.TrackID == massTrack.Object.TrackID);
                        row.Cells[colDestination.Name].Value = rowDDI;
                        valueChanged = true;
                    }
                }

                if (chkStrategicTrack.Checked && !row.Cells[colStrategic.Name].ReadOnly)
                {
                    if (cboStrategicTrack.SelectedItem == null)
                    {
                        row.Cells[colStrategic.Name].Value = null;
                        valueChanged = true;
                    }
                    else
                    {
                        DropDownItem<Track> massTrack = cboStrategicTrack.SelectedItem as DropDownItem<Track>;
                        DropDownItem<Track> rowDDI = ((DataGridViewComboBoxCell)row.Cells[colStrategic.Name]).Items.OfType<DropDownItem<Track>>().FirstOrDefault(ddi => ddi.Object?.TrackID == massTrack.Object.TrackID);
                        row.Cells[colStrategic.Name].Value = rowDDI;
                        valueChanged = true;
                    }
                }

                if (valueChanged)
                {
                    dgvCars_CellValueChanged(this, new DataGridViewCellEventArgs(colReleaseTo.Index, row.Index));
                }
            }
        }

        private void dgvCars_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_gridLoading ||
                (e.ColumnIndex != colReleaseTo.Index &&
                e.ColumnIndex != colDestination.Index &&
                e.ColumnIndex != colStrategic.Index) ||
                e.RowIndex < 0 ||
                e.RowIndex >= dgvEquipment.Rows.Count)
            {
                return;
            }

            DataGridViewRow row = dgvEquipment.Rows[e.RowIndex];
            RailLocation location = row.Tag as RailLocation;
            if (!modifiedRailLocationsByID.ContainsKey(location.RailLocationID))
            {
                modifiedRailLocationsByID[location.RailLocationID] = new ModifiedRailLocationData(location);
            }

            ModifiedRailLocationData modifiedData = modifiedRailLocationsByID[location.RailLocationID];
            modifiedData.ReleasedToIDCompanyNew = row.Cells[colReleaseTo.Name].Value.Cast<DropDownItem<Company>>()?.Object?.CompanyID;
            modifiedData.ReleasedToIDGovernmentNew = row.Cells[colReleaseTo.Name].Value.Cast<DropDownItem<Government>>()?.Object?.GovernmentID;
            modifiedData.TrackIDDestinationNew = row.Cells[colDestination.Name].Value.Cast<DropDownItem<Track>>()?.Object.TrackID;
            modifiedData.TrackIDStrategicNew = row.Cells[colStrategic.Name].Value.Cast<DropDownItem<Track>>()?.Object.TrackID;
        }

        private class ModifiedRailLocationData
        {
            public ModifiedRailLocationData(RailLocation railLocation)
            {
                RailLocation = railLocation;
            }
            public RailLocation RailLocation { get; set; }
            public long? ReleasedToIDCompanyNew { get; set; }
            public long? ReleasedToIDGovernmentNew { get; set; }
            public long? TrackIDDestinationNew { get; set; }
            public long? TrackIDStrategicNew { get; set; }
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            if (!modifiedRailLocationsByID.Any())
            {
                ParentForm?.Close();
                Dispose();
                return;
            }

            PatchData patch = _application.GetAccess<PatchData>();
            patch.API = DataAccess.APIs.FleetTracking;
            patch.PatchMethod = PatchData.PatchMethods.Replace;

            foreach(ModifiedRailLocationData modifiedData in modifiedRailLocationsByID.Values)
            {
                if (modifiedData.ReleasedToIDCompanyNew == null &&
                    modifiedData.ReleasedToIDGovernmentNew == null &&
                    modifiedData.TrackIDDestinationNew == null &&
                    modifiedData.TrackIDStrategicNew == null)
                {
                    continue;
                }

                if (modifiedData.RailLocation.RailcarID != null)
                {
                    patch.Resource = "Railcar/Patch";
                    patch.PrimaryKey = modifiedData.RailLocation.RailcarID;
                    patch.Values = new Dictionary<string, object>();
                    if (modifiedData.ReleasedToIDGovernmentNew != null || modifiedData.ReleasedToIDCompanyNew != null)
                    {
                        patch.Values.Add(nameof(Railcar.CompanyIDPossessor), modifiedData.ReleasedToIDCompanyNew);
                        patch.Values.Add(nameof(Railcar.GovernmentIDPossessor), modifiedData.ReleasedToIDGovernmentNew);
                    }

                    if (modifiedData.TrackIDDestinationNew != null)
                    {
                        patch.Values.Add(nameof(Railcar.TrackIDDestination), modifiedData.TrackIDDestinationNew);
                    }

                    if (modifiedData.TrackIDStrategicNew != null)
                    {
                        patch.Values.Add(nameof(Railcar.TrackIDStrategic), modifiedData.TrackIDStrategicNew);
                    }
                    await patch.Execute();
                }
                else if (modifiedData.RailLocation.LocomotiveID != null)
                {
                    patch.Resource = "Locomotive/Patch";
                    patch.PrimaryKey = modifiedData.RailLocation.LocomotiveID;
                    patch.Values = new Dictionary<string, object>();
                    if (modifiedData.ReleasedToIDGovernmentNew != null || modifiedData.ReleasedToIDCompanyNew != null)
                    {
                        patch.Values.Add(nameof(Locomotive.CompanyIDPossessor), modifiedData.ReleasedToIDCompanyNew);
                        patch.Values.Add(nameof(Locomotive.GovernmentIDPossessor), modifiedData.ReleasedToIDGovernmentNew);
                    }

                    await patch.Execute();
                }
            }

            ParentForm?.Close();
            Dispose();
            return;
        }
    }
}
