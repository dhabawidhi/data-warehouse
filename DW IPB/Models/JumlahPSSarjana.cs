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
    
    public partial class JumlahPSSarjana
    {
        public int id { get; set; }
        public Nullable<int> WaktuKey { get; set; }
        public Nullable<int> DepartemenKey { get; set; }
        public int JumlahMahasiswa { get; set; }
    
        public virtual Departeman Departeman { get; set; }
        public virtual WaktuSarjana WaktuSarjana { get; set; }
    }
}
