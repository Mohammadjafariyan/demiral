using Demiral.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demiral.Areas.Seller.Controllers
{
    public class SHomeController : BaseCustomerController
    {
        // GET: Seller/Home
        public ActionResult Index()
        {

            return View();
        }
    }
}