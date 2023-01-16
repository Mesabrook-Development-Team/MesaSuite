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
using FleetTracking.Interop;
using FleetTracking.Models;
using MesaSuite.Common.Collections;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using MesaSuite.Common.Utility;

namespace FleetTracking.Train
{
    public partial class RailLocationModifier : UserControl, IFleetTrackingControl
    {
        public RailLocationModifier()
        {
            InitializeComponent();
            dataGridViewStylizer.ApplyStyle(dgvFromList);
            dataGridViewStylizer.ApplyStyle(dgvToList);
            dgvFromList.MultiSelect = true;
            dgvToList.MultiSelect = true;
        }

        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public long? SelectedTrainID { get; set; }
        public long? SelectedTrackID { get; set; }

        private Dictionary<long?, List<RailLocation>> _modifiedTracksByID = new Dictionary<long?, List<RailLocation>>();
        private Dictionary<long?, List<RailLocation>> _modifiedTrainsByID = new Dictionary<long?, List<RailLocation>>();

        private List<Track> _allTracks = new List<Track>();
        private List<Models.Train> _allTrains = new List<Models.Train>();

        private List<RailLocation> _currentFromRailLocations = new List<RailLocation>();
        private List<RailLocation> _currentToRailLocations = new List<RailLocation>();

        private DataGridView lastClickedGrid = null;

        private int _formLoadingRequests = 0;

        private void loader_VisibleChanged(object sender, EventArgs e)
        {
            cmdMoveUp.Enabled = !loaderFull.Visible && !loaderFrom.Visible && !loaderTo.Visible;
            cmdAdd.Enabled = !loaderFull.Visible && !loaderFrom.Visible && !loaderTo.Visible;
            cmdRemove.Enabled = !loaderFull.Visible && !loaderFrom.Visible && !loaderTo.Visible;
            cmdMoveDown.Enabled = !loaderFull.Visible && !loaderFrom.Visible && !loaderTo.Visible;
        }

        private async void RailLocationModifier_Load(object sender, EventArgs e)
        {
            try
            {
                ParentForm.Text = string.IsNullOrEmpty(Text) ? "Modify Rail Locations" : Text;

                loaderFull.BringToFront();
                loaderFull.Visible = true;

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = "RailDistrict/GetAll";
                List<RailDistrict> railDistricts = await get.GetObject<List<RailDistrict>>() ?? new List<RailDistrict>();

                _formLoadingRequests++;
                DropDownItem<RailDistrict> allItem = new DropDownItem<RailDistrict>(null, "All Districts");
                cboFromDistrict.Items.Add(allItem);
                cboFromDistrict.SelectedItem = allItem;

                _formLoadingRequests++;
                allItem = allItem.CreateCopy();
                cboToDistrict.Items.Add(allItem);
                cboToDistrict.SelectedItem = allItem;

                foreach(RailDistrict rd in railDistricts)
                {
                    DropDownItem<RailDistrict> dropDownItem = new DropDownItem<RailDistrict>(rd, rd.Name);
                    cboFromDistrict.Items.Add(dropDownItem);
                    cboToDistrict.Items.Add(dropDownItem.CreateCopy());
                }

                get.Resource = "Track/GetAll";
                _allTracks = await get.GetObject<List<Track>>() ?? new List<Track>();
                _allTracks = _allTracks.OrderBy(t => t.Name).ToList();

                foreach(Track track in _allTracks)
                {
                    DropDownItem<Track> ddiTrack = new DropDownItem<Track>(track, track.Name);
                    cboFromTrack.Items.Add(ddiTrack);

                    ddiTrack = ddiTrack.CreateCopy();
                    cboToTrack.Items.Add(ddiTrack);

                    if (SelectedTrackID == track.TrackID)
                    {
                        tabControlTo.SelectedTab = tabTrackTo;
                        cboToTrack.SelectedItem = ddiTrack;
                    }
                }

                get.Resource = "TrainSymbol/GetAll";
                List<TrainSymbol> symbols = await get.GetObject<List<TrainSymbol>>() ?? new List<TrainSymbol>();

                _formLoadingRequests++;
                DropDownItem<TrainSymbol> allSymbols = new DropDownItem<TrainSymbol>(null, "All Symbols");
                cboFromSymbol.Items.Add(allSymbols);
                cboFromSymbol.SelectedItem = allSymbols;

                _formLoadingRequests++;
                allSymbols = allSymbols.CreateCopy();
                cboToSymbol.Items.Add(allSymbols);
                cboToSymbol.SelectedItem = allSymbols;

                foreach(TrainSymbol symbol in symbols)
                {
                    DropDownItem<TrainSymbol> symbolItem = new DropDownItem<TrainSymbol>(symbol, symbol.Name);
                    cboFromSymbol.Items.Add(symbolItem);
                    cboToSymbol.Items.Add(symbolItem.CreateCopy());
                }

                get.Resource = "Train/GetFiltered";
                get.QueryString = new MultiMap<string, string>()
                {
                    { "status", "all" },
                    { "operableonly", "false" }
                };

                var responseObject = new
                {
                    maxItems = 0,
                    trains = new List<Models.Train>()
                };

                responseObject = await get.GetAnonymousObject(responseObject);
                _allTrains = responseObject.trains.OrderByDescending(t => t.TrainDutyTransactions?.OrderBy(tdt => tdt.TimeOnDuty).FirstOrDefault()?.TimeOnDuty).ToList();

                foreach(Models.Train train in _allTrains)
                {
                    DropDownItem<Models.Train> trainItem = new DropDownItem<Models.Train>(train, GetTrainDisplay(train));
                    cboFromTrain.Items.Add(trainItem);

                    trainItem = trainItem.CreateCopy();
                    cboToTrain.Items.Add(trainItem);

                    if (train.TrainID == SelectedTrainID)
                    {
                        tabControlTo.SelectedTab = tabTrainTo;
                        cboToTrain.SelectedItem = trainItem;
                    }
                }
            }
            finally
            {
                loaderFull.Visible = false;
            }
        }

        private string GetTrainDisplay(Models.Train train)
        {
            string earliestDateTime;
            TrainDutyTransaction earliestTransaction = train.TrainDutyTransactions?.OrderBy(tdt => tdt.TimeOnDuty).FirstOrDefault();
            if (earliestTransaction?.TimeOnDuty == null)
            {
                earliestDateTime = "--/--/---- --:--:";
            }
            else
            {
                earliestDateTime = earliestTransaction.TimeOnDuty.Value.ToString("MM/dd/yyyy HH:mm");
            }

            return $"{earliestDateTime}: {train.TrainSymbol?.Name}";
        }

        private void FromCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (sender == cboFromTrack)
            {
                LoadTrackFrom();
            }
            else if (sender == cboFromTrain)
            {
                LoadTrainFrom();
            }
        }

        private async void LoadTrackFrom(bool skipReloadTo = false)
        {
            if (_formLoadingRequests <= 0 || _formLoadingRequests-- <= 0)
            {
                dgvFromList.Rows.Clear();
            }

            DropDownItem<Track> trackDDI = cboFromTrack.SelectedItem as DropDownItem<Track>;
            if (trackDDI == null)
            {
                return;
            }

            try
            {
                loaderFrom.BringToFront();
                loaderFrom.Visible = true;

                List<long?> selectedRailLocationIDs = dgvFromList.SelectedRows.Cast<DataGridViewRow>().Select(r => r.Tag).OfType<RailLocation>().Select(rl => rl.RailLocationID).ToList();

                if (!_modifiedTracksByID.ContainsKey(trackDDI.Object.TrackID))
                {
                    GetData get = _application.GetAccess<GetData>();
                    get.API = DataAccess.APIs.FleetTracking;
                    get.Resource = $"RailLocation/GetByTrack/{trackDDI.Object.TrackID}";
                    _currentFromRailLocations = await get.GetObject<List<RailLocation>>() ?? new List<RailLocation>();
                }
                else
                {
                    _currentFromRailLocations = _modifiedTracksByID[trackDDI.Object.TrackID];
                }

                PopulateView(true, selectedRailLocationIDs);
            }
            finally
            {
                loaderFrom.Visible = false;
            }

            PopulateViewImages(true);

            if (!skipReloadTo &&
                tabControlTo.SelectedTab == tabTrackTo &&
                cboToTrack.SelectedItem is DropDownItem<Track> toTrack &&
                toTrack.Object.TrackID == trackDDI.Object.TrackID)
            {
                LoadTrackTo(true);
            }
        }

        /// <summary>
        /// DO NOT CALL DIRECTLY
        /// </summary>
        /// <param name="isFromView"></param>
        private void PopulateView(bool isFromView, List<long?> selectedRailLocationIDs = null)
        {
            if (selectedRailLocationIDs == null)
            {
                selectedRailLocationIDs = new List<long?>();
            }

            DataGridView dgv = isFromView ? dgvFromList : dgvToList;
            DataGridViewColumn colImage = isFromView ? colFromImage : colToImage;
            DataGridViewColumn colReportingMark = isFromView ? colFromReportingMark : colToReportingMark;
            DataGridViewColumn colType = isFromView ? colFromType : colToType;
            DataGridViewColumn colPossesedBy = isFromView ? colFromPossession : colToPossession;
            DataGridViewColumn colPos = isFromView ? colFromPos : colToPos;
            DataGridViewColumn colDestination = isFromView ? colFromDestination : colToDestination;
            DataGridViewColumn colStrategic = isFromView ? colFromStrategic : colToStrategic;
            List<RailLocation> railLocations = isFromView ? _currentFromRailLocations : _currentToRailLocations;
            railLocations = railLocations.OrderBy(rl => rl.Position).ToList();

            foreach(RailLocation railLocation in railLocations)
            {
                int rowIndex = dgv.Rows.Add();
                DataGridViewRow row = dgv.Rows[rowIndex];

                row.Cells[colReportingMark.Name].Value = railLocation.LocomotiveID != null ? railLocation.Locomotive?.FormattedReportingMark : railLocation.Railcar?.FormattedReportingMark;
                row.Cells[colType.Name].Value = railLocation.LocomotiveID != null ? railLocation.Locomotive?.LocomotiveModel?.Name : railLocation.Railcar?.RailcarModel?.Name;
                row.Cells[colPossesedBy.Name].Value = railLocation.LocomotiveID != null ? (railLocation.Locomotive?.CompanyPossessor?.Name ?? railLocation.Locomotive?.GovernmentPossessor?.Name) : (railLocation.Railcar?.CompanyPossessor?.Name ?? railLocation.Railcar?.GovernmentPossessor?.Name);
                row.Cells[colPos.Name].Value = railLocation.Position.ToString();
                row.Cells[colDestination.Name].Value = railLocation.Railcar?.TrackDestination?.Name;
                row.Cells[colStrategic.Name].Value = railLocation.Railcar?.TrackStrategic?.Name;
                row.Tag = railLocation;
            }

            foreach(DataGridViewRow row in dgv.Rows)
            {
                RailLocation railLocation = row.Tag as RailLocation;
                row.Selected = railLocation != null && selectedRailLocationIDs.Contains(railLocation.RailLocationID);
            }
        }

        /// <summary>
        /// DO NOT CALL DIRECTLY
        /// </summary>
        /// <param name="isFromView"></param>
        private async void PopulateViewImages(bool isFromView)
        {
            try
            {
                DataGridView dgv = isFromView ? dgvFromList : dgvToList;
                DataGridViewColumn imageColumn = isFromView ? colFromImage : colToImage;

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    RailLocation railLocation = row.Tag as RailLocation;
                    if (railLocation == null)
                    {
                        continue;
                    }

                    byte[] imageData = null;
                    if (railLocation.LocomotiveID != null)
                    {
                        get.Resource = $"Locomotive/GetImage/{railLocation.LocomotiveID}";
                        imageData = await get.GetObject<byte[]>();
                    }
                    else if (railLocation.RailcarID != null)
                    {
                        get.Resource = $"Railcar/GetImage/{railLocation.RailcarID}";
                        imageData = await get.GetObject<byte[]>();
                    }

                    if (imageData == null)
                    {
                        continue;
                    }

                    using (MemoryStream memStream = new MemoryStream(imageData))
                    {
                        Image image = Image.FromStream(memStream);
                        row.Cells[imageColumn.Name].Value = image;
                    }
                }
            }
            catch { }
        }

        private async void LoadTrainFrom(bool skipReloadTo = false)
        {
            if (_formLoadingRequests <= 0 || _formLoadingRequests-- <= 0)
            {
                dgvFromList.Rows.Clear();
            }

            DropDownItem<Models.Train> trainDDI = cboFromTrain.SelectedItem as DropDownItem<Models.Train>;
            if (trainDDI == null)
            {
                return;
            }

            try
            {
                loaderFrom.BringToFront();
                loaderFrom.Visible = true;

                List<long?> selectedRailLocationIDs = dgvFromList.SelectedRows.Cast<DataGridViewRow>().Select(r => r.Tag).OfType<RailLocation>().Select(rl => rl.RailLocationID).ToList();

                if (!_modifiedTrainsByID.ContainsKey(trainDDI.Object.TrainID))
                {
                    GetData get = _application.GetAccess<GetData>();
                    get.API = DataAccess.APIs.FleetTracking;
                    get.Resource = $"RailLocation/GetByTrain/{trainDDI.Object.TrainID}";
                    _currentFromRailLocations = await get.GetObject<List<RailLocation>>() ?? new List<RailLocation>();
                }
                else
                {
                    _currentFromRailLocations = _modifiedTrainsByID[trainDDI.Object.TrainID];
                }

                PopulateView(true, selectedRailLocationIDs);
            }
            finally
            {
                loaderFrom.Visible = false;
            }

            PopulateViewImages(true);

            if (!skipReloadTo &&
                tabControlTo.SelectedTab == tabTrainTo &&
                cboToTrain.SelectedItem is DropDownItem<Models.Train> toTrain &&
                toTrain.Object.TrainID == trainDDI.Object.TrainID)
            {
                LoadTrainTo(true);
            }
        }

        private void cboDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox districtBox;
            ComboBox trackBox;

            if (sender == cboFromDistrict)
            {
                districtBox = cboFromDistrict;
                trackBox = cboFromTrack;
            }
            else if (sender == cboToDistrict)
            {
                districtBox = cboToDistrict;
                trackBox = cboToTrack;
            }
            else
            {
                return;
            }

            DropDownItem<RailDistrict> selectedDistrict = districtBox.SelectedItem as DropDownItem<RailDistrict>;
            if (selectedDistrict == null)
            {
                return;
            }

            DropDownItem<Track> currentTrack = trackBox.SelectedItem as DropDownItem<Track>;
            trackBox.Items.Clear();
            trackBox.Text = null;

            bool doViewRefresh = true;
            foreach(Track track in _allTracks.Where(t => selectedDistrict.Object == null || t.RailDistrictID == selectedDistrict.Object.RailDistrictID))
            {
                DropDownItem<Track> trackDDI = new DropDownItem<Track>(track, track.Name);
                trackBox.Items.Add(trackDDI);
                if (track.TrackID == currentTrack?.Object?.TrackID)
                {
                    trackBox.SelectedItem = trackDDI;
                    doViewRefresh = false;
                }
            }

            if (doViewRefresh)
            {
                if (districtBox == cboFromDistrict)
                {
                    LoadTrackFrom();
                }
                else
                {
                    LoadTrackTo();
                }
            }
        }

        private void cboSymbol_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox symbolBox;
            ComboBox trainBox;

            if (sender == cboFromSymbol)
            {
                symbolBox = cboFromSymbol;
                trainBox = cboFromTrain;
            }
            else if (sender == cboToSymbol)
            {
                symbolBox = cboToSymbol;
                trainBox = cboToTrain;
            }
            else
            {
                return;
            }

            DropDownItem<TrainSymbol> selectedSymbol = symbolBox.SelectedItem as DropDownItem<TrainSymbol>;
            if (selectedSymbol == null)
            {
                return;
            }

            DropDownItem<Models.Train> currentTrain = trainBox.SelectedItem as DropDownItem<Models.Train>;
            trainBox.Items.Clear();
            trainBox.Text = null;

            bool doViewRefresh = true;
            foreach(Models.Train train in _allTrains.Where(t => selectedSymbol.Object == null || t.TrainSymbolID == selectedSymbol.Object.TrainSymbolID))
            {
                DropDownItem<Models.Train> trainDDI = new DropDownItem<Models.Train>(train, GetTrainDisplay(train));
                trainBox.Items.Add(trainDDI);

                if (train.TrainID == currentTrain?.Object?.TrainID)
                {
                    trainBox.SelectedItem = trainDDI;
                    doViewRefresh = false;
                }
            }

            if (doViewRefresh)
            {
                if (symbolBox == cboFromSymbol)
                {
                    LoadTrainFrom();
                }
                else
                {
                    LoadTrainTo();
                }
            }
        }

        private async void LoadTrackTo(bool skipReloadFrom = false)
        {
            if (_formLoadingRequests <= 0 || _formLoadingRequests-- <= 0)
            {
                dgvToList.Rows.Clear();
            }

            DropDownItem<Track> trackDDI = cboToTrack.SelectedItem as DropDownItem<Track>;
            if (trackDDI == null)
            {
                return;
            }

            try
            {
                loaderTo.BringToFront();
                loaderTo.Visible = true;

                List<long?> selectedRailLocationIDs = dgvToList.SelectedRows.Cast<DataGridViewRow>().Select(r => r.Tag).OfType<RailLocation>().Select(rl => rl.RailLocationID).ToList();

                if (!_modifiedTracksByID.ContainsKey(trackDDI.Object.TrackID))
                {
                    GetData get = _application.GetAccess<GetData>();
                    get.API = DataAccess.APIs.FleetTracking;
                    get.Resource = $"RailLocation/GetByTrack/{trackDDI.Object.TrackID}";
                    _currentToRailLocations = await get.GetObject<List<RailLocation>>() ?? new List<RailLocation>();
                }
                else
                {
                    _currentToRailLocations = _modifiedTracksByID[trackDDI.Object.TrackID];
                }

                PopulateView(false, selectedRailLocationIDs);
            }
            finally
            {
                loaderTo.Visible = false;
            }

            PopulateViewImages(false);

            if (!skipReloadFrom &&
                tabControlFrom.SelectedTab == tabTrackFrom && 
                cboFromTrack.SelectedItem is DropDownItem<Track> fromTrack && 
                fromTrack.Object.TrackID == trackDDI.Object.TrackID)
            {
                LoadTrackFrom(true);
            }
        }

        private async void LoadTrainTo(bool skipReloadFrom = false)
        {
            if (_formLoadingRequests <= 0 || _formLoadingRequests-- <= 0)
            {
                dgvToList.Rows.Clear();
            }

            DropDownItem<Models.Train> trainDDI = cboToTrain.SelectedItem as DropDownItem<Models.Train>;
            if (trainDDI == null)
            {
                return;
            }

            try
            {
                loaderTo.BringToFront();
                loaderTo.Visible = true;

                List<long?> selectedRailLocationIDs = dgvToList.SelectedRows.Cast<DataGridViewRow>().Select(r => r.Tag).OfType<RailLocation>().Select(rl => rl.RailLocationID).ToList();

                if (!_modifiedTrainsByID.ContainsKey(trainDDI.Object.TrainID))
                {
                    GetData get = _application.GetAccess<GetData>();
                    get.API = DataAccess.APIs.FleetTracking;
                    get.Resource = $"RailLocation/GetByTrain/{trainDDI.Object.TrainID}";
                    _currentToRailLocations = await get.GetObject<List<RailLocation>>() ?? new List<RailLocation>();
                }
                else
                {
                    _currentToRailLocations = _modifiedTrainsByID[trainDDI.Object.TrainID];
                }

                PopulateView(false, selectedRailLocationIDs);
            }
            finally
            {
                loaderTo.Visible = false;
            }

            PopulateViewImages(false);

            if (!skipReloadFrom &&
                tabControlFrom.SelectedTab == tabTrainFrom &&
                cboFromTrain.SelectedItem is DropDownItem<Models.Train> fromTrain &&
                fromTrain.Object.TrainID == trainDDI.Object.TrainID)
            {
                LoadTrainFrom(true);
            }
        }

        private void ToCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender == cboToTrack)
            {
                LoadTrackTo();
            }
            else if (sender == cboToTrain)
            {
                LoadTrainTo();
            }
        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lastClickedGrid = (DataGridView)sender;
        }

        private void cmdMoveUp_Click(object sender, EventArgs e)
        {
            List<RailLocation> allRailLocations;
            List<RailLocation> selectedRailLocations;
            Action refresh;
            if (lastClickedGrid == dgvFromList)
            {
                PrepFromMovement(out allRailLocations, out selectedRailLocations, out refresh);
            }
            else if (lastClickedGrid == dgvToList)
            {
                PrepToMovement(out allRailLocations, out selectedRailLocations, out refresh);
            }
            else
            {
                return;
            }

            if (allRailLocations == null)
            {
                return;
            }

            if (!CheckForUnreleasedCars(selectedRailLocations))
            {
                return;
            }

            foreach (RailLocation railLocationToMove in selectedRailLocations.OrderBy(rl => rl.Position))
            {
                if (railLocationToMove.Position == 1)
                {
                    continue;
                }

                RailLocation precedingLocation = allRailLocations.First(rl => rl.Position == railLocationToMove.Position - 1);
                precedingLocation.Position++;
                railLocationToMove.Position--;
            }

            refresh?.Invoke();
        }

        private bool CheckForUnreleasedCars(List<RailLocation> railLocations)
        {
            StringBuilder unpossessedStock = new StringBuilder();
            foreach (RailLocation unpossessed in railLocations.Where(rl => (rl.RailcarID != null && !_application.IsCurrentEntity(rl.Railcar.CompanyIDPossessor, rl.Railcar.GovernmentIDPossessor)) || (rl.LocomotiveID != null && !_application.IsCurrentEntity(rl.Locomotive.CompanyIDPossessor, rl.Locomotive.GovernmentIDPossessor))))
            {
                unpossessedStock.AppendLine(string.Format("{0} is currently released to {1}", unpossessed.Railcar?.FormattedReportingMark ?? unpossessed.Locomotive?.FormattedReportingMark, unpossessed.Railcar?.CompanyPossessor?.Name ?? unpossessed.Railcar?.GovernmentPossessor?.Name ?? unpossessed.Locomotive?.CompanyPossessor?.Name ?? unpossessed.Locomotive?.GovernmentPossessor?.Name));
            }

            if (unpossessedStock.Length > 0)
            {
                this.ShowError("The action cannot be completed. The following stock are not released to your company:\r\n\r\n" + unpossessedStock.ToString() + "\r\n\r\nTo move this stock, you will need to first have them released to your company.");
                return false;
            }

            return true;
        }

        private void PrepFromMovement(out List<RailLocation> allRailLocations, out List<RailLocation> selectedRailLocations, out Action refreshAction)
        {
            refreshAction = () => { if (tabControlFrom.SelectedTab == tabTrackFrom) LoadTrackFrom(); else LoadTrainFrom(); };
            allRailLocations = null;
            selectedRailLocations = null;

            if (tabControlFrom.SelectedTab == tabTrainFrom)
            {
                DropDownItem<Models.Train> selectedTrain = cboFromTrain.SelectedItem as DropDownItem<Models.Train>;
                if (selectedTrain == null)
                {
                    return;
                }

                if (!_modifiedTrainsByID.ContainsKey(selectedTrain.Object.TrainID))
                {
                    _modifiedTrainsByID[selectedTrain.Object.TrainID] = new List<RailLocation>();

                    foreach (DataGridViewRow row in dgvFromList.Rows)
                    {
                        RailLocation location = row.Tag as RailLocation;
                        if (location == null)
                        {
                            continue;
                        }

                        _modifiedTrainsByID[selectedTrain.Object.TrainID].Add(location);
                    }
                }

                allRailLocations = _modifiedTrainsByID[selectedTrain.Object.TrainID];
            }
            else if (tabControlFrom.SelectedTab == tabTrackFrom)
            {
                DropDownItem<Track> selectedTrack = cboFromTrack.SelectedItem as DropDownItem<Track>;
                if (selectedTrack == null)
                {
                    return;
                }

                if (!_modifiedTracksByID.ContainsKey(selectedTrack.Object.TrackID))
                {
                    _modifiedTracksByID[selectedTrack.Object.TrackID] = new List<RailLocation>();

                    foreach (DataGridViewRow row in dgvFromList.Rows)
                    {
                        RailLocation location = row.Tag as RailLocation;
                        if (location == null)
                        {
                            continue;
                        }

                        _modifiedTracksByID[selectedTrack.Object.TrackID].Add(location);
                    }
                }

                allRailLocations = _modifiedTracksByID[selectedTrack.Object.TrackID];
            }

            selectedRailLocations = dgvFromList.SelectedRows.Cast<DataGridViewRow>().Select(r => r.Tag).OfType<RailLocation>().ToList();
        }

        private void PrepToMovement(out List<RailLocation> allRailLocations, out List<RailLocation> selectedRailLocations, out Action refreshAction)
        {
            refreshAction = () => { if (tabControlTo.SelectedTab == tabTrackTo) LoadTrackTo(); else LoadTrainTo(); };
            allRailLocations = null;
            selectedRailLocations = null;

            if (tabControlTo.SelectedTab == tabTrainTo)
            {
                DropDownItem<Models.Train> selectedTrain = cboToTrain.SelectedItem as DropDownItem<Models.Train>;
                if (selectedTrain == null)
                {
                    return;
                }

                if (!_modifiedTrainsByID.ContainsKey(selectedTrain.Object.TrainID))
                {
                    _modifiedTrainsByID[selectedTrain.Object.TrainID] = new List<RailLocation>();

                    foreach (DataGridViewRow row in dgvToList.Rows)
                    {
                        RailLocation location = row.Tag as RailLocation;
                        if (location == null)
                        {
                            continue;
                        }

                        _modifiedTrainsByID[selectedTrain.Object.TrainID].Add(location);
                    }
                }

                allRailLocations = _modifiedTrainsByID[selectedTrain.Object.TrainID];
            }
            else if (tabControlTo.SelectedTab == tabTrackTo)
            {
                DropDownItem<Track> selectedTrack = cboToTrack.SelectedItem as DropDownItem<Track>;
                if (selectedTrack == null)
                {
                    return;
                }

                if (!_modifiedTracksByID.ContainsKey(selectedTrack.Object.TrackID))
                {
                    _modifiedTracksByID[selectedTrack.Object.TrackID] = new List<RailLocation>();

                    foreach (DataGridViewRow row in dgvToList.Rows)
                    {
                        RailLocation location = row.Tag as RailLocation;
                        if (location == null)
                        {
                            continue;
                        }

                        _modifiedTracksByID[selectedTrack.Object.TrackID].Add(location);
                    }
                }

                allRailLocations = _modifiedTracksByID[selectedTrack.Object.TrackID];
            }

            selectedRailLocations = dgvToList.SelectedRows.Cast<DataGridViewRow>().Select(r => r.Tag).OfType<RailLocation>().ToList();
        }

        private void cmdMoveDown_Click(object sender, EventArgs e)
        {
            List<RailLocation> allRailLocations;
            List<RailLocation> selectedRailLocations;
            Action refresh;
            if (lastClickedGrid == dgvFromList)
            {
                PrepFromMovement(out allRailLocations, out selectedRailLocations, out refresh);
            }
            else if (lastClickedGrid == dgvToList)
            {
                PrepToMovement(out allRailLocations, out selectedRailLocations, out refresh);
            }
            else
            {
                return;
            }

            if (allRailLocations == null)
            {
                return;
            }

            if (!CheckForUnreleasedCars(selectedRailLocations))
            {
                return;
            }

            foreach (RailLocation selectedLocation in selectedRailLocations.OrderByDescending(rl => rl.Position))
            {
                RailLocation swap = allRailLocations.FirstOrDefault(rl => rl.Position == selectedLocation.Position + 1);
                if (swap == null)
                {
                    continue;
                }

                swap.Position--;
                selectedLocation.Position++;
            }

            refresh?.Invoke();
            

        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if ((tabControlFrom.SelectedTab == tabTrackFrom && cboFromTrack.SelectedItem == null) || (tabControlFrom.SelectedTab == tabTrainFrom && cboFromTrain.SelectedItem == null) ||
                (tabControlTo.SelectedTab == tabTrackTo && cboToTrack.SelectedItem == null) || (tabControlTo.SelectedTab == tabTrainTo && cboToTrain.SelectedItem == null))
            {
                return;
            }

            long? trackID = tabControlTo.SelectedTab == tabTrackTo ? (cboToTrack.SelectedItem as DropDownItem<Track>).Object.TrackID : (long?)null;
            long? trainID = tabControlTo.SelectedTab == tabTrainTo ? (cboToTrain.SelectedItem as DropDownItem<Models.Train>).Object.TrainID : (long?)null;

            PrepFromMovement(out List<RailLocation> allFromLocations, out List<RailLocation> selectedFromLocations, out Action refreshFrom);
            PrepToMovement(out List<RailLocation> allToLocations, out List<RailLocation> selectedToLocations, out Action refreshTo);

            if (!CheckForUnreleasedCars(selectedFromLocations))
            {
                return;
            }

            foreach (RailLocation selectedFromLocation in selectedFromLocations.OrderBy(rl => rl.Position))
            {
                int fromPosition = selectedFromLocation.Position;

                int maxPositionOnToSide = allToLocations.Count == 0 ? 0 : allToLocations.Max(rl => rl.Position);
                selectedFromLocation.TrackID = trackID;
                selectedFromLocation.TrainID = trainID;
                selectedFromLocation.Position = ++maxPositionOnToSide;
                allFromLocations.Remove(selectedFromLocation);
                allToLocations.Add(selectedFromLocation);

                foreach(RailLocation lowerPosition in allFromLocations.Where(rl => rl.Position > fromPosition))
                {
                    lowerPosition.Position--;
                }
            }

            refreshFrom?.Invoke();
            refreshTo?.Invoke();

            if (trackID != null)
            {
                Track track = _allTracks.First(t => t.TrackID == trackID);
                decimal currentTrackLength = allToLocations.Sum(rl => rl.Railcar?.RailcarModel?.Length ?? rl.Locomotive?.LocomotiveModel?.Length ?? 0);
                if (currentTrackLength > track.Length)
                {
                    this.ShowWarning(string.Format("Total stock length on track {0} ({1} meters) exceeds track length ({2} meters)", track.Name, track.Length, currentTrackLength));
                }
            }
        }

        private void cmdRemove_Click(object sender, EventArgs e)
        {
            if ((tabControlFrom.SelectedTab == tabTrackFrom && cboFromTrack.SelectedItem == null) || (tabControlFrom.SelectedTab == tabTrainFrom && cboFromTrain.SelectedItem == null) ||
                (tabControlTo.SelectedTab == tabTrackTo && cboToTrack.SelectedItem == null) || (tabControlTo.SelectedTab == tabTrainTo && cboToTrain.SelectedItem == null))
            {
                return;
            }

            long? trackID = tabControlFrom.SelectedTab == tabTrackFrom ? (cboFromTrack.SelectedItem as DropDownItem<Track>).Object.TrackID : (long?)null;
            long? trainID = tabControlFrom.SelectedTab == tabTrainFrom ? (cboFromTrain.SelectedItem as DropDownItem<Models.Train>).Object.TrainID : (long?)null;

            PrepFromMovement(out List<RailLocation> allFromLocations, out List<RailLocation> selectedFromLocations, out Action refreshFrom);
            PrepToMovement(out List<RailLocation> allToLocations, out List<RailLocation> selectedToLocations, out Action refreshTo);

            if (!CheckForUnreleasedCars(selectedToLocations))
            {
                return;
            }

            foreach (RailLocation selectedToLocation in selectedToLocations.OrderBy(rl => rl.Position))
            {
                int currentPosition = selectedToLocation.Position;

                int nextPosition = allFromLocations.Count == 0 ? 0 : allFromLocations.Max(rl => rl.Position);
                selectedToLocation.TrackID = trackID;
                selectedToLocation.TrainID = trainID;
                selectedToLocation.Position = ++nextPosition;
                allFromLocations.Add(selectedToLocation);
                allToLocations.Remove(selectedToLocation);

                foreach(RailLocation lowerPosition in allToLocations.Where(rl => rl.Position > currentPosition))
                {
                    lowerPosition.Position--;
                }
            }

            refreshTo?.Invoke();
            refreshFrom?.Invoke();

            if (trackID != null)
            {
                Track track = _allTracks.First(t => t.TrackID == trackID);
                decimal currentTrackLength = allFromLocations.Sum(rl => rl.Railcar?.RailcarModel?.Length ?? rl.Locomotive?.LocomotiveModel?.Length ?? 0);
                if (currentTrackLength > track.Length)
                {
                    this.ShowWarning(string.Format("Total stock length on track {0} ({1} meters) exceeds track length ({2} meters)", track.Name, track.Length, currentTrackLength));
                }
            }
        }

        private void tabControlFrom_Selected(object sender, TabControlEventArgs e)
        {
            FromCombo_SelectedValueChanged(e.TabPage == tabTrackFrom ? cboFromTrack : cboFromTrain, EventArgs.Empty);
        }

        private void tabControlTo_Selected(object sender, TabControlEventArgs e)
        {
            ToCombo_SelectedIndexChanged(e.TabPage == tabTrackTo ? cboToTrack : cboToTrain, EventArgs.Empty);
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                loaderFull.BringToFront();
                loaderFull.Visible = true;

                PutData put = _application.GetAccess<PutData>();
                put.API = DataAccess.APIs.FleetTracking;
                put.Resource = "RailLocation/Modify";
                put.ObjectToPut = new
                {
                    ModifiedTracksByID = _modifiedTracksByID,
                    ModifiedTrainsByID = _modifiedTrainsByID,
                    TimeMoved = dateTimePicker1.Value
                };
                await put.ExecuteNoResult();

                if (put.RequestSuccessful)
                {
                    if (this.Ask("Do you want to release any stock?", "Release Stock"))
                    {
                        ParentForm.Hide();

                        _application.MassReleaseStock();
                    }
                    ParentForm.Close();
                    Dispose();
                }
            }
            finally
            {
                loaderFull.Visible = false;
            }
        }
    }
}
