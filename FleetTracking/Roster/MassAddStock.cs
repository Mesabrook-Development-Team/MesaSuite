using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FleetTracking.Attributes;
using FleetTracking.Interop;
using FleetTracking.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;

namespace FleetTracking.Roster
{
    [SecuredControl(SecuredControlAttribute.Permissions.AllowSetup, SecuredControlAttribute.Permissions.IsTrainCrew, SecuredControlAttribute.Permissions.IsYardmaster)]
    public partial class MassAddStock : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public MassAddStock()
        {
            InitializeComponent();
        }

        private void MassAddStock_Load(object sender, EventArgs e)
        {
            ParentForm.Text = "Mass Add Stock";
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            TabPage newPage = new TabPage("New Model Group");
            tabModels.Controls.Add(newPage);
            lblWelcome.Visible = false;

            MassAddStockInput input = new MassAddStockInput()
            {
                Application = _application,
                Dock = DockStyle.Fill
            };
            input.ModelNameChanged += (s, name) => newPage.Text = string.IsNullOrEmpty(name) ? "New Model Group" : name;
            newPage.Controls.Add(input);
            tabModels.SelectedTab = newPage;
        }

        private void cmdRemove_Click(object sender, EventArgs e)
        {
            if (tabModels.SelectedTab == null || !this.Confirm("Are you sure you want to delete this model group?"))
            {
                return;
            }

            tabModels.TabPages.Remove(tabModels.SelectedTab);

            lblWelcome.Visible = tabModels.TabPages.Count <= 0;
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            foreach(TabPage page in tabModels.TabPages)
            {
                MassAddStockInput input = page.Controls.OfType<MassAddStockInput>().First();
                string errors = input.GetEntryErrors();
                if (!string.IsNullOrEmpty(errors))
                {
                    this.ShowError($"An error occurred on Tab Page number {tabModels.TabPages.IndexOf(page) + 1} ({page.Text}):\r\n\r\n{errors}");
                    return;
                }
            }

            try
            {
                loader.BringToFront();
                loader.Visible = true;

                PostData post = _application.GetAccess<PostData>();
                post.API = DataAccess.APIs.FleetTracking;

                PutData put = _application.GetAccess<PutData>();
                put.API = DataAccess.APIs.FleetTracking;

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;

                foreach(TabPage page in tabModels.TabPages)
                {
                    MassAddStockInput input = page.Controls.OfType<MassAddStockInput>().First();

                    post.Resource = "Railcar/Post";
                    foreach(Railcar railcar in input.GetRailcars())
                    {
                        post.ObjectToPost = railcar;
                        Railcar newRailcar = await post.Execute<Railcar>();
                        if (post.RequestSuccessful)
                        {
                            get.Resource = $"RailLocation/GetForRailcar/{newRailcar.RailcarID}";
                            RailLocation railLocation = await get.GetObject<RailLocation>();
                            railLocation.TrackID = railcar.RailLocation.TrackID;
                            railLocation.Position = int.MaxValue;

                            get.Resource = $"RailLocation/GetByTrack/{railLocation.TrackID}";
                            List<RailLocation> allLocations = await get.GetObject<List<RailLocation>>();
                            allLocations.Add(railLocation);

                            var modifyData = new
                            {
                                ModifiedTracksByID = new Dictionary<long?, List<RailLocation>>()
                                {
                                    { railLocation.TrackID, allLocations }
                                },
                                TimeMoved = DateTime.Now
                            };

                            put.Resource = "RailLocation/Modify";
                            put.ObjectToPut = modifyData;
                            await put.ExecuteNoResult();
                        }
                    }

                    post.Resource = "Locomotive/Post";
                    foreach (Locomotive locomotive in input.GetLocomotives())
                    {
                        post.ObjectToPost = locomotive;
                        Locomotive newLocomotive = await post.Execute<Locomotive>();
                        if (post.RequestSuccessful)
                        {
                            get.Resource = $"RailLocation/GetForLocomotive/{newLocomotive.LocomotiveID}";
                            RailLocation railLocation = await get.GetObject<RailLocation>();
                            railLocation.TrackID = locomotive.RailLocation.TrackID;
                            railLocation.Position = int.MaxValue;

                            get.Resource = $"RailLocation/GetByTrack/{railLocation.TrackID}";
                            List<RailLocation> allLocations = await get.GetObject<List<RailLocation>>();
                            allLocations.Add(railLocation);

                            var modifyData = new
                            {
                                ModifiedTracksByID = new Dictionary<long?, List<RailLocation>>()
                                {
                                    { railLocation.TrackID, allLocations }
                                },
                                TimeMoved = DateTime.Now
                            };

                            put.Resource = "RailLocation/Modify";
                            put.ObjectToPut = modifyData;
                            await put.ExecuteNoResult();
                        }
                    }
                }
            }
            finally
            {
                loader.Visible = false;
            }

            ParentForm.Close();
            Dispose();
        }
    }
}
