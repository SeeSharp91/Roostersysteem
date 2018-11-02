using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace Roostersysteem.Models
{
    //** Klasse vak**
    //
    //Door:    Natasja Pisters
    //Project: Caus Bureau Onderwijs
    //
    public class Vak
    {
        //Attributen
        public int VakNr;
        public enum TypeLokaal { Collegezaal, Practicumlokaal, Leslokaal };
        public enum TypeCollege { Hoorcollege, Discussiecollege, Werkcollege };
        //enum TypeVak even op 'public'gezet om te kunnen testen met het view 'VakkenKoppelen'
        public enum TypeVak {};
        public DateTime _totaalTijd;
        public string strConnection = ConfigurationManager.ConnectionStrings["DatabaseConnectionServer"].ConnectionString.ToString();
        //List <SelectVakken> items;

        //Properties
        public TypeVak _typeVak
        { get; set; }
        public DateTime TotaalTijd
        {
            get { return _totaalTijd; }
            set { _totaalTijd = TotaalTijd; }
        }

        //Constructor
        public Vak() { }
        public Vak (string vakNr, string vak)
        {
            //To do
        }

        //Methods 
        public void VakContacturenDoorgeven(string vakNr, int uren, string typeLokaal)
        {
            //To do
        }

        public void VakcontacturenOphalen()
        {
            //To do
        }

        public void VakkenAangeven(Vak oVak)
        {
            //List<string> items = new List <string>();
            
            //using (SqlConnection con = new SqlConnection(strConnection))
            //{
            //    string query = "SELECT * FROM TypeVak";
            //    using (SqlCommand cmd = new SqlCommand(query))
            //    {
            //        cmd.Connection = con;
            //        con.Open();
            //        using (SqlDataReader sdr = cmd.ExecuteReader())
            //        {
            //            while (sdr.Read())
            //            {
            //                items.Add(new SelectVakken
            //                {
            //                    Text = sdr["VakType"].ToString(),
            //                    Value = sdr["VakId"].ToString()
            //                });
            //            }
            //        }
            //        con.Close();
            //    }
            //}
        }

        public void DocentKoppelenVak(string docentNaam, string vak)
        {
            //To do
        }

        public  void DocentWijzigenVak(string docentNaam, string vak)
        {
            //To do
        }

        public void TypeLokaalOphalen()
        {
            //To do
        }

    }
}