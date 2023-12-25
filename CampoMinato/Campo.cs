using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;

namespace CampoMinato
{
    public partial class Campo : System.Windows.Forms.UserControl
    {
        Random rng = new Random((int)DateTimeOffset.Now.ToUnixTimeSeconds());

        public Campo()
        {
            InitializeComponent();
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
                    casella.Tag = new Pair(new Point(x, y), this);
                    casella.Bomba = rng.Next(0, 7) == 0;
                    Controls.Add(casella);
                }
            }
        }

        public void CalcolaCampo()
        {
            foreach (Casella casella in Controls)
            {
                casella.Adiacenti = (!casella.Bomba) ? ContaAdiacenti(casella) : 0;
            }
        }

        public void DisattivaVicini(Casella c, bool checkActive = true)
        {
            if (checkActive && !c.Attivo)
            {
                return;
            }
            if (!c.Bomba && c.Adiacenti == 0)
            {
                c.Disattiva();

                Point p;
                for (int i = -1; i <= 1; ++i)
                {
                    for (int j = -1; j <= 1; ++j)
                    {
                        p = (Point)((Pair)c.Tag).First;
                        try
                        {
                            DisattivaVicini(CasellaMatrice(p.X + j, p.Y + i));
                        }
                        catch (ArgumentOutOfRangeException) { }
                    }
                }
            }

            return;
        }

        private Casella CasellaMatrice(int x, int y)
        {
            return (Casella)Controls[x + 8 * y];
        }

        private int ContaAdiacenti(Casella casella)
        {
            int ads = 0;

            Point p;
            for (int i = -1; i <= 1; ++i)
            {
                for (int j = -1; j <= 1; ++j)
                {
                    p = (Point)((Pair)casella.Tag).First;
                    try
                    {
                        if (CasellaMatrice(p.X + j, p.Y + i).Bomba)
                            ads++;
                    }
                    catch (ArgumentOutOfRangeException) { }
                }
            }
            return ads;
        }
    }
}
