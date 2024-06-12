using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using MakeMeUpzz.Model;
using System.Web.Security;
using MakeMeUpzz.Models;

namespace MakeMeUpzz.Controllers
{
    public class HomeController : Controller
    {
        private MakeMeUpzzContext db = new MakeMeUpzzContext();

        // GET: Home
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("AdminHome");
            }
            else if (User.IsInRole("Customer"))
            {
                return RedirectToAction("CustomerHome");
            }
            return View();
        }

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.SingleOrDefault(u => u.Username == model.Username && u.Password == model.Password);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Username, model.RememberMe);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Invalid username or password.");
            }
            return View(model);
        }

        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Username = model.Username,
                    Password = model.Password,
                    Email = model.Email,
                    Gender = model.Gender,
                    DateOfBirth = model.DateOfBirth,
                    Role = "Customer"
                };
                db.Users.Add(user);
                db.SaveChanges();
                FormsAuthentication.SetAuthCookie(user.Username, false);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: AdminHome
        [Authorize(Roles = "Admin")]
        public ActionResult AdminHome()
        {
            var customers = db.Users.Where(u => u.Role == "Customer").ToList();
            return View(customers);
        }

        // GET: CustomerHome
        [Authorize(Roles = "Customer")]
        public ActionResult CustomerHome()
        {
            var makeup = db.Makeups.ToList();
            return View(makeup);
        }

        // GET: ManageMakeup
        [Authorize(Roles = "Admin")]
        public ActionResult ManageMakeup()
        {
            var makeups = db.Makeups.ToList();
            return View(makeups);
        }

        // GET: InsertMakeup
        [Authorize(Roles = "Admin")]
        public ActionResult InsertMakeup()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult InsertMakeup(Makeup model)
        {
            if (ModelState.IsValid)
            {
                db.Makeups.Add(model);
                db.SaveChanges();
                return RedirectToAction("ManageMakeup");
            }
            return View(model);
        }

        // GET: UpdateMakeup
        [Authorize(Roles = "Admin")]
        public ActionResult UpdateMakeup(int id)
        {
            var makeup = db.Makeups.Find(id);
            if (makeup == null)
            {
                return HttpNotFound();
            }
            return View(makeup);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult UpdateMakeup(Makeup model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ManageMakeup");
            }
            return View(model);
        }

        // GET: DeleteMakeup
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteMakeup(int id)
        {
            var makeup = db.Makeups.Find(id);
            if (makeup == null)
            {
                return HttpNotFound();
            }
            db.Makeups.Remove(makeup);
            db.SaveChanges();
            return RedirectToAction("ManageMakeup");
        }

        // GET: Logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
