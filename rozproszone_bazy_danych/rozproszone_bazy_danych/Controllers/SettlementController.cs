using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using rozproszone_bazy_danych.Models;

namespace rozproszone_bazy_danych.Controllers
    {
    public class SettlementController : Controller
        {
        private SettlementEntities db = new SettlementEntities();

        //
        // GET: /Settlement/

        public ActionResult Index()
            {
            try
                {
                var settlement = db.Settlement.Include(s => s.Users);
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
            Settlement settlement = db.Settlement.Find(id);
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
            ViewBag.UsersId = new SelectList(db.Users, "Id", "UserName");
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
            settlement.UsersId = 6;

            if (ModelState.IsValid)
                {
                db.Settlement.Add(settlement);
                db.SaveChanges();
                return RedirectToAction("Index");
                }

            ViewBag.UsersId = new SelectList(db.Users, "Id", "UserName", settlement.UsersId);
            return View(settlement);
            }

        //
        // GET: /Settlement/Edit/5

        public ActionResult Edit(int id = 0)
            {
            Settlement settlement = db.Settlement.Find(id);
            if (settlement == null)
                {
                return HttpNotFound();
                }
            ViewBag.UsersId = new SelectList(db.Users, "Id", "UserName", settlement.UsersId);
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
                db.Entry(settlement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
                }
            ViewBag.UsersId = new SelectList(db.Users, "Id", "UserName", settlement.UsersId);
            return View(settlement);
            }

        //
        // GET: /Settlement/Delete/5

        public ActionResult Delete(int id = 0)
            {
            Settlement settlement = db.Settlement.Find(id);
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
            Settlement settlement = db.Settlement.Find(id);
            db.Settlement.Remove(settlement);
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