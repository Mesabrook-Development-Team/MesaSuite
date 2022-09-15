using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;

namespace FleetTracking.Interop
{
    public class FleetTrackingApplication
    {
        public static class CallbackDelegates
        {
            public delegate Form OpenForm(IFleetTrackingControl primaryControl);
            public delegate TAccess GetAccess<out TAccess>() where TAccess : DataAccess;
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

        internal TAccess GetAccess<TAccess>() where TAccess : DataAccess
        {
            return GetCallback<CallbackDelegates.GetAccess<TAccess>>().Invoke();
        }

        public void BrowseLocomotiveModels()
        {
            Form parentForm = GetCallback<CallbackDelegates.OpenForm>().Invoke(new LocomotiveModel.BrowseLocomotiveModels() { Application = this });
            parentForm.Text = "Browse Locomotive Models";
        }

        public void BrowseEquipmentRoster()
        {
            Form parentForm = GetCallback<CallbackDelegates.OpenForm>().Invoke(new Roster.BrowseRoster() { Application = this });
            parentForm.Text = "Browse Equipment Roster";
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
                            new MainNavigationItem("Railcar Models")
                        }
                    },
                    new MainNavigationItem("Equipment Roster", BrowseEquipmentRoster),
                    new MainNavigationItem("Train Builder"),
                    new MainNavigationItem("Track Viewer"),
                    new MainNavigationItem("Spot/Release")
                }
            };
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
