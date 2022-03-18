using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace _1DestinyAdmin
{
    public class DB_TeamsController : Controller
    {
        private Entities db = new Entities();

        // GET: DB_Teams
        public ActionResult Index()
        {
            return View(db.DB_Teams.ToList());
        }

        // GET: DB_Teams/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DB_Teams dB_Teams = db.DB_Teams.Find(id);
            if (dB_Teams == null)
            {
                return HttpNotFound();
            }
            return View(dB_Teams);
        }

        // GET: DB_Teams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DB_Teams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TeamName")] DB_Teams dB_Teams)
        {
            if (ModelState.IsValid)
            {
                db.DB_Teams.Add(dB_Teams);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dB_Teams);
        }

        // GET: DB_Teams/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DB_Teams dB_Teams = db.DB_Teams.Find(id);
            if (dB_Teams == null)
            {
                return HttpNotFound();
            }
            return View(dB_Teams);
        }

        // POST: DB_Teams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TeamName")] DB_Teams dB_Teams)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dB_Teams).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dB_Teams);
        }

        // GET: DB_Teams/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DB_Teams dB_Teams = db.DB_Teams.Find(id);
            if (dB_Teams == null)
            {
                return HttpNotFound();
            }
            return View(dB_Teams);
        }

        // POST: DB_Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            DB_Teams dB_Teams = db.DB_Teams.Find(id);
            db.DB_Teams.Remove(dB_Teams);
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
