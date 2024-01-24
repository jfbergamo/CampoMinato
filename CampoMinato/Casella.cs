using System;
using System.Windows.Forms;

// Bergamasco Jacopo, 4AIA, A.S. 2023-2024

namespace CampoMinato
{
    public enum StatoCasella
    {
        Empty,
        Bandiera,
        Dubbio,
    }

    // UserControl che rappresenta la casella
    public partial class Casella : UserControl
    {

        #region ATTRIBUTI

        private StatoCasella statoCasella;
        private bool bomba = false;
        private int adiancenti = 0;

        #endregion

        #region COSTRUTTORE

        // Costruttore, imposta alcune cose di default
        public Casella()
        {
            InitializeComponent();
            statoCasella = StatoCasella.Empty;
            btnCover.Tag = this; // Autoriferimento della casella all'interno del buttone della casella stessa
        }

        #endregion

        #region METODI

        // Cicla attraverso gli stati di una casella
        public void CambiaStato()
        {
            StatoCasella = (StatoCasella)(((int)statoCasella + 1) % Enum.GetNames(typeof(StatoCasella)).Length);
        }

        // Imposta cosa visualizzare quando la casella verrà aperta
        private void Display()
        {
            if (Bomba)
            {
                lblText.Text = "💣";
            }
            else
            {
                lblText.Text = (adiancenti > 0) ? adiancenti.ToString() : "";
            }
        }

        #endregion

        #region PROPRIETA'

        // Associa lo stato attivo della casella alla visibilità del bottone
        public bool Attivo { get => btnCover.Visible; set => btnCover.Visible = value; }

        public string Testo { get => lblText.Text; set => lblText.Text = value; }

        // Sovrascrive lo stato di abilitazione della casella con quello del suo bottone
        public new bool Enabled { get => btnCover.Enabled; set => btnCover.Enabled = value; }

        public bool Bomba { get => bomba; set => bomba = value; }

        // Proprietà che implementa la visualizzazione della casella dal cambiamento del suo stato
        public StatoCasella StatoCasella
        {
            get => statoCasella;
            set
            {
                statoCasella = value;
                switch (statoCasella)
                {
                    case StatoCasella.Empty:
                        btnCover.Text = "";
                        break;
                    case StatoCasella.Bandiera:
                        btnCover.Text = "🚩";
                        break;
                    case StatoCasella.Dubbio:
                        btnCover.Text = "?";
                        break;
                }
            }
        }

        public int Adiacenti
        {
            get => adiancenti;
            set
            {
                if (!bomba)
                {
                    int ads = Math.Abs(value);
                    adiancenti = (ads > 8) ? 0 : ads;
                }
                Display();
            }
        }

        #endregion

    }
}
