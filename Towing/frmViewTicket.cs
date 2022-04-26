using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
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
using Towing.Models;

namespace Towing
{
    public partial class frmViewTicket : Form
    {
        public TowTicket TowTicket { get; set; }
        public ViewModes ViewMode { get; set; } = ViewModes.NewTicket;

        public frmViewTicket()
        {
            InitializeComponent();
        }

        private void frmViewTicket_Load(object sender, EventArgs e)
        {
            lblTicketNumber.Text = $"Ticket #: {TowTicket.TicketNumber}";
            txtIssuedTo.Text = TowTicket.UserIssuedTo;
            txtIssueDate.Text = TowTicket.IssueDate?.ConvertToLocalTime().ToString("MM/dd/yyyy HH:mm");
            txtPhoneNumber.Text = TowTicket.PhoneNumber;
            txtCoordX.Text = TowTicket.CoordX.ToString();
            txtCoordZ.Text = TowTicket.CoordZ.ToString();
            txtDescription.Text = TowTicket.Description;
            txtResponder.Text = TowTicket.UserResponding;
            txtResponseTime.Text = TowTicket.RespondingTime?.ConvertToLocalTime().ToString("MM/dd/yyyy HH:mm");
            txtCompleteTime.Text = TowTicket.CompletionTime?.ConvertToLocalTime().ToString("MM/dd/yyyy HH:mm");

            txtPhoneNumber.ReadOnly = ViewMode == ViewModes.NewTicket;
            txtCoordX.ReadOnly = ViewMode == ViewModes.NewTicket;
            txtCoordZ.ReadOnly = ViewMode == ViewModes.NewTicket;
            txtDescription.ReadOnly = ViewMode == ViewModes.NewTicket;

            cmdSave.Visible = ViewMode == ViewModes.NewTicket;
            cmdCancel.Visible = ViewMode == ViewModes.NewTicket;
            cmdClose.Visible = ViewMode == ViewModes.ViewTicket;
        }

        private void lnkDynmap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCoordX.Text) || string.IsNullOrEmpty(txtCoordZ.Text))
            {
                return;
            }

            Process.Start($"http://map.mesabrook.com?worldname=world&mapname=flat&zoom=6&x={txtCoordX.Text}&y=64&z={txtCoordZ.Text}");
        }

        public enum ViewModes
        {
            NewTicket,
            ViewTicket
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCoordX.Text) || !int.TryParse(txtCoordX.Text, out int coordX))
            {
                MessageBox.Show("Coord X must have a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtCoordZ.Text) || !int.TryParse(txtCoordZ.Text, out int coordZ))
            {
                MessageBox.Show("Coord Z must have a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Dictionary<string, object> valuesToUpdate = new Dictionary<string, object>()
            {
                { nameof(TowTicket.PhoneNumber), txtPhoneNumber.Text },
                { nameof(TowTicket.CoordX), coordX },
                { nameof(TowTicket.CoordZ), coordZ },
                { nameof(TowTicket.Description), txtDescription.Text }
            };

            PatchData patch = new PatchData(DataAccess.APIs.TowTickets, "TowTicket/RequestTow", PatchData.PatchMethods.Replace, TowTicket.TowTicketID, valuesToUpdate);
            await patch.Execute();
            if (patch.RequestSuccessful)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
