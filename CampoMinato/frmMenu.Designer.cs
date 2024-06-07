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
            this.numRighe = new System.Windows.Forms.NumericUpDown();
            this.numColonne = new System.Windows.Forms.NumericUpDown();
            this.numRiempimento = new System.Windows.Forms.NumericUpDown();
            this.btnConferma = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numRighe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColonne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRiempimento)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRighe
            // 
            this.lblRighe.Font = new System.Drawing.Font("Cascadia Code SemiBold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRighe.Location = new System.Drawing.Point(12, 79);
            this.lblRighe.Name = "lblRighe";
            this.lblRighe.Size = new System.Drawing.Size(145, 30);
            this.lblRighe.TabIndex = 0;
            this.lblRighe.Text = "Righe:";
            // 
            // lblColonne
            // 
            this.lblColonne.Font = new System.Drawing.Font("Cascadia Code SemiBold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColonne.Location = new System.Drawing.Point(12, 119);
            this.lblColonne.Name = "lblColonne";
            this.lblColonne.Size = new System.Drawing.Size(145, 30);
            this.lblColonne.TabIndex = 1;
            this.lblColonne.Text = "Colonne:";
            // 
            // lblRiempimento
            // 
            this.lblRiempimento.Font = new System.Drawing.Font("Cascadia Code SemiBold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRiempimento.Location = new System.Drawing.Point(12, 159);
            this.lblRiempimento.Name = "lblRiempimento";
            this.lblRiempimento.Size = new System.Drawing.Size(145, 30);
            this.lblRiempimento.TabIndex = 2;
            this.lblRiempimento.Text = "Riempimento:";
            // 
            // numRighe
            // 
            this.numRighe.Font = new System.Drawing.Font("Cascadia Code SemiBold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRighe.Location = new System.Drawing.Point(202, 79);
            this.numRighe.Name = "numRighe";
            this.numRighe.Size = new System.Drawing.Size(90, 28);
            this.numRighe.TabIndex = 4;
            // 
            // numColonne
            // 
            this.numColonne.Font = new System.Drawing.Font("Cascadia Code SemiBold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numColonne.Location = new System.Drawing.Point(202, 119);
            this.numColonne.Name = "numColonne";
            this.numColonne.Size = new System.Drawing.Size(90, 28);
            this.numColonne.TabIndex = 5;
            // 
            // numRiempimento
            // 
            this.numRiempimento.Font = new System.Drawing.Font("Cascadia Code SemiBold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRiempimento.Location = new System.Drawing.Point(202, 159);
            this.numRiempimento.Name = "numRiempimento";
            this.numRiempimento.Size = new System.Drawing.Size(90, 28);
            this.numRiempimento.TabIndex = 6;
            // 
            // btnConferma
            // 
            this.btnConferma.Location = new System.Drawing.Point(133, 228);
            this.btnConferma.Name = "btnConferma";
            this.btnConferma.Size = new System.Drawing.Size(76, 23);
            this.btnConferma.TabIndex = 7;
            this.btnConferma.Text = "Conferma";
            this.btnConferma.UseVisualStyleBackColor = true;
            this.btnConferma.Click += new System.EventHandler(this.btnConferma_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(342, 284);
            this.Controls.Add(this.btnConferma);
            this.Controls.Add(this.numRiempimento);
            this.Controls.Add(this.numColonne);
            this.Controls.Add(this.numRighe);
            this.Controls.Add(this.lblRiempimento);
            this.Controls.Add(this.lblColonne);
            this.Controls.Add(this.lblRighe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMenu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numRighe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColonne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRiempimento)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblRighe;
        private System.Windows.Forms.Label lblColonne;
        private System.Windows.Forms.Label lblRiempimento;
        private System.Windows.Forms.NumericUpDown numRighe;
        private System.Windows.Forms.NumericUpDown numColonne;
        private System.Windows.Forms.NumericUpDown numRiempimento;
        private System.Windows.Forms.Button btnConferma;
    }
}