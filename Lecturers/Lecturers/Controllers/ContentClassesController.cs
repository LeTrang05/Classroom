using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lecturers.Models;

namespace Lecturers.Controllers
{
    public class ContentClassesController : Controller
    {
        private DBContext db = new DBContext();

        // GET: ContentClasses
        public ActionResult Index()
        {
            return View(db.ContentClasses.ToList());
        }

        // GET: ContentClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContentClass contentClass = db.ContentClasses.Find(id);
            if (contentClass == null)
            {
                return HttpNotFound();
            }
            return View(contentClass);
        }

        // GET: ContentClasses/Create
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContentClass content)
        {
            if (ModelState.IsValid)
            {
              
                ContentClass contenclasses = new ContentClass
                {
                    IdClass = content.IdClass,
                    tin = content.tin,
                    userofclass = (string)Session["user"]

                };
                db.ContentClasses.Add(contenclasses);
                db.SaveChanges();
                return Redirect("/Classes/Myclass/" + content.IdClass);
            }

            return View();
        }

        // GET: ContentClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContentClass contentClass = db.ContentClasses.Find(id);
            if (contentClass == null)
            {
                return HttpNotFound();
            }
            return View(contentClass);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdClass,tin")] ContentClass contentClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contentClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contentClass);
        }

        // GET: ContentClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContentClass contentClass = db.ContentClasses.Find(id);
            if (contentClass == null)
            {
                return HttpNotFound();
            }
            return View(contentClass);
        }

        // POST: ContentClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContentClass contentClass = db.ContentClasses.Find(id);
            db.ContentClasses.Remove(contentClass);
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
