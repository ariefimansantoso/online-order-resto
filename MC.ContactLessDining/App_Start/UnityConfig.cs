using AutoMapper;
using MC.ContactLessDining.Configurations;
using MC.ContactLessDining.Controllers;
using MC.ContactLessDining.Repositories;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace MC.ContactLessDining
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IMenuRepository, MenuRepository>();
            container.RegisterType<ICartRepository, CartRepository>();
            
            MapperConfiguration config = AutoMapperConfiguration.Configure();
            IMapper mapper = config.CreateMapper();

            container.RegisterInstance(mapper);
            container.RegisterType<AccountController>(new InjectionConstructor());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}