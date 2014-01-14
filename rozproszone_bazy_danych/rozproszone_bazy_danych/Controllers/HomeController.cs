using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using rozproszone_bazy_danych.Models;
using rozproszone_bazy_danych.Security;

namespace rozproszone_bazy_danych.Controllers
    {
    public class HomeController : Controller
        {
        SettlementEntities db = new SettlementEntities();
        public ActionResult Index()
            {
            if (Request.IsAuthenticated)
                {
                ViewBag.Message = "Odnotowano awarie w dostawie energii elektrycznej w rejonach Wrocławia!";
                }
            else
                {
                ViewBag.Message = "Dowiedz się o nowościach w najszej firmie! Załóż konto lub zaloguj się."; // +GetRegion("http://www.geobytes.com/IpLocator.htm?GetLocation", "IpAddress=156.17.233.85");
                }
            return View();
            }

        private static string GetRegion(string Url, string IP)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(Url);
            req.Method = "POST";
            req.Timeout = 100000;
            req.ContentType = "application/x-www-form-urlencoded";
            byte[] sentData = Encoding.GetEncoding(1251).GetBytes(IP);
            req.ContentLength = sentData.Length;
            System.IO.Stream sendStream = req.GetRequestStream();
            sendStream.Write(sentData, 0, sentData.Length);
            sendStream.Close();
            System.Net.WebResponse res = req.GetResponse();
            System.IO.Stream ReceiveStream = res.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(ReceiveStream, Encoding.UTF8);
            //Кодировка указывается в зависимости от кодировки ответа сервера
            Char[] read = new Char[256];
            int count = sr.Read(read, 0, 256);
            string Out = String.Empty;
            while (count > 0)
            {
                String str = new String(read, 0, count);
                Out += str;
                count = sr.Read(read, 0, 256);
            }
            string[] stringSeparators = new string[] { "ro-no_bots_pls15\" value=\"" };
            Out = Out.Split(stringSeparators, StringSplitOptions.None).ElementAt(1);
            Out = Out.Split(new Char[] { '\"' }).ElementAt(0);
            return Out;
        }


        public ActionResult History()
            {
            ViewBag.Message = "Sprawdź historię rachunku.";
            var settlements = db.Settlement.Where(item => item.Users.UserName == User.Identity.Name);
            return View(settlements);
            }
        }
    }
