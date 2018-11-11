namespace Roostersysteem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PersoonVak
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PersoonVak()
        {
            this.Roosters = new HashSet<Rooster>();
        }
    
        public Nullable<int> Persoon_Id { get; set; }
        public Nullable<int> Vak_Id { get; set; }
        public int PersoonVak_Id { get; set; }
    
        public virtual Persoon Persoon { get; set; }
        public virtual Vak Vak { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rooster> Roosters { get; set; }
    }
}
