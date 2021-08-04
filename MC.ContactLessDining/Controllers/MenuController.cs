using MC.ContactLessDining.Models;
using MC.ContactLessDining.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;

namespace MC.ContactLessDining.Controllers
{
    
    public class MenuController : Controller
    {
        ContactlessMenuDataContext _db;
        IMenuRepository _menuRepository;

        public MenuController(IMenuRepository menuRepository)
        {
            _db = new ContactlessMenuDataContext();
            _menuRepository = menuRepository;
        }

        // GET: Menu
        public ActionResult Index()
        {
            var menuCategories = _db.MenuCategories.Where(x => x.IsActive).OrderBy(x => x.SortingOrder).ToList();

            return View(menuCategories);
        }

        public ActionResult Detail(int id)
        {
            var categoryItem = _db.MenuCategories.FirstOrDefault(x => x.Id == id);
            var menuCards = _db.MenuCards.Where(x => x.MenuCategoryId == id && x.IsActive).OrderBy(x => x.SortingOrder).ToList();
            ViewBag.CategoryName = categoryItem.CategoryName;

            return View(menuCards);
        }
    }
}