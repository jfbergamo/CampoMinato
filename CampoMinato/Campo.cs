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

        #region ATTRIBUTI

        Random rng = new Random((int)DateTimeOffset.Now.ToUnixTimeSeconds());
        
        private static Campo _campo;

        private int bombe = 0;
        private int chiuse;
        
        #endregion

        #region INIT

        public Campo()
        {
            _campo = this;
            InitializeComponent();
            CreaCampo();
            CalcolaCampo();
        }

        public void CreaCampo()
        {
            bool bomba;
            chiuse = Config.Righe * Config.Colonne;
            for (int y = 0; y < Config.Righe; y++)
            {
                for (int x = 0; x < Config.Colonne; x++)
                {
                    Casella casella = new Casella();
                    casella.Location = new Point(x * casella.Width, y * casella.Height);
                    casella.Tag = new Point(x, y);
                    bomba = rng.Next(0, 7) == 0;
                    casella.Bomba = bomba;
                    if (bomba) bombe++;
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

        public void CasellaClick(object sender, MouseEventArgs e)
        {
            Casella c = (Casella)((Button)sender).Tag;

            if (e.Button == MouseButtons.Right)
            {
                c.CambiaStato();
            }
            if (e.Button == MouseButtons.Left)
            {
                if (c.StatoCasella == StatoCasella.Empty)
                {
                    if (c.Bomba)
                    {
                        c.Attivo = false;
                        ((frmMain)Tag).Perso = true;
                    }
                    else
                    {
                        DisattivaVicini(c);
                    }
                }
            }
        }

        #endregion

        #region METODI

        public void DisattivaVicini(Casella c)
        {
            if (!c.Attivo || c.StatoCasella != StatoCasella.Empty)
            {
                return;
            }

            c.Attivo = false;
            chiuse--;

            if (!c.Bomba && c.Adiacenti == 0)
            {
                for (int x = -1; x < 2; x += 2)
                {
                    try
                    {
                        DisattivaVicini(CasellaMatrice(((Point)c.Tag).X + x, ((Point)c.Tag).Y));
                    }
                    catch (ArgumentOutOfRangeException) { }
                }
                for (int y = -1; y < 2; y += 2)
                {
                    try
                    {
                        DisattivaVicini(CasellaMatrice(((Point)c.Tag).X, ((Point)c.Tag).Y + y));
                    }
                    catch (ArgumentOutOfRangeException) { }
                }
                
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
            if (x < 0 || y < 0 || x >= Config.Colonne || y >= Config.Righe)
            {
                throw new ArgumentOutOfRangeException();
            }
            return (Casella)Controls[x + Config.Colonne * y];
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

        public bool Vittoria()
        {
            if (chiuse == bombe)
            {
                foreach (Casella c in Controls)
                {
                    if (c.Attivo && c.StatoCasella != StatoCasella.Bandiera)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public void Reset()
        {
            Controls.Clear();
            bombe = 0;
            CreaCampo();
            CalcolaCampo();
        }

        #endregion

        #region PROPRIETA'

        public static Campo campo { get => _campo; }

        public int Bombe { get => bombe; }

        #endregion

    }
}
