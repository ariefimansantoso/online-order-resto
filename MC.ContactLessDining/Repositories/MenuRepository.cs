using MC.ContactLessDining.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MC.ContactLessDining.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        ContactlessMenuDataContext _db;

        public MenuRepository(ContactlessMenuDataContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Gets active menu categories sorted by SortingOrder column
        /// </summary>
        /// <returns></returns>
        public List<MenuCategory> GetActiveMenuCategories()
        {
            return _db.MenuCategories.Where(x => x.IsActive).OrderBy(x => x.SortingOrder).ToList();
        }

        public MenuCategory GetMenuCategoryById(int id)
        {
            return _db.MenuCategories.FirstOrDefault(x => x.Id == id);
        }

        public List<MenuCard> GetMenuCardsByCategoryId(int categoryId)
        {
            return _db.MenuCards.Where(x => x.MenuCategoryId == categoryId && x.IsActive).OrderBy(x => x.SortingOrder).ToList();
        }

        public MenuCard GetMenuCardById(int id)
        {
            return _db.MenuCards.FirstOrDefault(x => x.Id == id && x.IsActive);
        }
    }
}