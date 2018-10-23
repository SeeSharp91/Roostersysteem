using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Roostersysteem.Models
{
    public class Authenticator
    {
        private string _code;
        private DateTime _timeStamp;

        public string Code
        {
            get { return _code; }
            set { _code = Code; }
        }

        public DateTime TimeStamp
        {
            get { return _timeStamp; }
            set { _timeStamp = TimeStamp; }
        }

        public bool True { get; private set; } //tijdelijk om bugs te voorkomen //weghalen op het moment van implementeren

        public bool VerifiërenGebruiker(
            string code, DateTime timeStamp)
        {
            return True; //tijdelijk om bugs te voorkomen //weghalen op het moment van implementeren
        }            
    }
}