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
        Random rng = new Random((int)DateTimeOffset.Now.ToUnixTimeSeconds());
        public static bool Perso = false;

        public frmMain()
        {
            InitializeComponent();
            pnlCampo.Tag = this;
            CreaCampo();
            CalcolaCampo();
        }

        public void CreaCampo()
        {
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    Casella casella = new Casella();
                    casella.Location = new Point(x * casella.Width, y * casella.Height);
                    casella.Tag = new Point(x, y);
                    casella.Bomba = rng.Next(0, 7) == 0;
                    pnlCampo.Controls.Add(casella);
                }
            }
        }

        public void CalcolaCampo()
        {
            foreach (Casella casella in pnlCampo.Controls)
            {
                if (!casella.Bomba)
                {
                    casella.Adiacenti(ContaAdiacenti(casella));
                }
                else
                {
                    casella.Adiacenti(-1);
                }
            }
        }

        public void DisattivaVicini()
        {
            return;
        }

        private Casella CasellaMatrice(int x, int y)
        {
            return (Casella)pnlCampo.Controls[x + 8 * y];
        }

        private int ContaAdiacenti(Casella casella)
        {
            int ads = 0;

            for (int i = -1; i <= 1; ++i)
            {
                for (int j = -1; j <= 1; ++j)
                {
                    try
                    {
                        if (CasellaMatrice(((Point)casella.Tag).Y + i, ((Point)casella.Tag).X + j).Bomba)
                            ads++;
                    }
                    catch (ArgumentOutOfRangeException) { }
                }
            }
            return ads;
        }
    }
}
