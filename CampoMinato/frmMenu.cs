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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            numRighe.Minimum   = Config.MinRighe;
            numColonne.Minimum = Config.MinColonne;

            numRighe.Value       = Config.Righe;
            numColonne.Value     = Config.Colonne;
            numRiempimento.Value = Config.Riempimento;
        }

        private void btnConferma_Click(object sender, EventArgs e)
        {
            Config.Righe       = (int)numRighe.Value;
            Config.Colonne     = (int)numColonne.Value;
            Config.Riempimento = (int)numRiempimento.Value;
            Config.CheckConfig();
            Config.DumpConfig();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
