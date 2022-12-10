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
                loaderFull.BringToFront();
                loaderFull.Visible = true;

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = "RailDistrict/GetAll";
                List<RailDistrict> railDistricts = await get.GetObject<List<RailDistrict>>() ?? new List<RailDistrict>();

                DropDownItem<RailDistrict> allItem = new DropDownItem<RailDistrict>(null, "All Districts");
                cboFromDistrict.Items.Add(allItem);
                cboFromDistrict.SelectedItem = allItem;

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
                        cboToTrack.SelectedItem = ddiTrack;
                        tabControlTo.SelectedTab = tabTrackTo;
                    }
                }

                get.Resource = "TrainSymbol/GetAll";
                List<TrainSymbol> symbols = await get.GetObject<List<TrainSymbol>>() ?? new List<TrainSymbol>();

                DropDownItem<TrainSymbol> allSymbols = new DropDownItem<TrainSymbol>(null, "All Symbols");
                cboFromSymbol.Items.Add(allSymbols);
                cboFromSymbol.SelectedItem = allSymbols;

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
                        cboToTrain.SelectedItem = trainItem;
                        tabControlTo.SelectedTab = tabTrainTo;
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

        private async void LoadTrackFrom()
        {
            try
            {
                loaderFrom.BringToFront();
                loaderFrom.Visible = true;

                dgvFromList.Rows.Clear();

                DropDownItem<Track> trackDDI = cboFromTrack.SelectedItem as DropDownItem<Track>;
                if (trackDDI == null)
                {
                    return;
                }

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

                PopulateView(true);
            }
            finally
            {
                loaderFrom.Visible = false;
            }

            PopulateViewImages(true);
        }

        /// <summary>
        /// DO NOT CALL DIRECTLY
        /// </summary>
        /// <param name="isFromView"></param>
        private void PopulateView(bool isFromView)
        {
            DataGridView dgv = isFromView ? dgvFromList : dgvToList;
            DataGridViewColumn colImage = isFromView ? colFromImage : colToImage;
            DataGridViewColumn colReportingMark = isFromView ? colFromReportingMark : colToReportingMark;
            DataGridViewColumn colType = isFromView ? colFromType : colToType;
            DataGridViewColumn colPos = isFromView ? colFromPos : colToPos;
            List<RailLocation> railLocations = isFromView ? _currentFromRailLocations : _currentToRailLocations;
            railLocations = railLocations.OrderBy(rl => rl.Position).ToList();

            foreach(RailLocation railLocation in railLocations)
            {
                int rowIndex = dgv.Rows.Add();
                DataGridViewRow row = dgv.Rows[rowIndex];

                row.Cells[colReportingMark.Name].Value = railLocation.LocomotiveID != null ? railLocation.Locomotive?.FormattedReportingMark : railLocation.Railcar?.FormattedReportingMark;
                row.Cells[colType.Name].Value = railLocation.LocomotiveID != null ? railLocation.Locomotive?.LocomotiveModel?.Name : railLocation.Railcar?.RailcarModel?.Name;
                row.Cells[colPos.Name].Value = railLocation.Position.ToString();
                row.Tag = railLocation;
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

        private async void LoadTrainFrom()
        {
            try
            {
                loaderFrom.BringToFront();
                loaderFrom.Visible = true;

                dgvFromList.Rows.Clear();

                DropDownItem<Models.Train> trainDDI = cboFromTrain.SelectedItem as DropDownItem<Models.Train>;
                if (trainDDI == null)
                {
                    return;
                }

                // TODO: We're going to need to keep a cached version if we modify/add/remove any Rail Location on this train
                // If we have a cached version, display that. Otherwise fetch from API
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

                PopulateView(true);
            }
            finally
            {
                loaderFrom.Visible = false;
            }

            PopulateViewImages(true);
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
                trackBox = cboToTrain;
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

        private async void LoadTrackTo()
        {
            try
            {
                loaderTo.BringToFront();
                loaderTo.Visible = true;

                dgvToList.Rows.Clear();

                DropDownItem<Track> trackDDI = cboToTrack.SelectedItem as DropDownItem<Track>;
                if (trackDDI == null)
                {
                    return;
                }

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

                PopulateView(false);
            }
            finally
            {
                loaderTo.Visible = false;
            }

            PopulateViewImages(false);
        }

        private async void LoadTrainTo()
        {
            try
            {
                loaderTo.BringToFront();
                loaderTo.Visible = true;

                dgvFromList.Rows.Clear();

                DropDownItem<Models.Train> trainDDI = cboToTrain.SelectedItem as DropDownItem<Models.Train>;
                if (trainDDI == null)
                {
                    return;
                }

                // TODO: We're going to need to keep a cached version if we modify/add/remove any Rail Location on this train
                // If we have a cached version, display that. Otherwise fetch from API
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

                PopulateView(false);
            }
            finally
            {
                loaderTo.Visible = false;
            }

            PopulateViewImages(false);
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

            foreach(RailLocation selectedLocation in selectedRailLocations.OrderByDescending(rl => rl.Position))
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
    }
}
