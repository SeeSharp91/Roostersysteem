using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Roostersysteem.Models
{
    public class Klas
    {
        private int _klasNr;
        private string _klasNaam;

        public int KlasNr
        {
            get { return _klasNr; }
            set { _klasNr = KlasNr; }
        }

        public string KlasNaam
        {
            get { return _klasNaam; }
            set { _klasNaam = KlasNaam; }
        }
    }
}