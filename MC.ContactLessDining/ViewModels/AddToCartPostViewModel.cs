using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MC.ContactLessDining.ViewModels
{
    public class AddToCartPostViewModel
    {
        public int Id { get; set; }
        public bool IsSteak { get; set; }
        public string Doneness { get; set; }
        public string Sauce { get; set; }
        public string Potato { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal SubTotal { get; set; }
    }
}