using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

// Bergamasco Jacopo, 4AIA, A.S. 2023-2024

namespace CampoMinato
{
    // UserControl che funge da classe di gestione
    // Contiene tutte le caselle e i metodi per manipolarle
    public partial class Campo : UserControl
    {

        #region ATTRIBUTI

        private static Campo c; // Attributo statico per autoriferirsi,
                                // serve alla singola casella per accedere al campo

        private int caselle;
        private int bombe;
        private int chiuse;
        
        #endregion

        #region INIT

        public Campo()
        {
            c = this; // Autoriferimento dell'attributo c
            InitializeComponent();
            CreaCampo();
            CalcolaCampo();
        }

        // Calcola alcuni parametri del campo, crea le celle le inserisce nel campo
        public void CreaCampo()
        {
            // Calcola il numero totale di caselle per la dimensione data dal config
            caselle = Config.Righe * Config.Colonne;
            bombe = (int)((double)Config.Riempimento / 100d * (double)caselle);
            chiuse = caselle; // Usato per controllare la vittoria

            // Crea e inserisce le caselle nel campo
            for (int y = 0; y < Config.Righe; y++)
            {
                for (int x = 0; x < Config.Colonne; x++)
                {
                    Casella casella = new Casella();
                    casella.Location = new Point(x * casella.Width, y * casella.Height);
                    casella.Tag = new Point(x, y); // Le coordinate della casella vengono inserite nel suo tag con oggetto Point
                    Controls.Add(casella);
                }
            }
        }

        // Inserisce le bombe e conta le bombe adiacenti
        public void CalcolaCampo()
        {
            // Estrazione delle caselle che avranno la bomba
            List<Casella> caselle = Config.ListFromControlCollection(Controls);
            Config.ListShuffle(caselle);
            for (int i = 0; i < bombe; i++)
            {
                caselle[i].Bomba = true;
            }

            // Calcolo delle bombe adiacenti per le caselle vuote
            foreach (Casella casella in Controls)
            {
                casella.Adiacenti = (!casella.Bomba) ? ContaAdiacenti(casella) : 0;
            }
        }

        #endregion

        #region EVENTI

        // Gestisce il click di una casella
        public void CasellaClick(object sender, MouseEventArgs e)
        {
            // Ottiene la casella prendendola dal tag del bottone all'interno della casella stessa
            Casella c = (Casella)((Button)sender).Tag;

            // Gestisce i vari click
            if (e.Button == MouseButtons.Right)
            {
                c.CambiaStato();
            }
            if (e.Button == MouseButtons.Left)
            {
                if (c.StatoCasella == StatoCasella.Empty)
                {
                    if (c.Bomba)
                    {
                        c.Attivo = false;
                        frmMain.Perso = true;
                    }
                    else
                    {
                        DisattivaVicini(c);
                    }
                }
            }
        }

        #endregion

        #region METODI

        // Disattiva tutte le caselle vuote vicine alla casella appena disattivata
        // Metodo ricorsivo
        public void DisattivaVicini(Casella c)
        {
            // Condizione di uscita per metodo ricorsivo
            if (!c.Attivo || c.StatoCasella != StatoCasella.Empty)
            {
                return;
            }

            // Disattiva la singola cella
            c.Attivo = false;
            chiuse--; // Serve per calcolare la vincita

            if (!c.Bomba && c.Adiacenti == 0)
            {
                // Logica per disattivare le caselle circostanti
                for (int x = -1; x < 2; x += 2)
                {
                    try
                    {
                        DisattivaVicini(CasellaMatrice(((Point)c.Tag).X + x, ((Point)c.Tag).Y));
                    }
                    catch (ArgumentOutOfRangeException) { }
                }
                for (int y = -1; y < 2; y += 2)
                {
                    try
                    {
                        DisattivaVicini(CasellaMatrice(((Point)c.Tag).X, ((Point)c.Tag).Y + y));
                    }
                    catch (ArgumentOutOfRangeException) { }
                }
                
            }

            return;
        }

        // Disattiva tutte le celle
        public void DisattivaTutto()
        {
            foreach (Casella c in Controls)
            {
                c.Enabled = false;
            }
        }

        // Mostra tutte le caselle che avevano la bomba
        // Serve per quando si perde
        public void MostraBombe()
        {
            foreach (Casella c in Controls)
            {
                if (c.Bomba)
                {
                    c.Attivo = false;
                }
            }
        }

        // Ottiene una casella dal campo date le sue coordinate
        private Casella CasellaMatrice(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Config.Colonne || y >= Config.Righe)
            {
                throw new ArgumentOutOfRangeException();
            }
            return (Casella)Controls[x + Config.Colonne * y];
        }

        // Conta tutte le bombe adiacenti alla casella data
        private int ContaAdiacenti(Casella casella)
        {
            int ads = 0;

            Point p;
            for (int i = -1; i <= 1; ++i)
            {
                for (int j = -1; j <= 1; ++j)
                {
                    p = (Point)casella.Tag;
                    try
                    {
                        if (CasellaMatrice(p.X + j, p.Y + i).Bomba)
                            ads++;
                    }
                    catch (ArgumentOutOfRangeException) { }
                }
            }
            return ads;
        }

        // Logica di controllo per la vittoria
        public bool Vittoria()
        {
            if (chiuse == bombe) // Se le caselle rimaste chiuse sono uguali al numero delle bombe...
            {
                foreach (Casella c in Controls)
                {
                    if (c.Attivo && c.StatoCasella != StatoCasella.Bandiera)
                    // ... tutte le caselle rimaste non sono state aperte
                    // e hanno la bandiera...
                    {
                        return false;
                    }
                }
                return true; // ...allora hai vinto.
            }
            return false;
        }

        // Svuota il campo e lo rigenera
        public void Reset()
        {
            SuspendLayout();
            Controls.Clear();
            bombe = 0;
            caselle = Config.Righe * Config.Colonne;
            CreaCampo();
            CalcolaCampo();
            ResumeLayout();
        }

        #endregion

        #region PROPRIETA'

        // Proprietà per attributo statico di autoriferimento, funzionamento già spiegato
        public static Campo campo { get => c; }

        public int Bombe { get => bombe; }

        #endregion

    }
}
