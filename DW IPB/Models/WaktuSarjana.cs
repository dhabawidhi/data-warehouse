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
    
    public partial class WaktuSarjana
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WaktuSarjana()
        {
            this.SarjanaIPKTPBs = new HashSet<SarjanaIPKTPB>();
            this.SarjanaLulusans = new HashSet<SarjanaLulusan>();
            this.JumlahPSSarjanas = new HashSet<JumlahPSSarjana>();
        }
    
        public int WaktuKey { get; set; }
        public Nullable<int> TahunAwal { get; set; }
        public string TahunAkademik { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SarjanaIPKTPB> SarjanaIPKTPBs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SarjanaLulusan> SarjanaLulusans { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JumlahPSSarjana> JumlahPSSarjanas { get; set; }
    }
}
