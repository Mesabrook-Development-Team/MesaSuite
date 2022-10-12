﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FleetTracking.Interop;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using MesaSuite.Common.Utility;

namespace FleetTracking.Roster
{
    public partial class RailcarDetail : UserControl, IFleetTrackingControl
    {
        public event EventHandler<Models.Railcar> RailcarSaved;

        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }
        public long? RailcarID { get; set; }

        public RailcarDetail()
        {
            InitializeComponent();
        }

        private void RailcarDetail_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public async Task LoadData()
        {
            loader.BringToFront();
            loader.Visible = true;

            try
            {
                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                Models.Railcar railcar = new Models.Railcar();
                if (RailcarID != null)
                {
                    get.Resource = $"Railcar/Get/{RailcarID}";
                    railcar = await get.GetObject<Models.Railcar>() ?? new Models.Railcar();

                    txtReportingMark.Text = railcar.ReportingMark;
                    txtReportingNumber.Text = railcar.ReportingNumber?.ToString();
                    txtCurrentLocation.Text = "Your mom's house";

                    bool isOwner = _application.IsCurrentEntity(railcar.CompanyIDOwner, railcar.GovernmentIDOwner);
                    bool isPossessor = _application.IsCurrentEntity(railcar.CompanyIDPossessor, railcar.GovernmentIDPossessor);

                    cboModel.Enabled = isOwner;
                    txtReportingMark.Enabled = isOwner;
                    txtReportingNumber.Enabled = isOwner;
                    cboOwner.Enabled = isOwner;
                    cboPossessor.Enabled = isPossessor;

                    cmdUpdateImage.Enabled = isOwner;
                }

                get.Resource = "RailcarModel/GetAll";
                List<Models.RailcarModel> railcarModels = await get.GetObject<List<Models.RailcarModel>>() ?? new List<Models.RailcarModel>();

                foreach (Models.RailcarModel railcarModel in railcarModels)
                {
                    RailcarModel.RailcarModelDropDownItem ddi = new RailcarModel.RailcarModelDropDownItem()
                    {
                        Application = _application,
                        RailcarModelID = railcarModel.RailcarModelID
                    };
                    Label closedControl = new Label()
                    {
                        Text = railcarModel.Name
                    };
                    closedControl.Size = TextRenderer.MeasureText(closedControl.Text, closedControl.Font);
                    ControlSelector.ControlSelectorItem dropDownItem = new ControlSelector.ControlSelectorItem(ddi, closedControl);
                    cboModel.Items.Add(dropDownItem);

                    if (railcarModel.RailcarModelID == railcar.RailcarModelID)
                    {
                        cboModel.SelectedItem = dropDownItem;
                    }
                }

                get.Resource = $"Company/GetAll";
                List<Models.Company> companies = await get.GetObject<List<Models.Company>>() ?? new List<Models.Company>();
                foreach (Models.Company company in companies)
                {
                    DropDownItem<Models.Company> dropDownItem = new DropDownItem<Models.Company>(company, company.Name);
                    cboOwner.Items.Add(dropDownItem);

                    if (railcar.CompanyIDOwner != null && company.CompanyID == railcar.CompanyIDOwner)
                    {
                        cboOwner.SelectedItem = dropDownItem;
                    }

                    dropDownItem = dropDownItem.CreateCopy();
                    cboPossessor.Items.Add(dropDownItem);
                    if (railcar.CompanyIDPossessor != null && company.CompanyID == railcar.CompanyIDPossessor)
                    {
                        cboPossessor.SelectedItem = dropDownItem;
                    }
                }

                get.Resource = $"Government/GetAll";
                List<Models.Government> governments = await get.GetObject<List<Models.Government>>() ?? new List<Models.Government>();
                foreach (Models.Government government in governments)
                {
                    DropDownItem<Models.Government> dropDownItem = new DropDownItem<Models.Government>(government, government.Name);
                    cboOwner.Items.Add(dropDownItem);

                    if (railcar.GovernmentIDOwner != null && railcar.GovernmentIDOwner == government.GovernmentID)
                    {
                        cboOwner.SelectedItem = dropDownItem;
                    }

                    dropDownItem = dropDownItem.CreateCopy();
                    cboPossessor.Items.Add(dropDownItem);
                    if (railcar.GovernmentIDPossessor != null && government.GovernmentID == railcar.GovernmentIDPossessor)
                    {
                        cboPossessor.SelectedItem = dropDownItem;
                    }
                }

            }
            finally
            {
                loader.Visible = false;
            }

            if (RailcarID != null)
            {
                try
                {
                    GetData get = _application.GetAccess<GetData>();
                    get.API = DataAccess.APIs.FleetTracking;
                    get.Resource = $"Railcar/GetImage/{RailcarID}";
                    byte[] imageData = await get.GetObject<byte[]>();

                    if (imageData != null)
                    {
                        MemoryStream stream = new MemoryStream(imageData);
                        Image image = Image.FromStream(stream);
                        pboxImage.Image = image;
                    }
                }
                catch { }
            }
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            if (!this.AreFieldsPresent(new List<(string, Control)>()
            {
                ("Model", cboModel),
                ("Reporting Mark", txtReportingMark),
                ("Reporting Mark", txtReportingNumber),
                ("Owner", cboOwner),
                ("Possessor", cboPossessor)
            }))
            {
                return;
            }

            if (!int.TryParse(txtReportingNumber.Text, out int reportingNumber))
            {
                this.ShowError("Reporting Mark must have a valid number");
                return;
            }

            ControlSelector.ControlSelectorItem selectedModelItem = cboModel.SelectedItem as ControlSelector.ControlSelectorItem;
            long? modelID = ((RailcarModel.RailcarModelDropDownItem)selectedModelItem.DropDownControl).RailcarModelID;
            long? governmentIDOwner = null;
            long? companyIDOwner = null;
            long? governmentIDPossessor = null;
            long? companyIDPossessor = null;
            if (cboOwner.SelectedItem is DropDownItem<Models.Government> government)
            {
                governmentIDOwner = government.Object.GovernmentID;
            }
            else if (cboOwner.SelectedItem is DropDownItem<Models.Company> company)
            {
                companyIDOwner = company.Object.CompanyID;
            }

            if (cboPossessor.SelectedItem is DropDownItem<Models.Government> governmentPossessor)
            {
                governmentIDPossessor = governmentPossessor.Object.GovernmentID;
            }
            else if (cboPossessor.SelectedItem is DropDownItem<Models.Company> company)
            {
                companyIDPossessor = company.Object.CompanyID;
            }

            Models.Railcar railcar = new Models.Railcar()
            {
                RailcarID = this.RailcarID,
                GovernmentIDOwner = governmentIDOwner,
                CompanyIDOwner = companyIDOwner,
                GovernmentIDPossessor = governmentIDPossessor,
                CompanyIDPossessor = companyIDPossessor,
                RailcarModelID = modelID,
                ReportingMark = txtReportingMark.Text,
                ReportingNumber = reportingNumber
            };

            bool saveSuccessful;
            if (RailcarID == null)
            {
                PostData post = _application.GetAccess<PostData>();
                post.API = DataAccess.APIs.FleetTracking;
                post.Resource = "Railcar/Post";
                post.ObjectToPost = railcar;
                railcar = await post.Execute<Models.Railcar>();
                saveSuccessful = post.RequestSuccessful;
            }
            else
            {
                PutData put = _application.GetAccess<PutData>();
                put.API = DataAccess.APIs.FleetTracking;
                put.Resource = "Railcar/Put";
                put.ObjectToPut = railcar;
                await put.ExecuteNoResult();
                saveSuccessful = put.RequestSuccessful;
            }

            if (saveSuccessful && pboxImage.Image != null)
            {
                byte[] imageData;
                using (MemoryStream stream = new MemoryStream())
                {
                    pboxImage.Image.Save(stream, ImageFormat.Png);
                    stream.Position = 0;

                    imageData = new byte[stream.Length];
                    stream.Read(imageData, 0, (int)stream.Length);
                }

                PutData updateImage = _application.GetAccess<PutData>();
                updateImage.API = DataAccess.APIs.FleetTracking;
                updateImage.Resource = "Railcar/UpdateImage";
                updateImage.ObjectToPut = new { railcarID = railcar.RailcarID, image = imageData };
                await updateImage.ExecuteNoResult();
                if (updateImage.RequestSuccessful)
                {
                    RailcarSaved?.Invoke(this, railcar);
                }
            }
            else if (saveSuccessful)
            {
                RailcarSaved?.Invoke(this, railcar);
            }
        }

        private void cmdUpdateImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openImage = new OpenFileDialog();
            openImage.Filter = "Images|*.bmp;*.gif;*.jpeg;*.jpg;*.png;*.tiff";
            openImage.Title = "Select Railcar Image";
            openImage.Multiselect = false;
            if (openImage.ShowDialog() != DialogResult.OK || string.IsNullOrEmpty(openImage.FileName))
            {
                return;
            }

            Image image;
            using (FileStream stream = new FileStream(openImage.FileName, FileMode.Open))
            {
                MemoryStream memoryStream = new MemoryStream();
                stream.CopyTo(memoryStream);
                memoryStream.Position = 0;
                if (memoryStream.Length > 1_048_576 && !this.Confirm("The selected file is larger than 1MB, which may result in degraded performance during download.\r\n\r\nDo you want to use this file anyway?"))
                {
                    return;
                }
                image = Image.FromStream(memoryStream);
            }

            pboxImage.Image = image;
        }
    }
}