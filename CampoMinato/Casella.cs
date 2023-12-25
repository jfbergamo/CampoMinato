using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;

namespace CampoMinato
{
    public enum StatoCasella
    {
        Empty,
        Bandiera,
        Dubbio,
    }

    public partial class Casella : System.Windows.Forms.UserControl
    {

        #region ATTRIBUTI

        private StatoCasella statoCasella;
        private bool bomba = false;
        private int adiancenti = 0;

        #endregion

        public Casella()
        {
            InitializeComponent();
            statoCasella = StatoCasella.Empty;
        }

        #region EVENTI

        private void CoverPress(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                CambiaStato();
            }
            if (e.Button == MouseButtons.Left)
            {
                Disattiva();
            }
        }

        #endregion

        #region METODI

        public void CambiaStato()
        {
            StatoCasella = (StatoCasella)(((int)statoCasella + 1) % Enum.GetNames(typeof(StatoCasella)).Length);
        }

        public void Disattiva()
        {
            Attivo = false;
            if (bomba)
            {
                frmMain.Perso = true;
            }
            else
            {
                if (lblText.Text != "")
                {
                    ((Campo)((Pair)Tag).Second).DisattivaVicini(this, false);
                }
            }
        }

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

        #region ATTRIBUTI

        public bool Attivo {  get => btnCover.Visible; set => btnCover.Visible = value; }
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
        public bool Bomba { get => bomba; set => bomba = value; }

        #endregion

    }
}
