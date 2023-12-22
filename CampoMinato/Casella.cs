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
        Empty,
        Bandiera,
        Dubbio,
    }

    public partial class Casella : UserControl
    {

        #region ATTRIBUTI

        private StatoCasella statoCasella;
        private bool bomba = false;

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
                DisattivaCella();
            }
        }

        #endregion

        #region METODI

        public void CambiaStato()
        {
            StatoCasella = (StatoCasella)(((int)statoCasella + 1) % Enum.GetNames(typeof(StatoCasella)).Length);
        }

        public void DisattivaCella()
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
                    ((frmMain)Tag).DisattivaVicini();
                }
            }
        }

        public void Adiacenti(int ads)
        {
            if (Bomba)
            {
                lblText.Text = "💣";
            }
            else
            {
                lblText.Text = (ads > 0) ? ads.ToString() : "";
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
        public bool Bomba { get => bomba; set => bomba = value; }

        #endregion

    }
}
