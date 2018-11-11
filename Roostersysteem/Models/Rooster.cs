namespace Roostersysteem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Web.Mvc;

    public partial class Rooster
    {
        [DisplayName("Manager")]
        public int RoosterId { get; set; }
        [DisplayName("Docent")]
        public Nullable<int> PersoonVak_Id { get; set; }
        [DisplayName("Uren")]
        public Nullable<int> VakUrenCollege_Id { get; set; }
        [DisplayName("Klas")]
        public string Klas { get; set; }
        [DisplayName("Soort lokaal")]
        public Nullable<int> VakLokaalType_Id { get; set; }

        public DateTime StartTijd { get; set; }
        public DateTime EindTijd { get; set; }

        public virtual PersoonVak PersoonVak { get; set; }
        public virtual VakLokaalType VakLokaalType { get; set; }
        public virtual VakUrenCollege VakUrenCollege { get; set; }
        public virtual Vak Vak { get; set; }
    }
}
