using Demiral.Controllers;
using Demiral.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Demiral.Areas.Admin.Controllers
{

    [Authorize(Roles ="Admin")]
    public class AdminAccountController : BaseAccountController
    {
        // GET: Admin/AdminAccount

        public override Task<ActionResult> Login([Bind(Include = "Email,Password,RememberMe")] LoginViewModel model, string returnUrl)
        {
            model.Role = "Admin";
            return base.Login(model, "Admin/AHome");
        }
        public override ActionResult Login(string returnUrl)
        {
            var c=User.IsInRole("Admin");

            return base.Login(returnUrl);
        }

        public override ActionResult Register()
        {
            return base.Register();
        }

        public override Task<ActionResult> Register([Bind(Include = "Email,Password,ConfirmPassword")]RegisterViewModel model)
        {
            model.Role = "Admin";
            return base.Register(model);
        }
    }
}