using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SumModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SumModels
        public ActionResult Index()
        {
            return View(db.SumModels.ToList());
        }

        // GET: SumModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SumModel sumModel = db.SumModels.Find(id);
            if (sumModel == null)
            {
                return HttpNotFound();
            }
            return View(sumModel);
        }

        // GET: SumModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SumModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,costPrice,viewYear,truckAge,salvageValue,totalDep")] SumModel sumModel)
        {
            if (ModelState.IsValid)
            {
                sumModel.salvageValue = sumModel.CalSalvageValue();
                sumModel.totalDep = sumModel.CalDepreciation();
                db.SumModels.Add(sumModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sumModel);
        }

        // GET: SumModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SumModel sumModel = db.SumModels.Find(id);
            if (sumModel == null)
            {
                return HttpNotFound();
            }
            return View(sumModel);
        }

        // POST: SumModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,costPrice,viewYear,truckAge,salvageValue,totalDep")] SumModel sumModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sumModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sumModel);
        }

        // GET: SumModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SumModel sumModel = db.SumModels.Find(id);
            if (sumModel == null)
            {
                return HttpNotFound();
            }
            return View(sumModel);
        }

        // POST: SumModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SumModel sumModel = db.SumModels.Find(id);
            db.SumModels.Remove(sumModel);
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
