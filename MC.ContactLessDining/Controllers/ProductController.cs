using MC.ContactLessDining.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
namespace MC.ContactLessDining.Controllers
{
    public class ProductController : Controller
    {
        ContactlessMenuDataContext _db;

        public ProductController()
        {
            _db = new ContactlessMenuDataContext();
        }

        public ActionResult Detail(int id)
        {
            var categoryItem = _db.MenuCategories.FirstOrDefault(x => x.Id == id);
            var menuCards = _db.MenuCards.FirstOrDefault(x => x.Id == id && x.IsActive);
            if (menuCards != null)
            {
                ViewBag.CategoryName = menuCards.MenuCategory.CategoryName;

                return View(menuCards);
            }

            return HttpNotFound();
        }
    }
}