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
    
    public partial class Departeman
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Departeman()
        {
            this.Sarjana3 = new HashSet<Sarjana3>();
            this.SarjanaIPKTPBs = new HashSet<SarjanaIPKTPB>();
            this.SarjanaLulusans = new HashSet<SarjanaLulusan>();
            this.JumlahPSSarjanas = new HashSet<JumlahPSSarjana>();
            this.SarjanaLulusan2 = new HashSet<SarjanaLulusan2>();
        }
    
        public int DepartemenKey { get; set; }
        public string DepartemenNama { get; set; }
        public string Kode { get; set; }
        public Nullable<int> FakultasKey { get; set; }
    
        public virtual Fakulta Fakulta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sarjana3> Sarjana3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SarjanaIPKTPB> SarjanaIPKTPBs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SarjanaLulusan> SarjanaLulusans { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JumlahPSSarjana> JumlahPSSarjanas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SarjanaLulusan2> SarjanaLulusan2 { get; set; }
    }
}
