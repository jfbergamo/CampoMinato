﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CampoMinato
{
    internal static class Config
    {
        #region PROPRIETA'

        private static int righe = 8;
        private static int colonne = 8;
        private static int riempimento = 12;

        private static string configFilePath = "config.yml";

        public static int Righe { get => righe; set => righe = value; }
        public static int Colonne { get => colonne; set => colonne = value; }
        public static int Riempimento { get => riempimento; set => riempimento = value; }

        // Limiti minimi calcolati perché non si rompa la UI
        public static int MinRighe { get => 4; }
        public static int MinColonne { get => 7; }

        // Limiti massimi calcolati perché stia nello schermo
        // ATTENZIONE: valori così alti probabilmente friggono i pc più scarsi
        public static int MaxRighe { get => 25; }
        public static int MaxColonne { get => 50; }

        #endregion

        #region DATA

        public static void CheckConfig()
        {
            if (righe < MinRighe || righe > MaxRighe)
            {
                righe = MinRighe;
            }

            if (colonne < MinColonne || colonne > MaxColonne)
            {
                colonne = MinColonne;
            }

            if (riempimento < 0 || riempimento > 100)
            {
                riempimento = 12;
            }
        }

        #endregion

        #region LOADING

        public static void DumpConfig()
        {
            try
            {
                XmlTextWriter writer = new XmlTextWriter(configFilePath, System.Text.Encoding.UTF8);
                
                writer.WriteStartDocument(true);
                writer.WriteStartElement("PartoMinato");
            
                writer.WriteStartElement("Righe");
                    writer.WriteString(Righe.ToString());
                writer.WriteEndElement();
            
                writer.WriteStartElement("Colonne");
                    writer.WriteString(Colonne.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("Riempimento");
                    writer.WriteString(Riempimento.ToString());
                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }
            catch { }
        }

        public static void LoadConfig()
        {
            XmlTextReader reader = new XmlTextReader(configFilePath);
            try
            {

                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        if (reader.Name == "Righe")
                        {
                            Righe = int.Parse(reader.ReadString());
                            continue;
                        }
                        if (reader.Name == "Colonne")
                        {
                            Colonne = int.Parse(reader.ReadString());
                            continue;
                        }
                        if (reader.Name == "Riempimento")
                        {
                            Riempimento = int.Parse(reader.ReadString());
                            continue;
                        }
                    }
                }
            }
            catch { }
            
            reader.Close();
            CheckConfig();
        }

        #endregion

        #region UTILITIES

        public static void ListShuffle<T>(List<T> list)
        {
            Random rng = new Random((int)DateTimeOffset.Now.ToUnixTimeSeconds());
            for (int i = list.Count - 1; i >= 0; i--)
            {
                int j = rng.Next(0, i + 1);
                T c = list[j];
                list[j] = list[i];
                list[i] = c;
            }
        }
        
        public static List<Casella> ListFromControlCollection(System.Windows.Forms.Control.ControlCollection controls)
        {
            List<Casella> list = new List<Casella>();
            foreach (Casella c in controls)
            {
                list.Add(c);
            }
            return list;
        }

        #endregion
    }
}
