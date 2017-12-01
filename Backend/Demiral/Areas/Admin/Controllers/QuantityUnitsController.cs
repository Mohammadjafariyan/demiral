using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demiral.Models;

namespace Demiral.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class QuantityUnitsController : Controller
    {
        private DemiralEntities db = new DemiralEntities();

        // GET: Admin/QuantityUnits
        public async Task<ActionResult> Index()
        {
            return View(await db.QuantityUnits.ToListAsync());
        }

        // GET: Admin/QuantityUnits/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuantityUnit quantityUnit = await db.QuantityUnits.FindAsync(id);
            if (quantityUnit == null)
            {
                return HttpNotFound();
            }
            return View(quantityUnit);
        }

        // GET: Admin/QuantityUnits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/QuantityUnits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,Name")] QuantityUnit quantityUnit)
        {
            if (ModelState.IsValid)
            {
                db.QuantityUnits.Add(quantityUnit);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(quantityUnit);
        }

        // GET: Admin/QuantityUnits/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuantityUnit quantityUnit = await db.QuantityUnits.FindAsync(id);
            if (quantityUnit == null)
            {
                return HttpNotFound();
            }
            return View(quantityUnit);
        }

        // POST: Admin/QuantityUnits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,Name")] QuantityUnit quantityUnit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quantityUnit).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(quantityUnit);
        }

        // GET: Admin/QuantityUnits/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuantityUnit quantityUnit = await db.QuantityUnits.FindAsync(id);
            if (quantityUnit == null)
            {
                return HttpNotFound();
            }
            return View(quantityUnit);
        }

        // POST: Admin/QuantityUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            QuantityUnit quantityUnit = await db.QuantityUnits.FindAsync(id);
            db.QuantityUnits.Remove(quantityUnit);
            await db.SaveChangesAsync();
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
