using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Roostersysteem.Models.Classes
{
    public class DatabaseConnection
    {
        public void Connection()
        {
            // aan te passen naar methode voor aanroepen via alle classes
            SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=RoosterDB");
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT PersoonId, PersoonGbn, PersoonWw FROM [Persoon]";
            cmd.Connection = conn;

            SqlDataReader rd = cmd.ExecuteReader();
            conn.close();
            
            while (rd.Read())
            {

            }
        }
    }
}