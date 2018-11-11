namespace Roostersysteem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vak
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vak()
        {
            this.PersoonVaks = new HashSet<PersoonVak>();
            this.VakLokaalTypes = new HashSet<VakLokaalType>();
            this.VakUrenColleges = new HashSet<VakUrenCollege>();
        }
    
        public int VakId { get; set; }
        public string VakNaam { get; set; }
        public string VakCode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersoonVak> PersoonVaks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VakLokaalType> VakLokaalTypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VakUrenCollege> VakUrenColleges { get; set; }
    }
}
