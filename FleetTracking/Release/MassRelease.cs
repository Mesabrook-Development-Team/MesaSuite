using FleetTracking.Interop;
using FleetTracking.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using MesaSuite.Common.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FleetTracking.Release
{
    public partial class MassRelease : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        private List<Company> _companies;
        private List<Government> _governments;
        private List<Railcar> _modifiedRailcars = new List<Railcar>();
        private List<Locomotive> _modifiedLocomotives = new List<Locomotive>();

        public MassRelease()
        {
            InitializeComponent();
            dataGridViewStylizer.ApplyStyle(dgvRailLocations);
            dgvRailLocations.ReadOnly = false;
        }


        private async void MassRelease_Load(object sender, EventArgs e)
        {
            try
            {
                loader.BringToFront();
                loader.Visible = true;

                colNewPossessor.ValueType = typeof(object);
                colNewPossessor.ValueMember = "Object";
                colNewPossessor.DisplayMember = nameof(DropDownItem.Text);

                ParentForm.Text = string.IsNullOrEmpty(Text) ? "Mass Release" : Text;

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = "Company/GetAll";
                _companies = await get.GetObject<List<Company>>() ?? new List<Company>();

                get.Resource = "Government/GetAll";
                _governments = await get.GetObject<List<Government>>() ?? new List<Government>();

                get.Resource = "Track/GetAll";
                List<Track> tracks = await get.GetObject<List<Track>>() ?? new List<Track>();
                foreach(Track track in tracks)
                {
                    DropDownItem<Track> trackDDI = new DropDownItem<Track>(track, track.Name);
                    cboTrackTrain.Items.Add(trackDDI);
                }

                get.Resource = "Train/GetAll";
                List<Models.Train> trains = await get.GetObject<List<Models.Train>>() ?? new List<Models.Train>();
                foreach(Models.Train train in trains)
                {
                    string onDutyTime = train.TrainDutyTransactions.OrderBy(tdt => tdt.TimeOnDuty).FirstOrDefault()?.TimeOnDuty?.ToString("MM/dd/yyyy HH:mm") ?? "--/--/---- --:--";

                    DropDownItem<Models.Train> trainDDI = new DropDownItem<Models.Train>(train, $"{onDutyTime}: {train.TrainSymbol?.Name}");
                    cboTrackTrain.Items.Add(trainDDI);
                }
            }
            finally
            {
                loader.Visible = false;
            }
        }

        private async void cboTrackTrain_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                loader.BringToFront();
                loader.Visible = true;

                DropDownItem<Track> trackItem = cboTrackTrain.SelectedItem.Cast<DropDownItem<Track>>();
                DropDownItem<Models.Train> trainItem = cboTrackTrain.SelectedItem.Cast<DropDownItem<Models.Train>>();

                dgvRailLocations.Rows.Clear();

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;

                if (trackItem != null)
                {
                    get.Resource = $"RailLocation/GetByTrack/{trackItem.Object.TrackID}";
                }
                else if (trainItem != null)
                {
                    get.Resource = $"RailLocation/GetByTrain/{trainItem.Object.TrainID}";
                }

                List<RailLocation> railLocations = await get.GetObject<List<RailLocation>>() ?? new List<RailLocation>();
                railLocations = railLocations.OrderBy(rl => rl.Position).ToList();

                foreach(RailLocation railLocation in railLocations)
                {
                    int rowIndex = dgvRailLocations.Rows.Add();
                    DataGridViewRow row = dgvRailLocations.Rows[rowIndex];

                    Railcar modifiedRailcar = null;
                    Locomotive modifiedLocomotive = null;

                    if (railLocation.RailcarID != null)
                    {
                        modifiedRailcar = _modifiedRailcars.FirstOrDefault(r => r.RailcarID == railLocation.RailcarID);
                        row.Cells[colReportingMark.Name].Value = railLocation.Railcar?.FormattedReportingMark;
                        row.Cells[colCurrentPossessor.Name].Value = railLocation.Railcar?.CompanyPossessor?.Name ?? railLocation.Railcar?.GovernmentPossessor?.Name;
                    }
                    else if (railLocation.LocomotiveID != null)
                    {
                        modifiedLocomotive = _modifiedLocomotives.FirstOrDefault(l => l.LocomotiveID == railLocation.LocomotiveID);
                        row.Cells[colReportingMark.Name].Value = railLocation.Locomotive?.FormattedReportingMark;
                        row.Cells[colCurrentPossessor.Name].Value = railLocation.Locomotive?.CompanyPossessor?.Name ?? railLocation.Locomotive?.GovernmentPossessor?.Name;
                    }

                    row.Cells[colPosition.Name].Value = railLocation.Position.ToString();
                    row.Tag = railLocation;

                    DataGridViewComboBoxCell releaseToCell = row.Cells[colNewPossessor.Name].Cast<DataGridViewComboBoxCell>();
                    releaseToCell.Items.Add(new DropDownItem<object>(null, "[No Change]"));
                    if (!_application.IsCurrentEntity(railLocation.Railcar?.CompanyIDPossessor ?? railLocation.Locomotive?.CompanyIDPossessor, railLocation.Railcar?.GovernmentIDPossessor ?? railLocation.Locomotive?.GovernmentIDPossessor))
                    {
                        releaseToCell.ReadOnly = true;
                    }
                    
                    foreach(Company company in _companies)
                    {
                        DropDownItem<Company> companyDDI = new DropDownItem<Company>(company, company.Name);
                        releaseToCell.Items.Add(companyDDI);

                        if (modifiedRailcar?.CompanyIDPossessor == company.CompanyID || modifiedLocomotive?.CompanyIDPossessor == company.CompanyID)
                        {
                            releaseToCell.Value = companyDDI;
                        }
                    }

                    foreach (Government government in _governments)
                    {
                        DropDownItem<Government> governmentDDI = new DropDownItem<Government>(government, government.Name);
                        releaseToCell.Items.Add(governmentDDI);

                        if (modifiedRailcar?.GovernmentIDPossessor == government.GovernmentID || modifiedLocomotive?.GovernmentIDPossessor == government.GovernmentID)
                        {
                            releaseToCell.Value = governmentDDI;
                        }
                    }
                }
            }
            finally
            {
                loader.Visible = false;
            }

            try
            {
                foreach(DataGridViewRow row in dgvRailLocations.Rows)
                {
                    RailLocation location = row.Tag as RailLocation;
                    if (location == null)
                    {
                        continue;
                    }

                    GetData get = _application.GetAccess<GetData>();
                    get.API = DataAccess.APIs.FleetTracking;
                    if (location.RailcarID != null)
                    {
                        get.Resource = $"Railcar/GetImage/{location.RailcarID}";
                    }
                    else if (location.LocomotiveID != null)
                    {
                        get.Resource = $"Locomotive/GetImage/{location.LocomotiveID}";
                    }
                    else
                    {
                        continue;
                    }

                    byte[] imageData = await get.GetObject<byte[]>();
                    if (imageData != null)
                    {
                        using (MemoryStream stream = new MemoryStream(imageData))
                        {
                            Image image = Image.FromStream(stream);
                            row.Cells[colImage.Name].Value = image;
                        }
                    }
                }
            }
            catch { }
        }

        private async void dgvRailLocations_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                loader.BringToFront();
                loader.Visible = true;

                if (e.ColumnIndex != colNewPossessor.Index || e.RowIndex < 0 || e.RowIndex >= dgvRailLocations.Rows.Count)
                {
                    return;
                }

                RailLocation location = dgvRailLocations.Rows[e.RowIndex].Tag as RailLocation;
                if (location == null)
                {
                    return;
                }

                DataGridViewComboBoxCell newPossessorCell = dgvRailLocations[e.ColumnIndex, e.RowIndex].Cast<DataGridViewComboBoxCell>();
                if (newPossessorCell == null)
                {
                    return;
                }

                Company newCompany = newPossessorCell.Value.Cast<Company>();
                Government newGovernment = newPossessorCell.Value.Cast<Government>();

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;

                if (location.RailcarID != null)
                {
                    Railcar modifiedRailcar = _modifiedRailcars.FirstOrDefault(r => r.RailcarID == location.RailcarID);
                    if (modifiedRailcar == null)
                    {
                        get.Resource = $"Railcar/Get/{location.RailcarID}";
                        modifiedRailcar = await get.GetObject<Railcar>();
                        _modifiedRailcars.Add(modifiedRailcar);
                    }

                    if (newCompany == null && newGovernment == null)
                    {
                        _modifiedRailcars.Remove(modifiedRailcar);
                    }
                    else
                    {
                        modifiedRailcar.CompanyIDPossessor = newCompany?.CompanyID;
                        modifiedRailcar.GovernmentIDPossessor = newGovernment?.GovernmentID;
                    }
                }
                else if (location.LocomotiveID != null)
                {
                    Locomotive modifiedLocomotive = _modifiedLocomotives.FirstOrDefault(l => l.LocomotiveID == location.LocomotiveID);
                    if (modifiedLocomotive == null)
                    {
                        get.Resource = $"Locomotive/Get/{location.LocomotiveID}";
                        modifiedLocomotive = await get.GetObject<Locomotive>();
                        _modifiedLocomotives.Add(modifiedLocomotive);
                    }

                    if (newCompany == null && newGovernment == null)
                    {
                        _modifiedLocomotives.Remove(modifiedLocomotive);
                    }
                    else
                    {
                        modifiedLocomotive.CompanyIDPossessor = newCompany?.CompanyID;
                        modifiedLocomotive.GovernmentIDPossessor = newGovernment?.GovernmentID;
                    }
                }
            }
            finally
            {
                loader.Visible = false;
            }
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                foreach(Locomotive modifiedLocomotive in _modifiedLocomotives)
                {
                    PatchData patch = _application.GetAccess<PatchData>();
                    patch.API = DataAccess.APIs.FleetTracking;
                    patch.Resource = "Locomotive/Patch";
                    patch.PrimaryKey = modifiedLocomotive.LocomotiveID;
                    patch.Values = new Dictionary<string, object>()
                    {
                        { nameof(Locomotive.CompanyIDPossessor), modifiedLocomotive.CompanyIDPossessor },
                        { nameof(Locomotive.GovernmentIDPossessor), modifiedLocomotive.GovernmentIDPossessor }
                    };
                    await patch.Execute();
                }

                foreach (Railcar modifiedRailcar in _modifiedRailcars)
                {
                    PatchData patch = _application.GetAccess<PatchData>();
                    patch.API = DataAccess.APIs.FleetTracking;
                    patch.Resource = "Railcar/Patch";
                    patch.PrimaryKey = modifiedRailcar.RailcarID;
                    patch.Values = new Dictionary<string, object>()
                    {
                        { nameof(Railcar.CompanyIDPossessor), modifiedRailcar.CompanyIDPossessor },
                        { nameof(Railcar.GovernmentIDPossessor), modifiedRailcar.GovernmentIDPossessor }
                    };
                    await patch.Execute();
                }

                ParentForm.Close();
            }
            finally
            {
                loader.Visible = false;
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            ParentForm.Close();
        }
    }
}
