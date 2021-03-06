using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cinema.Models;

namespace Cinema.Areas.Admin.Controllers
{
    public class MoviesAdminController : Controller
    {
        StringProcess strPro = new StringProcess();
        private Connect db = new Connect();

        // GET: Admin/MoviesAdmin
        public ActionResult Index()
        {
            var movies = db.Movies.Include(m => m.Giochieus);
            return View(movies.ToList());
        }

        // GET: Admin/MoviesAdmin/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Admin/MoviesAdmin/Create
        public ActionResult Create()
        {
            if(db.Movies.OrderByDescending(m => m.MovieID).Count() == 0)
            {
                ViewBag.NewMVID = "Movi1";
            }else
            {
            var MVID = db.Movies.OrderByDescending(m => m.MovieID).FirstOrDefault().MovieID;
            var newID = strPro.Genneratekey(MVID);
            ViewBag.NewMVID = newID;
            }
            ViewBag.IDGioChieu = new SelectList(db.Giochieus, "IDGioChieu", "ThoiGianChieu");
            return View();
        }

        // POST: Admin/MoviesAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*[Bind(Include = "MovieID,MovieName,IDGioChieu,MovieMoney,MovieSeat,ProductImageName")]*/ Movie movie)
        {
            if (ModelState.IsValid)
            {//lấy trên file
                string fileName = Path.GetFileNameWithoutExtension(movie.ProductImgFile.FileName);
                //lấy phần mở rộng
                string extension = Path.GetExtension(movie.ProductImgFile.FileName);
                // đổi tên
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                //gán tên file bằng tên product
                movie.ProductImageName = "/Images/" + fileName;
                //Lưu vào trong thư mục
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                movie.ProductImgFile.SaveAs(fileName);
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDGioChieu = new SelectList(db.Giochieus, "IDGioChieu", "ThoiGianChieu", movie.IDGioChieu);
            return View(movie);
        }

        // GET: Admin/MoviesAdmin/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDGioChieu = new SelectList(db.Giochieus, "IDGioChieu", "ThoiGianChieu", movie.IDGioChieu);
            return View(movie);
        }

        // POST: Admin/MoviesAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieID,MovieName,IDGioChieu,MovieMoney,MovieSeat,ProductImageName")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDGioChieu = new SelectList(db.Giochieus, "IDGioChieu", "ThoiGianChieu", movie.IDGioChieu);
            return View(movie);
        }

        // GET: Admin/MoviesAdmin/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Admin/MoviesAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
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
