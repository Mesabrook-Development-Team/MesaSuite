using CompanyStudio.Models;
using MesaSuite.Common.Data;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CompanyStudio
{
    public partial class frmCompanyConnect : BaseCompanyStudioContent
    {
        public frmCompanyConnect()
        {
            InitializeComponent();
        }

        private async void frmCompanyConnect_Load(object sender, EventArgs e)
        {
            loader.Visible = true;
            loader.BringToFront();

            GetData get = new GetData(DataAccess.APIs.CompanyStudio, "Company/GetForEmployee");
            List<Company> companies = await get.GetObject<List<Company>>();

            if (companies != null)
            {
                foreach (Company company in companies)
                {
                    cboCompany.Items.Add(new CompanyItem(company, company.Name));
                }
            }

            loader.Visible = false;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdConnect_Click(object sender, EventArgs e)
        {
            if (cboCompany.SelectedItem == null)
            {
                MessageBox.Show("You must select a company to connect to.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Studio.AddCompany(((CompanyItem)cboCompany.SelectedItem).Company);
            Close();
        }

        private class CompanyItem
        {
            public Company Company { get; set; }
            public string Text { get; set; }

            public CompanyItem(Company company, string text)
            {
                Company = company;
                Text = text;
            }

            public override string ToString()
            {
                return Text;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cboCompany_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
