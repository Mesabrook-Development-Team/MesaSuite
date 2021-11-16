
namespace MesaSuite.Common
{
    partial class frmCrashReport
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
            this.lblProgram = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtException = new System.Windows.Forms.TextBox();
            this.cmdRestart = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblProgram
            // 
            this.lblProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgram.Location = new System.Drawing.Point(12, 9);
            this.lblProgram.Name = "lblProgram";
            this.lblProgram.Size = new System.Drawing.Size(776, 37);
            this.lblProgram.TabIndex = 0;
            this.lblProgram.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(1, 46);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(798, 20);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "has crashed.  Reporting to MesaSuite development team...";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Crash Details:";
            // 
            // txtException
            // 
            this.txtException.BackColor = System.Drawing.Color.Tomato;
            this.txtException.Location = new System.Drawing.Point(12, 83);
            this.txtException.Multiline = true;
            this.txtException.Name = "txtException";
            this.txtException.ReadOnly = true;
            this.txtException.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtException.Size = new System.Drawing.Size(776, 326);
            this.txtException.TabIndex = 3;
            // 
            // cmdRestart
            // 
            this.cmdRestart.Location = new System.Drawing.Point(713, 415);
            this.cmdRestart.Name = "cmdRestart";
            this.cmdRestart.Size = new System.Drawing.Size(75, 23);
            this.cmdRestart.TabIndex = 4;
            this.cmdRestart.Text = "Restart";
            this.cmdRestart.UseVisualStyleBackColor = true;
            this.cmdRestart.Click += new System.EventHandler(this.cmdRestart_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Location = new System.Drawing.Point(632, 415);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(75, 23);
            this.cmdExit.TabIndex = 4;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // frmCrashReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tomato;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.cmdRestart);
            this.Controls.Add(this.txtException);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblProgram);
            this.Name = "frmCrashReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MesaSuite Crash";
            this.Load += new System.EventHandler(this.frmCrashReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdRestart;
        private System.Windows.Forms.Button cmdExit;
        public System.Windows.Forms.Label lblProgram;
        public System.Windows.Forms.TextBox txtException;
    }
}