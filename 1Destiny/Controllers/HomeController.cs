using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using _1Destiny.Models;

namespace _1Destiny.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }
        

        public ActionResult SDK()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Resources()
        {
            DB_Connect objdbconnect = new DB_Connect();
            ViewBag.Message = "Your Resource page";
            return View(objdbconnect.GetTeams());
        }
        public ActionResult Resources1(int id)
        {
            DB_Connect objdbconnect = new DB_Connect();
            ViewBag.Message = "Your Resource page";
            return View(objdbconnect.GetTools(id,2));
        }
        public ActionResult Training(int id)
        {
            DB_Connect objdbconnect = new DB_Connect();
            ViewBag.Message = "Your Resource page";
            return View(objdbconnect.GetTools(id,3));
        }
        public ActionResult Tools(int id)
        {
            DB_Connect objdbconnect = new DB_Connect();
            ViewBag.Message = "Your Resource page";
            return View(objdbconnect.GetTools(id,1));
        }
        public void QuickAssist()
        {
            Process p = new Process();
            p.StartInfo.FileName = "C:\\Windows\\System32\\quickassist.exe";
            p.Start();
        }
        
    }
}