using MC.ContactLessDining.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MC.ContactLessDining.Controllers
{
   
    public class HomeController : BaseController
    {
        ContactlessMenuDataContext _db;

        public HomeController()
        {
            _db = new ContactlessMenuDataContext();            
        }

        public ActionResult Index()
        {
            var menuCardBestSellers = _db.MenuCards.Where(x => x.BestSellers).ToList();

            return View(menuCardBestSellers);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}