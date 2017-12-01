using Demiral.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demiral.Areas.Buyer.Controllers
{
    public class BHomeController : BaseCustomerController
    {
        // GET: Buyer/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}