﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cinema.Models;

namespace Cinema.Controllers
{
    public class HinhThucThanhToansController : Controller
    {
        private Connect db = new Connect();

        // GET: HinhThucThanhToans
        public ActionResult Index()
        {
            return View(db.HinhThucThanhToans.ToList());
        }

        // GET: HinhThucThanhToans/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HinhThucThanhToan hinhThucThanhToan = db.HinhThucThanhToans.Find(id);
            if (hinhThucThanhToan == null)
            {
                return HttpNotFound();
            }
            return View(hinhThucThanhToan);
        }

        // GET: HinhThucThanhToans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HinhThucThanhToans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "hinhthucID,LoaiHinhThuc")] HinhThucThanhToan hinhThucThanhToan)
        {
            if (ModelState.IsValid)
            {
                db.HinhThucThanhToans.Add(hinhThucThanhToan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hinhThucThanhToan);
        }

        // GET: HinhThucThanhToans/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HinhThucThanhToan hinhThucThanhToan = db.HinhThucThanhToans.Find(id);
            if (hinhThucThanhToan == null)
            {
                return HttpNotFound();
            }
            return View(hinhThucThanhToan);
        }

        // POST: HinhThucThanhToans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "hinhthucID,LoaiHinhThuc")] HinhThucThanhToan hinhThucThanhToan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hinhThucThanhToan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hinhThucThanhToan);
        }

        // GET: HinhThucThanhToans/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HinhThucThanhToan hinhThucThanhToan = db.HinhThucThanhToans.Find(id);
            if (hinhThucThanhToan == null)
            {
                return HttpNotFound();
            }
            return View(hinhThucThanhToan);
        }

        // POST: HinhThucThanhToans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HinhThucThanhToan hinhThucThanhToan = db.HinhThucThanhToans.Find(id);
            db.HinhThucThanhToans.Remove(hinhThucThanhToan);
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
