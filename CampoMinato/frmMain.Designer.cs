namespace CampoMinato
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
            this.pnlCampo = new System.Windows.Forms.Panel();
            this.btnTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlCampo
            // 
            this.pnlCampo.Location = new System.Drawing.Point(24, 137);
            this.pnlCampo.Name = "pnlCampo";
            this.pnlCampo.Size = new System.Drawing.Size(240, 240);
            this.pnlCampo.TabIndex = 0;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(78, 81);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(288, 450);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.pnlCampo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmMain";
            this.Text = "ICA1 Simulator";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCampo;
        private System.Windows.Forms.Button btnTest;
    }
}

