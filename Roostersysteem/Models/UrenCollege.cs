namespace Roostersysteem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UrenCollege
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UrenCollege()
        {
            this.VakUrenColleges = new HashSet<VakUrenCollege>();
        }
    
        public int UrenCollegeId { get; set; }
        public string CollegeNaam { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VakUrenCollege> VakUrenColleges { get; set; }
    }
}
