//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DW_IPB.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DepartemenDoktor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DepartemenDoktor()
        {
            this.Doktor3 = new HashSet<Doktor3>();
        }
    
        public int DepartemenKey { get; set; }
        public string DepartemenNama { get; set; }
        public string Kode { get; set; }
        public Nullable<int> FakultasKey { get; set; }
    
        public virtual Fakulta Fakulta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Doktor3> Doktor3 { get; set; }
    }
}
