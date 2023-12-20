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

        private static bool perso = false;
        private static CampoMinato pannello;

        #endregion
        
        #region METODI

        public int IndiceDaCoordinate(int x, int y)
        {
            return x + Grandezza * y;
        }

        public Casella CasellaDaCoordinate(int x, int y)
        {
            return (Casella)this.Controls[IndiceDaCoordinate(x, y)];
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

        public int ContaAdiacenti(Casella c)
        {
            int x, y, adiacenti = 0;
            {
                string[] temp = c.Tag.ToString().Split('|');
                x = int.Parse(temp[0]);
                y = int.Parse(temp[1]);
            }
            
            for (int i = -1; i <= 1; ++i)
            {
                for (int j = -1; j <= 1; ++j)
                {
                    try
                    {
                        if (CasellaDaCoordinate(x + j, y + i).Bomba)
                        {
                            adiacenti++;
                        }
                    }
                    catch (ArgumentOutOfRangeException) { }
                }
            }
            return adiacenti;
        }

        public void ControllaVittoria(Casella c)
        {
            if (Perso)
            {
                frmMain.frm.Perdi();
                
                foreach (Casella casella in Controls)
                {
                    casella.Enabled = false;
                }
            }
            else
            {
                int adiacenti = ContaAdiacenti(c);
                c.Text = (adiacenti > 0) ? adiacenti.ToString() : "";
                DisattivaAdiacenti(c);
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
                        adiacente = CasellaDaCoordinate(x + j, y + i);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        continue;
                    }
                    if (adiacente.Enabled && !adiacente.Bomba)
                    {
                        adiacente.Disattiva();
                    }
                }
            }
        }

        #endregion

        #region PROPRIETA'

        public int Grandezza { get => grandezza; }
        public int Bombe { get => bombe; set => bombe = value; }
        
        public static bool Perso { get => perso; set => perso = value; }
        public static CampoMinato Campo { get => pannello; set => pannello = value; }

        #endregion
    }
}
