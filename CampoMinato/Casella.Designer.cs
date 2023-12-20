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
            this.btnControl.Size = new System.Drawing.Size(40, 40);
            this.btnControl.TabIndex = 0;
            this.btnControl.Tag = this;
            this.btnControl.UseVisualStyleBackColor = true;
            // 
            // lblControl
            // 
            this.lblControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblControl.Font = new System.Drawing.Font("Cascadia Code SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControl.Location = new System.Drawing.Point(0, 0);
            this.lblControl.Name = "lblControl";
            this.lblControl.Size = new System.Drawing.Size(40, 40);
            this.lblControl.TabIndex = 1;
            this.lblControl.Text = "0";
            this.lblControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblControl.BackColor = System.Drawing.Color.DimGray;
            // 
            // Casella
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnControl);
            this.Controls.Add(this.lblControl);
            this.Name = "Casella";
            this.Size = new System.Drawing.Size(40, 40);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnControl;
        private System.Windows.Forms.Label lblControl;
    }
}
