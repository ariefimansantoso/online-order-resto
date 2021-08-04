using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MC.ContactLessDining.ViewModels
{
    public class CartItemViewModel
    {
        public int ID { get; set; }
        public int ShoppingCartID { get; set; }
        public int MenuCardID { get; set; }
        public string Doneness { get; set; }
        public string Sauce { get; set; }
        public string Potato { get; set; }
        public bool IsSteak { get; set; }
        public int Quantity { get; set; }
        public DateTime Created { get; set; }
        public decimal SubTotal { get; set; }
        public decimal ItemPrice { get; set; }
        public bool IsDeleted { get; set; }
        public decimal Discount { get; set; }
        public DateTime Modified { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}