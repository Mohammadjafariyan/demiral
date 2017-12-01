using Demiral.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demiral.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AHomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Refresh()
        {
            HomeRepository hr = new HomeRepository();
            hr.Groups = null;
            return RedirectToAction("Index");
        }
    }
}