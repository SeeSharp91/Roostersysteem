using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;
using System.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Roostersysteem.Models
{

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Gebruikersnaam")]

        public string Gebruikersnaam { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Wachtwoord")]
        public string Wachtwoord { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }



    public class Persoon
    {

        string strCon = ConfigurationManager.ConnectionStrings["DatabaseConnectionExpress"].ConnectionString.ToString();
        //----------------------------Public variables------------------------------------------------
        public int PersoonId { get; set; }

        public string PersoonNaam { get; set; }

        public string PersoonEmail { get; set; }

        public int TelefoonNr { get; set; }

        public string StraatNaam { get; set; }

        public int HuisNummer { get; set; }

        public string Postcode { get; set; }

        public string PersoonGbn { get; set; }

        public string PersoonWw { get; set; }

        public string PersoonWwHerhaling { get; set; }

        public string Functie { get; set; }

        public string Vcode { get; set; }


        //-------------------------------METHODS------------------------------------------------------

        public bool Inloggen(string gebruikersnaam, string wachtwoord)
        {

            // te verplaatsen naar database connectie
            // link is verkeerd moet fixen            

            bool Flag = false;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT PersoonId, PersoonGbn, PersoonWw, PersoonEmail, PersoonNaam FROM [Persoon]";
            cmd.Connection = conn;

            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                if (rd[1].ToString() == gebruikersnaam && rd[2].ToString() == wachtwoord)
                {
                    Flag = true;

                    PersoonId = Convert.ToInt32(rd[0]);
                    PersoonEmail = Convert.ToString(rd[3]);
                    PersoonNaam = Convert.ToString(rd[4]);
                    Mail(PersoonId, PersoonEmail);
                }
            }
            conn.Close();

            return Flag;
        }



        public void Mail(int gebruikerid, string email)
        {
            //get random functie voor code generator
            Random rnd = new Random();
            //Generate code                    
            string code = rnd.Next(100000, 999999).ToString();
            //get timestamp
            DateTime localDate = DateTime.Now;

            //load values to database
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString))
            {
                using (SqlCommand comm = new SqlCommand())
                {
                    comm.Connection = conn;
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = "INSERT INTO Authenticator (PersoonId, Code, TimeStamp) VALUES (@PersoonId, @Code, @TimeStamp)";
                    comm.Parameters.Add("@PersoonId", SqlDbType.VarChar, 50).Value = gebruikerid;
                    comm.Parameters.Add("@Code", SqlDbType.VarChar, 50).Value = code;
                    comm.Parameters.Add("@TimeStamp", SqlDbType.DateTime).Value = localDate;

                    //try
                    //{
                    conn.Open();
                    comm.ExecuteNonQuery();
                    //}
                    //catch(SqlException)
                    //{
                    // error
                    //}
                    //finally
                    //{
                    conn.Close();
                    //}

                }
            }

            //send email

            // Command line argument must the the SMTP host.
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp-mail.outlook.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("RoosterDontReplyVerificatie@hotmail.com", "100200MMmn");

            MailMessage mm = new MailMessage("RoosterDontReplyVerificatie@hotmail.com", email, "test", "test" + code);
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mm);

        }




        public void WachtwoordWijzigen(Persoon persoon)
        {
            string strCon = ConfigurationManager.ConnectionStrings["DatabaseConnectionExpress"].ConnectionString.ToString();

            using (SqlConnection con = new SqlConnection(strCon))
            {
                string sql = "UPDATE Persoon set PersoonWw = '" + persoon.PersoonWw + "' WHERE PersoonGbn = '" + persoon.PersoonGbn + "'  ";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void WachtwoordResetten(string persoonNaam, string persoonWw, string persoonEmail, bool check)
        {
            //to do
        }

        public void GegevensWijzigen(Persoon persoon)
        {
            string strCon = ConfigurationManager.ConnectionStrings["DatabaseConnectionExpress"].ConnectionString.ToString();

            using (SqlConnection con = new SqlConnection(strCon))
            {
                string sql = "UPDATE Persoon set PersoonNaam = '" + persoon.PersoonNaam + "', PersoonEmail = '" + persoon.PersoonEmail + "', TelefoonNr = '" + persoon.TelefoonNr + "', StraatNaam = '" + persoon.StraatNaam + "', HuisNummer = '" + persoon.HuisNummer + "', Postcode = '" + persoon.Postcode + "' WHERE persoonId = '" + persoon.PersoonId + "'  ";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }



        public void getGegevens(Persoon persoon)
        {
            string strCon = ConfigurationManager.ConnectionStrings["DatabaseConnectionExpress"].ConnectionString.ToString();
            // method ophalen PersoonId
            using (SqlConnection con = new SqlConnection(strCon))
            {
                string sql = "SELECT * FROM Persoon WHERE PersoonId = 1 ";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }       

    }
}
