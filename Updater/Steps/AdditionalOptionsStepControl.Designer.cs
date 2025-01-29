﻿
namespace Updater.Steps
{
    partial class AdditionalOptionsStepControl
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
            this.chkDesktop = new System.Windows.Forms.CheckBox();
            this.chkStartMenu = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkInstallMusic = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkDesktop
            // 
            this.chkDesktop.AutoSize = true;
            this.chkDesktop.Location = new System.Drawing.Point(22, 121);
            this.chkDesktop.Name = "chkDesktop";
            this.chkDesktop.Size = new System.Drawing.Size(221, 17);
            this.chkDesktop.TabIndex = 0;
            this.chkDesktop.Text = "Create a MesaSuite icon on the Desktop.";
            this.chkDesktop.UseVisualStyleBackColor = true;
            this.chkDesktop.CheckedChanged += new System.EventHandler(this.chkDesktop_CheckedChanged);
            // 
            // chkStartMenu
            // 
            this.chkStartMenu.AutoSize = true;
            this.chkStartMenu.Location = new System.Drawing.Point(22, 155);
            this.chkStartMenu.Name = "chkStartMenu";
            this.chkStartMenu.Size = new System.Drawing.Size(215, 17);
            this.chkStartMenu.TabIndex = 0;
            this.chkStartMenu.Text = "Create a Start Menu icon for MesaSuite.";
            this.chkStartMenu.UseVisualStyleBackColor = true;
            this.chkStartMenu.CheckedChanged += new System.EventHandler(this.chkStartMenu_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Additional Options";
            // 
            // chkInstallMusic
            // 
            this.chkInstallMusic.AutoSize = true;
            this.chkInstallMusic.Location = new System.Drawing.Point(22, 189);
            this.chkInstallMusic.Name = "chkInstallMusic";
            this.chkInstallMusic.Size = new System.Drawing.Size(160, 17);
            this.chkInstallMusic.TabIndex = 0;
            this.chkInstallMusic.Text = " Play installation soundtrack.";
            this.chkInstallMusic.UseVisualStyleBackColor = true;
            this.chkInstallMusic.CheckedChanged += new System.EventHandler(this.chkInstallMusic_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Why not set the mood with some music while you wait?";
            // 
            // AdditionalOptionsStepControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkInstallMusic);
            this.Controls.Add(this.chkStartMenu);
            this.Controls.Add(this.chkDesktop);
            this.Name = "AdditionalOptionsStepControl";
            this.Size = new System.Drawing.Size(538, 318);
            this.Load += new System.EventHandler(this.AdditionalOptionsStepControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkDesktop;
        private System.Windows.Forms.CheckBox chkStartMenu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkInstallMusic;
        private System.Windows.Forms.Label label1;
    }
}
