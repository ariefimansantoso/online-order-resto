using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MC.ContactLessDining.ViewModels
{
    public class CartIndexViewModel
    {
        public int ID { get; set; }
        public bool IsCheckedOut { get; set; }
        public bool IsPaid { get; set; }
        public bool IsCompleted { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal TotalBeforeTax { get; set; }
        public decimal Tax { get; set; }
        public decimal ServiceCharge { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string UserID { get; set; }
        public List<CartItemViewModel> ShoppingCartItems { get; set; }
    }
}