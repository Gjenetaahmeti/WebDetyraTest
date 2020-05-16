using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebDetyra.Models;

namespace WebDetyra.Controllers
{
    public class UserisController : Controller
    {
        private Entities db = new Entities();

        // GET: Useris
        public ActionResult Index()
        {
            return View(db.Useris.ToList());
        }

        // GET: Useris/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Useri useri = db.Useris.Find(id);
            if (useri == null)
            {
                return HttpNotFound();
            }
            return View(useri);
        }

        // GET: Useris/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Useris/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,EmriUserit,EmailUserit,PasswordUserit,Emri,Mbiemri,Email")] Useri useri)
        {
            if (ModelState.IsValid)
            {
                db.Useris.Add(useri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(useri);
        }

        // GET: Useris/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Useri useri = db.Useris.Find(id);
            if (useri == null)
            {
                return HttpNotFound();
            }
            return View(useri);
        }

        // POST: Useris/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,EmriUserit,EmailUserit,PasswordUserit,Emri,Mbiemri,Email")] Useri useri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(useri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(useri);
        }

        // GET: Useris/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Useri useri = db.Useris.Find(id);
            if (useri == null)
            {
                return HttpNotFound();
            }
            return View(useri);
        }

        // POST: Useris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Useri useri = db.Useris.Find(id);
            db.Useris.Remove(useri);
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
