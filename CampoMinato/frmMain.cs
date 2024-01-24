using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Bergamasco Jacopo, 4AIA, A.S. 2023-2024

namespace CampoMinato
{
    // Finestra principale.
    public partial class frmMain : Form
    {
        #region ATTRIBUTI E PROPRIETA'

        // Attributo statico che segna lo stato della partita
        private static bool perso = false;
        public static bool Perso { get => perso; set => perso = value; }

        #endregion

        #region COSTRUTTORE E INIT

        // Costruttore
        // Carica il config dal file XML e inizializza il form
        public frmMain()
        {
            Config.LoadConfig();
            InitializeComponent();
        }

        // Esegue azioni preliminari di caricamento
        private void frmMain_Load(object sender, EventArgs e)
        {
            lblBombe.Text = campo.Bombe.ToString("000");
            DimensionaFinestra();
            Config.DumpConfig();
            tmrSecs.Start();
        }

        #endregion

        #region EVENTI

        // Tick che viene eseguito ogni secondo
        // Aumenta il cronometro in gioco
        private void tmrSecs_Tick(object sender, EventArgs e)
        {
            int secs = int.Parse(lblTimer.Text);
            secs++;
            lblTimer.Text = secs.ToString("000");
        }

        // Tick che viene eseguito 20 volte al secondo
        // Controlla lo stato di perdita e di vincita
        private void tmrCheck_Tick(object sender, EventArgs e)
        {
            // Controllo perdita
            if (perso)
            {
                tmrCheck.Stop();
                tmrSecs.Stop();
                campo.MostraBombe();
                campo.DisattivaTutto();
                btnRestart.Text = "💀";
                btnRestart.Visible = true;
            }
            else
            // Controllo vittoria
            {
                if (campo.Vittoria())
                {
                    tmrCheck.Stop();
                    tmrSecs.Stop();
                    btnRestart.Text = "😀";
                    btnRestart.Visible = true;
                    campo.DisattivaTutto();
                }
            }
        }

        // Esegue un reset del campo e azzera i parametri del form per riavviare la partita
        private void btnRestart_Click(object sender, EventArgs e)
        {
            campo.Reset();
            lblTimer.Text = "000";
            lblBombe.Text = campo.Bombe.ToString("000");
            perso = false;
            tmrSecs.Start();
            tmrCheck.Start();
            btnRestart.Visible = false;
            btnRestart.Text = "😻";

            DimensionaFinestra();
        }

        // Apre il menù di configurazione
        private void menuConfig_Click(object sender, EventArgs e)
        {
            // Ferma i tick
            tmrCheck.Stop();
            tmrSecs.Stop();

            frmMenu config = new frmMenu();
            if (config.ShowDialog() == DialogResult.OK)
            {
                // Se sono state apportate modifiche al config resetta il campo
                // Il metodo btnRestart_Click riavvia automaticamente anche i tick
                btnRestart_Click(null, null);
            }
            else
            {
                // Se non sono state apportate modifiche al config riavvia i tick e non fa nient'altro
                tmrCheck.Start();
                tmrSecs.Start();
            }
        }

        // Apre una finestra di dialogo per chiudere il programma
        private void menuEsci_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sei sicuro di voler uscire?",
                                "Uscire?",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question
                ) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        #endregion

        #region METODI

        // Ridimensiona il campo e riposiziona i pulsanti e le label in base al numero di righe e colonne
        private void DimensionaFinestra()
        {
            campo.Size = new Size(new Casella().Size.Width * Config.Colonne, new Casella().Size.Height * Config.Righe);
            btnRestart.Location = new Point(campo.Location.X + campo.Size.Width / 2 - btnRestart.Size.Width / 2, btnRestart.Location.Y);
            lblBombe.Location = new Point(campo.Location.X + campo.Size.Width - lblBombe.Size.Width, lblBombe.Location.Y);
            // 68, 86 = offset di pixel da aggiungere per mantenere la UI simmetrica
            this.Size = new Size(campo.Location.X + campo.Size.Width + 68, campo.Location.Y + campo.Size.Height + 86);
        }

        #endregion

    }
}
