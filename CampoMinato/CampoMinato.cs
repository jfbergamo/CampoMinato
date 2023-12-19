using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CampoMinato
{
    internal class CampoMinato : System.Windows.Forms.Panel
    {
        #region ATTRIBUTI

        private static int grandezza = 8;
        private static int bombe = 0;

        #endregion

        public CampoMinato() : base() { }

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

        #endregion

        #region PROPRIETA'

        public static int Grandezza { get => grandezza; }
        public static int Bombe { get => bombe; set => bombe = value; }

        #endregion
    }
}
