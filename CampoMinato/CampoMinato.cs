﻿using System;
using System.Collections.Generic;
using System.Linq;
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

        #endregion

        #region PROPRIETA'

        public static int Grandezza { get => grandezza; }
        public static int Bombe { get => bombe; set => bombe = value; }

        #endregion
    }
}
