using AutoMapper;
using MC.ContactLessDining.Models;
using MC.ContactLessDining.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MC.ContactLessDining.Configurations
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration Configure()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg => {
                cfg.CreateMap<ShoppingCartItem, CartItemViewModel>();
                cfg.CreateMap<ShoppingCart, CartIndexViewModel>().ForMember(x => x.ShoppingCartItems, c => c.MapFrom(s => s.ShoppingCartItems));
            });

            return mapperConfiguration;
        }
    }
}