using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Roostersysteem.Models
{
    public class Rooster
    {
        private DateTime _startTijd;
        private DateTime _stopTijd;

        public DateTime StartTijd
        {
            get { return _startTijd; }
            set { _startTijd = StartTijd; }
        }

        public DateTime StopTijd
        {
            get { return _stopTijd; }
            set { _stopTijd = StopTijd; }
        }

        public void OpvragenDocentRooster(
            string docent, string vak, DateTime weken)
        {
            //To do
        }

        public void OpvragenIngezetteUren(
            string docent, DateTime uren, DateTime weken, int ingezetteUren)
        {
            //To do
        }

        public void OpvragenBeschikbaarheidDocenten(
            string docent, DateTime weken)
        {
            //To do
        }

        public void MogelijkRoosterGenereren()
        {
            //To do
        }

        public void ConflictenTonen()
        {
            //To do
        }
    } 
}