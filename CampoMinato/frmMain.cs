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
            /*
             * TODO:
             * - Rifare la casella come vuole Piazza
             * - Sfrutta la ricorsione per le celle che esplodono
             */
        }

        public void InitCampo()
        {
            pnlCampo.Controls.Clear();
            CampoMinato.Perso = false;
            btnPlay.Enabled = false;
            btnPlay.Text = "😻";
            pnlCampo.Bombe = 0;
            lblTime.Text = "000";

            for (int y = 0; y < pnlCampo.Grandezza; y++)
            {
                for (int x = 0; x < pnlCampo.Grandezza; x++)
                {
                    Casella casella = new Casella();
                    casella.Tag = x + "|" + y;
                    casella.Location = new Point(casella.Width * x, casella.Height * y);
                    
                    casella.Bomba = rng.Next(0, 7) == 0;
                    if (casella.Bomba)
                    {
                        pnlCampo.Bombe++;
                    }

                    casella.MouseDown += (sender, e) =>
                    {
                        pnlCampo.ControllaVittoria((Casella)((Button)sender).Tag);
                        if (CampoMinato.Perso)
                        {
                            tmrTick.Enabled = false;
                            btnPlay.Text = "🥶";
                            btnPlay.Enabled = true;
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
            MessageBox.Show(pnlCampo.CasellaDaCoordinate(7, 2).Tag.ToString());
        }
    }
}
