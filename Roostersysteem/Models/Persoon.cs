namespace Roostersysteem.Models
{
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
    public partial class Persoon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Persoon()
        {
            this.Authenticators = new HashSet<Authenticator>();
            this.PersoonUrens = new HashSet<PersoonUren>();
            this.PersoonVaks = new HashSet<PersoonVak>();
        }
    
        public int PersoonId { get; set; }
        public string PersoonVoornaam { get; set; }
        public string PersoonAchternaam { get; set; }
        public Nullable<int> PersoonTelefoonnummer { get; set; }
        public string PersoonEmail { get; set; }
        public string PersoonStraat { get; set; }
        public Nullable<int> PersoonHuisnummer { get; set; }
        public string PersoonToevoegingHuisnr { get; set; }
        public string PersoonWoonplaats { get; set; }
        public string PersoonPostcode { get; set; }
        public string PersoonGebruikersnaam { get; set; }
        public string PersoonWachtwoord { get; set; }
        public string PersoonFunctie { get; set; }
        public Nullable<int> PersoonContractUren { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Authenticator> Authenticators { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersoonUren> PersoonUrens { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersoonVak> PersoonVaks { get; set; }

        public bool Inloggen(string gebruikersnaam, string wachtwoord)
        {

            // te verplaatsen naar database connectie
            // link is verkeerd moet fixen            

            bool Flag = false;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT PersoonId, PersoonGebruikersnaam, PersoonWachtwoord, PersoonEmail, PersoonVoornaam FROM [Persoon]";
            cmd.Connection = conn;

            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                if (rd[1].ToString() == gebruikersnaam && rd[2].ToString() == wachtwoord)
                {
                    Flag = true;

                    PersoonId = Convert.ToInt32(rd[0]);
                    PersoonEmail = Convert.ToString(rd[3]);
                    PersoonVoornaam = Convert.ToString(rd[4]);
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
                    comm.CommandText = "INSERT INTO Authenticator (Persoon_Id, Code, TimeStamp) VALUES (@PersoonId, @Code, @TimeStamp)";
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
    }
}
