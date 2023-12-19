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
            InitCampo();
        }

        public void InitCampo()
        {
            pnlCampo.Controls.Clear();
            pnlCampo.Perso = false;
            btnPlay.Enabled = false;
            btnPlay.Text = "😻";
            pnlCampo.Bombe = 0;
            lblTime.Text = "000";

            for (int y = 0; y < pnlCampo.Grandezza; y++)
            {
                for (int x = 0; x < pnlCampo.Grandezza; x++)
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
                        pnlCampo.Bombe++;
                    }

                    casella.MouseDown += (sender, e) =>
                    {
                        Casella c = (Casella)sender;
                        MouseEventArgs args = (MouseEventArgs)e;
                        if (args.Button == MouseButtons.Left && c.Stato != StatoCasella.Bandiera)
                        {
                            pnlCampo.DisattivaCasella(c);
                            if (pnlCampo.Perso)
                            {
                                tmrTick.Enabled = false;
                                btnPlay.Text = "🥶";
                                btnPlay.Enabled = true;
                            }
                            pnlCampo.DisattivaAdiacenti(c);
                        }
                        else if (args.Button == MouseButtons.Right)
                        {
                            c.ScorriStato();
                        }
                    };
                    pnlCampo.Controls.Add(casella);
                }
            }
            lblBombe.Text = CampoMinato.AggiungiZeri(pnlCampo.Bombe, 3);
            tmrTick.Enabled = true;
        }

        private void tmrTick_Tick(object sender, EventArgs e)
        {
            lblTime.Text = CampoMinato.AggiungiZeri(int.Parse(lblTime.Text) + 1, 3);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            InitCampo();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            MessageBox.Show(pnlCampo.TrovaInMatrice(7, 2).Tag.ToString());
        }
    }
}
