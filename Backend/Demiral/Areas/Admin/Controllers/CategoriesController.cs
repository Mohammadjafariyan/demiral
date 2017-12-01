using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demiral.Models;
using PagedList;

namespace Demiral.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoriesController : Controller
    {
        private DemiralEntities db = new DemiralEntities();

        // GET: Admin/Categories
        public ActionResult Index(int? pageNumber, int? size)
        {
            int pn = pageNumber.HasValue ? pageNumber.Value : 1;
            int s = size.HasValue ? size.Value : 10;
            var categories = db.Categories.Include("Category2").Include("Category1").OrderByDescending(c => c.Id).ToList();
            return View(categories.ToPagedList(pn, s));
        }
        public ActionResult GeneralCategories(int? pageNumber, int? size)
        {
            int pn = pageNumber.HasValue ? pageNumber.Value : 1;
            int s = size.HasValue ? size.Value : 10;
            var categories = db.Categories.Where(c => c.ParentId == null).Include("Category2").Include("Category1").OrderByDescending(c => c.Id).ToList();
            return View(categories.ToPagedList(pn, s));
        }

     
        public ActionResult LeafCategories(int? pageNumber, int? size)
        {
            int pn = pageNumber.HasValue ? pageNumber.Value : 1;
            int s = size.HasValue ? size.Value : 10;
            var categories = db.Categories.Where(c => c.IsLeaf == true && c.ParentId != null).Include("Category2").Include("Category1").OrderByDescending(c => c.Id).ToList();
            return View(categories.ToPagedList(pn, s));
        }

        // GET: Admin/Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Admin/Categories/Create
        public ActionResult Create(int? type, int? id)
        {
            ViewData["Id"] = id;
            ViewData["type"] = 1;//1 = add sub category  , 2= add leaf

            var list = db.Categories.Where(c=>c.ParentId== null).ToList();
            list.Add(new Category { Name = "هیچکدام", Id = -1 });
            ViewBag.ParentId = new SelectList(list, "Id", "Name");

            //ViewData["Id"] = id;
            //ViewData["type"] = 1;//1 = add sub category  , 2= add leaf

            return View();
        }

        // POST: Admin/Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.ParentId == -1)
                    category.ParentId = null;
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ParentId = new SelectList(db.Categories, "Id", "Name", category.ParentId);
            return View(category);
        }

        // GET: Admin/Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            var list = db.Categories.ToList();
            list.Add(new Category { Name = "هیچکدام", Id = -1 });
            ViewBag.ParentId = new SelectList(list, "Id", "Name", category.ParentId);


            //var list2 = db.Groups.ToList();
            //list2.Add(new Group { Name = "هیچکدام", Id =-1 });
            //ViewBag.groupId = new SelectList(list2, "Id", "Name");

            return View(category);
        }

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.ParentId == -1)
                    category.ParentId = null;
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParentId = new SelectList(db.Categories, "Id", "Name", category.ParentId);
            return View(category);
        }

        // GET: Admin/Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
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
