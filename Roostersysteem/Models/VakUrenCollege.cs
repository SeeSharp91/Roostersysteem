namespace Roostersysteem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VakUrenCollege
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VakUrenCollege()
        {
            this.Roosters = new HashSet<Rooster>();
        }
    
        public Nullable<int> Vak_Id { get; set; }
        public Nullable<int> UrenCollege_Id { get; set; }
        public Nullable<double> Vakduur { get; set; }
        public int VakUrenCollege_Id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rooster> Roosters { get; set; }
        public virtual UrenCollege UrenCollege { get; set; }
        public virtual Vak Vak { get; set; }
    }
}
