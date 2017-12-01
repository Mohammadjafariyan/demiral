using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using Demiral.Models;
using System.Web.Http;

namespace Demiral.Controllers
{
    public class RFQsController : ApiController
    {
        private DemiralEntities db = new DemiralEntities();

        // GET: RFQs



        [Route("~/api/RFQs/Search")]
        [HttpGet]
        public List<Rfq_Search_Result> Search(string searchterm)
        {
            searchterm = searchterm ?? "";
            var c = db.Rfq_Search(searchterm).ToList();
            return c;
        }

        [Route("~/api/RFQs/Submit")]
        [HttpGet]
        public void Submit(RFQ rfq)
        {
            if (ModelState.IsValid)
            {
                db.RFQs.Add(rfq);
                db.SaveChanges();
            }
            else
            {
                throw new Exception();
            }
        }

        // GET: RFQs/Details/5

        [Route("~/api/RFQs/detail")]
        [HttpGet]
        public Category Details(int? id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            Category category =  db.Categories.Find(id);
            category.Category1 = null;
            category.Category2 = null;
            category.Products = null;
            category.RFQs = null;


            return category;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
