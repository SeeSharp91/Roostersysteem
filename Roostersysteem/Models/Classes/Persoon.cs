﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Roostersysteem.Models
{
    public class Persoon
    {
        //----------------------------Private variables------------------------------------------------
        private int _persoonId;

        private string _persoonNaam;

        private string _persoonEmail;

        private string _persoonGbn;

        private string _persoonWw;

        private string _functie;

        private double _telefoonNr;

        private string _straatNaam;

        private string _huisNummer;

        private string _postcode;

        //----------------------------Public variables-----------------------------------------------
        //Dit zijn geen variabelen maar properties. Mede mogelijk gemaakt door Micha corp. ©

        public int persoonId
        {
            get { return _persoonId; }
            set { _persoonId = persoonId; }
        }

        public string persoonNaam
        {
            get { return _persoonNaam; }
            set { _persoonNaam = persoonNaam; }
        }

        public string persoonEmail
        {
            get { return _persoonEmail; }
            set { _persoonEmail = persoonEmail; }
        }

        public string persoonGbn
        {
            get { return _persoonGbn; }
            set { _persoonGbn = persoonGbn; }
        }

        public string persoonWw
        {
            get { return _persoonWw; }
            set { _persoonWw = persoonWw; }
        }

        public string functie
        {
            get { return _functie; }
            set { _functie = functie; }
        }

        public double telefoonNr
        {
            get { return _telefoonNr; }
            set { _telefoonNr = telefoonNr; }
        }

        public string straatNaam
        {
            get { return _straatNaam; }
            set { _straatNaam = straatNaam; }
        }

        public string huisNummer
        {
            get { return _huisNummer; }
            set { _huisNummer = huisNummer; }
        }

        public string postcode
        {
            get { return _postcode; }
            set { _postcode = postcode; }
        }

        //-------------------------------METHODS------------------------------------------------------

        public bool Inloggen(string gebruikersnaam, string wachtwoord)
        {
            // te verplaatsen naar database connectie
            // link is verkeerd moet fixen
            SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=RoosterDB");
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT PersoonId, PersoonGbn, PersoonWw FROM [Persoon]";
            cmd.Connection = conn;

            SqlDataReader rd = cmd.ExecuteReader();
            conn.Close();



            bool Flag = false;

            persoonId = Convert.ToInt32(rd[0]);

            while (rd.Read())
            {
                if(rd[1].ToString()==gebruikersnaam && rd[2].ToString()==wachtwoord)
                {
                    Flag = true;
                }
                

            }
            return Flag;
            
                

        }

        public void TweeStapsVer(string token, bool True)
        {
            //to do
        }

        public void WachtwoordWijzigen(string persoonNaam, string PersoonWw, string persoonEmail, bool check)
        {
            //to do
        }

        public void WachtwoordResetten(string persoonNaam, string persoonWw, string persoonEmail, bool check)
        {
            //to do
        }

        public void GegevensWijzigen(string persoonNaam, string persoonEmail, double telefoonNr, string huisNummer, string postcode, bool check)
        {
            //to do
        }     
    }
}