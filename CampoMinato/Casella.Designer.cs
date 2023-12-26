using System;
using System.Windows.Forms;

namespace CampoMinato
{
    partial class Casella
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
            this.lblText = new System.Windows.Forms.Label();
            this.btnCover = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblText
            // 
            this.lblText.BackColor = System.Drawing.Color.Transparent;
            this.lblText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblText.Font = new System.Drawing.Font("Cascadia Code SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.Location = new System.Drawing.Point(0, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(30, 30);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "0";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCover
            // 
            this.btnCover.BackColor = System.Drawing.Color.DarkGray;
            this.btnCover.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCover.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCover.Font = new System.Drawing.Font("Cascadia Code SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCover.Location = new System.Drawing.Point(0, 0);
            this.btnCover.Name = "btnCover";
            this.btnCover.Size = new System.Drawing.Size(30, 30);
            this.btnCover.TabIndex = 1;
            this.btnCover.UseVisualStyleBackColor = false;
            this.btnCover.MouseDown += new System.Windows.Forms.MouseEventHandler(Campo.campo.CoverPress);
            // 
            // Casella
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.btnCover);
            this.Controls.Add(this.lblText);
            this.Name = "Casella";
            this.Size = new System.Drawing.Size(30, 30);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Button btnCover;
    }
}
