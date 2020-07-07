using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KT0707NguyenTuanNghia_59131580.Models;

namespace KT0707NguyenTuanNghia_59131580.Controllers
{
    public class SanPham0720_59131580Controller : Controller
    {
        private KT0702_59131580Entities db = new KT0702_59131580Entities();
        public ActionResult GioiThieu()
        {
            return View();
        }
        // GET: SanPham0720_59131580
        public ActionResult Index()
        {
            var sanPhams = db.SanPhams.Include(s => s.LoaiSP);
            return View(sanPhams.ToList());
        }

        // GET: SanPham0720_59131580/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: SanPham0720_59131580/Create
        public ActionResult Create()
        {
            ViewBag.MaLSP = new SelectList(db.LoaiSPs, "MaLSP", "TenLSP");
            return View();
        }

        // POST: SanPham0720_59131580/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,TenSP,DVT,DonGia,XuatXu,NhaCungCap,MaLSP,GhiChu")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLSP = new SelectList(db.LoaiSPs, "MaLSP", "TenLSP", sanPham.MaLSP);
            return View(sanPham);
        }

        // GET: SanPham0720_59131580/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLSP = new SelectList(db.LoaiSPs, "MaLSP", "TenLSP", sanPham.MaLSP);
            return View(sanPham);
        }

        // POST: SanPham0720_59131580/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,TenSP,DVT,DonGia,XuatXu,NhaCungCap,MaLSP,GhiChu")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLSP = new SelectList(db.LoaiSPs, "MaLSP", "TenLSP", sanPham.MaLSP);
            return View(sanPham);
        }

        // GET: SanPham0720_59131580/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: SanPham0720_59131580/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanPham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult TimKiem(String MaSP ="", String MaLSP="")
        {
            
            ViewBag.MaSP = MaSP;
            
            ViewBag.MaLSP = new SelectList(db.LoaiSPs, "MaLSP", "TenLSP");
            var sanpham = db.SanPhams.SqlQuery("SanPham_TimKiem'" + MaSP + MaLSP + "'");
            if (sanpham.Count() == 0)
                ViewBag.TB = "Không có thông tin tìm kiếm.";
            return View(sanpham.ToList());
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
