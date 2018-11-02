using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Net.Mail;
using System.Text;

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

        string strCon = ConfigurationManager.ConnectionStrings["myDatabase"].ConnectionString.ToString();
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

        public string persoonEmail
        {
            get { return _persoonEmail; }
            set { _persoonEmail = persoonEmail; }
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
         


            bool Flag = false;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
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
                    persoonId = Convert.ToInt32(rd[0]);
                    
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

        public void WachtwoordWijzigen(string persoonNaam, string PersoonWw, string persoonEmail, bool check)
        {
            //to do
        }

        public void WachtwoordResetten(string persoonNaam, string persoonWw, string persoonEmail, bool check)
        {
            //to do
        }

        public static void GegevensWijzigen(int persoonId, string persoonNaam, string persoonEmail, double telefoonNr, string straatNaam, string huisNummer, string postcode)
        {
            string constring;
            SqlConnection con;
            constring = @"Data Source=localhost; Initial Catalog=testDB; Integrated Security=True;";
            con = new SqlConnection(constring);
            con.Open();

            try
            {
                SqlCommand cmd;
                SqlDataAdapter adapter = new SqlDataAdapter();
                string sql = "";
                sql = "DELETE testTable WHERE persoonID = 1";
                cmd = new SqlCommand(sql, con);

                adapter.DeleteCommand = new SqlCommand(sql, con);
                adapter.DeleteCommand.ExecuteNonQuery();
                cmd.Dispose();


                //cmd.CommandType = CommandType.Text;
                //cmd.CommandText = "DELETE FROM testTable where persoonID = persoonId";
                ////cmd.CommandText = "UPDATE testTable SET PERSOONnaam = persoonNaam, " +
                ////    "PERSOONemail = persoonEmail, PERSOONtelnr = telefoonNr, STRAATnaam = straatNaam, STRAATnr = huisnNummer, POSTcode = postcode = WHERE persoonID = persoonId";
                //cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
            throw ex;
            }

            finally
            {
                con.Close();
            }

            
        }   
        
        public void test()
        {
            string strCon = ConfigurationManager.ConnectionStrings["myDatabase"].ConnectionString.ToString();

            using (SqlConnection con = new SqlConnection(strCon))
            {
                string sql = "DELETE testTable WHERE persoonID = 1";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }

}