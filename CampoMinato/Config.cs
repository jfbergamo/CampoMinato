using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampoMinato
{
    internal class Config
    {
        private static int righe = 8;
        private static int colonne = 8;
        private static int riempimento = 40;

        public static int Righe { get => righe; set => righe = value; }
        public static int Colonne { get => colonne; set => colonne = value; }
        public static int Riempimento { get => riempimento; set => riempimento = value; }

        #region UTILITIES

        public static void ListShuffle<T>(List<T> list)
        {
            Random rng = new Random((int)DateTimeOffset.Now.ToUnixTimeSeconds());
            for (int i = list.Count - 1; i >= 0; i--)
            {
                int j = rng.Next(0, i + 1);
                T c = list[j];
                list[j] = list[i];
                list[i] = c;
            }
        }
        
        public static List<Casella> ListFromControlCollection(System.Windows.Forms.Control.ControlCollection controls)
        {
            List<Casella> list = new List<Casella>();
            foreach (Casella c in controls)
            {
                list.Add(c);
            }
            return list;
        }

        #endregion
    }
}
