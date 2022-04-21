namespace Towing
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lblMyTickets = new System.Windows.Forms.Label();
            this.lblTicketHistory = new System.Windows.Forms.Label();
            this.lblPerformTowing = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(672, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tow Tickets";
            // 
            // lblMyTickets
            // 
            this.lblMyTickets.BackColor = System.Drawing.Color.White;
            this.lblMyTickets.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMyTickets.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMyTickets.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(121)))), ((int)(((byte)(0)))));
            this.lblMyTickets.Location = new System.Drawing.Point(0, 41);
            this.lblMyTickets.Name = "lblMyTickets";
            this.lblMyTickets.Size = new System.Drawing.Size(147, 54);
            this.lblMyTickets.TabIndex = 1;
            this.lblMyTickets.Text = "My Tickets";
            this.lblMyTickets.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTicketHistory
            // 
            this.lblTicketHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTicketHistory.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTicketHistory.Location = new System.Drawing.Point(0, 149);
            this.lblTicketHistory.Name = "lblTicketHistory";
            this.lblTicketHistory.Size = new System.Drawing.Size(147, 54);
            this.lblTicketHistory.TabIndex = 1;
            this.lblTicketHistory.Text = "Ticket History";
            this.lblTicketHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPerformTowing
            // 
            this.lblPerformTowing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPerformTowing.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPerformTowing.Location = new System.Drawing.Point(0, 95);
            this.lblPerformTowing.Name = "lblPerformTowing";
            this.lblPerformTowing.Size = new System.Drawing.Size(147, 54);
            this.lblPerformTowing.TabIndex = 1;
            this.lblPerformTowing.Text = "Perform Towing";
            this.lblPerformTowing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(121)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(811, 371);
            this.Controls.Add(this.lblPerformTowing);
            this.Controls.Add(this.lblTicketHistory);
            this.Controls.Add(this.lblMyTickets);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tow Tickets";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmMain_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMyTickets;
        private System.Windows.Forms.Label lblTicketHistory;
        private System.Windows.Forms.Label lblPerformTowing;
    }
}

