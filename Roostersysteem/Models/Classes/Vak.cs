using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data;

namespace Roostersysteem.Models
{
    //** Klasse vak**
    //
    //Door:    Natasja Pisters
    //Project: Casus Bureau Onderwijs
    //
    public class Vak
    {
        //Attributen
        public int docentId;
        public int vakId;


        //Properties
        public int persoonId { get; set; }
        public int VakId { get; set; }
        public string VakNaam { get; set; }
        public bool IsSelected { get; set; }
        public SelectList DropDownList { get; set; } // dropdownmenu
        public int Hoorcollege { get; set; }
        public int Werkcollege { get; set; }
        public int Discussiecollege { get; set; }
        public IEnumerable<SelectListItem> Vakken { get; set; }

        public Vak() { }
        public Vak(int PersoonId)//Constructor voor het ophalen van de vakken van een docent
        {
            //Connectie("SELECT Vak.VakNaam, PersoonVak.Vak_Id, PersoonVak.Persoon_Id" +
            //            "FROM Vak" +
            //            "INNER JOIN PersoonVak ON PersoonVak.Vak_Id = Vak.VakId WHERE Persoon_Id = "+ PersoonId.ToString());
            //reader.Read
            List<Vak> l = getvakken("SELECT Vak.VakNaam, PersoonVak.Vak_Id, PersoonVak.Persoon_Id" +
                        "FROM Vak" +
                        "INNER JOIN PersoonVak ON PersoonVak.Vak_Id = Vak.VakId WHERE Persoon_Id = " + PersoonId.ToString());
        }

        public Vak(int VakId, int PersoonId, bool nieuw)//Constructor vakken toevoegen aan docent
        {
            persoonId = PersoonId;
            vakId = VakId;
            Connectie("INSERT INTO PersoonVak (Persoon_Id, Vak_Id) VALUES ('"
                    + PersoonId + "','"
                    + VakId + "')");

        }

        public static List<Vak> getvakken(string query)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionNP"].ConnectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            var vak = new List<Vak>(ds.Tables[0].Rows.Count);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                var values = row.ItemArray;
                var vakken = new Vak()
                {
                    VakId = (int)values[0],
                    VakNaam = (string)values[1],
                };
                vak.Add(vakken);
            }
            return vak;
        }

        //table voor dropdownmenu
        public class MyListTable
        {
            public string key { get; set; }
            public string Display { get; set; }
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

        public IEnumerable<SelectListItem> takeVakken { get; set; }

       

        public void VakkenDocentOphalen()
        {
            //To do
        }
        public void Connectie(string sql)
        {
            //Connectie maken.
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionNP"].ConnectionString);

            //Vakken toevoegen aan docent met sql command.
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            cmd.Connection = con;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            //return cmd.ExecuteReader();
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