using MC.ContactLessDining.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MC.ContactLessDining.Controllers
{
    public class BaseController : Controller
    {
        UserManager<ApplicationUser> _userManager;
        ApplicationUser _currentUser;

        public BaseController()
        {
            // Create manager
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));            
        }

        public ActionResult DisplayName()
        {
            if(CurrentUser != null && !string.IsNullOrEmpty(CurrentUser.FirstName))
            {
                return PartialView("_DisplayName", CurrentUser.FirstName);
            }

            return PartialView("_DisplayName", User.Identity.GetUserName());
        }

        public ApplicationUser CurrentUser 
        { 
            get
            {
                if (User.Identity.IsAuthenticated)
                {
                    _currentUser = _userManager.FindById(User.Identity.GetUserId());
                }
                else
                {
                    _currentUser = null;
                }

                return _currentUser;
            }
        }

        public string UserID
        {
            get
            {
                if (User.Identity.IsAuthenticated)
                {
                    return User.Identity.GetUserId();
                }

                return string.Empty;
            }
        }
    }
}