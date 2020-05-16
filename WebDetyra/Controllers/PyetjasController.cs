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
    public class PyetjasController : Controller
    {
        private Entities db = new Entities();

        // GET: Pyetjas
        public ActionResult Index()
        {
            return View(db.Pyetjas.ToList());
        }

        // GET: Pyetjas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pyetja pyetja = db.Pyetjas.Find(id);
            if (pyetja == null)
            {
                return HttpNotFound();
            }
            return View(pyetja);
        }

        // GET: Pyetjas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pyetjas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PyetjaID,Pyejta,Opcioni1,Opcioni2,Opcioni3,Opcioni4,PergjigjjaESakte")] Pyetja pyetja)
        {
            if (ModelState.IsValid)
            {
                db.Pyetjas.Add(pyetja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pyetja);
        }

        // GET: Pyetjas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pyetja pyetja = db.Pyetjas.Find(id);
            if (pyetja == null)
            {
                return HttpNotFound();
            }
            return View(pyetja);
        }

        // POST: Pyetjas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PyetjaID,Pyejta,Opcioni1,Opcioni2,Opcioni3,Opcioni4,PergjigjjaESakte")] Pyetja pyetja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pyetja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pyetja);
        }

        // GET: Pyetjas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pyetja pyetja = db.Pyetjas.Find(id);
            if (pyetja == null)
            {
                return HttpNotFound();
            }
            return View(pyetja);
        }

        // POST: Pyetjas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pyetja pyetja = db.Pyetjas.Find(id);
            db.Pyetjas.Remove(pyetja);
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
