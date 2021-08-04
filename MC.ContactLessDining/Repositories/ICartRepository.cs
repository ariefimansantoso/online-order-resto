using MC.ContactLessDining.Models;
using System.Collections.Generic;

namespace MC.ContactLessDining.Repositories
{
    public interface ICartRepository
    {
        void AddItemToCart(ShoppingCartItem item);
        void DeleteAllCartItem(int shoppingCartId, bool isDeleted);
        void DeleteCartItem(ShoppingCartItem item, bool isDeleted);
        ShoppingCartItem GetCartItem(int id);
        List<ShoppingCartItem> GetCartItems(int shoppingCartId);
        ShoppingCart GetShoppingCart(string userId);
        void SaveChanges();
    }
}