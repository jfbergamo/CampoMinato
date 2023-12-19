using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CampoMinato
{
    internal class CampoMinato : Panel
    {
        #region ATTRIBUTI

        private int grandezza = 8;
        private int bombe = 0;
        private bool perso = false;

        #endregion
        
        #region METODI

        public int TrovaIndiceInMatrice(int x, int y)
        {
            return x + Grandezza * y;
        }

        public Casella TrovaInMatrice(int x, int y)
        {
            return (Casella)this.Controls[TrovaIndiceInMatrice(x, y)];
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

        public int Adiacenti(string tag)
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
                        if (TrovaInMatrice(x + j, y + i).Bomba)
                            adiacenti++;
                    }
                    catch (ArgumentOutOfRangeException) { }
            return adiacenti;
        }

        public void DisattivaCasella(Casella c)
        {
            c.Enabled = false;
            c.BackColor = Color.LightGray;
            if (c.Bomba)
            {
                c.Stato = StatoCasella.Bomba;
                Perso = true;
                foreach (Casella casella in this.Controls)
                {
                    casella.Enabled = false;
                }
            }
            else
            {
                int adiacenti = Adiacenti(c.Tag.ToString());
                c.Text = adiacenti > 0 ? adiacenti.ToString() : "";
            }
        }

        public void DisattivaAdiacenti(Casella c)
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
                        adiacente = TrovaInMatrice(x + j, y + i);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        continue;
                    }
                    if (adiacente.Enabled && !adiacente.Bomba)
                    {
                        DisattivaCasella(adiacente);
                    }
                }
            }
        }

        #endregion

        #region PROPRIETA'

        public int Grandezza { get => grandezza; }
        public int Bombe { get => bombe; set => bombe = value; }
        public bool Perso { get => perso; set => perso = value; }

        #endregion
    }
}
