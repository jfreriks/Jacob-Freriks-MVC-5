using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo.Models;

namespace Demo.Controllers
{
    public class EnlistController : Controller
    {
        private InfoDBContext db = new InfoDBContext();

        public ActionResult Index()
        {
            return View(db.Info.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InfoDB infoDB = db.Info.Find(id);
            if (infoDB == null)
            {
                return HttpNotFound();
            }
            return View(infoDB);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Address,Birthdate")] InfoDB infoDB)
        {
            if (ModelState.IsValid)
            {
                db.Info.Add(infoDB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(infoDB);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InfoDB infoDB = db.Info.Find(id);
            if (infoDB == null)
            {
                return HttpNotFound();
            }
            return View(infoDB);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Address,Birthdate")] InfoDB infoDB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(infoDB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(infoDB);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InfoDB infoDB = db.Info.Find(id);
            if (infoDB == null)
            {
                return HttpNotFound();
            }
            return View(infoDB);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InfoDB infoDB = db.Info.Find(id);
            db.Info.Remove(infoDB);
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
