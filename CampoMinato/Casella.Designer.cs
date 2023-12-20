using System.Drawing;

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
            this.btnControl = new System.Windows.Forms.Button();
            this.lblControl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnControl
            // 
            this.btnControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnControl.ForeColor = System.Drawing.Color.Transparent;
            this.btnControl.Location = new System.Drawing.Point(0, 0);
            this.btnControl.Name = "btnControl";
            this.btnControl.Size = new System.Drawing.Size(389, 214);
            this.btnControl.TabIndex = 0;
            this.btnControl.UseVisualStyleBackColor = true;
            this.btnControl.MouseDown += Press;
            this.btnControl.Tag = this;
            // 
            // lblControl
            // 
            this.lblControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblControl.Location = new System.Drawing.Point(0, 0);
            this.lblControl.Name = "lblControl";
            this.lblControl.Size = new System.Drawing.Size(389, 214);
            this.lblControl.TabIndex = 1;
            this.lblControl.Font = new Font("Cascadia Code SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.lblControl.Text = "label1";
            // 
            // Casella
            // 
            this.Bomba = false;
            this.Stato = StatoCasella.Vuota;

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblControl);
            this.Controls.Add(this.btnControl);
            this.Name = "Casella";
            this.Size = new System.Drawing.Size(389, 214);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnControl;
        private System.Windows.Forms.Label lblControl;
    }
}
