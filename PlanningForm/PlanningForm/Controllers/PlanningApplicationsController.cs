using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlanningForm.Models;

namespace PlanningForm.Controllers
{
    public class PlanningApplicationsController : Controller
    {
        private PlanningApplicationDBContext db = new PlanningApplicationDBContext();

        //
        // GET: /PlanningApplications/

        public ActionResult Index()
        {
            return View(db.PlanningApplications.ToList());
        }

        //
        // GET: /PlanningApplications/Details/5

        public ActionResult Details(int id = 0)
        {
            PlanningApplication planningapplication = db.PlanningApplications.Find(id);
            if (planningapplication == null)
            {
                return HttpNotFound();
            }
            return View(planningapplication);
        }
        public ActionResult SearchIndex(string searchString)
        {
            
            var planningapplications = from m in db.PlanningApplications
            select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                planningapplications = planningapplications.Where(s => s.address.Contains(searchString));
            }

            return View(planningapplications);
        }

        //
        // GET: /PlanningApplications/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PlanningApplications/Create

        [HttpPost]
        public ActionResult Create(PlanningApplication planningapplication)
        {
            if (ModelState.IsValid)
            {
                db.PlanningApplications.Add(planningapplication);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(planningapplication);
        }

        //
        // GET: /PlanningApplications/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PlanningApplication planningapplication = db.PlanningApplications.Find(id);
            if (planningapplication == null)
            {
                return HttpNotFound();
            }
            return View(planningapplication);
        }

        //
        // POST: /PlanningApplications/Edit/5

        [HttpPost]
        public ActionResult Edit(PlanningApplication planningapplication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planningapplication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(planningapplication);
        }

        //
        // GET: /PlanningApplications/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PlanningApplication planningapplication = db.PlanningApplications.Find(id);
            if (planningapplication == null)
            {
                return HttpNotFound();
            }
            return View(planningapplication);
        }

        //
        // POST: /PlanningApplications/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PlanningApplication planningapplication = db.PlanningApplications.Find(id);
            db.PlanningApplications.Remove(planningapplication);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}