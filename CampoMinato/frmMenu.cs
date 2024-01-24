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
    // Menù di configurazione
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        // Imposta i valori minimi, massimi e attuali dei NumericUpDown in base alla configurazione in Config
        private void frmMenu_Load(object sender, EventArgs e)
        {
            numRighe.Minimum   = Config.MinRighe;
            numColonne.Minimum = Config.MinColonne;

            numRighe.Maximum   = Config.MaxRighe;
            numColonne.Maximum = Config.MaxColonne;

            numRighe.Value       = Config.Righe;
            numColonne.Value     = Config.Colonne;
            numRiempimento.Value = Config.Riempimento;
        }

        // Imposta i campi di Config con i valori dei NumericUpDown
        private void btnConferma_Click(object sender, EventArgs e)
        {
            Config.Righe       = (int)numRighe.Value;
            Config.Colonne     = (int)numColonne.Value;
            Config.Riempimento = (int)numRiempimento.Value;
            Config.CheckConfig(); // Controlla la nuova configurazione
            Config.DumpConfig(); // Esporta la nuova configurazione in un file XML
            DialogResult = DialogResult.OK; // Imposta un codice di uscita per far capire a frmMain
                                            // che sono state apportate modifiche al config
            Close(); // Chiude il menù
        }
    }
}
