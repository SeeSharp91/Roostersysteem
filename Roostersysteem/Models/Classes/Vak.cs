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
    public class Vak
    {
        //Attributen
        private int _vakNr;
        private enum TypeLokaal { Collegezaal, Practicumlokaal, Leslokaal };
        private enum TypeCollege { Hoorcollege, Discussiecollege, Werkcollege };
        //enum TypeVak even op 'public'gezet om te kunnen testen voor de radiobuttons met het view 'VakkenKoppelen'
        public enum TypeVak {};//Enum's nog verwerken in DB
        private DateTime _totaalTijd;

        //Properties
        public TypeVak _typeVak
        { get; set; }
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