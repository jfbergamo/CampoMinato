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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private bool perso = false;
        public bool Perso { get => perso; set => perso = value; }

        private void frmMain_Load(object sender, EventArgs e)
        {
            campo.Tag = this;
            tmrSecs.Start();
            lblBombe.Text = campo.Bombe.ToString("000");
        }

        private void tmrTick_Tick(object sender, EventArgs e)
        {
            int secs = int.Parse(lblTimer.Text);
            secs++;
            lblTimer.Text = secs.ToString("000");
        }

        private void tmrCheck_Tick(object sender, EventArgs e)
        {
            // Controllo perdita
            if (perso)
            {
                tmrCheck.Stop();
                tmrSecs.Stop();
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
        }
    }
}
