namespace FleetTracking.Roster
{
    partial class MassAddStock
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabModels = new System.Windows.Forms.TabControl();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdRemove = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.dataGridViewStylizer = new FleetTracking.DataGridViewStylizer(this.components);
            this.loader = new FleetTracking.Loader();
            this.SuspendLayout();
            // 
            // tabModels
            // 
            this.tabModels.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabModels.Location = new System.Drawing.Point(0, 0);
            this.tabModels.Name = "tabModels";
            this.tabModels.SelectedIndex = 0;
            this.tabModels.Size = new System.Drawing.Size(638, 373);
            this.tabModels.TabIndex = 0;
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.Location = new System.Drawing.Point(563, 379);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 3;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdRemove
            // 
            this.cmdRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRemove.Location = new System.Drawing.Point(581, 2);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(55, 20);
            this.cmdRemove.TabIndex = 2;
            this.cmdRemove.Text = "Remove";
            this.cmdRemove.UseVisualStyleBackColor = true;
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAdd.Location = new System.Drawing.Point(524, 2);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(55, 20);
            this.cmdAdd.TabIndex = 1;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(191, 192);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(259, 20);
            this.lblWelcome.TabIndex = 3;
            this.lblWelcome.Text = "Click Add in the upper right to begin";
            // 
            // loader
            // 
            this.loader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(641, 405);
            this.loader.TabIndex = 4;
            this.loader.Visible = false;
            // 
            // MassAddStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.cmdRemove);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.tabModels);
            this.Controls.Add(this.loader);
            this.Name = "MassAddStock";
            this.Size = new System.Drawing.Size(641, 405);
            this.Load += new System.EventHandler(this.MassAddStock_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabModels;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdRemove;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Label lblWelcome;
        private DataGridViewStylizer dataGridViewStylizer;
        private Loader loader;
    }
}
