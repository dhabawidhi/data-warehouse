using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DW_IPB.Models;
using System.Diagnostics;
using DW_IPB.ViewModels;

namespace DW_IPB.Controllers
{
    [Authorize]
    public class SarjanaController : Controller
    {
        //private DBPKLG62016Entitas3 db = new DBPKLG62016Entities3();
        private DBPKLG62016Entities3 db = new DBPKLG62016Entities3();
        public string gantiWarna(string data)
        {
            string warna;
            //fakultas
            if (data == "A") warna = "#03A221";
            else if (data == "B") warna = "#AC24A5";
            else if (data == "C") warna = "#1D4CC0";
            else if (data == "D") warna = "#93530F";
            else if (data == "E") warna = "#5F5F5F";
            else if (data == "F") warna = "#AC0101";
            else if (data == "G") warna = "#F9F9F9";
            else if (data == "H") warna = "#F46F0A";
            else if (data == "I") warna = "#F78B39";
            else if (data == "J") warna = "#4D7D58";
            else if (data == "K") warna = "#4A7B55";
            else if (data == "P") warna = "#110862";
            else if (data == "USMI/SNMPTN Undangan") warna = "#AAAAAA";
            else if (data == "XSPMB/UMPTN/SNMPTN Ujian Tertulis") warna = "#BBBBBB";
            else if (data == "PIN") warna = "#CCCCCC";
            else if (data == "Alih Jenjang/Ekstensi/Alih Jenis") warna = "#DDDDDD";
            else if (data == "Pindahan/Melanjutkan Studi") warna = "#EEEEEE";
            else if (data == "BUD/Beasiswa/Kemitraan/Jalur Kerjasama") warna = "#FFFF00";
            else if (data == "UTM") warna = "#111111";
            else if (data == "Mahasiswa Asing") warna = "#222222";
            else if (data == "Warga Negara Asing") warna = "#333333";
            else if (data == "Pindah Mayor") warna = "#444444";
            else if (data == "Research Student") warna = "#555555";
            else if (data == "Reguler") warna = "#666666";
            else if (data == "by Research/Jalur Penelitian") warna = "#777777";
            else if (data == "Kelas Khusus") warna = "#888888";
            else if (data == "Kelas Profesional") warna = "#999999";
            else if (data == "Program Sinergi S1-S2") warna = "#101010";
            else if (data == "Student Exchange") warna = "#A1A1A1";
            else if (data == "Program Doktor Sarjana Unggulan") warna = "#B2B2B2";
            else if (data == "Tugas Belajar") warna = "#C3C3C3";
            else if (data == "Undefined") warna = "#D4D4D4";
            else if (data == "Afirmasi") warna = "#AABBCC";
            else if (data == "Aktif") warna = "#BBCCDD";
            else if (data == "Cuti") warna = "#CCDDEE";
            else if (data == "Lulus") warna = "#DDEEFF";
            else if (data == "Mengundurkan Diri (MD)") warna = "#FFCCDD";
            else if (data == "Drop Out (DO)") warna = "#11AABB";
            else if (data == "Tanpa Keterangan") warna = "#11CCDD";
            else if (data == "Meninggal Dunia") warna = "#22FFDD";
            else if (data == "Non Aktif") warna = "#33AABB";
            else if (data == "Pindah Mayor") warna = "#AAFF00";
            else warna = "#F0F0F0";
            return (warna);
        }
        // GET: Sarjana
        public ActionResult Index()
        {
            var sarjana3 = db.Sarjana3.Include(s => s.Departeman).Include(s => s.JalurMasuk).Include(s => s.JenisKelamin).Include(s => s.StatusAkademik).Include(s => s.WaktuTahunSarjana);
            return View(sarjana3.ToList());
        }

        // GET: Sarjana/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sarjana3 sarjana3 = db.Sarjana3.Find(id);
            if (sarjana3 == null)
            {
                return HttpNotFound();
            }
            return View(sarjana3);
        }

        // GET: Sarjana/Create
        public ActionResult Create()
        {
            ViewBag.DepartemenKey = new SelectList(db.Departemen, "DepartemenKey", "DepartemenNama");
            ViewBag.JalurMasukKey = new SelectList(db.JalurMasuks, "JalurMasukKey", "JalurMasukNama");
            ViewBag.JenisKelaminKey = new SelectList(db.JenisKelamins, "JenisKelaminKey", "JenisKelaminNama");
            ViewBag.StatusAkademikKey = new SelectList(db.StatusAkademiks, "StatusAkademikKey", "StatusAkademikNama");
            ViewBag.WaktuKey = new SelectList(db.WaktuTahunSarjanas, "WaktuKey", "TahunAkademik");
            return View();
        }

        // POST: Sarjana/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,WaktuKey,DepartemenKey,JalurMasukKey,StatusAkademikKey,JenisKelaminKey,JumlahMahasiswa")] Sarjana3 sarjana3)
        {
            if (ModelState.IsValid)
            {
                db.Sarjana3.Add(sarjana3);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartemenKey = new SelectList(db.Departemen, "DepartemenKey", "DepartemenNama", sarjana3.DepartemenKey);
            ViewBag.JalurMasukKey = new SelectList(db.JalurMasuks, "JalurMasukKey", "JalurMasukNama", sarjana3.JalurMasukKey);
            ViewBag.JenisKelaminKey = new SelectList(db.JenisKelamins, "JenisKelaminKey", "JenisKelaminNama", sarjana3.JenisKelaminKey);
            ViewBag.StatusAkademikKey = new SelectList(db.StatusAkademiks, "StatusAkademikKey", "StatusAkademikNama", sarjana3.StatusAkademikKey);
            ViewBag.WaktuKey = new SelectList(db.WaktuTahunSarjanas, "WaktuKey", "TahunAkademik", sarjana3.WaktuKey);
            return View(sarjana3);
        }

        // GET: Sarjana/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sarjana3 sarjana3 = db.Sarjana3.Find(id);
            if (sarjana3 == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartemenKey = new SelectList(db.Departemen, "DepartemenKey", "DepartemenNama", sarjana3.DepartemenKey);
            ViewBag.JalurMasukKey = new SelectList(db.JalurMasuks, "JalurMasukKey", "JalurMasukNama", sarjana3.JalurMasukKey);
            ViewBag.JenisKelaminKey = new SelectList(db.JenisKelamins, "JenisKelaminKey", "JenisKelaminNama", sarjana3.JenisKelaminKey);
            ViewBag.StatusAkademikKey = new SelectList(db.StatusAkademiks, "StatusAkademikKey", "StatusAkademikNama", sarjana3.StatusAkademikKey);
            ViewBag.WaktuKey = new SelectList(db.WaktuTahunSarjanas, "WaktuKey", "TahunAkademik", sarjana3.WaktuKey);
            return View(sarjana3);
        }

        // POST: Sarjana/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,WaktuKey,DepartemenKey,JalurMasukKey,StatusAkademikKey,JenisKelaminKey,JumlahMahasiswa")] Sarjana3 sarjana3)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sarjana3).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartemenKey = new SelectList(db.Departemen, "DepartemenKey", "DepartemenNama", sarjana3.DepartemenKey);
            ViewBag.JalurMasukKey = new SelectList(db.JalurMasuks, "JalurMasukKey", "JalurMasukNama", sarjana3.JalurMasukKey);
            ViewBag.JenisKelaminKey = new SelectList(db.JenisKelamins, "JenisKelaminKey", "JenisKelaminNama", sarjana3.JenisKelaminKey);
            ViewBag.StatusAkademikKey = new SelectList(db.StatusAkademiks, "StatusAkademikKey", "StatusAkademikNama", sarjana3.StatusAkademikKey);
            ViewBag.WaktuKey = new SelectList(db.WaktuTahunSarjanas, "WaktuKey", "TahunAkademik", sarjana3.WaktuKey);
            return View(sarjana3);
        }

        // GET: Sarjana/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sarjana3 sarjana3 = db.Sarjana3.Find(id);
            if (sarjana3 == null)
            {
                return HttpNotFound();
            }
            return View(sarjana3);
        }

        // POST: Sarjana/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sarjana3 sarjana3 = db.Sarjana3.Find(id);
            db.Sarjana3.Remove(sarjana3);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        
        public ActionResult JumlahPerProgramStudi()
        {
            int id = 1;
            ViewBag.id = id;
            var jumlahS1 = (from p in db.Sarjana3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS1 = jumlahS1;
            var jumlahS2 = (from p in db.Magister3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS2 = jumlahS2;
            var jumlahS3 = (from p in db.Doktor3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS3 = jumlahS3;
            var jumlahD = (from p in db.Diploma3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahD = jumlahD;
            var tahun = (from p in db.WaktuTahunSarjanas orderby p.TahunAkademik select p);
            //Debug.WriteLine("Tahun =" + tahun);
            ViewBag.data = tahun;
            var tahunAkademik = (from p in db.WaktuTahunSarjanas where p.WaktuKey == id select p);
            ViewBag.tahunAkademik = tahunAkademik;
            //var JumlahA = (from p in db.Sarjanas where p.WaktuKey == id && p.DepartemenKey == (from c in db.Departemen where c.FakultasKey == 1 select c))
            List<IPKViewModel> model = new List<IPKViewModel>();
            var jumlahPerPS = (from s in db.Sarjana3
                               where
                                 s.WaktuKey == 1
                               group new { s.Departeman, s } by new
                               {
                                   s.Departeman.Kode
                               } into g
                               orderby
                                 g.Key.Kode
                               select new
                               {
                                   g.Key.Kode,
                                   Column1 = (int?)g.Sum(p => p.s.JumlahMahasiswa)
                               }).ToList();
            double ipk;
            foreach (var item in jumlahPerPS)
            {
                ipk = (double)item.Column1;
                model.Add(new IPKViewModel()
                {
                    kode = item.Kode,
                    ipk = ipk
                });
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult JumlahPerProgramStudi(int id)
        {
            ViewBag.id = id;
            var jumlahS1 = (from p in db.Sarjana3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS1 = jumlahS1;
            var jumlahS2 = (from p in db.Magister3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS2 = jumlahS2;
            var jumlahS3 = (from p in db.Doktor3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS3 = jumlahS3;
            var jumlahD = (from p in db.Diploma3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahD = jumlahD;
            var tahun = (from p in db.WaktuTahunSarjanas orderby p.TahunAkademik select p);
            //Debug.WriteLine("Tahun =" + tahun);
            ViewBag.data = tahun;
            var tahunAkademik = (from p in db.WaktuTahunSarjanas where p.WaktuKey == id select p);
            ViewBag.tahunAkademik = tahunAkademik;
            //var JumlahA = (from p in db.Sarjanas where p.WaktuKey == id && p.DepartemenKey == (from c in db.Departemen where c.FakultasKey == 1 select c))
            List<IPKViewModel> model = new List<IPKViewModel>();
            var jumlahPerPS = (from s in db.Sarjana3
                               where
                                 s.WaktuKey == id
                               group new { s.Departeman, s } by new
                               {
                                   s.Departeman.Kode
                               } into g
                               orderby
                                 g.Key.Kode
                               select new
                               {
                                   g.Key.Kode,
                                   Column1 = (int?)g.Sum(p => p.s.JumlahMahasiswa)
                               }).ToList();
            double ipk;
            foreach (var item in jumlahPerPS)
            {
                ipk = (double)item.Column1;
                model.Add(new IPKViewModel()
                {
                    kode = item.Kode,
                    ipk = ipk
                });
            }
            return View(model);
        }
        public ActionResult JumlahPerFakultas()
        {
            int id = 1;
            ViewBag.id = id;
            var jumlahS1 = (from p in db.Sarjana3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS1 = jumlahS1;
            var jumlahS2 = (from p in db.Magister3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS2 = jumlahS2;
            var jumlahS3 = (from p in db.Doktor3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS3 = jumlahS3;
            var jumlahD = (from p in db.Diploma3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahD = jumlahD;
            var tahun = (from p in db.WaktuTahunSarjanas orderby p.TahunAkademik select p);
            //Debug.WriteLine("Tahun =" + tahun);
            ViewBag.data = tahun;
            var tahunAkademik = (from p in db.WaktuTahunSarjanas where p.WaktuKey == id select p);
            ViewBag.tahunAkademik = tahunAkademik;
            //var JumlahA = (from p in db.Sarjanas where p.WaktuKey == id && p.DepartemenKey == (from c in db.Departemen where c.FakultasKey == 1 select c))
            var jumlahPerFakultas = (from s in db.Sarjana3
                                     where
                                       s.WaktuKey == id
                                     group new { s.Departeman.Fakulta, s } by new
                                     {
                                         s.Departeman.Fakulta.Kode
                                     } into g
                                     orderby
                                         g.Key.Kode
                                     select new
                                     {
                                         g.Key.Kode,
                                         Column1 = (int?)g.Sum(p => p.s.JumlahMahasiswa)
                                     }).ToList();
            List<SarjanaViewModel> model = new List<SarjanaViewModel>();
            string warna;
            foreach (var item in jumlahPerFakultas)
            {
                warna = gantiWarna(item.Kode);
                model.Add(new SarjanaViewModel()
                {
                    country = item.Kode,
                    visits = item.Column1,
                    color = warna
                });
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult JumlahPerFakultas(int id)
        {
            ViewBag.id = id;
            var jumlahS1 = (from p in db.Sarjana3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS1 = jumlahS1;
            var jumlahS2 = (from p in db.Magister3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS2 = jumlahS2;
            var jumlahS3 = (from p in db.Doktor3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS3 = jumlahS3;
            var jumlahD = (from p in db.Diploma3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahD = jumlahD;
            var tahun = (from p in db.WaktuTahunSarjanas orderby p.TahunAkademik select p);
            //Debug.WriteLine("Tahun =" + tahun);
            ViewBag.data = tahun;
            var tahunAkademik = (from p in db.WaktuTahunSarjanas where p.WaktuKey == id select p);
            ViewBag.tahunAkademik = tahunAkademik;
            //var JumlahA = (from p in db.Sarjanas where p.WaktuKey == id && p.DepartemenKey == (from c in db.Departemen where c.FakultasKey == 1 select c))
            var jumlahPerFakultas = (from s in db.Sarjana3
                                     where
                                       s.WaktuKey == id
                                     group new { s.Departeman.Fakulta, s } by new
                                     {
                                         s.Departeman.Fakulta.Kode
                                     } into g
                                     orderby
                                         g.Key.Kode
                                     select new
                                     {
                                         g.Key.Kode,
                                         Column1 = (int?)g.Sum(p => p.s.JumlahMahasiswa)
                                     }).ToList();
            List<SarjanaViewModel> model = new List<SarjanaViewModel>();
            string warna;
            foreach (var item in jumlahPerFakultas)
            {
                warna = gantiWarna(item.Kode);
                model.Add(new SarjanaViewModel()
                {
                    country = item.Kode,
                    visits = item.Column1,
                    color = warna
                });
            }
            return View(model);
        }
        public ActionResult JumlahPerJalurMasuk()
        {
            int id = 1;
            ViewBag.id = id;
            var jumlahS1 = (from p in db.Sarjana3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS1 = jumlahS1;
            var jumlahS2 = (from p in db.Magister3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS2 = jumlahS2;
            var jumlahS3 = (from p in db.Doktor3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS3 = jumlahS3;
            var jumlahD = (from p in db.Diploma3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahD = jumlahD;
            var tahun = (from p in db.WaktuTahunSarjanas orderby p.TahunAkademik select p);
            //Debug.WriteLine("Tahun =" + tahun);
            ViewBag.data = tahun;
            var tahunAkademik = (from p in db.WaktuTahunSarjanas where p.WaktuKey == id select p);
            ViewBag.tahunAkademik = tahunAkademik;
            //var JumlahA = (from p in db.Sarjanas where p.WaktuKey == id && p.DepartemenKey == (from c in db.Departemen where c.FakultasKey == 1 select c))
            var jumlahPerJalurMasuk = (from s in db.Sarjana3
                                       where
                                         s.WaktuKey == id
                                       group new { s.JalurMasuk, s } by new
                                       {
                                           s.JalurMasuk.JalurMasukKey,
                                           s.JalurMasuk.JalurMasukNama
                                       } into g
                                       orderby
                                         g.Key.JalurMasukKey
                                       select new
                                       {
                                           g.Key.JalurMasukNama,
                                           Column1 = (int?)g.Sum(p => p.s.JumlahMahasiswa)
                                       }).ToList();
            List<SarjanaViewModel> model = new List<SarjanaViewModel>();
            string warna;
            foreach (var item in jumlahPerJalurMasuk)
            {
                warna = gantiWarna(item.JalurMasukNama);
                model.Add(new SarjanaViewModel()
                {
                    country = item.JalurMasukNama,
                    visits = item.Column1,
                    color = warna
                });
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult JumlahPerJalurMasuk(int id)
        {
            ViewBag.id = id;
            var jumlahS1 = (from p in db.Sarjana3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS1 = jumlahS1;
            var jumlahS2 = (from p in db.Magister3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS2 = jumlahS2;
            var jumlahS3 = (from p in db.Doktor3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS3 = jumlahS3;
            var jumlahD = (from p in db.Diploma3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahD = jumlahD;
            var tahun = (from p in db.WaktuTahunSarjanas orderby p.TahunAkademik select p);
            //Debug.WriteLine("Tahun =" + tahun);
            ViewBag.data = tahun;
            var tahunAkademik = (from p in db.WaktuTahunSarjanas where p.WaktuKey == id select p);
            ViewBag.tahunAkademik = tahunAkademik;
            //var JumlahA = (from p in db.Sarjanas where p.WaktuKey == id && p.DepartemenKey == (from c in db.Departemen where c.FakultasKey == 1 select c))
            var jumlahPerJalurMasuk = (from s in db.Sarjana3
                                       where
                                         s.WaktuKey == id
                                       group new { s.JalurMasuk, s } by new
                                       {
                                           s.JalurMasuk.JalurMasukKey,
                                           s.JalurMasuk.JalurMasukNama
                                       } into g
                                       orderby
                                         g.Key.JalurMasukKey
                                       select new
                                       {
                                           g.Key.JalurMasukNama,
                                           Column1 = (int?)g.Sum(p => p.s.JumlahMahasiswa)
                                       }).ToList();
            List<SarjanaViewModel> model = new List<SarjanaViewModel>();
            string warna;
            foreach (var item in jumlahPerJalurMasuk)
            {
                warna = gantiWarna(item.JalurMasukNama);
                model.Add(new SarjanaViewModel()
                {
                    country = item.JalurMasukNama,
                    visits = item.Column1,
                    color = warna
                });
            }
            return View(model);
        }
        public ActionResult JumlahPerStrata()
        {
            int id = 1;
            ViewBag.id = id;
            List<IPKViewModel> model = new List<IPKViewModel>();
            var jumlahS1 = (from p in db.Sarjana3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS1 = jumlahS1;
            model.Add(new IPKViewModel()
            {
                kode="Sarjana",
                ipk=ViewBag.jumlahS1
            });
            var jumlahS3 = (from p in db.Doktor3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS3 = jumlahS3;
            if (ViewBag.jumlahS3 == null) ViewBag.jumlahS3 = 0.0;
            model.Add(new IPKViewModel()
            {
                kode = "Doktor",
                ipk = ViewBag.jumlahS3
            });
            var jumlahS2 = (from p in db.Magister3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS2 = jumlahS2;
            if (ViewBag.jumlahS2 == null) ViewBag.jumlahS2 = 0.0;
            model.Add(new IPKViewModel()
            {
                kode = "Master",
                ipk = ViewBag.jumlahS2
            });
            var jumlahD = (from p in db.Diploma3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahD = jumlahD;
            if (ViewBag.jumlahD == null) ViewBag.jumlahD = 0.0;
            model.Add(new IPKViewModel()
            {
                kode = "Diploma",
                ipk = ViewBag.jumlahD
            });
            var tahun = (from p in db.WaktuTahunSarjanas orderby p.TahunAkademik select p);
            //Debug.WriteLine("Tahun =" + tahun);
            ViewBag.data = tahun;
            var tahunAkademik = (from p in db.WaktuTahunSarjanas where p.WaktuKey == id select p);
            ViewBag.tahunAkademik = tahunAkademik;
            return View(model);
        }
        [HttpPost]
        public ActionResult JumlahPerStrata(int id)
        {
            ViewBag.id = id;
            List<IPKViewModel> model = new List<IPKViewModel>();
            var jumlahS1 = (from p in db.Sarjana3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS1 = jumlahS1;
            model.Add(new IPKViewModel()
            {
                kode = "Sarjana",
                ipk = ViewBag.jumlahS1
            });
            var jumlahS3 = (from p in db.Doktor3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS3 = jumlahS3;
            if (ViewBag.jumlahS3 == null) ViewBag.jumlahS3 = 0.0;
            model.Add(new IPKViewModel()
            {
                kode = "Doktor",
                ipk = ViewBag.jumlahS3
            });
            var jumlahS2 = (from p in db.Magister3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS2 = jumlahS2;
            if (ViewBag.jumlahS2 == null) ViewBag.jumlahS2 = 0.0;
            model.Add(new IPKViewModel()
            {
                kode = "Master",
                ipk = ViewBag.jumlahS2
            });
            var jumlahD = (from p in db.Diploma3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahD = jumlahD;
            if (ViewBag.jumlahD == null) ViewBag.jumlahD = 0.0;
            model.Add(new IPKViewModel()
            {
                kode = "Diploma",
                ipk = ViewBag.jumlahD
            });
            var tahun = (from p in db.WaktuTahunSarjanas orderby p.TahunAkademik select p);
            //Debug.WriteLine("Tahun =" + tahun);
            ViewBag.data = tahun;
            var tahunAkademik = (from p in db.WaktuTahunSarjanas where p.WaktuKey == id select p);
            ViewBag.tahunAkademik = tahunAkademik;
            return View(model);
        }
        public ActionResult JumlahMahasiswaAsing()
        {
            int id = 1;
            ViewBag.id = id;
            var jumlahS1 = (from p in db.Sarjana3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS1 = jumlahS1;
            var jumlahS2 = (from p in db.Magister3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS2 = jumlahS2;
            var jumlahS3 = (from p in db.Doktor3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS3 = jumlahS3;
            var jumlahD = (from p in db.Diploma3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahD = jumlahD;
            var tahun = (from p in db.WaktuTahunSarjanas orderby p.TahunAkademik select p);
            //Debug.WriteLine("Tahun =" + tahun);
            ViewBag.data = tahun;
            var tahunAkademik = (from p in db.WaktuTahunSarjanas where p.WaktuKey == id select p);
            ViewBag.tahunAkademik = tahunAkademik;
            //var JumlahA = (from p in db.Sarjanas where p.WaktuKey == id && p.DepartemenKey == (from c in db.Departemen where c.FakultasKey == 1 select c))
            List<IPKViewModel> model = new List<IPKViewModel>();
            var jumlahPerPS = (from s in db.Sarjana3
                               where
                                 s.WaktuKey == id &&
                                 (s.JalurMasukKey == 8 ||
                                 s.JalurMasukKey == 9)
                               group new { s.Departeman, s } by new
                               {
                                   s.Departeman.Kode
                               } into g
                               orderby
                                 g.Key.Kode
                               select new
                               {
                                   g.Key.Kode,
                                   Column1 = (int?)g.Sum(p => p.s.JumlahMahasiswa)
                               }).ToList();
            double ipk;
            foreach (var item in jumlahPerPS)
            {
                ipk = (double)item.Column1;
                model.Add(new IPKViewModel()
                {
                    kode = item.Kode,
                    ipk = ipk
                });
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult JumlahMahasiswaAsing(int id)
        {
            ViewBag.id = id;
            var jumlahS1 = (from p in db.Sarjana3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS1 = jumlahS1;
            var jumlahS2 = (from p in db.Magister3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS2 = jumlahS2;
            var jumlahS3 = (from p in db.Doktor3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS3 = jumlahS3;
            var jumlahD = (from p in db.Diploma3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahD = jumlahD;
            var tahun = (from p in db.WaktuTahunSarjanas orderby p.TahunAkademik select p);
            //Debug.WriteLine("Tahun =" + tahun);
            ViewBag.data = tahun;
            var tahunAkademik = (from p in db.WaktuTahunSarjanas where p.WaktuKey == id select p);
            ViewBag.tahunAkademik = tahunAkademik;
            //var JumlahA = (from p in db.Sarjanas where p.WaktuKey == id && p.DepartemenKey == (from c in db.Departemen where c.FakultasKey == 1 select c))
            List<IPKViewModel> model = new List<IPKViewModel>();
            var jumlahPerPS = (from s in db.Sarjana3
                               where
                                 s.WaktuKey == id &&
                                 (s.JalurMasukKey == 8 ||
                                 s.JalurMasukKey == 9)
                               group new { s.Departeman, s } by new
                               {
                                   s.Departeman.Kode
                               } into g
                               orderby
                                 g.Key.Kode
                               select new
                               {
                                   g.Key.Kode,
                                   Column1 = (int?)g.Sum(p => p.s.JumlahMahasiswa)
                               }).ToList();
            double ipk;
            foreach (var item in jumlahPerPS)
            {
                ipk = (double)item.Column1;
                model.Add(new IPKViewModel()
                {
                    kode = item.Kode,
                    ipk = ipk
                });
            }
            return View(model);
        }
        public ActionResult JumlahPerJenisKelamin()
        {
            int id = 1;
            ViewBag.id = id;
            var jumlahS1 = (from p in db.Sarjana3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS1 = jumlahS1;
            var jumlahS2 = (from p in db.Magister3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS2 = jumlahS2;
            var jumlahS3 = (from p in db.Doktor3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS3 = jumlahS3;
            var jumlahD = (from p in db.Diploma3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahD = jumlahD;
            var tahun = (from p in db.WaktuTahunSarjanas orderby p.TahunAkademik select p);
            //Debug.WriteLine("Tahun =" + tahun);
            ViewBag.data = tahun;
            var tahunAkademik = (from p in db.WaktuTahunSarjanas where p.WaktuKey == id select p);
            ViewBag.tahunAkademik = tahunAkademik;
            List<JenisKelaminViewModel> model = new List<JenisKelaminViewModel>();
            var jumlahPerJKL = (from s in db.Sarjana3
                                where
                                  s.WaktuKey == id &&
                                  s.JenisKelaminKey == 1
                                group new { s.Departeman, s } by new
                                {
                                    s.Departeman.Kode
                                } into g
                                orderby
                                  g.Key.Kode
                                select new
                                {
                                    g.Key.Kode,
                                    Column1 = (int?)g.Sum(p => p.s.JumlahMahasiswa)
                                }).ToList();
            string[] kode = new string[90];
            int?[] jumlah = new int?[90];
            int c = 0;
            foreach (var item in jumlahPerJKL)
            {
                kode[c] = item.Kode;
                jumlah[c] = item.Column1;
                c++;
            }
            var jumlahPerJKW = (from s in db.Sarjana3
                                where
                                  s.WaktuKey == id &&
                                  s.JenisKelaminKey == 2
                                group new { s.Departeman, s } by new
                                {
                                    s.Departeman.Kode
                                } into g
                                orderby
                                  g.Key.Kode
                                select new
                                {
                                    g.Key.Kode,
                                    Column1 = (int?)g.Sum(p => p.s.JumlahMahasiswa)
                                }).ToList();
            c = 0;
            foreach (var item in jumlahPerJKW)
            {
                model.Add(new JenisKelaminViewModel()
                {
                    year = kode[c],
                    income = jumlah[c],
                    expenses = item.Column1
                });
                c++;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult JumlahPerJenisKelamin(int id)
        {
            ViewBag.id = id;
            var jumlahS1 = (from p in db.Sarjana3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS1 = jumlahS1;
            var jumlahS2 = (from p in db.Magister3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS2 = jumlahS2;
            var jumlahS3 = (from p in db.Doktor3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS3 = jumlahS3;
            var jumlahD = (from p in db.Diploma3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahD = jumlahD;
            var tahun = (from p in db.WaktuTahunSarjanas orderby p.TahunAkademik select p);
            //Debug.WriteLine("Tahun =" + tahun);
            ViewBag.data = tahun;
            var tahunAkademik = (from p in db.WaktuTahunSarjanas where p.WaktuKey == id select p);
            ViewBag.tahunAkademik = tahunAkademik;
            List<JenisKelaminViewModel> model = new List<JenisKelaminViewModel>();
            var jumlahPerJKL = (from s in db.Sarjana3
                                where
                                  s.WaktuKey == id &&
                                  s.JenisKelaminKey == 1
                                group new { s.Departeman, s } by new
                                {
                                    s.Departeman.Kode
                                } into g
                                orderby
                                  g.Key.Kode
                                select new
                                {
                                    g.Key.Kode,
                                    Column1 = (int?)g.Sum(p => p.s.JumlahMahasiswa)
                                }).ToList();
            string[] kode = new string[90];
            int?[] jumlah = new int?[90];
            int c = 0;
            foreach (var item in jumlahPerJKL)
            {
                kode[c] = item.Kode;
                jumlah[c] = item.Column1;
                c++;
            }
            var jumlahPerJKW = (from s in db.Sarjana3
                                where
                                  s.WaktuKey == id &&
                                  s.JenisKelaminKey == 2
                                group new { s.Departeman, s } by new
                                {
                                    s.Departeman.Kode
                                } into g
                                orderby
                                  g.Key.Kode
                                select new
                                {
                                    g.Key.Kode,
                                    Column1 = (int?)g.Sum(p => p.s.JumlahMahasiswa)
                                }).ToList();
            c = 0;
            foreach (var item in jumlahPerJKW)
            {
                model.Add(new JenisKelaminViewModel()
                {
                    year = kode[c],
                    income = jumlah[c],
                    expenses = item.Column1
                });
                c++;
            }
            return View(model);
        }
        public ActionResult JumlahPerStatusAkademik()
        {
            int id = 1;
            ViewBag.id = id;
            var jumlahS1 = (from p in db.Sarjana3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS1 = jumlahS1;
            var jumlahS2 = (from p in db.Magister3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS2 = jumlahS2;
            var jumlahS3 = (from p in db.Doktor3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS3 = jumlahS3;
            var jumlahD = (from p in db.Diploma3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahD = jumlahD;
            var tahun = (from p in db.WaktuTahunSarjanas orderby p.TahunAkademik select p);
            //Debug.WriteLine("Tahun =" + tahun);
            ViewBag.data = tahun;
            var tahunAkademik = (from p in db.WaktuTahunSarjanas where p.WaktuKey == id select p);
            ViewBag.tahunAkademik = tahunAkademik;
            //var JumlahA = (from p in db.Sarjanas where p.WaktuKey == id && p.DepartemenKey == (from c in db.Departemen where c.FakultasKey == 1 select c))
            var jumlahPerStatusAkademik = (from s in db.Sarjana3
                                       where
                                         s.WaktuKey == id
                                       group new { s.StatusAkademik, s } by new
                                       {
                                           s.StatusAkademik.StatusAkademikNama,
                                           s.StatusAkademik.StatusAkademikKey
                                       } into g
                                       orderby
                                         g.Key.StatusAkademikKey
                                       select new
                                       {
                                           g.Key.StatusAkademikNama,
                                           Column1 = (int?)g.Sum(p => p.s.JumlahMahasiswa)
                                       }).ToList();
            List<SarjanaViewModel> model = new List<SarjanaViewModel>();
            string warna;
            foreach (var item in jumlahPerStatusAkademik)
            {
                warna = gantiWarna(item.StatusAkademikNama);
                model.Add(new SarjanaViewModel()
                {
                    country = item.StatusAkademikNama,
                    visits = item.Column1,
                    color = warna
                });
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult JumlahPerStatusAkademik(int id)
        {
            ViewBag.id = id;
            var jumlahS1 = (from p in db.Sarjana3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS1 = jumlahS1;
            var jumlahS2 = (from p in db.Magister3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS2 = jumlahS2;
            var jumlahS3 = (from p in db.Doktor3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS3 = jumlahS3;
            var jumlahD = (from p in db.Diploma3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahD = jumlahD;
            var tahun = (from p in db.WaktuTahunSarjanas orderby p.TahunAkademik select p);
            //Debug.WriteLine("Tahun =" + tahun);
            ViewBag.data = tahun;
            var tahunAkademik = (from p in db.WaktuTahunSarjanas where p.WaktuKey == id select p);
            ViewBag.tahunAkademik = tahunAkademik;
            //var JumlahA = (from p in db.Sarjanas where p.WaktuKey == id && p.DepartemenKey == (from c in db.Departemen where c.FakultasKey == 1 select c))
            var jumlahPerStatusAkademik = (from s in db.Sarjana3
                                           where
                                             s.WaktuKey == id
                                           group new { s.StatusAkademik, s } by new
                                           {
                                               s.StatusAkademik.StatusAkademikNama,
                                               s.StatusAkademik.StatusAkademikKey
                                           } into g
                                           orderby
                                             g.Key.StatusAkademikKey
                                           select new
                                           {
                                               g.Key.StatusAkademikNama,
                                               Column1 = (int?)g.Sum(p => p.s.JumlahMahasiswa)
                                           }).ToList();
            List<SarjanaViewModel> model = new List<SarjanaViewModel>();
            string warna;
            foreach (var item in jumlahPerStatusAkademik)
            {
                warna = gantiWarna(item.StatusAkademikNama);
                model.Add(new SarjanaViewModel()
                {
                    country = item.StatusAkademikNama,
                    visits = item.Column1,
                    color = warna
                });
            }
            return View(model);
        }
        public ActionResult JumlahDOPerProgramStudi()
        {
            int id = 1;
            ViewBag.id = id;
            var jumlahS1 = (from p in db.Sarjana3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS1 = jumlahS1;
            var jumlahS2 = (from p in db.Magister3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS2 = jumlahS2;
            var jumlahS3 = (from p in db.Doktor3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS3 = jumlahS3;
            var jumlahD = (from p in db.Diploma3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahD = jumlahD;
            var tahun = (from p in db.WaktuTahunSarjanas orderby p.TahunAkademik select p);
            //Debug.WriteLine("Tahun =" + tahun);
            ViewBag.data = tahun;
            var tahunAkademik = (from p in db.WaktuTahunSarjanas where p.WaktuKey == id select p);
            ViewBag.tahunAkademik = tahunAkademik;
            //var JumlahA = (from p in db.Sarjanas where p.WaktuKey == id && p.DepartemenKey == (from c in db.Departemen where c.FakultasKey == 1 select c))
            List<IPKViewModel> model = new List<IPKViewModel>();
            var jumlahPerPS = (from s in db.Sarjana3
                               where
                                 s.WaktuKey == id &&
                                 s.StatusAkademikKey == 4
                               group new { s.Departeman, s } by new
                               {
                                   s.Departeman.Kode
                               } into g
                               orderby
                                 g.Key.Kode
                               select new
                               {
                                   g.Key.Kode,
                                   Column1 = (int?)g.Sum(p => p.s.JumlahMahasiswa)
                               }).ToList();
            double ipk;
            foreach (var item in jumlahPerPS)
            {
                ipk = (double)item.Column1;
                model.Add(new IPKViewModel()
                {
                    kode = item.Kode,
                    ipk = ipk
                });
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult JumlahDOPerProgramStudi(int id)
        {
            ViewBag.id = id;
            var jumlahS1 = (from p in db.Sarjana3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS1 = jumlahS1;
            var jumlahS2 = (from p in db.Magister3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS2 = jumlahS2;
            var jumlahS3 = (from p in db.Doktor3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS3 = jumlahS3;
            var jumlahD = (from p in db.Diploma3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahD = jumlahD;
            var tahun = (from p in db.WaktuTahunSarjanas orderby p.TahunAkademik select p);
            //Debug.WriteLine("Tahun =" + tahun);
            ViewBag.data = tahun;
            var tahunAkademik = (from p in db.WaktuTahunSarjanas where p.WaktuKey == id select p);
            ViewBag.tahunAkademik = tahunAkademik;
            //var JumlahA = (from p in db.Sarjanas where p.WaktuKey == id && p.DepartemenKey == (from c in db.Departemen where c.FakultasKey == 1 select c))
            List<IPKViewModel> model = new List<IPKViewModel>();
            var jumlahPerPS = (from s in db.Sarjana3
                               where
                                 s.WaktuKey == id &&
                                 s.StatusAkademikKey == 4
                               group new { s.Departeman, s } by new
                               {
                                   s.Departeman.Kode
                               } into g
                               orderby
                                 g.Key.Kode
                               select new
                               {
                                   g.Key.Kode,
                                   Column1 = (int?)g.Sum(p => p.s.JumlahMahasiswa)
                               }).ToList();
            double ipk;
            foreach (var item in jumlahPerPS)
            {
                ipk = (double)item.Column1;
                model.Add(new IPKViewModel()
                {
                    kode = item.Kode,
                    ipk = ipk
                });
            }
            return View(model);
        }
        public ActionResult JumlahDOPerJalurMasuk()
        {
            int id = 1;
            ViewBag.id = id;
            var jumlahS1 = (from p in db.Sarjana3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS1 = jumlahS1;
            var jumlahS2 = (from p in db.Magister3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS2 = jumlahS2;
            var jumlahS3 = (from p in db.Doktor3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS3 = jumlahS3;
            var jumlahD = (from p in db.Diploma3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahD = jumlahD;
            var tahun = (from p in db.WaktuTahunSarjanas orderby p.TahunAkademik select p);
            //Debug.WriteLine("Tahun =" + tahun);
            ViewBag.data = tahun;
            var tahunAkademik = (from p in db.WaktuTahunSarjanas where p.WaktuKey == id select p);
            ViewBag.tahunAkademik = tahunAkademik;
            //var JumlahA = (from p in db.Sarjanas where p.WaktuKey == id && p.DepartemenKey == (from c in db.Departemen where c.FakultasKey == 1 select c))
            var jumlahPerJalurMasuk = (from s in db.Sarjana3
                                       where
                                         s.StatusAkademikKey == 5 &&
                                         s.WaktuKey == id
                                       group new { s.JalurMasuk, s } by new
                                       {
                                           s.JalurMasuk.JalurMasukKey,
                                           s.JalurMasuk.JalurMasukNama
                                       } into g
                                       orderby
                                         g.Key.JalurMasukKey
                                       select new
                                       {
                                           g.Key.JalurMasukNama,
                                           Column1 = (int?)g.Sum(p => p.s.JumlahMahasiswa)
                                       }).ToList();
            List<SarjanaViewModel> model = new List<SarjanaViewModel>();
            string warna;
            foreach (var item in jumlahPerJalurMasuk)
            {
                warna = gantiWarna(item.JalurMasukNama);
                model.Add(new SarjanaViewModel()
                {
                    country = item.JalurMasukNama,
                    visits = item.Column1,
                    color = warna
                });
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult JumlahDOPerJalurMasuk(int id)
        {
            ViewBag.id = id;
            var jumlahS1 = (from p in db.Sarjana3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS1 = jumlahS1;
            var jumlahS2 = (from p in db.Magister3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS2 = jumlahS2;
            var jumlahS3 = (from p in db.Doktor3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS3 = jumlahS3;
            var jumlahD = (from p in db.Diploma3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahD = jumlahD;
            var tahun = (from p in db.WaktuTahunSarjanas orderby p.TahunAkademik select p);
            //Debug.WriteLine("Tahun =" + tahun);
            ViewBag.data = tahun;
            var tahunAkademik = (from p in db.WaktuTahunSarjanas where p.WaktuKey == id select p);
            ViewBag.tahunAkademik = tahunAkademik;
            //var JumlahA = (from p in db.Sarjanas where p.WaktuKey == id && p.DepartemenKey == (from c in db.Departemen where c.FakultasKey == 1 select c))
            var jumlahPerJalurMasuk = (from s in db.Sarjana3
                                       where
                                         s.StatusAkademikKey == 5 &&
                                         s.WaktuKey == id
                                       group new { s.JalurMasuk, s } by new
                                       {
                                           s.JalurMasuk.JalurMasukKey,
                                           s.JalurMasuk.JalurMasukNama
                                       } into g
                                       orderby
                                         g.Key.JalurMasukKey
                                       select new
                                       {
                                           g.Key.JalurMasukNama,
                                           Column1 = (int?)g.Sum(p => p.s.JumlahMahasiswa)
                                       }).ToList();
            List<SarjanaViewModel> model = new List<SarjanaViewModel>();
            string warna;
            foreach (var item in jumlahPerJalurMasuk)
            {
                warna = gantiWarna(item.JalurMasukNama);
                model.Add(new SarjanaViewModel()
                {
                    country = item.JalurMasukNama,
                    visits = item.Column1,
                    color = warna
                });
            }
            return View(model);
        }
        public ActionResult RataRataSKS()
        {
            int id = 1;
            ViewBag.id = id;
            var jumlahS1 = (from p in db.Sarjana3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS1 = jumlahS1;
            var jumlahS2 = (from p in db.Magister3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS2 = jumlahS2;
            var jumlahS3 = (from p in db.Doktor3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS3 = jumlahS3;
            var jumlahD = (from p in db.Diploma3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahD = jumlahD;
            var tahun = (from p in db.WaktuTahunSarjanas orderby p.TahunAkademik select p);
            //Debug.WriteLine("Tahun =" + tahun);
            ViewBag.data = tahun;
            var tahunAkademik = (from p in db.WaktuTahunSarjanas where p.WaktuKey == id select p);
            ViewBag.tahunAkademik = tahunAkademik;
            //var JumlahA = (from p in db.Sarjanas where p.WaktuKey == id && p.DepartemenKey == (from c in db.Departemen where c.FakultasKey == 1 select c))
            List<IPKViewModel> model = new List<IPKViewModel>();
            var jumlahPerPS = (from Fact_RataRataSKSSarjana in db.RataRataSKSSarjanas
                               where
                                 Fact_RataRataSKSSarjana.WaktuKey == id
                               orderby
                                 Fact_RataRataSKSSarjana.SemesterMahasiswa
                               select new
                               {
                                   Fact_RataRataSKSSarjana.SemesterMahasiswa,
                                   Fact_RataRataSKSSarjana.RataRataSKS
                               }).ToList();
            double ipk;
            foreach (var item in jumlahPerPS)
            {
                ipk = (double)item.RataRataSKS;
                model.Add(new IPKViewModel()
                {
                    kode = item.SemesterMahasiswa.ToString(),
                    ipk = ipk
                });
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult RataRataSKS(int id)
        {
            ViewBag.id = id;
            var jumlahS1 = (from p in db.Sarjana3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS1 = jumlahS1;
            var jumlahS2 = (from p in db.Magister3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS2 = jumlahS2;
            var jumlahS3 = (from p in db.Doktor3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahS3 = jumlahS3;
            var jumlahD = (from p in db.Diploma3 where p.WaktuKey == id select p.JumlahMahasiswa).Sum();
            ViewBag.jumlahD = jumlahD;
            var tahun = (from p in db.WaktuTahunSarjanas orderby p.TahunAkademik select p);
            //Debug.WriteLine("Tahun =" + tahun);
            ViewBag.data = tahun;
            var tahunAkademik = (from p in db.WaktuTahunSarjanas where p.WaktuKey == id select p);
            ViewBag.tahunAkademik = tahunAkademik;
            //var JumlahA = (from p in db.Sarjanas where p.WaktuKey == id && p.DepartemenKey == (from c in db.Departemen where c.FakultasKey == 1 select c))
            List<IPKViewModel> model = new List<IPKViewModel>();
            var jumlahPerPS = (from Fact_RataRataSKSSarjana in db.RataRataSKSSarjanas
                               where
                                 Fact_RataRataSKSSarjana.WaktuKey == id
                               orderby
                                 Fact_RataRataSKSSarjana.SemesterMahasiswa
                               select new
                               {
                                   Fact_RataRataSKSSarjana.SemesterMahasiswa,
                                   Fact_RataRataSKSSarjana.RataRataSKS
                               }).ToList();
            double ipk;
            foreach (var item in jumlahPerPS)
            {
                ipk = (double)item.RataRataSKS;
                model.Add(new IPKViewModel()
                {
                    kode = item.SemesterMahasiswa.ToString(),
                    ipk = ipk
                });
            }
            return View(model);
        }
        public ActionResult RataRataIPKTPB()
        {
            int id = 1;
            ViewBag.id = id;
            var IPKTPB = (from p in db.SarjanaIPKTPBs where p.WaktuKey == id && p.RataRataIPKTPB != 0 select p.RataRataIPKTPB).Average();
            if (IPKTPB == null) IPKTPB = 0;
            double IPKTPBs = (double)IPKTPB;
            ViewBag.IPKTPB = Math.Round(IPKTPBs, 2);
            var IPKLulusan = (from p in db.SarjanaLulusan2 where p.WaktuKey == id && p.RataRataIPKLulusan != 0 select p.RataRataIPKLulusan).Average();
            if (IPKLulusan == null) IPKLulusan = 0;
            double IPKLulusans = (double)IPKLulusan;
            ViewBag.IPKLulusan = Math.Round(IPKLulusans, 2);
            var masaStudi = (from p in db.SarjanaLulusan2 where p.WaktuKey == id && p.RataRataLamaStudi != 0 select p.RataRataLamaStudi).Average();
            if (masaStudi == null) masaStudi = 0;
            double masaStudis = (double)masaStudi;
            ViewBag.masaStudi = Math.Round(masaStudis, 1);
            var masaTunggu = 0;
            ViewBag.masaTunggu = masaTunggu;
            var tahun = (from p in db.WaktuSarjanas select p);
            Debug.WriteLine("Tahun =" + tahun);
            ViewBag.data = tahun;
            var tahunAkademik = (from p in db.WaktuSarjanas where p.WaktuKey == id select p);
            ViewBag.tahunAkademik = tahunAkademik;
            Debug.WriteLine("Tahun Akademik =" + tahunAkademik);
            //var JumlahA = (from p in db.Sarjanas where p.WaktuKey == id && p.DepartemenKey == (from c in db.Departemen where c.FakultasKey == 1 select c))
            List<IPKViewModel> model = new List<IPKViewModel>();
            var rataRataIPKTPB = (from s in db.SarjanaIPKTPBs
                                  where
                                    s.WaktuKey == id &&
                                    s.RataRataIPKTPB != null
                                  orderby
                                    s.Departeman.Kode
                                  select new
                                  {
                                      s.Departeman.Kode,
                                      s.RataRataIPKTPB
                                  });
            double ipkTPB;
            foreach (var item in rataRataIPKTPB)
            {
                ipkTPB = (double)item.RataRataIPKTPB;
                ipkTPB = Math.Round(ipkTPB, 2);
                model.Add(new IPKViewModel()
                {
                    kode = item.Kode,
                    ipk = ipkTPB
                });
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult RataRataIPKTPB(int id)
        {
            ViewBag.id = id;
            var IPKTPB = (from p in db.SarjanaIPKTPBs where p.WaktuKey == id && p.RataRataIPKTPB != 0 select p.RataRataIPKTPB).Average();
            if (IPKTPB == null) IPKTPB = 0;
            double IPKTPBs = (double)IPKTPB;
            ViewBag.IPKTPB = Math.Round(IPKTPBs, 2);
            var IPKLulusan = (from p in db.SarjanaLulusan2 where p.WaktuKey == id && p.RataRataIPKLulusan != 0 select p.RataRataIPKLulusan).Average();
            if (IPKLulusan == null) IPKLulusan = 0;
            double IPKLulusans = (double)IPKLulusan;
            ViewBag.IPKLulusan = Math.Round(IPKLulusans, 2);
            var masaStudi = (from p in db.SarjanaLulusan2 where p.WaktuKey == id && p.RataRataLamaStudi != 0 select p.RataRataLamaStudi).Average();
            if (masaStudi == null) masaStudi = 0;
            double masaStudis = (double)masaStudi;
            ViewBag.masaStudi = Math.Round(masaStudis, 1);
            var masaTunggu = 0;
            ViewBag.masaTunggu = masaTunggu;
            var tahun = (from p in db.WaktuSarjanas select p);
            Debug.WriteLine("Tahun =" + tahun);
            ViewBag.data = tahun;
            var tahunAkademik = (from p in db.WaktuSarjanas where p.WaktuKey == id select p);
            ViewBag.tahunAkademik = tahunAkademik;
            Debug.WriteLine("Tahun Akademik =" + tahunAkademik);
            //var JumlahA = (from p in db.Sarjanas where p.WaktuKey == id && p.DepartemenKey == (from c in db.Departemen where c.FakultasKey == 1 select c))
            List<IPKViewModel> model = new List<IPKViewModel>();
            var rataRataIPKTPB = (from s in db.SarjanaIPKTPBs
                                  where
                                    s.WaktuKey == id &&
                                    s.RataRataIPKTPB != null
                                  orderby
                                    s.Departeman.Kode
                                  select new
                                  {
                                      s.Departeman.Kode,
                                      s.RataRataIPKTPB
                                  });
            double ipkTPB;
            foreach (var item in rataRataIPKTPB)
            {
                ipkTPB = (double)item.RataRataIPKTPB;
                ipkTPB = Math.Round(ipkTPB, 2);
                model.Add(new IPKViewModel()
                {
                    kode = item.Kode,
                    ipk = ipkTPB
                });
            }
            return View(model);
        }
        public ActionResult RataRataIPKLulusan()
        {
            int id = 1;
            ViewBag.id = id;
            var IPKTPB = (from p in db.SarjanaIPKTPBs where p.WaktuKey == id && p.RataRataIPKTPB != 0 select p.RataRataIPKTPB).Average();
            if (IPKTPB == null) IPKTPB = 0;
            double IPKTPBs = (double)IPKTPB;
            ViewBag.IPKTPB = Math.Round(IPKTPBs, 2);
            var IPKLulusan = (from p in db.SarjanaLulusan2 where p.WaktuKey == id && p.RataRataIPKLulusan != 0 select p.RataRataIPKLulusan).Average();
            if (IPKLulusan == null) IPKLulusan = 0;
            double IPKLulusans = (double)IPKLulusan;
            ViewBag.IPKLulusan = Math.Round(IPKLulusans, 2);
            var masaStudi = (from p in db.SarjanaLulusan2 where p.WaktuKey == id && p.RataRataLamaStudi != 0 select p.RataRataLamaStudi).Average();
            if (masaStudi == null) masaStudi = 0;
            double masaStudis = (double)masaStudi;
            ViewBag.masaStudi = Math.Round(masaStudis, 1);
            var masaTunggu = 0;
            ViewBag.masaTunggu = masaTunggu;
            var tahun = (from p in db.WaktuSarjanas select p);
            Debug.WriteLine("Tahun =" + tahun);
            ViewBag.data = tahun;
            var tahunAkademik = (from p in db.WaktuSarjanas where p.WaktuKey == id select p);
            ViewBag.tahunAkademik = tahunAkademik;
            Debug.WriteLine("Tahun Akademik =" + tahunAkademik);
            //var JumlahA = (from p in db.Sarjanas where p.WaktuKey == id && p.DepartemenKey == (from c in db.Departemen where c.FakultasKey == 1 select c))
            List<IPKViewModel> model = new List<IPKViewModel>();
            var rataRataIPKL = (from sl in db.SarjanaLulusan2
                                where
                                  sl.WaktuKey == id
                                orderby
                                  sl.Departeman.Kode
                                select new
                                {
                                    sl.Departeman.Kode,
                                    sl.RataRataIPKLulusan
                                }).ToList();
            double ipkTPB;
            foreach (var item in rataRataIPKL)
            {
                if (item.RataRataIPKLulusan == 0) ipkTPB = 0.0;
                else
                {
                    ipkTPB = (double)item.RataRataIPKLulusan;
                    ipkTPB = Math.Round(ipkTPB, 2);
                }
                model.Add(new IPKViewModel()
                {
                    kode = item.Kode,
                    ipk = ipkTPB
                });
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult RataRataIPKLulusan(int id)
        {
            ViewBag.id = id;
            var IPKTPB = (from p in db.SarjanaIPKTPBs where p.WaktuKey == id && p.RataRataIPKTPB != 0 select p.RataRataIPKTPB).Average();
            if (IPKTPB == null) IPKTPB = 0;
            double IPKTPBs = (double)IPKTPB;
            ViewBag.IPKTPB = Math.Round(IPKTPBs, 2);
            var IPKLulusan = (from p in db.SarjanaLulusan2 where p.WaktuKey == id && p.RataRataIPKLulusan != 0 select p.RataRataIPKLulusan).Average();
            if (IPKLulusan == null) IPKLulusan = 0;
            double IPKLulusans = (double)IPKLulusan;
            ViewBag.IPKLulusan = Math.Round(IPKLulusans, 2);
            var masaStudi = (from p in db.SarjanaLulusan2 where p.WaktuKey == id && p.RataRataLamaStudi != 0 select p.RataRataLamaStudi).Average();
            if (masaStudi == null) masaStudi = 0;
            double masaStudis = (double)masaStudi;
            ViewBag.masaStudi = Math.Round(masaStudis, 1);
            var masaTunggu = 0;
            ViewBag.masaTunggu = masaTunggu;
            var tahun = (from p in db.WaktuSarjanas select p);
            Debug.WriteLine("Tahun =" + tahun);
            ViewBag.data = tahun;
            var tahunAkademik = (from p in db.WaktuSarjanas where p.WaktuKey == id select p);
            ViewBag.tahunAkademik = tahunAkademik;
            Debug.WriteLine("Tahun Akademik =" + tahunAkademik);
            //var JumlahA = (from p in db.Sarjanas where p.WaktuKey == id && p.DepartemenKey == (from c in db.Departemen where c.FakultasKey == 1 select c))
            List<IPKViewModel> model = new List<IPKViewModel>();
            var rataRataIPKL = (from sl in db.SarjanaLulusan2
                                where
                                  sl.WaktuKey == id
                                orderby
                                  sl.Departeman.Kode
                                select new
                                {
                                    sl.Departeman.Kode,
                                    sl.RataRataIPKLulusan
                                }).ToList();
            double ipkTPB;
            foreach (var item in rataRataIPKL)
            {
                if (item.RataRataIPKLulusan == 0) ipkTPB = 0.0;
                else
                {
                    ipkTPB = (double)item.RataRataIPKLulusan;
                    ipkTPB = Math.Round(ipkTPB, 2);
                }
                model.Add(new IPKViewModel()
                {
                    kode = item.Kode,
                    ipk = ipkTPB
                });
            }
            return View(model);
        }
        public ActionResult RataRataLamaStudi()
        {
            int id = 1;
            ViewBag.id = id;
            var IPKTPB = (from p in db.SarjanaIPKTPBs where p.WaktuKey == id && p.RataRataIPKTPB != 0 select p.RataRataIPKTPB).Average();
            if (IPKTPB == null) IPKTPB = 0;
            double IPKTPBs = (double)IPKTPB;
            ViewBag.IPKTPB = Math.Round(IPKTPBs, 2);
            var IPKLulusan = (from p in db.SarjanaLulusan2 where p.WaktuKey == id && p.RataRataIPKLulusan != 0 select p.RataRataIPKLulusan).Average();
            if (IPKLulusan == null) IPKLulusan = 0;
            double IPKLulusans = (double)IPKLulusan;
            ViewBag.IPKLulusan = Math.Round(IPKLulusans, 2);
            var masaStudi = (from p in db.SarjanaLulusan2 where p.WaktuKey == id && p.RataRataLamaStudi != 0 select p.RataRataLamaStudi).Average();
            if (masaStudi == null) masaStudi = 0;
            double masaStudis = (double)masaStudi;
            ViewBag.masaStudi = Math.Round(masaStudis, 1);
            var masaTunggu = 0;
            ViewBag.masaTunggu = masaTunggu;
            var tahun = (from p in db.WaktuSarjanas select p);
            Debug.WriteLine("Tahun =" + tahun);
            ViewBag.data = tahun;
            var tahunAkademik = (from p in db.WaktuSarjanas where p.WaktuKey == id select p);
            ViewBag.tahunAkademik = tahunAkademik;
            Debug.WriteLine("Tahun Akademik =" + tahunAkademik);
            //var JumlahA = (from p in db.Sarjanas where p.WaktuKey == id && p.DepartemenKey == (from c in db.Departemen where c.FakultasKey == 1 select c))
            List<IPKViewModel> model = new List<IPKViewModel>();
            var rataRataIPKL = (from sl in db.SarjanaLulusan2
                                where
                                  sl.WaktuKey == id
                                orderby
                                  sl.Departeman.Kode
                                select new
                                {
                                    sl.Departeman.Kode,
                                    sl.RataRataLamaStudi
                                }).ToList();
            double ipkTPB;
            foreach (var item in rataRataIPKL)
            {
                if (item.RataRataLamaStudi == 0) ipkTPB = 0.0;
                else
                {
                    ipkTPB = (double)item.RataRataLamaStudi;
                    ipkTPB = Math.Round(ipkTPB, 0);
                }
                model.Add(new IPKViewModel()
                {
                    kode = item.Kode,
                    ipk = ipkTPB
                });
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult RataRataLamaStudi(int id)
        {
            ViewBag.id = id;
            var IPKTPB = (from p in db.SarjanaIPKTPBs where p.WaktuKey == id && p.RataRataIPKTPB != 0 select p.RataRataIPKTPB).Average();
            if (IPKTPB == null) IPKTPB = 0;
            double IPKTPBs = (double)IPKTPB;
            ViewBag.IPKTPB = Math.Round(IPKTPBs, 2);
            var IPKLulusan = (from p in db.SarjanaLulusan2 where p.WaktuKey == id && p.RataRataIPKLulusan != 0 select p.RataRataIPKLulusan).Average();
            if (IPKLulusan == null) IPKLulusan = 0;
            double IPKLulusans = (double)IPKLulusan;
            ViewBag.IPKLulusan = Math.Round(IPKLulusans, 2);
            var masaStudi = (from p in db.SarjanaLulusan2 where p.WaktuKey == id && p.RataRataLamaStudi != 0 select p.RataRataLamaStudi).Average();
            if (masaStudi == null) masaStudi = 0;
            double masaStudis = (double)masaStudi;
            ViewBag.masaStudi = Math.Round(masaStudis, 1);
            var masaTunggu = 0;
            ViewBag.masaTunggu = masaTunggu;
            var tahun = (from p in db.WaktuSarjanas select p);
            Debug.WriteLine("Tahun =" + tahun);
            ViewBag.data = tahun;
            var tahunAkademik = (from p in db.WaktuSarjanas where p.WaktuKey == id select p);
            ViewBag.tahunAkademik = tahunAkademik;
            Debug.WriteLine("Tahun Akademik =" + tahunAkademik);
            //var JumlahA = (from p in db.Sarjanas where p.WaktuKey == id && p.DepartemenKey == (from c in db.Departemen where c.FakultasKey == 1 select c))
            List<IPKViewModel> model = new List<IPKViewModel>();
            var rataRataIPKL = (from sl in db.SarjanaLulusan2
                                where
                                  sl.WaktuKey == id
                                orderby
                                  sl.Departeman.Kode
                                select new
                                {
                                    sl.Departeman.Kode,
                                    sl.RataRataLamaStudi
                                }).ToList();
            double ipkTPB;
            foreach (var item in rataRataIPKL)
            {
                if (item.RataRataLamaStudi == 0) ipkTPB = 0.0;
                else
                {
                    ipkTPB = (double)item.RataRataLamaStudi;
                    ipkTPB = Math.Round(ipkTPB, 0);
                }
                model.Add(new IPKViewModel()
                {
                    kode = item.Kode,
                    ipk = ipkTPB
                });
            }
            return View(model);
        }
        public ActionResult ProsentaseLulusTepatWaktu()
        {
            int id = 1;
            ViewBag.id = id;
            var IPKTPB = (from p in db.SarjanaIPKTPBs where p.WaktuKey == id && p.RataRataIPKTPB != 0 select p.RataRataIPKTPB).Average();
            if (IPKTPB == null) IPKTPB = 0;
            double IPKTPBs = (double)IPKTPB;
            ViewBag.IPKTPB = Math.Round(IPKTPBs, 2);
            var IPKLulusan = (from p in db.SarjanaLulusan2 where p.WaktuKey == id && p.RataRataIPKLulusan != 0 select p.RataRataIPKLulusan).Average();
            if (IPKLulusan == null) IPKLulusan = 0;
            double IPKLulusans = (double)IPKLulusan;
            ViewBag.IPKLulusan = Math.Round(IPKLulusans, 2);
            var masaStudi = (from p in db.SarjanaLulusan2 where p.WaktuKey == id && p.RataRataLamaStudi != 0 select p.RataRataLamaStudi).Average();
            if (masaStudi == null) masaStudi = 0;
            double masaStudis = (double)masaStudi;
            ViewBag.masaStudi = Math.Round(masaStudis, 1);
            var masaTunggu = 0;
            ViewBag.masaTunggu = masaTunggu;
            var tahun = (from p in db.WaktuSarjanas select p);
            Debug.WriteLine("Tahun =" + tahun);
            ViewBag.data = tahun;
            var tahunAkademik = (from p in db.WaktuSarjanas where p.WaktuKey == id select p);
            ViewBag.tahunAkademik = tahunAkademik;
            Debug.WriteLine("Tahun Akademik =" + tahunAkademik);
            //var JumlahA = (from p in db.Sarjanas where p.WaktuKey == id && p.DepartemenKey == (from c in db.Departemen where c.FakultasKey == 1 select c))
            List<IPKViewModel> model = new List<IPKViewModel>();
            var jumlahLulusTepatWaktu = (from s in db.SarjanaLulusan2
                                         where
                                           s.WaktuKey == id
                                         orderby
                                           s.Departeman.Kode
                                         select new
                                         {
                                             s.Departeman.Kode,
                                             s.ProsentaseLulusTepatWaktu
                                         }).ToList();
            int?[] jumlahTepat = new int?[90];
            int? temp;
            int c = 0;
            foreach (var item in jumlahLulusTepatWaktu)
            {
                temp = item.ProsentaseLulusTepatWaktu;
                if (item.ProsentaseLulusTepatWaktu == null) temp = 0;
                jumlahTepat[c] = temp;
                c++;
            }
            var jumlahPerPS = (from s in db.JumlahPSSarjanas
                               where
                                 s.WaktuKey == id
                               group new { s.Departeman, s } by new
                               {
                                   s.Departeman.Kode
                               } into g
                               orderby
                                g.Key.Kode
                               select new
                               {
                                   g.Key.Kode,
                                   Column1 = (int?)g.Sum(p => p.s.JumlahMahasiswa)
                               }).ToList();
            c = 0;
            double prosentaseTepat;
            foreach (var item in jumlahPerPS)
            {
                prosentaseTepat = Math.Round((double)jumlahTepat[c] / (double)item.Column1 * 100, 2);
                model.Add(new IPKViewModel()
                {
                    kode = item.Kode,
                    ipk = prosentaseTepat
                });
                c++;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult ProsentaseLulusTepatWaktu(int id)
        {
            ViewBag.id = id;
            var IPKTPB = (from p in db.SarjanaIPKTPBs where p.WaktuKey == id && p.RataRataIPKTPB != 0 select p.RataRataIPKTPB).Average();
            if (IPKTPB == null) IPKTPB = 0;
            double IPKTPBs = (double)IPKTPB;
            ViewBag.IPKTPB = Math.Round(IPKTPBs, 2);
            var IPKLulusan = (from p in db.SarjanaLulusan2 where p.WaktuKey == id && p.RataRataIPKLulusan != 0 select p.RataRataIPKLulusan).Average();
            if (IPKLulusan == null) IPKLulusan = 0;
            double IPKLulusans = (double)IPKLulusan;
            ViewBag.IPKLulusan = Math.Round(IPKLulusans, 2);
            var masaStudi = (from p in db.SarjanaLulusan2 where p.WaktuKey == id && p.RataRataLamaStudi != 0 select p.RataRataLamaStudi).Average();
            if (masaStudi == null) masaStudi = 0;
            double masaStudis = (double)masaStudi;
            ViewBag.masaStudi = Math.Round(masaStudis, 1);
            var masaTunggu = 0;
            ViewBag.masaTunggu = masaTunggu;
            var tahun = (from p in db.WaktuSarjanas select p);
            Debug.WriteLine("Tahun =" + tahun);
            ViewBag.data = tahun;
            var tahunAkademik = (from p in db.WaktuSarjanas where p.WaktuKey == id select p);
            ViewBag.tahunAkademik = tahunAkademik;
            Debug.WriteLine("Tahun Akademik =" + tahunAkademik);
            //var JumlahA = (from p in db.Sarjanas where p.WaktuKey == id && p.DepartemenKey == (from c in db.Departemen where c.FakultasKey == 1 select c))
            List<IPKViewModel> model = new List<IPKViewModel>();
            var jumlahLulusTepatWaktu = (from s in db.SarjanaLulusan2
                                         where
                                           s.WaktuKey == id
                                         orderby
                                           s.Departeman.Kode
                                         select new
                                         {
                                             s.Departeman.Kode,
                                             s.ProsentaseLulusTepatWaktu
                                         }).ToList();
            int?[] jumlahTepat = new int?[90];
            int? temp;
            int c = 0;
            foreach (var item in jumlahLulusTepatWaktu)
            {
                temp = item.ProsentaseLulusTepatWaktu;
                if (item.ProsentaseLulusTepatWaktu == null) temp = 0;
                jumlahTepat[c] = temp;
                c++;
            }
            var jumlahPerPS = (from s in db.JumlahPSSarjanas
                               where
                                 s.WaktuKey == id
                               group new { s.Departeman, s } by new
                               {
                                   s.Departeman.Kode
                               } into g
                               orderby
                                g.Key.Kode
                               select new
                               {
                                   g.Key.Kode,
                                   Column1 = (int?)g.Sum(p => p.s.JumlahMahasiswa)
                               }).ToList();
            c = 0;
            double prosentaseTepat;
            foreach (var item in jumlahPerPS)
            {
                prosentaseTepat = Math.Round((double)jumlahTepat[c] / (double)item.Column1 * 100, 2);
                model.Add(new IPKViewModel()
                {
                    kode = item.Kode,
                    ipk = prosentaseTepat
                });
                c++;
            }
            return View(model);
        }
    }
}
