using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Demiral.Models;

namespace Demiral.Controllers
{
    public class HomeApiController : ApiController
    {
        private DemiralEntities db = new DemiralEntities();
        private HomeRepository hr = new HomeRepository();
        // GET: api/Home

        [Route("~/api/Home")]
        public Category[] GetCategories()
        {
            return hr.Groups;
        }



        // GET: api/Home/5
        [ResponseType(typeof(Category))]
        [Route("~/api/Home/{id:int}")]
        public async Task<IHttpActionResult> GetCategory(int id)
        {
            Category category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryExists(int id)
        {
            return db.Categories.Count(e => e.Id == id) > 0;
        }
    }
}