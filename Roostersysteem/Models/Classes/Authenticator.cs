using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Roostersysteem.Models
{

    public class ValiderenViewModel
    {
        [Required]
        [Display(Name = "verificatiecode")]
        public string verificatiecode { get; set; }

    }

    public class Authenticator
    {
        public string Code { get; set; }

        public DateTime TimeStamp { get; set; }      

        

        public bool TweeStapsVer(int userID, string verificatiecode) // todo: add check for code
        {
            bool Flag = false;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT Code FROM [Authenticator] WHERE Code = '" + verificatiecode + "'";

            cmd.Connection = conn;
            string CodeExists = Convert.ToString(cmd.ExecuteScalar());

            if (CodeExists != null)
            {

                cmd.CommandText = "SELECT TimeStamp FROM [Authenticator] WHERE Code = '" + verificatiecode + "'";
                DateTime StoredTime = Convert.ToDateTime(cmd.ExecuteScalar());
                DateTime TimeLimit = StoredTime.AddMinutes(5);
                DateTime CurrentTime = DateTime.Now;
                if (CurrentTime < TimeLimit)
                {
                    Flag = true;
                }
            }

            conn.Close();

            return Flag;
        }
    }
}