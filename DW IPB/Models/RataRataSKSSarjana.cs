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
    
    public partial class RataRataSKSSarjana
    {
        public int id { get; set; }
        public int WaktuKey { get; set; }
        public Nullable<int> SemesterMahasiswa { get; set; }
        public Nullable<int> RataRataSKS { get; set; }
    
        public virtual WaktuTahunSarjana WaktuTahunSarjana { get; set; }
    }
}
