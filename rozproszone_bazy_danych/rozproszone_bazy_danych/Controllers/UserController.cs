using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using rozproszone_bazy_danych.Models;
using System.Web.Security;
using System.Data.SqlClient;

namespace rozproszone_bazy_danych.Controllers
    {
    public class UserController : Controller
        {
        //private UsersContext db = new UsersContext();
        private SettlementEntities db = new SettlementEntities();
        //
        // GET: /User/

        public ActionResult Index()
            {
            return View(db.Users.ToList());
            }

        [HttpGet]
        public ActionResult LogIn()
            {
            return View();
            }

        [HttpPost]
        public ActionResult LogIn(UserLogin userr)
            {
            if (ModelState.IsValid)
                {
                if (IsValid(userr.UserName, userr.Password))
                    {
                    //FormsAuthentication.SetAuthCookie(userr.UserName, true);

                    return RedirectToAction("Index", "Home");
                    }
                else
                    {
                    ModelState.AddModelError("", "Login details are wrong.");
                    }
                }
            return View(userr);
            }


        private bool IsValid(string login, string password)
            {
            var crypto = new SimpleCrypto.PBKDF2();
            bool IsValid = false;

            var user = db.Users.FirstOrDefault(u => u.UserName == login);

            if (user != null)
                {
                if (user.Password == crypto.Compute(password, user.PasswordSalt))
                    {
                    var ticket = new FormsAuthenticationTicket(1, user.UserName,
                      DateTime.Now, DateTime.Now.AddMinutes(30), false, user.Id.ToString(), FormsAuthentication.FormsCookiePath);
                    Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket)));

                    IsValid = true;
                    }
                }

            return IsValid;
            }


        public ActionResult Register()
            {
            return View();
            }

        [HttpPost]
        public ActionResult Register(Users model)
            {
            if (ModelState.IsValid)
                {
                try
                    {
                    var crypto = new SimpleCrypto.PBKDF2();

                    var encrypted = crypto.Compute(model.Password);

                    var newuser = db.Users.Create();
                    newuser.UserName = model.UserName;
                    newuser.Password = encrypted;
                    newuser.PasswordSalt = crypto.Salt;
                    newuser.Phone = model.Phone;
                    newuser.Pesel = model.Pesel;
                    newuser.Mail = model.Mail;
                    newuser.Last_energy_usage = 0;
                    newuser.FirstName = model.FirstName;
                    newuser.SureName = model.SureName;
                    newuser.City_Id = model.City_Id;
                    db.Users.Add(newuser);
                    db.SaveChanges();
                    }
                catch (Exception ex)
                    {
                    Console.WriteLine(ex.Message);
                    }

                }
            return RedirectToAction("Index", "Home");
            }

        public ActionResult ProvinceList()
            {
            List<Province> list = db.Province.ToList();

            if (HttpContext.Request.IsAjaxRequest())
                {
                return Json(new SelectList(list, "Id", "name"), JsonRequestBehavior.AllowGet);
                }

            return View(list);
            }

        public ActionResult CityList(int id)
            {
            List<City> list = db.City.Where(x=>x.Province_Id == id).ToList();

            if (HttpContext.Request.IsAjaxRequest())
                {
                return Json(new SelectList(list, "Id", "name"), JsonRequestBehavior.AllowGet);
                }
            
            return View(list);
            }

        public ActionResult LogOut()
            {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
            }
        //
        // GET: /User/Details/5

        public ActionResult Details(int id = 0)
            {
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            var ticketInfo = FormsAuthentication.Decrypt(cookie.Value);
            id = int.Parse(ticketInfo.UserData);
            Users users = db.Users.Find(id);
            if (users == null)
                {
                return HttpNotFound();
                }
            return View(users);
            }

        //
        // GET: /User/Create

        public ActionResult Create()
            {
            return View();
            }

        //
        // POST: /User/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Users users)
            {
            if (ModelState.IsValid)
                {
                db.Users.Add(users);
                db.SaveChanges();
                return RedirectToAction("Index");
                }

            return View(users);
            }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(int id = 0)
            {

            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            var ticketInfo = FormsAuthentication.Decrypt(cookie.Value);
            id = int.Parse(ticketInfo.UserData);
            Users users = db.Users.Find(id);
            if (users == null)
                {
                return HttpNotFound();
                }
            return View(users);
           
            }

        //
        // POST: /User/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Users users)
            {
            if (ModelState.IsValid)
                {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
                }
            return View(users);
            }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(int id = 0)
            {
            Users users = db.Users.Find(id);
            if (users == null)
                {
                return HttpNotFound();
                }
            return View(users);
            }

        //
        // POST: /User/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
            {
            Users users = db.Users.Find(id);
            db.Users.Remove(users);
            db.SaveChanges();
            return RedirectToAction("Index");
            }

        protected override void Dispose(bool disposing)
            {
            db.Dispose();
            base.Dispose(disposing);
            }
        }
    }