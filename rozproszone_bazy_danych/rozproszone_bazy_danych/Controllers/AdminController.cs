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

    }
}
