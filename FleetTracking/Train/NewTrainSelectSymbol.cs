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
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;

namespace FleetTracking.Train
{
    public partial class NewTrainSelectSymbol : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        private TrainSymbols.TrainSymbolList symbolList;
        public NewTrainSelectSymbol()
        {
            InitializeComponent();
        }

        private void NewTrainSelectSymbol_Load(object sender, EventArgs e)
        {
            if (ParentForm != null)
            {
                ParentForm.Text = "New Train - Select Symbol";
            }

            pnlSymbol.Controls.Clear();

            symbolList = new TrainSymbols.TrainSymbolList()
            {
                Name = nameof(symbolList),
                Application = _application,
                Dock = DockStyle.Fill,
                SelectionMode = true,
                Filter = (ts) => !ts.HasTrainInProgress && _application.IsCurrentEntity(ts.CompanyIDOperator, ts.GovernmentIDOperator)
            };
            pnlSymbol.Controls.Add(symbolList);
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Dispose();
            ParentForm?.Close();
        }

        private async void cmdCreate_Click(object sender, EventArgs e)
        {
            if (symbolList.SelectedSymbol == null)
            {
                this.ShowError("A Train Symbol must be selected");
                return;
            }

            InputBox instructions = new InputBox()
            {
                Application = _application,
                InputValueType = typeof(string),
                MultiLine = true
            };
            instructions.Text = "Train Instructions";
            instructions.lblPrompt.Text = "Enter Train Instructions (if needed):";
            Form inputForm = _application.OpenForm(instructions, FleetTrackingApplication.OpenFormOptions.Dialog);
            if (inputForm.DialogResult != DialogResult.OK)
            {
                return;
            }

            try
            {
                loader.BringToFront();
                loader.Visible = true;

                Models.Train newTrain = new Models.Train()
                {
                    TrainSymbolID = symbolList.SelectedSymbol.TrainSymbolID,
                    TrainInstructions = instructions.InputValue,
                    Status = Models.Train.Statuses.NotStarted
                };

                PostData post = _application.GetAccess<PostData>();
                post.API = DataAccess.APIs.FleetTracking;
                post.Resource = "Train/Post";
                post.ObjectToPost = newTrain;
                Models.Train savedTrain = await post.Execute<Models.Train>();
                if (post.RequestSuccessful)
                {
                    InProgressTrainDisplay trainDisplay = new InProgressTrainDisplay()
                    {
                        Application = _application,
                        TrainID = savedTrain.TrainID
                    };

                    Form form = _application.OpenForm(trainDisplay, FleetTrackingApplication.OpenFormOptions.Popout);
                    form.Text = symbolList.SelectedSymbol.Name;

                    Dispose();
                    ParentForm?.Close();
                }
            }
            finally
            {
                loader.Visible = false;
            }
        }
    }
}
