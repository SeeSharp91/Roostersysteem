namespace Roostersysteem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PersoonUren
    {
        public Nullable<int> UrenBeschikbaarheid_Id { get; set; }
        public Nullable<int> Persoon_Id { get; set; }
        public int PersoonUren_Id { get; set; }
    
        public virtual Persoon Persoon { get; set; }
        public virtual UrenBeschikbaarheid UrenBeschikbaarheid { get; set; }
    }
}
