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
            this.components = new System.ComponentModel.Container();
            this.btnTest = new System.Windows.Forms.Button();
            this.lblBombe = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.tmrTick = new System.Windows.Forms.Timer(this.components);
            this.pnlCampo = new CampoMinato();
            this.btnPlay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(106, 382);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(76, 23);
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Visible = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // lblBombe
            // 
            this.lblBombe.AutoSize = true;
            this.lblBombe.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblBombe.Font = new System.Drawing.Font("Roboto", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBombe.ForeColor = System.Drawing.Color.Red;
            this.lblBombe.Location = new System.Drawing.Point(24, 35);
            this.lblBombe.Name = "lblBombe";
            this.lblBombe.Size = new System.Drawing.Size(63, 33);
            this.lblBombe.TabIndex = 2;
            this.lblBombe.Text = "000";
            this.lblBombe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblTime.Font = new System.Drawing.Font("Roboto", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.Red;
            this.lblTime.Location = new System.Drawing.Point(201, 34);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(63, 33);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "000";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmrTick
            // 
            this.tmrTick.Enabled = true;
            this.tmrTick.Interval = 1000;
            this.tmrTick.Tick += new System.EventHandler(this.tmrTick_Tick);
            // 
            // pnlCampo
            // 
            this.pnlCampo.Bombe = 0;
            this.pnlCampo.Location = new System.Drawing.Point(24, 104);
            this.pnlCampo.Name = "pnlCampo";
            this.pnlCampo.Perso = false;
            this.pnlCampo.Size = new System.Drawing.Size(240, 240);
            this.pnlCampo.TabIndex = 0;
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.Silver;
            this.btnPlay.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPlay.Font = new System.Drawing.Font("Cascadia Code SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.Location = new System.Drawing.Point(112, 19);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(64, 64);
            this.btnPlay.TabIndex = 4;
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(288, 424);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblBombe);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.pnlCampo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "ICA1 Simulator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CampoMinato pnlCampo;
        //private System.Windows.Forms.Panel pnlCampo;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label lblBombe;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer tmrTick;
        private System.Windows.Forms.Button btnPlay;
    }
}

