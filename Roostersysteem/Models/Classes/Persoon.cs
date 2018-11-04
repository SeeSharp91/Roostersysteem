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
        public string PersoonNaam { get; set; }

        public int PersoonId { get; set; }

        public string PersoonEmail { get; set; }

        public int TelefoonNr { get; set; }

        public string StraatNaam { get; set; }

        public int HuisNummer { get; set; }

        public string Postcode { get; set; }

        public string PersoonGbn { get; set; }

        public string PersoonWw { get; set; }

        public string PersoonWwHerhaling { get; set; }

        public string Functie { get; set; }


        //-------------------------------METHODS------------------------------------------------------

        public bool Inloggen(string gebruikersnaam, string wachtwoord)
        {

            // te verplaatsen naar database connectie
            // link is verkeerd moet fixen



            bool Flag = false;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionExpress"].ConnectionString;
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT PersoonId, PersoonGbn, PersoonWw FROM [Persoon]";
            cmd.Connection = conn;

            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                if (rd[1].ToString() == gebruikersnaam && rd[2].ToString() == wachtwoord)
                {
                    Flag = true;
                    PersoonId = Convert.ToInt32(rd[0]);

                }
            }
            conn.Close();
            TweeStapsVer();
            return Flag;
        }




        public void TweeStapsVer()
        {
            // Command line argument must the the SMTP host.
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp-mail.outlook.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("RoosterDontReplyVerificatie@hotmail.com", "100200MMmn");

            MailMessage mm = new MailMessage("RoosterDontReplyVerificatie@hotmail.com", "maxthomas2805@gmail.com", "test", "test");
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mm);

        }

        public void WachtwoordWijzigen(Persoon persoon)
        {
            string strCon = ConfigurationManager.ConnectionStrings["DatabaseConnectionExpress"].ConnectionString.ToString();

            using (SqlConnection con = new SqlConnection(strCon))
            {
                string sql = "UPDATE Persoon set PersoonWw = '"+ persoon.PersoonWw +"' WHERE PersoonGbn = '" + persoon.PersoonGbn + "'  ";
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
                string sql = "UPDATE Persoon set PersoonNaam = '"+ persoon.PersoonNaam + "', PersoonEmail = '" + persoon.PersoonEmail+ "', TelefoonNr = '" + persoon.TelefoonNr + "', StraatNaam = '" + persoon.StraatNaam + "', HuisNummer = '" + persoon.HuisNummer + "', Postcode = '" + persoon.Postcode + "' WHERE persoonId = '"+ persoon.PersoonId +"'  ";
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


        public Persoon()
        {
            PersoonId = 1;
            PersoonNaam = "Voornaam Achternaam";
            PersoonEmail = "email@email.com";
            TelefoonNr = 0000000000;
            PersoonGbn = "0000000Achternaam";
            PersoonWw = "Wachtwoord";
            PersoonWwHerhaling = PersoonWw;
            StraatNaam = "Straatnaam";
            HuisNummer = 1;
            Postcode = "1234AB";
        }

    }
}
