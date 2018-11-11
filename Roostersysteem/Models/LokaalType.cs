namespace Roostersysteem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LokaalType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LokaalType()
        {
            this.VakLokaalTypes = new HashSet<VakLokaalType>();
        }
    
        public int LokaalTypeId { get; set; }
        public string LokaalTypeNaam { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VakLokaalType> VakLokaalTypes { get; set; }
    }
}
