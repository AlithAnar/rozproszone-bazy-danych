using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using rozproszone_bazy_danych.Models;
using rozproszone_bazy_danych.Security;
using System.Web.Security;

namespace rozproszone_bazy_danych.Controllers
{
    public class AdminController : Controller
    {
        DataBaseManager db;
        public AdminController()
        {
            db = new DataBaseManager();
        }
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Settlements()
        {
            try
            {
                //var settlement = db.Settlement.Where(item => item.Users.UserName == User.Identity.Name);
                var settlement = db.GetAllSettlements();
                ViewBag.error = "";
                return View(settlement.ToList());
            }
            catch (EntityException ex)
            {
                var settlement = new List<Settlement>();
                ViewBag.error = "Brak połączenia z bazą danych";
                return View(settlement);
            }
        }

        public ActionResult Users()
        {
            try
            {
                var Users = db.GetUsers();
                ViewBag.error = "";
                return View(Users.ToList());
            }
            catch (EntityException ex)
            {
                var settlement = new List<Settlement>();
                ViewBag.error = "Brak połączenia z bazą danych";
                return View(settlement);
            }
        }

        public ActionResult DetailsSettlement(int id = 0)
        {
            Settlement settlement = db.GetSettlement(id, User.Identity.Name);
            if (settlement == null)
            {
                return HttpNotFound();
            }
            return View(settlement);
        }

        public ActionResult DetailsUser(int id = 0)
        {
            Users user = db.GetUser(User.Identity.Name);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: /Settlement/Edit/5

        public ActionResult EditSettlement(int id = 0)
        {
            Settlement settlement = db.GetSettlement(id, User.Identity.Name);
            if (settlement == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsersId = new SelectList(db.GetUsers(), "Id", "UserName", settlement.UsersId);
            return View(settlement);
        }

        public ActionResult EditUser(int id = 0)
        {
            Users user = db.GetUser(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /Settlement/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSettlement(Settlement settlement)
        {
            if (ModelState.IsValid)
            {
                db.EditSettlement(settlement, User.Identity.Name);
                return RedirectToAction("Settlements");
            }
            ViewBag.UsersId = new SelectList(db.GetUsers(), "Id", "UserName", settlement.UsersId);
            return View(settlement);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser(Users user)
        {
            if (ModelState.IsValid)
            {
                db.EditUser(user);
                return RedirectToAction("Users");
            }
            return View(user);
        }


        //
        // GET: /Settlement/Delete/5

        public ActionResult DeleteSettlement(int id = 0)
        {
            Settlement settlement = db.GetSettlement(id, User.Identity.Name);
            if (settlement == null)
            {
                return HttpNotFound();
            }
            return View(settlement);
        }

        public ActionResult DeleteUser(int id = 0)
        {
            Users users = db.GetUser(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }
        //
        // POST: /Settlement/Delete/5

        [HttpPost, ActionName("DeleteSettlement")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedSettlement(int id)
        {
            db.RemoveSettlement(id, User.Identity.Name);
            return RedirectToAction("Settlements");
        }

        [HttpPost, ActionName("DeleteUser")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.RemoveUser(id, User.Identity.Name);
            return RedirectToAction("Users");
        }

    }
}
