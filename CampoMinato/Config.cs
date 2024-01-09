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

        public static int Righe { get => righe; set => righe = value; }
        public static int Colonne { get => colonne; set => colonne = value; }
    }
}
