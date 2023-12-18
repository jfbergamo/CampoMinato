using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CampoMinato
{
    public enum StatoCasella
    {
        Vuota,
        Bandiera,
        Bomba,
    }
    
    internal class Casella : Button
    {
        #region ATTRIBUTI

        private bool bomba;
        private StatoCasella statoCasella;

        private static Font numberFont = new Font("Cascadia Code SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);

        #endregion

        #region METODI

        public void AggiornaStato(StatoCasella stato)
        {
            statoCasella = stato;

            switch (statoCasella)
            {
                case StatoCasella.Vuota:
                    this.Text = "";
                    break;
                case StatoCasella.Bandiera:
                    this.Text = "🚩";
                    break;
                case StatoCasella.Bomba:
                    this.Text = "💣";
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region PROPRIETA'

        public bool Bomba { get => bomba; set => bomba = value; }
        public StatoCasella Stato {  get => statoCasella; set => AggiornaStato(value); }
        public static Font NumberFont { get => numberFont; }

        #endregion
    }
}
