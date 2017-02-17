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
    public class BottomTypesController : Controller
    {
        private WardrobeMVCEntities db = new WardrobeMVCEntities();

        // GET: BottomTypes
        public ActionResult Index()
        {
            return View(db.BottomTypes.ToList());
        }

        // GET: BottomTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BottomType bottomType = db.BottomTypes.Find(id);
            if (bottomType == null)
            {
                return HttpNotFound();
            }
            return View(bottomType);
        }

        // GET: BottomTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BottomTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BottomTypeID,BottomTypeName")] BottomType bottomType)
        {
            if (ModelState.IsValid)
            {
                db.BottomTypes.Add(bottomType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bottomType);
        }

        // GET: BottomTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BottomType bottomType = db.BottomTypes.Find(id);
            if (bottomType == null)
            {
                return HttpNotFound();
            }
            return View(bottomType);
        }

        // POST: BottomTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BottomTypeID,BottomTypeName")] BottomType bottomType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bottomType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bottomType);
        }

        // GET: BottomTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BottomType bottomType = db.BottomTypes.Find(id);
            if (bottomType == null)
            {
                return HttpNotFound();
            }
            return View(bottomType);
        }

        // POST: BottomTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BottomType bottomType = db.BottomTypes.Find(id);
            db.BottomTypes.Remove(bottomType);
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
