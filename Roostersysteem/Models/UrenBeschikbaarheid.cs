namespace Roostersysteem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UrenBeschikbaarheid
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UrenBeschikbaarheid()
        {
            this.PersoonUrens = new HashSet<PersoonUren>();
        }
    
        public int UrenBeschikbaarheidId { get; set; }
        public Nullable<System.DateTime> TijdstipBeschikbaarheid { get; set; }
        public string DagBeschikbaarheid { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersoonUren> PersoonUrens { get; set; }
    }
}
