using MC.ContactLessDining.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MC.ContactLessDining.Repositories
{
    public class CartRepository : ICartRepository
    {
        ContactlessMenuDataContext _db;

        public CartRepository(ContactlessMenuDataContext db)
        {
            _db = db;
        }

        public ShoppingCart GetShoppingCart(string userId)
        {
            var existingCart = _db.ShoppingCarts.Where(x => x.UserID == userId && x.IsPaid == false).FirstOrDefault();
            if(existingCart == null)
            {
                var createdDate = DateTime.Now;

                var newShoppingCart = new ShoppingCart
                {
                    UserID = userId,
                    Created = createdDate,
                    Modified = createdDate
                };

                _db.ShoppingCarts.InsertOnSubmit(newShoppingCart);
                _db.SubmitChanges();

                return newShoppingCart;
            }

            return existingCart;
        }

        public void AddItemToCart(ShoppingCartItem item)
        {
            _db.ShoppingCartItems.InsertOnSubmit(item);
            _db.SubmitChanges();
        }

        public ShoppingCartItem GetCartItem(int id)
        {
            return _db.ShoppingCartItems.Where(x => x.ID == id).FirstOrDefault();
        }

        public List<ShoppingCartItem> GetCartItems(int shoppingCartId)
        {
            return _db.ShoppingCartItems.Where(x => x.ShoppingCartID == shoppingCartId && x.IsDeleted == false).ToList();
        }

        public void DeleteCartItem(ShoppingCartItem item, bool isDeleted)
        {
            item.IsDeleted = isDeleted;
            _db.SubmitChanges();
        }

        public void DeleteAllCartItem(int shoppingCartId, bool isDeleted)
        {
            var allCartItems = _db.ShoppingCartItems.Where(x => x.ShoppingCartID == shoppingCartId).ToList();
            foreach (var cartItem in allCartItems)
            {
                cartItem.IsDeleted = isDeleted;
            }

            _db.SubmitChanges();
        }

        public void SaveChanges()
        {
            _db.SubmitChanges();
        }
    }
}