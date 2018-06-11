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
    public class companiesController : Controller
    {

        //private ApplicationDbContext db = new ApplicationDbContext();
        private IMockCompaniesRepository db;

        //default constructor - no dependecy incoming => use the db
        public companiesController()
        {
            this.db = new EFCompaniesRepository();

        }

        //mock contructor - mock object passed as a dependency for unit testing

        public companiesController(IMockCompaniesRepository mockRepo)
        {
            this.db = mockRepo;
        }
        // GET: companies
        public ActionResult Index()
        {
            return View(db.companies.ToList());
        }

        // GET: companies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");

            }

            //company company = db.companies.Find(id);
            company company = db.companies.SingleOrDefault(c => c.companyID == id);
            


            if (company == null)
            {
                //return HttpNotFound();
                return View("Error");

            }
            return View(company);
        }

        // GET: companies/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "companyID,Name,Address,Logo,Phone,CEO,numEmployees,stockName")] company company)
        {
            if (ModelState.IsValid)
            {
                //db.companies.Add(company);
                //db.SaveChanges();

                db.Save(company);
                return RedirectToAction("Index");


            }

            return View("Create", company);
        }

        // GET: companies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");

            }
            //company company = db.companies.Find(id);
            company company = db.companies.SingleOrDefault(c => c.companyID == id);

            if (company == null)
            {
                //return HttpNotFound();
                return View("Error");
            }
            return View("Edit", company);
        }

        // POST: companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "companyID,Name,Address,Logo,Phone,CEO,numEmployees,stockName")] company company)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(company).State = EntityState.Modified;
                //db.SaveChanges();

                db.Save(company);
                return RedirectToAction("Index");
            }
            return View("Edit", company);
        }

        // GET: companies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");

            }
            //company company = db.companies.Find(id);
            company company = db.companies.SingleOrDefault(c => c.companyID == id);

            if (company == null)
            {
                //return HttpNotFound();
                return View("Error");

            }
            return View(company);
        }

        // POST: companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //company company = db.companies.Find(id);
            //db.companies.Remove(company);
            //db.SaveChanges();
            company company = db.companies.SingleOrDefault(c => c.companyID == id);
            db.Delete(company);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
