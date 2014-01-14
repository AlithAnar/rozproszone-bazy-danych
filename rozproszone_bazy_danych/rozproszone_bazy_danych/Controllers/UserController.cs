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
using rozproszone_bazy_danych.Security;

namespace rozproszone_bazy_danych.Controllers
    {
    public class UserController : Controller
        {
        //private UsersContext db = new UsersContext();
        DataBaseManager db;
        public UserController()
        {
            db = new DataBaseManager();
        }
        //
        // GET: /User/

        public ActionResult Index()
            {
            return View(db.GetUsers().ToList());
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

            var user = db.GetUser(login);

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
                        db.CreateUser(model);
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

                List<Province> list = db.GetProvinces().ToList();

            if (HttpContext.Request.IsAjaxRequest())
                {
                return Json(new SelectList(list, "Id", "name"), JsonRequestBehavior.AllowGet);
                }

            return View(list);
            }

        public ActionResult CityList(int id)
            {
                List<City> list = db.GetCities(id).ToList();

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
            Users users = db.GetUser(User.Identity.Name);
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
                db.CreateUser(users);
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
            Users users = db.GetUser(User.Identity.Name);
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
        public ActionResult Edit(Users user)
            {
            if (ModelState.IsValid)
                {
                    db.EditUser(user);
                return RedirectToAction("Index");
                }
            return View(user);
            }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(int id = 0)
            {
            Users users = db.GetUser(User.Identity.Name);
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
                db.RemoveUser(id, User.Identity.Name);
            return RedirectToAction("Index");
            }

        public PartialViewResult GetMenu()
        {
            ViewBag.admin = db.IsInRole(User.Identity.Name, "Admin");
            return PartialView();
        }
        protected override void Dispose(bool disposing)
            {
            db.Dispose();
            base.Dispose(disposing);
            }
        }
    }