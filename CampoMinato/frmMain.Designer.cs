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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tmrSecs = new System.Windows.Forms.Timer(this.components);
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblBombe = new System.Windows.Forms.Label();
            this.tmrCheck = new System.Windows.Forms.Timer(this.components);
            this.btnRestart = new System.Windows.Forms.Button();
            this.campo = new CampoMinato.Campo();
            this.SuspendLayout();
            // 
            // tmrSecs
            // 
            this.tmrSecs.Interval = 1000;
            this.tmrSecs.Tick += new System.EventHandler(this.tmrTick_Tick);
            // 
            // lblTimer
            // 
            this.lblTimer.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblTimer.Font = new System.Drawing.Font("Cascadia Code SemiBold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.ForeColor = System.Drawing.Color.Red;
            this.lblTimer.Location = new System.Drawing.Point(52, 62);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(63, 38);
            this.lblTimer.TabIndex = 1;
            this.lblTimer.Text = "000";
            this.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBombe
            // 
            this.lblBombe.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblBombe.Font = new System.Drawing.Font("Cascadia Code SemiBold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBombe.ForeColor = System.Drawing.Color.Red;
            this.lblBombe.Location = new System.Drawing.Point(229, 62);
            this.lblBombe.Name = "lblBombe";
            this.lblBombe.Size = new System.Drawing.Size(63, 38);
            this.lblBombe.TabIndex = 2;
            this.lblBombe.Text = "000";
            this.lblBombe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmrCheck
            // 
            this.tmrCheck.Enabled = true;
            this.tmrCheck.Interval = 50;
            this.tmrCheck.Tick += new System.EventHandler(this.tmrCheck_Tick);
            // 
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnRestart.Font = new System.Drawing.Font("Cascadia Code SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestart.ForeColor = System.Drawing.SystemColors.Control;
            this.btnRestart.Location = new System.Drawing.Point(134, 39);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(76, 76);
            this.btnRestart.TabIndex = 3;
            this.btnRestart.Text = "😻";
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Visible = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // campo
            // 
            this.campo.BackColor = System.Drawing.Color.Transparent;
            this.campo.Location = new System.Drawing.Point(52, 154);
            this.campo.Name = "campo";
            this.campo.Size = new System.Drawing.Size(240, 240);
            this.campo.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.BackgroundImage = global::CampoMinato.Properties.Resources.bgm;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(344, 441);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.lblBombe);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.campo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Parto Fiorito";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Campo campo;
        private System.Windows.Forms.Timer tmrSecs;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label lblBombe;
        private System.Windows.Forms.Timer tmrCheck;
        private System.Windows.Forms.Button btnRestart;
    }
}