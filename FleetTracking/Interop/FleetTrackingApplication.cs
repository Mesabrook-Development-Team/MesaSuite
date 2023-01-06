using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using FleetTracking.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;

namespace FleetTracking.Interop
{
    public class FleetTrackingApplication
    {
        public static class CallbackDelegates
        {
            public delegate Form OpenForm(IFleetTrackingControl primaryControl, OpenFormOptions formOptions, IWin32Window parentWindow);
            public delegate TAccess GetAccess<out TAccess>() where TAccess : DataAccess;
            public delegate bool IsCurrentEntity(long? companyID, long? governmentID);
            public delegate (long?, long?) GetCurrentCompanyIDGovernmentID();
            public delegate Task<List<User>> GetUsersForEntity();
        }

        private Dictionary<Type, Delegate> callbacks = new Dictionary<Type, Delegate>();

        public void RegisterCallback<TDelegate>(TDelegate callback) where TDelegate : Delegate
        {
            callbacks[typeof(TDelegate)] = callback;
        }

        public TDelegate GetCallback<TDelegate>() where TDelegate : Delegate
        {
            return (TDelegate)callbacks.GetOrDefault(typeof(TDelegate));
        }

        internal Form OpenForm(IFleetTrackingControl control, OpenFormOptions formOptions, IWin32Window parent)
        {
            return GetCallback<CallbackDelegates.OpenForm>().Invoke(control, formOptions, parent);
        }

        internal Form OpenForm(IFleetTrackingControl control, OpenFormOptions formOptions)
        {
            return OpenForm(control, formOptions, null);
        }

        internal Form OpenForm(IFleetTrackingControl control)
        {
            return OpenForm(control, OpenFormOptions.None);
        }

        internal TAccess GetAccess<TAccess>() where TAccess : DataAccess
        {
            return GetCallback<CallbackDelegates.GetAccess<TAccess>>().Invoke();
        }

        public void BrowseLocomotiveModels()
        {
            Form parentForm = OpenForm(new LocomotiveModel.BrowseLocomotiveModels() { Application = this });
            parentForm.Text = "Browse Locomotive Models";
        }

        public void BrowseRailcarModels()
        {
            Form parentForm = OpenForm(new RailcarModel.BrowseRailcarModels() { Application = this });
            parentForm.Text = "Browse Railcar Models";
        }

        public void BrowseEquipmentRoster()
        {
            Form parentForm = OpenForm(new Roster.BrowseRoster() { Application = this });
            parentForm.Text = "Browse Equipment Roster";
        }

        public void ManageLeasing()
        {
            Form parentForm = OpenForm(new Leasing.LeaseManagement() { Application = this });
            parentForm.Text = "Manage Leasing";
        }

        public void BrowseTrainSymbols()
        {
            Form parentForm = OpenForm(new TrainSymbols.TrainSymbolList()
            {
                Application = this
            });
            parentForm.Text = "Train Symbols";
        }

        public void BrowseTrains()
        {
            Train.TrainList trainList = new Train.TrainList()
            {
                Application = this
            };
            Form form = OpenForm(trainList);
            form.Text = "Train List";
        }

        public void OpenTrackViewer()
        {
            Tracks.TrackViewer viewer = new Tracks.TrackViewer()
            {
                Application = this
            };
            Form form = OpenForm(viewer);
            form.Text = "Track Viewer";
        }

        public void BrowseRailDistricts()
        {
            Tracks.RailDistrictList districtList = new Tracks.RailDistrictList()
            {
                Application = this
            };
            Form form = OpenForm(districtList);
            form.Text = "Rail Districts";
        }

        public void MassReleaseStock()
        {
            Release.MassRelease massRelease = new Release.MassRelease()
            {
                Application = this
            };
            Form releaseForm = OpenForm(massRelease);
        }

        public void ManageCarHandlingRates()
        {
            Rates.CarHandlingRateList list = new Rates.CarHandlingRateList()
            {
                Application = this
            };
            Form rates = OpenForm(list);
            rates.Text = "Car Handling Rates";
        }

        public void ManageMiscSetup()
        {
            Misc.MiscellaneousSettings settings = new Misc.MiscellaneousSettings()
            {
                Application = this
            };
            Form settingsForm = OpenForm(settings);
            settingsForm.Text = "Miscellaneous Setup";
        }

        public void StartLiveLoading()
        {
            InputBox input = new InputBox()
            {
                Application = this
            };
            input.Text = "Live Load Code";
            input.lblPrompt.Text = "Enter the Live Load Code provided by the train crew";

            Form inputForm = OpenForm(input, OpenFormOptions.Dialog);
            if (inputForm.DialogResult != DialogResult.OK)
            {
                return;
            }

            CarLoading.LiveLoadClient liveLoadClient = new CarLoading.LiveLoadClient()
            {
                Application = this,
                LiveLoadCode = input.InputValue
            };
            OpenForm(liveLoadClient, OpenFormOptions.Popout);
        }

        public IEnumerable<MainNavigationItem> GetNavigationItems()
        {
            yield return new MainNavigationItem("Rail")
            {
                SubItems = new List<MainNavigationItem>()
                {
                    new MainNavigationItem("Setup")
                    {
                        SubItems = new List<MainNavigationItem>()
                        {
                            new MainNavigationItem("Locomotive Models", BrowseLocomotiveModels),
                            new MainNavigationItem("Railcar Models", BrowseRailcarModels),
                            new MainNavigationItem("Train Symbols", BrowseTrainSymbols),
                            new MainNavigationItem("Track Districts", BrowseRailDistricts),
                            new MainNavigationItem("Car Handling Rates", ManageCarHandlingRates),
                            new MainNavigationItem("Misc Setup", ManageMiscSetup)
                        }
                    },
                    new MainNavigationItem("Leasing", ManageLeasing),
                    new MainNavigationItem("Equipment Roster", BrowseEquipmentRoster),
                    new MainNavigationItem("Train Manager", BrowseTrains),
                    new MainNavigationItem("Track Viewer", OpenTrackViewer),
                    new MainNavigationItem("Release Equipment", () => OpenForm(new Release.MassRelease() { Application = this })),
                    new MainNavigationItem("Load/Unload Cars")
                    {
                        SubItems = new List<MainNavigationItem>()
                        {
                            new MainNavigationItem("Live Load", StartLiveLoading),
                            new MainNavigationItem("Load On Track", () => OpenForm(new CarLoading.LoadOnTrack() { Application = this, Text = "Load On Track" }))
                        }
                    }
                }
            };
        }

        internal bool IsCurrentEntity(long? companyID, long? governmentID)
        {
            return GetCallback<CallbackDelegates.IsCurrentEntity>()?.Invoke(companyID, governmentID) ?? false;
        }

        internal (long?, long?) GetCurrentCompanyIDGovernmentID()
        {
            return GetCallback<CallbackDelegates.GetCurrentCompanyIDGovernmentID>()?.Invoke() ?? (null, null);
        }

        internal async Task<List<User>> GetUsersForCurrentEntity()
        {
            return (await GetCallback<CallbackDelegates.GetUsersForEntity>()?.Invoke()) ?? new List<User>();
        }

        public enum OpenFormOptions
        {
            None = 0,
            Popout = 1,
            Dialog = 2,
            ResizeToControl = 4
        }

        public class MainNavigationItem
        {
            public MainNavigationItem(string text, Action selectedAction)
            {
                Text = text;
                SelectedAction = selectedAction;
            }

            public MainNavigationItem(string text) : this(text, null) { }

            public MainNavigationItem() : this(null, null) { }

            public string Text { get; set; }
            public Action SelectedAction { get; set; }
            public List<MainNavigationItem> SubItems { get; set; }
        }
    }
}
