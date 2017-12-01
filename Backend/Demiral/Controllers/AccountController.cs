using Demiral.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Demiral.Controllers
{
    public class AccountController : BaseAccountController
    {

        public override Task<ActionResult> Login([Bind(Include = "Email,Password,RememberMe")] LoginViewModel model, string returnUrl)
        {
            model.Role = "Customer";
            return base.Login(model, returnUrl);
        }
        public override ActionResult Login(string returnUrl)
        {
            return base.Login(returnUrl);
        }

        public override ActionResult Register()
        {
            return base.Register();
        }

        public override Task<ActionResult> Register([Bind(Include = "Email,Password,ConfirmPassword")]RegisterViewModel model)
        {
            model.Role = "Customer";
            return base.Register(model);
        }
    }
}