using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using rozproszone_bazy_danych.Models;
using System.Web.Security;

namespace rozproszone_bazy_danych.Controllers
{
    public class UserController : Controller
    {
        private UsersContext db = new UsersContext();

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
        public ActionResult LogIn(Users userr)
            {
            if (IsValid(userr.UserName, userr.Password))
                {
                FormsAuthentication.SetAuthCookie(userr.UserName, false);
                return RedirectToAction("Index", "Home");
                }
            else
                {
                ModelState.AddModelError("", "Login details are wrong.");
                }
            return View(userr);
            }

        private bool IsValid(string login, string password)
            {
            bool IsValid = false;

                var user = db.Users.FirstOrDefault(u => u.UserName == login);
                if (user != null)
                    {
                    if (user.Password == password)
                        {
                        IsValid = true;
                        }
                    }
                
            return IsValid;
            } 


        //
        // GET: /User/Details/5

        public ActionResult Details(int id = 0)
        {
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