using MC.ContactLessDining.Models;
using System.Collections.Generic;

namespace MC.ContactLessDining.Repositories
{
    public interface IMenuRepository
    {
        List<MenuCategory> GetActiveMenuCategories();
        MenuCard GetMenuCardById(int id);
        List<MenuCard> GetMenuCardsByCategoryId(int categoryId);
        MenuCategory GetMenuCategoryById(int id);
    }
}