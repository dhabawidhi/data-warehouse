﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBPKLG62016Entities2 : DbContext
    {
        public DBPKLG62016Entities2()
            : base("name=DBPKLG62016Entities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Departeman> Departemen { get; set; }
        public virtual DbSet<DepartemenDoktor> DepartemenDoktors { get; set; }
        public virtual DbSet<DepartemenMagister> DepartemenMagisters { get; set; }
        public virtual DbSet<Fakulta> Fakultas { get; set; }
        public virtual DbSet<JalurMasuk> JalurMasuks { get; set; }
        public virtual DbSet<JenisKelamin> JenisKelamins { get; set; }
        public virtual DbSet<Predikat> Predikats { get; set; }
        public virtual DbSet<ProgramKeahlian> ProgramKeahlians { get; set; }
        public virtual DbSet<StatusAkademik> StatusAkademiks { get; set; }
        public virtual DbSet<WaktuSarjana> WaktuSarjanas { get; set; }
        public virtual DbSet<WaktuTahunDiploma> WaktuTahunDiplomas { get; set; }
        public virtual DbSet<WaktuTahunDoktor> WaktuTahunDoktors { get; set; }
        public virtual DbSet<WaktuTahunMagister> WaktuTahunMagisters { get; set; }
        public virtual DbSet<WaktuTahunSarjana> WaktuTahunSarjanas { get; set; }
        public virtual DbSet<Diploma3> Diploma3 { get; set; }
        public virtual DbSet<Doktor3> Doktor3 { get; set; }
        public virtual DbSet<Magister3> Magister3 { get; set; }
        public virtual DbSet<Sarjana3> Sarjana3 { get; set; }
        public virtual DbSet<SarjanaIPKTPB> SarjanaIPKTPBs { get; set; }
        public virtual DbSet<SarjanaLulusan2> SarjanaLulusan2 { get; set; }
        public virtual DbSet<JumlahPSSarjana> JumlahPSSarjanas { get; set; }
        public virtual DbSet<RataRataSKSSarjana> RataRataSKSSarjanas { get; set; }
    }
}