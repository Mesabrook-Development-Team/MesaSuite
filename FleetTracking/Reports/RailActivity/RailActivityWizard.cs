using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FleetTracking.Interop;
using FleetTracking.Models;
using MesaSuite.Common;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using MesaSuite.Common.Utility;

namespace FleetTracking.Reports.RailActivity
{
    public partial class RailActivityWizard : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        private StepConfigurationCollection stepConfig;
        public RailActivityWizard()
        {
            InitializeComponent();

            imlState.Images.Add("success", Properties.Resources.accept);
            imlState.Images.Add("fail", Properties.Resources.cancel);
        }

        private void RailActivityWizard_Load(object sender, EventArgs e)
        {
            ParentForm.Text = "Rail Activity Report Wizard";

            stepConfig = new StepConfigurationCollection()
            {
                { lstNav.Items[0], pnlWelcome, () => true, false, true },
                { lstNav.Items[1], pnlDateSelection, ValidateDateSelection },
                { lstNav.Items[2], pnlOptions, () => true },
                { lstNav.Items[3], pnlTrainSelection, ValidateTrainSelection },
                { lstNav.Items[4], pnlTrackSelection, ValidateTrackSelection },
                { lstNav.Items[5], pnlReview, () => true, true, false }
            };

            foreach(KeyValuePair<ListViewItem, StepConfiguration> kvp in stepConfig)
            {
                string imageKey = kvp.Value.Validate() ? "success" : "fail";
                kvp.Key.ImageKey = imageKey;
            }

            lstNav.Items[0].Selected = true;

            Dictionary<string, object> preferences = UserPreferences.Get().GetPreferencesForSection("ft_railactivitywizard");
            dtpStart.Value = preferences.GetOrDefault("startDate", DateTime.Today).Cast<DateTime>();
            dtpEnd.Value = preferences.GetOrDefault("endDate", DateTime.Today).Cast<DateTime>();
            chkMovementByTrain.Checked = preferences.GetOrDefault("showTrains", true).Cast<bool>();
            chkTrackToTrackMovement.Checked = preferences.GetOrDefault("showTracks", true).Cast<bool>();
            rdoAllTrains.Checked = preferences.GetOrDefault("showAllTrains", true).Cast<bool>();
            rdoSpecificTrains.Checked = !rdoAllTrains.Checked;
            rdoAllTracks.Checked = preferences.GetOrDefault("showAllTracks", true).Cast<bool>();
            rdoSpecificTracks.Checked = !rdoAllTracks.Checked;

            LoadTrains();
            LoadTracks();
        }

        private async void LoadTrains()
        {
            Dictionary<string, object> preferences = UserPreferences.Get().GetPreferencesForSection("ft_railactivitywizard");
            List<long> preloadTrainSymbolIDs = preferences.GetOrDefault("trainSymbolIDs", new List<long>()).Cast<List<long>>();

            GetData get = _application.GetAccess<GetData>();
            get.API = DataAccess.APIs.FleetTracking;
            get.Resource = "TrainSymbol/GetAll";
            List<TrainSymbol> trainSymbols = (await get.GetObject<List<TrainSymbol>>() ?? new List<TrainSymbol>()).OrderBy(ts => ts.Name).ToList();
            foreach(TrainSymbol trainSymbol in trainSymbols.Where(ts => _application.IsCurrentEntity(ts.CompanyIDOperator, ts.GovernmentIDOperator)))
            {
                DropDownItem<TrainSymbol> ddi = new DropDownItem<TrainSymbol>(trainSymbol, trainSymbol.Name);
                lstTrains.Items.Add(ddi);

                if (preloadTrainSymbolIDs.Contains(trainSymbol.TrainSymbolID.Value))
                {
                    lstTrains.SelectedItems.Add(ddi);
                }
            }

            ldrTrain.Visible = false;
        }

        private async void LoadTracks()
        {
            Dictionary<string, object> preferences = UserPreferences.Get().GetPreferencesForSection("ft_railactivitywizard");
            List<long> preloadedTrackIDs = preferences.GetOrDefault("trackIDs", new List<long>()).Cast<List<long>>();

            GetData get = _application.GetAccess<GetData>();
            get.API = DataAccess.APIs.FleetTracking;
            get.Resource = "Track/GetAll";
            List<Track> tracks = (await get.GetObject<List<Track>>() ?? new List<Track>()).OrderBy(t => t.Name).ToList();
            foreach(Track track in tracks.Where(t => _application.IsCurrentEntity(t.RailDistrict.CompanyIDOperator, t.RailDistrict.GovernmentIDOperator)))
            {
                DropDownItem<Track> ddi = new DropDownItem<Track>(track, track.Name);
                lstTracks.Items.Add(ddi);

                if (preloadedTrackIDs.Contains(track.TrackID.Value))
                {
                    lstTracks.SelectedItems.Add(ddi);
                }
            }

            ldrTrack.Visible = false;
        }

        private bool ValidateDateSelection()
        {
            if (dtpEnd.Value.Date < dtpStart.Value.Date)
            {
                this.ShowError("Through Date must be after Start Date");
                return false;
            }

            return true;
        }

        private bool ValidateTrainSelection()
        {
            if (rdoSpecificTrains.Checked && lstTrains.SelectedItems.Count == 0)
            {
                this.ShowError("You must select at least one Train to display");
                return false;
            }

            return true;
        }

        private bool ValidateTrackSelection()
        {
            if (rdoSpecificTracks.Checked && lstTracks.SelectedItems.Count == 0)
            {
                this.ShowError("You must select at least one Track to display");
                return false;
            }

            return true;
        }

        #region Fancy Step Stuff
        private class StepConfiguration
        {
            public bool AllowPrevious { get; set; } = true;
            public bool AllowNext { get; set; } = true;

            public Panel StepPanel { get; set; }
            public Func<bool> Validate { get; set; }
        }

        private class StepConfigurationCollection : Dictionary<ListViewItem, StepConfiguration>
        {
            public void Add(ListViewItem item, Panel panel, Func<bool> validate, bool allowPrevious, bool allowNext)
            {
                Add(item, new StepConfiguration() { Validate = validate, StepPanel = panel, AllowPrevious = allowPrevious, AllowNext = allowNext });
            }

            public void Add(ListViewItem item, Panel panel, Func<bool> validate)
            {
                Add(item, panel, validate, true, true);
            }
        }
        #endregion

        private ListViewItem _lastSelectedItem = null;

        private void lstNav_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (!e.IsSelected || e.Item == _lastSelectedItem)
            {
                return;
            }

            if (e.Item.ForeColor == SystemColors.GrayText)
            {
                lstNav.SelectedItems.Clear();

                if (_lastSelectedItem == null)
                {
                    lstNav.Items[0].Selected = true;
                }
                else if (!_lastSelectedItem.Selected)
                {
                    _lastSelectedItem.Selected = true;
                }
            }
            else
            {
                string imageKey = "success";
                if (_lastSelectedItem != null && !stepConfig[_lastSelectedItem].Validate())
                {
                    imageKey = "fail";
                }

                foreach (StepConfiguration stepConfiguration in stepConfig.Values)
                {
                    stepConfiguration.StepPanel.Visible = false;
                }

                stepConfig[e.Item].StepPanel.Visible = true;
                if (_lastSelectedItem != null)
                {
                    _lastSelectedItem.ImageKey = imageKey;
                }

                cmdBack.Enabled = stepConfig[e.Item].AllowPrevious;
                cmdNext.Enabled = stepConfig[e.Item].AllowNext;
            }

            _lastSelectedItem = lstNav.SelectedItems[0];
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            ParentForm.Close();
            Dispose();
        }

        private void cmdNext_Click(object sender, EventArgs e)
        {
            ListViewItem item = lstNav.Items[_lastSelectedItem.Index + 1];
            while(item.ForeColor == SystemColors.GrayText)
            {
                item = lstNav.Items[item.Index + 1];
            }

            _lastSelectedItem.Selected = false;
            item.Selected = true;
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            ListViewItem item = lstNav.Items[_lastSelectedItem.Index - 1];
            while(item.ForeColor == SystemColors.GrayText)
            {
                item = lstNav.Items[item.Index - 1];
            }

            _lastSelectedItem.Selected = false;
            item.Selected = true;
        }

        private void chkMovementByTrain_CheckedChanged(object sender, EventArgs e)
        { 
            lstNav.Items[3].ForeColor = chkMovementByTrain.Checked ? Color.Black : SystemColors.GrayText;
            lstNav.RedrawItems(3, 3, false);
        }

        private void chkTrackToTrackMovement_CheckedChanged(object sender, EventArgs e)
        {
            lstNav.Items[4].ForeColor = chkTrackToTrackMovement.Checked ? Color.Black : SystemColors.GrayText;

            lstNav.RedrawItems(4, 4, false);
        }

        private void rdoSpecificTracks_CheckedChanged(object sender, EventArgs e)
        {
            lstTracks.Enabled = rdoSpecificTracks.Checked;
        }

        private void rdoSpecificTrains_CheckedChanged(object sender, EventArgs e)
        {
            lstTrains.Enabled = rdoSpecificTrains.Checked;
        }

        private void pnlReview_VisibleChanged(object sender, EventArgs e)
        {
            if (!pnlReview.Visible)
            {
                return;
            }

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Activity Dates: " + dtpStart.Value.ToString("MM/dd/yyyy") + " through " + dtpEnd.Value.ToString("MM/dd/yyyy"));

            builder.Append("Show Trains: ");
            builder.AppendLine(chkMovementByTrain.Checked ? "Yes" : "No");
            if (chkMovementByTrain.Checked)
            {
                builder.Append("├─ Trains to show: ");
                builder.AppendLine(rdoAllTrains.Checked ? "All" : "Specific");

                if (rdoSpecificTrains.Checked)
                {
                    foreach(DropDownItem<TrainSymbol> ddi in lstTrains.SelectedItems.OfType<DropDownItem<TrainSymbol>>())
                    {
                        builder.AppendLine("  ├─ " + ddi.Text);
                    }
                }
            }

            builder.Append("Show Tracks: ");
            builder.AppendLine(chkTrackToTrackMovement.Checked ? "Yes" : "No");
            if (chkTrackToTrackMovement.Checked)
            {
                builder.Append("├─ Tracks to show: ");
                builder.AppendLine(rdoAllTracks.Checked ? "All" : "Specific");

                if (rdoSpecificTracks.Checked)
                {
                    foreach (DropDownItem<Track> ddi in lstTracks.SelectedItems.OfType<DropDownItem<Track>>())
                    {
                        builder.AppendLine("   ├─ " + ddi.Text);
                    }
                }
            }

            txtReview.Text = builder.ToString();
        }

        private void cmdRun_Click(object sender, EventArgs e)
        {
            bool validConfig = true;
            foreach(StepConfiguration configuration in stepConfig.Values)
            {
                validConfig &= configuration.Validate();
            }

            if (!validConfig)
            {
                return;
            }

            Dictionary<string, object> preferences = UserPreferences.Get().GetPreferencesForSection("ft_railactivitywizard");
            preferences["startDate"] = dtpStart.Value.Date;
            preferences["endDate"] = dtpEnd.Value.Date.AddDays(1).AddMinutes(-1);
            preferences["showTrains"] = chkMovementByTrain.Checked;
            preferences["showTracks"] = chkTrackToTrackMovement.Checked;
            preferences["showAllTrains"] = rdoAllTrains.Checked;
            preferences["showAllTracks"] = rdoAllTracks.Checked;
            if (rdoSpecificTrains.Checked)
            {
                List<long> trainSymbolIDs = new List<long>();
                foreach(DropDownItem<TrainSymbol> ddi in lstTrains.SelectedItems.OfType<DropDownItem<TrainSymbol>>())
                {
                    trainSymbolIDs.Add(ddi.Object.TrainSymbolID.Value);
                }

                preferences["trainSymbolIDs"] = trainSymbolIDs;
            }

            if (rdoSpecificTracks.Checked)
            {
                List<long> trackIDs = new List<long>();
                foreach(DropDownItem<Track> ddi in lstTracks.SelectedItems.OfType<DropDownItem<Track>>())
                {
                    trackIDs.Add(ddi.Object.TrackID.Value);
                }

                preferences["trackIDs"] = trackIDs;
            }

            UserPreferences.Get().Save();

            RailActivityReportContext context = new RailActivityReportContext(
                dtpStart.Value.Date,
                dtpEnd.Value.Date.AddDays(1).AddMinutes(-1),
                chkMovementByTrain.Checked,
                chkTrackToTrackMovement.Checked,
                lstTrains.SelectedItems.OfType<DropDownItem<TrainSymbol>>().Select(ts => ts.Object.TrainSymbolID.Value).ToList(),
                lstTracks.SelectedItems.OfType<DropDownItem<Track>>().Select(t => t.Object.TrackID.Value).ToList())
            {
                Application = _application
            };

            PrintableReport printableReport = new PrintableReport()
            {
                Application = _application,
                ReportContext = context
            };
            _application.OpenForm(printableReport);
            ParentForm.Close();
            Dispose();
        }
    }
}
