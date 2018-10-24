using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Roostersysteem.Models
{
    //** Klasse vak**
    //
    //Door:    Natasja Pisters
    //Project: Caus Bureau Onderwijs
    //
    //test
    //TEStIK
    public class Vak
    {
        //Attributen
        private int _vakNr;
        private enum TypeLokaal { Collegezaal, Practicumlokaal, Leslokaal };
        private enum TypeCollege { Hoorcollege, Discussiecollege, Werkcollege };
        private enum TypeVak {};//Enum's nog verwerken in DB
        private DateTime _totaalTijd;

        
        public DateTime TotaalTijd
        {
            get { return _totaalTijd; }
            set { _totaalTijd = TotaalTijd; }
        }

        //Constructor
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

        public void VakkenAangeven(string vak)
        {
            //To do
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