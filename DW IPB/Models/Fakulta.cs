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
    
    public partial class Fakulta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fakulta()
        {
            this.Departemen = new HashSet<Departeman>();
            this.DepartemenDoktors = new HashSet<DepartemenDoktor>();
            this.DepartemenMagisters = new HashSet<DepartemenMagister>();
        }
    
        public int FakultasKey { get; set; }
        public string FakultasNama { get; set; }
        public string Kode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Departeman> Departemen { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartemenDoktor> DepartemenDoktors { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartemenMagister> DepartemenMagisters { get; set; }
    }
}
