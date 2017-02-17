using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WardrobeMVC.Models;

namespace WardrobeMVC.Controllers
{
    public class ShoeTypesController : Controller
    {
        private WardrobeMVCEntities db = new WardrobeMVCEntities();

        // GET: ShoeTypes
        public ActionResult Index()
        {
            return View(db.ShoeTypes.ToList());
        }

        // GET: ShoeTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoeType shoeType = db.ShoeTypes.Find(id);
            if (shoeType == null)
            {
                return HttpNotFound();
            }
            return View(shoeType);
        }

        // GET: ShoeTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShoeTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShoeTypeID,ShoeTypeName")] ShoeType shoeType)
        {
            if (ModelState.IsValid)
            {
                db.ShoeTypes.Add(shoeType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shoeType);
        }

        // GET: ShoeTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoeType shoeType = db.ShoeTypes.Find(id);
            if (shoeType == null)
            {
                return HttpNotFound();
            }
            return View(shoeType);
        }

        // POST: ShoeTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShoeTypeID,ShoeTypeName")] ShoeType shoeType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shoeType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shoeType);
        }

        // GET: ShoeTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoeType shoeType = db.ShoeTypes.Find(id);
            if (shoeType == null)
            {
                return HttpNotFound();
            }
            return View(shoeType);
        }

        // POST: ShoeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShoeType shoeType = db.ShoeTypes.Find(id);
            db.ShoeTypes.Remove(shoeType);
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
