using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ManageMyStuff.Models;

namespace ManageMyStuff.Controllers
{
    public class WebpagesController : Controller
    {
        private ManageMyStuffContext db = new ManageMyStuffContext();

        // GET: Webpages
        public ActionResult Index()
        {
            return View(db.Webpages.ToList());
        }

        // GET: Webpages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Webpage webpage = db.Webpages.Find(id);
            if (webpage == null)
            {
                return HttpNotFound();
            }
            return View(webpage);
        }

        // GET: Webpages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Webpages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WebPageID,Category,WebAddressDescription,WebAddress,WebAddressExtraDescription,WebAddressExtra")] Webpage webpage)
        {
            if (ModelState.IsValid)
            {
                db.Webpages.Add(webpage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(webpage);
        }

        // GET: Webpages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Webpage webpage = db.Webpages.Find(id);
            if (webpage == null)
            {
                return HttpNotFound();
            }
            return View(webpage);
        }

        // POST: Webpages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WebPageID,Category,WebAddressDescription,WebAddress,WebAddressExtraDescription,WebAddressExtra")] Webpage webpage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(webpage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(webpage);
        }

        // GET: Webpages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Webpage webpage = db.Webpages.Find(id);
            if (webpage == null)
            {
                return HttpNotFound();
            }
            return View(webpage);
        }

        // POST: Webpages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Webpage webpage = db.Webpages.Find(id);
            db.Webpages.Remove(webpage);
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
