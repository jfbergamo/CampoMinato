using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CampoMinato
{
    public partial class Campo : UserControl
    {
        Random rng = new Random((int)DateTimeOffset.Now.ToUnixTimeSeconds());
        
        private static Campo _campo;
        public static Campo campo { get => _campo; }

        public Campo()
        {
            _campo = this;
            InitializeComponent();
            CreaCampo();
            CalcolaCampo();
        }

        #region INIT

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

        #endregion

        #region EVENTI

        public void CoverPress(object sender, MouseEventArgs e)
        {
            Casella c = (Casella)((Button)sender).Tag;

            if (e.Button == MouseButtons.Right)
            {
                c.CambiaStato();
            }
            if (e.Button == MouseButtons.Left)
            {
                if (c.Bomba)
                {
                    c.Attivo = false;
                    ((frmMain)Tag).Running = false;
                }
                else
                {
                    DisattivaVicini(c);
                }
            }
        }

        #endregion

        public void DisattivaVicini(Casella c)
        {
            if (!c.Attivo)
            {
                return;
            }

            c.Attivo = false;

            if (!c.Bomba && c.Adiacenti == 0)
            {
                try
                {
                    DisattivaVicini(CasellaMatrice(((Point)c.Tag).X,     ((Point)c.Tag).Y - 1));
                    DisattivaVicini(CasellaMatrice(((Point)c.Tag).X,     ((Point)c.Tag).Y + 1));
                    DisattivaVicini(CasellaMatrice(((Point)c.Tag).X - 1, ((Point)c.Tag).Y    ));
                    DisattivaVicini(CasellaMatrice(((Point)c.Tag).X + 1, ((Point)c.Tag).Y    ));
                }
                catch (ArgumentOutOfRangeException) { }
            }

            return;
        }

        public void DisattivaTutto()
        {
            foreach (Casella c in Controls)
            {
                c.Enabled = false;
            }
        }

        private Casella CasellaMatrice(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
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
                    p = (Point)casella.Tag;
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
