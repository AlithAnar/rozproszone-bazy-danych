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
    public class SettlementController : Controller
        {
        DataBaseManager db;
        public SettlementController()
        {
            db = new DataBaseManager();
        }
        //
        // GET: /Settlement/

        //[SystemRoleAuthorizeAttribute(RequiredSystemRole = "Admin")]
        public ActionResult Index()
            {
            try
                {
                //var settlement = db.Settlement.Where(item => item.Users.UserName == User.Identity.Name);
                var settlement = db.GetSettlements(User.Identity.Name);
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

        //
        // GET: /Settlement/Details/5

        public ActionResult Details(int id = 0)
            {
            Settlement settlement = db.GetSettlement(id, User.Identity.Name);
            if (settlement == null)
                {
                return HttpNotFound();
                }
            return View(settlement);
            }

        //
        // GET: /Settlement/Create

        public ActionResult Create()
            {
            ViewBag.UsersId = new SelectList(db.GetUsers(), "Id", "UserName");
            return View();
            }

        //
        // POST: /Settlement/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Settlement settlement)
            {
            settlement.Current_date = DateTime.Now;
            settlement.settlement_date = DateTime.Now;
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            var ticketInfo = FormsAuthentication.Decrypt(cookie.Value);
            settlement.UsersId = int.Parse(ticketInfo.UserData);

            if (ModelState.IsValid)
                {
                    db.AddSettlement(settlement, User.Identity.Name);
                return RedirectToAction("Index");
                }

            ViewBag.UsersId = new SelectList(db.GetUsers(), "Id", "UserName", settlement.UsersId);
            return View(settlement);
            }

        //
        // GET: /Settlement/Edit/5

        public ActionResult Edit(int id = 0)
            {
            Settlement settlement = db.GetSettlement(id, User.Identity.Name);
            if (settlement == null)
                {
                return HttpNotFound();
                }
            ViewBag.UsersId = new SelectList(db.GetUsers(), "Id", "UserName", settlement.UsersId);
            return View(settlement);
            }

        //
        // POST: /Settlement/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Settlement settlement)
            {
            if (ModelState.IsValid)
                {
                    db.EditSettlement(settlement, User.Identity.Name);
                    return RedirectToAction("Index");
                }
            ViewBag.UsersId = new SelectList(db.GetUsers(), "Id", "UserName", settlement.UsersId);
            return View(settlement);
            }

        //
        // GET: /Settlement/Delete/5

        public ActionResult Delete(int id = 0)
            {
            Settlement settlement = db.GetSettlement(id, User.Identity.Name);
            if (settlement == null)
                {
                return HttpNotFound();
                }
            return View(settlement);
            }

        //
        // POST: /Settlement/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
            {
                db.RemoveSettlement(id, User.Identity.Name);
            return RedirectToAction("Index");
            }

        protected override void Dispose(bool disposing)
            {
            db.Dispose();
            base.Dispose(disposing);
            }
        }  
    }