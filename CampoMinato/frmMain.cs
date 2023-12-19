using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CampoMinato
{
    public partial class frmMain : Form
    {
        private Random rng = new Random((int)DateTimeOffset.Now.ToUnixTimeSeconds());

        public frmMain()
        {
            InitializeComponent();

            for (int y = 0; y < CampoMinato.Grandezza; y++)
            {
                for (int x = 0; x < CampoMinato.Grandezza; x++)
                {
                    Casella casella = new Casella();
                    casella.UseVisualStyleBackColor = true;
                    
                    casella.Tag = x + "|" + y;
                    
                    casella.Size = new Size(30, 30);
                    casella.Location = new Point(casella.Width * x, casella.Height * y);
                    
                    casella.FlatStyle = FlatStyle.Popup;
                    casella.BackColor = Color.LightGreen;

                    casella.Font = Casella.NumberFont;

                    casella.Bomba = rng.Next(0, 7) == 0;
                    if (casella.Bomba)
                    {
                        CampoMinato.Bombe++;
                    }

                    casella.MouseDown += (sender, e) =>
                    {
                        Casella c = (Casella)sender;
                        MouseEventArgs args = (MouseEventArgs)e;
                        if (args.Button == MouseButtons.Left && c.Stato != StatoCasella.Bandiera)
                        {
                            CampoMinato.DisattivaCasella(c, pnlCampo);
                            CampoMinato.DisattivaAdiacenti(c, pnlCampo);
                        }
                        else if (args.Button == MouseButtons.Right)
                        {
                            c.ScorriStato();
                        }
                    };
                    pnlCampo.Controls.Add(casella);
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblBombe.Text = CampoMinato.AggiungiZeri(CampoMinato.Bombe, 3);
        }

        private void tmrTick_Tick(object sender, EventArgs e)
        {
            lblTime.Text = CampoMinato.AggiungiZeri(int.Parse(lblTime.Text) + 1, 3);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            MessageBox.Show(CampoMinato.TrovaInMatrice(7, 2, pnlCampo).Tag.ToString());
        }
    }
}
