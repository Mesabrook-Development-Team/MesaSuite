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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FleetTracking
{
    public partial class PrintableReportSelectPrinter : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }
        public PrintableReportSelectPrinter()
        {
            InitializeComponent();
        }

        public long? PrinterID { get; set; }
        public string DocumentName { get; set; }

        private async void PrintableReportSelectPrinter_Load(object sender, EventArgs e)
        {
            try
            {
                loader.BringToFront();
                loader.Visible = true;

                GetData get = new GetData(DataAccess.APIs.SystemManagement, "Printer/GetAll");
                List<Printer> printers = await get.GetObject<List<Printer>>();
                printers = printers.OrderBy(p => p.Name).ToList();
                foreach(Printer printer in printers)
                {
                    DropDownItem<Printer> ddi = new DropDownItem<Printer>(printer, printer.Name);
                    cboPrinter.Items.Add(ddi);

                    if (PrinterID == printer.PrinterID)
                    {
                        cboPrinter.SelectedItem = ddi;
                    }
                }

                txtDocumentName.Text = DocumentName;
            }
            finally
            {
                loader.Visible = false;
            }
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            if (!this.AreFieldsPresent(new List<(string, Control)>()
            {
                ("Printer", cboPrinter),
                ("Document Name", txtDocumentName)
            }))
            {
                return;
            }

            PrinterID = cboPrinter.SelectedItem.Cast<DropDownItem<Printer>>()?.Object.PrinterID;
            DocumentName = txtDocumentName.Text;
            ParentForm.DialogResult = DialogResult.OK;
            ParentForm.Close();
            Dispose();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            ParentForm.DialogResult = DialogResult.Cancel;
            ParentForm.Close();
            Dispose();
        }
    }
}
