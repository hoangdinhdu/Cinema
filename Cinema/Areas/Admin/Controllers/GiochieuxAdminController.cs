using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cinema.Models;

namespace Cinema.Areas.Admin.Controllers
{
    public class GiochieuxAdminController : Controller
    {
        private Connect db = new Connect();

        // GET: Admin/GiochieuxAdmin
        public ActionResult Index()
        {
            return View(db.Giochieus.ToList());
        }

        // GET: Admin/GiochieuxAdmin/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giochieu giochieu = db.Giochieus.Find(id);
            if (giochieu == null)
            {
                return HttpNotFound();
            }
            return View(giochieu);
        }

        // GET: Admin/GiochieuxAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/GiochieuxAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDGioChieu,ThoiGianChieu")] Giochieu giochieu)
        {
            if (ModelState.IsValid)
            {
                db.Giochieus.Add(giochieu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(giochieu);
        }

        // GET: Admin/GiochieuxAdmin/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giochieu giochieu = db.Giochieus.Find(id);
            if (giochieu == null)
            {
                return HttpNotFound();
            }
            return View(giochieu);
        }

        // POST: Admin/GiochieuxAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDGioChieu,ThoiGianChieu")] Giochieu giochieu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(giochieu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(giochieu);
        }

        // GET: Admin/GiochieuxAdmin/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giochieu giochieu = db.Giochieus.Find(id);
            if (giochieu == null)
            {
                return HttpNotFound();
            }
            return View(giochieu);
        }

        // POST: Admin/GiochieuxAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Giochieu giochieu = db.Giochieus.Find(id);
            db.Giochieus.Remove(giochieu);
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
    }
}
