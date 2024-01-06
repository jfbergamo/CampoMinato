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

        private bool running = true;
        public bool Running { get => running; set => running = value; }

        private void frmMain_Load(object sender, EventArgs e)
        {
            campo.Tag = this;
            tmrTick.Start();
        }

        private void tmrTick_Tick(object sender, EventArgs e)
        {
            if (running)
            {

            }
            else
            {
                tmrTick.Stop();
            }
        }
    }
}
