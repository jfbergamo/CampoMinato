using System;
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

        #endregion

        #region PROPRIETA'

        public static int Grandezza { get => grandezza; }

        #endregion
    }
}
