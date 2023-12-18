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

            for (int y = 0; y < CampoMinato.Grandezza; y++)
            {
                for (int x = 0; x < CampoMinato.Grandezza; x++)
                {
                    Casella casella = new Casella();
                    casella.UseVisualStyleBackColor = true;
                    
                    casella.Tag = x + "|" + y;
                    
                    casella.Size = new Size(30, 30);
                    casella.Location = new Point(casella.Width * x, casella.Height * y);
                    
                    casella.FlatStyle = FlatStyle.Popup;
                    casella.BackColor = Color.LightGreen;

                    casella.MouseDown += (sender, e) =>
                    {
                        Casella c = (Casella)sender;
                        MouseEventArgs args = (MouseEventArgs)e;
                        if (args.Button == MouseButtons.Left && c.Stato != StatoCasella.Bandiera)
                        {
                            if (c.Bomba)
                            {
                                c.Stato = StatoCasella.Bomba;
                                c.Enabled = false;
                            }
                            c.BackColor = Color.LightGray;
                            c.Enabled = false;
                            c.Font = Casella.NumberFont;
                            c.Text = 7.ToString();
                        }
                        else if (args.Button == MouseButtons.Right)
                        {
                            if (c.Stato == StatoCasella.Bandiera)
                            {
                                c.Stato = StatoCasella.Vuota;
                            }
                            else
                            {
                                c.Stato = StatoCasella.Bandiera;
                            }
                        }
                    };
                    pnlCampo.Controls.Add(casella);
                }
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            MessageBox.Show(CampoMinato.TrovaInMatrice(7, 2, pnlCampo).Tag.ToString());
        }
    }
}
