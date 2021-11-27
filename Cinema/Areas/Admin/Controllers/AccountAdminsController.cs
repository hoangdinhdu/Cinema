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
    [Authorize(Roles ="Admin")]
    public class AccountAdminsController : Controller
    {
        private Connect db = new Connect();
        Encrytion ecry = new Encrytion();

        // GET: Admin/Accounts
        public ActionResult Index()
        {
            return View(db.Accounts.ToList());
        }

        // GET: Admin/Accounts/Details/5
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(Account acc)
        {
            if (ModelState.IsValid)
            {
                acc.Password = ecry.PassWordEncrytion(acc.Password);
                acc.ConfirmPassword = ecry.PassWordEncrytion(acc.ConfirmPassword);
                db.Accounts.Add(acc);
                db.SaveChanges();
                return RedirectToAction("Index", "Movies");
            }
            return View(acc);
        }
    }
}
