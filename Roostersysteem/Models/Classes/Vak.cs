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

        public int VakId { get; set; }
        public string VakType { get; set; }
        public bool IsSelected { get; set; }
        public SelectList DropDownList { get; set; } // dropdownmenu
        public int Hoorcollege { get; set; }
        public int Werkcollege { get; set; }
        public int Discussiecollege { get; set; }
        public IEnumerable<SelectListItem> Vakken { get; set; }
        public string VakNaam { get; set; }




        public static List<Vak>getvakken()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionExpress"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from Vak", con);
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
                    VakType = (string)values[1],
                };
                vak.Add(vakken);
            }
            return vak;
        }




        //Attributen

       

        //public IEnumerable<SelectListItem> ToSelectListItems(this IEnumerable<Vak> vakken, int selectedId)
        //{
        //    return
        //        vakken.OrderBy(Vak => Vak.Name)
        //        .Select(Vak =>
        //        new SelectListItem
        //        {
        //            Selected = (Vak.ID == selectedId),
        //            Text = Vak.Name,
        //            Value = Vak.ID.ToString()
        //        });
        //}



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