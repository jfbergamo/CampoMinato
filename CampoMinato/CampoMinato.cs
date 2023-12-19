using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CampoMinato
{
    internal class CampoMinato
    {
        #region ATTRIBUTI

        private static int grandezza = 8;
        private static int bombe = 0;

        #endregion

        #region METODI

        public static int TrovaIndiceInMatrice(int x, int y)
        {
            return x + Grandezza * y;
        }

        public static Casella TrovaInMatrice(int x, int y, Panel pnl)
        {
            return (Casella)pnl.Controls[TrovaIndiceInMatrice(x, y)];
        }

        public static string AggiungiZeri(int n, int len)
        {
            string m = n.ToString();
            while (m.Length < len)
            {
                m = "0" + m;
            }
            return m;
        }

        public static int Adiacenti(string tag, Panel pnl)
        {
            int x, y, adiacenti = 0;
            {
                string[] a = tag.Split('|');
                x  = int.Parse(a[0]);
                y = int.Parse(a[1]);
            }
            
            for (int i = -1; i <= 1; ++i)
                for (int j = -1; j <= 1; ++j)
                    try
                    {
                        if (TrovaInMatrice(x + j, y + i, pnl).Bomba)
                            adiacenti++;
                    }
                    catch (ArgumentOutOfRangeException) { }
            return adiacenti;
        }

        public static void DisattivaCasella(Casella c, Panel caselle, Timer tmr)
        {
            c.Enabled = false;
            c.BackColor = Color.LightGray;
            if (c.Bomba)
            {
                c.Stato = StatoCasella.Bomba;
                tmr.Enabled = false;
                foreach (Casella casella in caselle.Controls)
                {
                    casella.Enabled = false;
                }
            }
            else
            {
                int adiacenti = Adiacenti(c.Tag.ToString(), caselle);
                c.Text = adiacenti > 0 ? adiacenti.ToString() : "";
            }
        }

        public static void DisattivaAdiacenti(Casella c, Panel pnl)
        {
            int x, y;
            {
                string[] temp = c.Tag.ToString().Split('|');
                x = int.Parse(temp[0]);
                y = int.Parse(temp[1]);
            }
            Casella adiacente;
            for (int i = -1; i <= 1; ++i)
            {
                for (int j = -1; j <= 1; ++j)
                {
                    try
                    {
                        adiacente = TrovaInMatrice(x + j, y + i, pnl);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        continue;
                    }
                    if (adiacente.Enabled && !adiacente.Bomba)
                    {
                        DisattivaCasella(adiacente, pnl, null);
                    }
                }
            }
        }

        #endregion

        #region PROPRIETA'

        public static int Grandezza { get => grandezza; }
        public static int Bombe { get => bombe; set => bombe = value; }

        #endregion
    }
}
