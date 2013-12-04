using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using rozproszone_bazy_danych.Models;
namespace rozproszone_bazy_danych.Controllers
    {
    public class HomeController : Controller
        {
        SettlementEntities db = new SettlementEntities();
        public ActionResult Index()
            {
            ViewBag.Message = "Dowiedz się o nowościach w najszej firmie!";

            return View();
            }

        public ActionResult History()
            {
            ViewBag.Message = "Sprawdź historię rachunku.";
            var settlements = db.Settlement;
            return View(settlements);
            }
        }
    }
