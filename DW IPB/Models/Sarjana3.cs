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
    
    public partial class Sarjana3
    {
        public int ID { get; set; }
        public Nullable<int> WaktuKey { get; set; }
        public Nullable<int> DepartemenKey { get; set; }
        public Nullable<int> JalurMasukKey { get; set; }
        public Nullable<int> StatusAkademikKey { get; set; }
        public Nullable<int> JenisKelaminKey { get; set; }
        public Nullable<int> JumlahMahasiswa { get; set; }
    
        public virtual Departeman Departeman { get; set; }
        public virtual JalurMasuk JalurMasuk { get; set; }
        public virtual JenisKelamin JenisKelamin { get; set; }
        public virtual StatusAkademik StatusAkademik { get; set; }
        public virtual WaktuTahunSarjana WaktuTahunSarjana { get; set; }
    }
}