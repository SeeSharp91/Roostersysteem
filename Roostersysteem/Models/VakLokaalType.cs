namespace Roostersysteem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VakLokaalType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VakLokaalType()
        {
            this.Roosters = new HashSet<Rooster>();
        }
    
        public Nullable<int> LokaalType_Id { get; set; }
        public Nullable<int> Vak_Id { get; set; }
        public int VakLokaalType_Id { get; set; }
    
        public virtual LokaalType LokaalType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rooster> Roosters { get; set; }
        public virtual Vak Vak { get; set; }
    }
}
