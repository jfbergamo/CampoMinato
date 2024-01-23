namespace CampoMinato
{
    partial class frmMenu
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
            this.lblRighe = new System.Windows.Forms.Label();
            this.lblColonne = new System.Windows.Forms.Label();
            this.lblRiempimento = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblRighe
            // 
            this.lblRighe.AutoSize = true;
            this.lblRighe.Font = new System.Drawing.Font("Cascadia Code SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRighe.Location = new System.Drawing.Point(32, 59);
            this.lblRighe.Name = "lblRighe";
            this.lblRighe.Size = new System.Drawing.Size(84, 28);
            this.lblRighe.TabIndex = 0;
            this.lblRighe.Text = "Righe:";
            // 
            // lblColonne
            // 
            this.lblColonne.AutoSize = true;
            this.lblColonne.Font = new System.Drawing.Font("Cascadia Code SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColonne.Location = new System.Drawing.Point(32, 110);
            this.lblColonne.Name = "lblColonne";
            this.lblColonne.Size = new System.Drawing.Size(108, 28);
            this.lblColonne.TabIndex = 1;
            this.lblColonne.Text = "Colonne:";
            // 
            // lblRiempimento
            // 
            this.lblRiempimento.AutoSize = true;
            this.lblRiempimento.Font = new System.Drawing.Font("Cascadia Code SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRiempimento.Location = new System.Drawing.Point(32, 189);
            this.lblRiempimento.Name = "lblRiempimento";
            this.lblRiempimento.Size = new System.Drawing.Size(156, 28);
            this.lblRiempimento.TabIndex = 2;
            this.lblRiempimento.Text = "Riempimento:";
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(310, 332);
            this.Controls.Add(this.lblRiempimento);
            this.Controls.Add(this.lblColonne);
            this.Controls.Add(this.lblRighe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMenu";
            this.Text = "frmMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRighe;
        private System.Windows.Forms.Label lblColonne;
        private System.Windows.Forms.Label lblRiempimento;
    }
}