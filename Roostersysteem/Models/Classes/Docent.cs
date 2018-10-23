using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Roostersysteem.Models
{
    public class Docent
    {
        private DateTime _urenBeschikbaarheid;
        private int _contractUren;

        public DateTime UrenBeschikbaarheid
        {
            get { return _urenBeschikbaarheid; }
            set { _urenBeschikbaarheid = UrenBeschikbaarheid; }
        }

        public int ContractUren
        {
            get{ return _contractUren; }
            set{ _contractUren = ContractUren; }
        }

        public void BeschikbaarheidAangeven(DateTime Beschikbaarheid)
        {
            // to do
        }

        public void ContracturenAangeven (int contracturen)
        {
            // to do
        }

        public void VakVerwijderenDocent(string vak, string docent)
        {
            // to do
        }
    }
}