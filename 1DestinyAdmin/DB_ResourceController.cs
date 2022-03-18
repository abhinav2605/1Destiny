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
    public class DB_ResourceController : Controller
    {
        private Entities db = new Entities();

        // GET: DB_Resource
        public ActionResult Index()
        {
            //return View(db.DB_Resource.Where(x => x.ResourceID == 1 && x.TeamID ==1).ToList());
            return View(db.DB_Resource.ToList().OrderByDescending(x => x.Sl_No_));
        }

        // GET: DB_Resource/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DB_Resource dB_Resource = db.DB_Resource.Find(id);
            if (dB_Resource == null)
            {
                return HttpNotFound();
            }
            return View(dB_Resource);
        }

        // GET: DB_Resource/Create
        public ActionResult Create()
        {
            var teamList = db.DB_Teams.ToList();
            ViewBag.TeamList = teamList;
            var ResourceCategoryList = db.DB_Category.ToList();
            ViewBag.ResourceCategoryList = ResourceCategoryList;
            return View();
        }

        // POST: DB_Resource/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sl_No_,ResourceName,ResourceLink,ResourceID,ResourceImage,TeamID")] DB_Resource dB_Resource)
        {
            if (ModelState.IsValid)
            {
                db.DB_Resource.Add(dB_Resource);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(dB_Resource);
        }

        // GET: DB_Resource/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DB_Resource dB_Resource = db.DB_Resource.Find(id);
            ViewBag.EditTeamList = db.DB_Teams.ToList();
            ViewBag.EditCategoryList = db.DB_Category.ToList();
            if (dB_Resource == null)
            {
                return HttpNotFound();
            }
            return View(dB_Resource);
        }

        // POST: DB_Resource/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sl_No_,ResourceName,ResourceLink,ResourceID,ResourceImage,TeamID")] DB_Resource dB_Resource)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dB_Resource).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dB_Resource);
        }

        // GET: DB_Resource/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DB_Resource dB_Resource = db.DB_Resource.Find(id);
            if (dB_Resource == null)
            {
                return HttpNotFound();
            }
            return View(dB_Resource);
        }

        // POST: DB_Resource/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            DB_Resource dB_Resource = db.DB_Resource.Find(id);
            db.DB_Resource.Remove(dB_Resource);
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
