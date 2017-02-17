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
    public class TopTypesController : Controller
    {
        private WardrobeMVCEntities db = new WardrobeMVCEntities();

        // GET: TopTypes
        public ActionResult Index()
        {
            return View(db.TopTypes.ToList());
        }

        // GET: TopTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopType topType = db.TopTypes.Find(id);
            if (topType == null)
            {
                return HttpNotFound();
            }
            return View(topType);
        }

        // GET: TopTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TopTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TopTypeID,TopTypeName")] TopType topType)
        {
            if (ModelState.IsValid)
            {
                db.TopTypes.Add(topType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(topType);
        }

        // GET: TopTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopType topType = db.TopTypes.Find(id);
            if (topType == null)
            {
                return HttpNotFound();
            }
            return View(topType);
        }

        // POST: TopTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TopTypeID,TopTypeName")] TopType topType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(topType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(topType);
        }

        // GET: TopTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopType topType = db.TopTypes.Find(id);
            if (topType == null)
            {
                return HttpNotFound();
            }
            return View(topType);
        }

        // POST: TopTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TopType topType = db.TopTypes.Find(id);
            db.TopTypes.Remove(topType);
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
