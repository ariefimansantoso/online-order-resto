using MC.ContactLessDining.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MC.ContactLessDining.ViewModels;
using AutoMapper;
using MC.ContactLessDining.Models;

namespace MC.ContactLessDining.Controllers
{
    [Authorize]
    public class CartController : BaseController
    {
        ICartRepository _cartRepository;
        IMapper _mapper;

        public CartController(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        // GET: Cart
        public ActionResult Index()
        {
            var shoppingCart = _cartRepository.GetShoppingCart(UserID);
            var viewModel = new CartIndexViewModel();
            viewModel.Created = shoppingCart.Created;
            viewModel.ID = shoppingCart.ID;
            viewModel.IsCheckedOut = shoppingCart.IsCheckedOut;
            viewModel.IsCompleted = shoppingCart.IsCompleted;
            viewModel.IsPaid = shoppingCart.IsPaid;
            viewModel.Modified = shoppingCart.Modified;
            viewModel.ServiceCharge = shoppingCart.ServiceCharge;
            viewModel.ShoppingCartItems = new List<CartItemViewModel>();
            viewModel.Tax = shoppingCart.Tax;
            viewModel.TotalBeforeTax = shoppingCart.TotalBeforeTax;
            viewModel.TotalPaid = shoppingCart.TotalPaid;
            viewModel.UserID = shoppingCart.UserID;

            //_mapper.Map<CartIndexViewModel>(shoppingCart);

            if (shoppingCart.ShoppingCartItems.Count > 0)
            {
                foreach (var cartItem in shoppingCart.ShoppingCartItems)
                {
                    viewModel.ShoppingCartItems.Add(new CartItemViewModel
                    {
                        Discount = cartItem.Discount,
                        Doneness = cartItem.Doneness,
                        ID = cartItem.ID,
                        IsSteak = cartItem.IsSteak,
                        MenuCardID = cartItem.MenuCardID,
                        Potato = cartItem.Potato,
                        Quantity = cartItem.Quantity,
                        Sauce = cartItem.Sauce,
                        ShoppingCartID = cartItem.ShoppingCartID,
                        SubTotal = cartItem.SubTotal,
                        ItemPrice = cartItem.ItemPrice,
                        Name = cartItem.MenuCard.Name,
                        ImageUrl = cartItem.MenuCard.ImageUrl
                    });
                }

                return View(viewModel);
            }

            return View("CartEmpty");
        }

        [HttpPost]
        public ActionResult AddToCart(AddToCartPostViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var shoppingCart = _cartRepository.GetShoppingCart(UserID);
                var createDate = DateTime.Now;

                var shoppingCartItem = new ShoppingCartItem
                {
                    IsSteak = viewModel.IsSteak,
                    Created = createDate,
                    Discount = 0,
                    Doneness = viewModel.IsSteak ? viewModel.Doneness : string.Empty,
                    IsDeleted = false,
                    MenuCardID = viewModel.Id,
                    Modified = createDate,
                    Potato = viewModel.IsSteak ? viewModel.Potato : string.Empty,
                    Quantity = viewModel.Quantity,
                    Sauce = viewModel.IsSteak ? viewModel.Sauce : string.Empty,
                    ShoppingCartID = shoppingCart.ID,
                    SubTotal = viewModel.ItemPrice * viewModel.Quantity,
                    ItemPrice = viewModel.ItemPrice
                };

                _cartRepository.AddItemToCart(shoppingCartItem);
            }

            return RedirectToAction("Index");
        }
    }
}