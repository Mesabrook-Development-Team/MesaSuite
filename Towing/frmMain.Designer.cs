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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMyTickets = new System.Windows.Forms.Label();
            this.lblTicketHistory = new System.Windows.Forms.Label();
            this.lblPerformTowing = new System.Windows.Forms.Label();
            this.cmdExit = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.loader = new Towing.Loader();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(796, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Tow Tickets";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseDown);
            this.lblTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseMove);
            this.lblTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseUp);
            // 
            // lblMyTickets
            // 
            this.lblMyTickets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(121)))), ((int)(((byte)(0)))));
            this.lblMyTickets.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMyTickets.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMyTickets.ForeColor = System.Drawing.Color.White;
            this.lblMyTickets.Location = new System.Drawing.Point(0, 41);
            this.lblMyTickets.Name = "lblMyTickets";
            this.lblMyTickets.Size = new System.Drawing.Size(147, 54);
            this.lblMyTickets.TabIndex = 1;
            this.lblMyTickets.Text = "My Tickets";
            this.lblMyTickets.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMyTickets.Click += new System.EventHandler(this.LabelButton_Click);
            this.lblMyTickets.MouseEnter += new System.EventHandler(this.LabelButton_MouseEnter);
            this.lblMyTickets.MouseLeave += new System.EventHandler(this.LabelButton_MouseLeave);
            // 
            // lblTicketHistory
            // 
            this.lblTicketHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTicketHistory.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTicketHistory.Location = new System.Drawing.Point(0, 149);
            this.lblTicketHistory.Name = "lblTicketHistory";
            this.lblTicketHistory.Size = new System.Drawing.Size(147, 54);
            this.lblTicketHistory.TabIndex = 1;
            this.lblTicketHistory.Text = "Ticket History";
            this.lblTicketHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTicketHistory.Click += new System.EventHandler(this.LabelButton_Click);
            this.lblTicketHistory.MouseEnter += new System.EventHandler(this.LabelButton_MouseEnter);
            this.lblTicketHistory.MouseLeave += new System.EventHandler(this.LabelButton_MouseLeave);
            // 
            // lblPerformTowing
            // 
            this.lblPerformTowing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPerformTowing.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPerformTowing.Location = new System.Drawing.Point(0, 95);
            this.lblPerformTowing.Name = "lblPerformTowing";
            this.lblPerformTowing.Size = new System.Drawing.Size(147, 54);
            this.lblPerformTowing.TabIndex = 1;
            this.lblPerformTowing.Text = "Perform Towing";
            this.lblPerformTowing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPerformTowing.Click += new System.EventHandler(this.LabelButton_Click);
            this.lblPerformTowing.MouseEnter += new System.EventHandler(this.LabelButton_MouseEnter);
            this.lblPerformTowing.MouseLeave += new System.EventHandler(this.LabelButton_MouseLeave);
            // 
            // cmdExit
            // 
            this.cmdExit.FlatAppearance.BorderSize = 0;
            this.cmdExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExit.Location = new System.Drawing.Point(772, 0);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(40, 40);
            this.cmdExit.TabIndex = 2;
            this.cmdExit.Text = "X";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.Controls.Add(this.loader);
            this.pnlContent.ForeColor = System.Drawing.Color.Black;
            this.pnlContent.Location = new System.Drawing.Point(148, 42);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(664, 330);
            this.pnlContent.TabIndex = 3;
            // 
            // loader
            // 
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(234, 115);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(196, 101);
            this.loader.TabIndex = 0;
            this.loader.Visible = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(121)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(811, 371);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.lblPerformTowing);
            this.Controls.Add(this.lblTicketHistory);
            this.Controls.Add(this.lblMyTickets);
            this.Controls.Add(this.lblTitle);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tow Tickets";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmMain_Paint);
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMyTickets;
        private System.Windows.Forms.Label lblTicketHistory;
        private System.Windows.Forms.Label lblPerformTowing;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Panel pnlContent;
        private Loader loader;
    }
}

