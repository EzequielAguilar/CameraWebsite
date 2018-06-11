using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using assignment1.Models;

namespace assignment1.Controllers
{
    public class camerasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: cameras
        public ActionResult Index()
        {
            var cameras = db.cameras.Include(c => c.company);
            return View(cameras.ToList());
        }

        // GET: cameras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            camera camera = db.cameras.Find(id);
            if (camera == null)
            {
                return HttpNotFound();
            }
            return View(camera);
        }

        // GET: cameras/Create
        public ActionResult Create()
        {
            ViewBag.companyID = new SelectList(db.companies, "companyID", "Name");
            return View();
        }

        // POST: cameras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cameraID,companyID,Model,Megapixels,cameraPrice,image")] camera camera)
        {
            if (ModelState.IsValid)
            {
                db.cameras.Add(camera);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.companyID = new SelectList(db.companies, "companyID", "Name", camera.companyID);
            return View(camera);
        }

        // GET: cameras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            camera camera = db.cameras.Find(id);
            if (camera == null)
            {
                return HttpNotFound();
            }
            ViewBag.companyID = new SelectList(db.companies, "companyID", "Name", camera.companyID);
            return View(camera);
        }

        // POST: cameras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cameraID,companyID,Model,Megapixels,cameraPrice,image")] camera camera)
        {
            if (ModelState.IsValid)
            {
                db.Entry(camera).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.companyID = new SelectList(db.companies, "companyID", "Name", camera.companyID);
            return View(camera);
        }

        // GET: cameras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            camera camera = db.cameras.Find(id);
            if (camera == null)
            {
                return HttpNotFound();
            }
            return View(camera);
        }

        // POST: cameras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            camera camera = db.cameras.Find(id);
            db.cameras.Remove(camera);
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
