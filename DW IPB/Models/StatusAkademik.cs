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
    
    public partial class StatusAkademik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StatusAkademik()
        {
            this.Diploma3 = new HashSet<Diploma3>();
            this.Sarjana3 = new HashSet<Sarjana3>();
        }
    
        public int StatusAkademikKey { get; set; }
        public string StatusAkademikNama { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Diploma3> Diploma3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sarjana3> Sarjana3 { get; set; }
    }
}
