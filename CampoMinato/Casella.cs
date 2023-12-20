using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        PuntoDomanda,
        Bomba,
    }

    public partial class Casella : UserControl
    {
        #region ATTRIBUTI

        private static Color enabledColor = Color.Silver;
        private static Color disabledColor = Color.LightGray;

        private bool bomba;
        private StatoCasella statoCasella;

        #endregion

        #region COSTRUTTORI

        public Casella()
        {
            InitializeComponent();
        }

        #endregion

        #region METODI

        public void ScorriStato()
        {
            Stato = (StatoCasella)(((int)Stato + 1) % (int)StatoCasella.Bomba);
        }

        public void Disattiva()
        {
            Enabled = false;
            BackColor = disabledColor;
            if (Bomba)
            {
                Stato = StatoCasella.Bomba;
                CampoMinato.Perso = true;
            }
            else
            {
                
            }
        }

        #endregion

        #region EVENTI

        private void Press(object sender, EventArgs e)
        {
            Casella c = (Casella)((Button)sender).Tag;
            MouseEventArgs args = (MouseEventArgs)e;
            if (args.Button == MouseButtons.Left && c.Stato != StatoCasella.Bandiera)
            {
                c.Disattiva();
                
            }
            else if (args.Button == MouseButtons.Right)
            {
                c.ScorriStato();
            }
        }

        #endregion

        #region PROPRIETA'

        public override string Text { get => lblControl.Text; set => lblControl.Text = value; }
        
        public bool Bomba { get => bomba; set => bomba = value; }
        public StatoCasella Stato
        {
            get => statoCasella;
            set
            {
                statoCasella = value;
                switch (statoCasella)
                {
                    case StatoCasella.Vuota:
                        Text = "";
                        break;
                    case StatoCasella.Bandiera:
                        Text = "🚩";
                        break;
                    case StatoCasella.PuntoDomanda:
                        Text = "?";
                        break;
                    case StatoCasella.Bomba:
                        Text = "💣";
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion
    }
}
