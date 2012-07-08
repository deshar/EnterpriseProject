using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlanningForm.Models;
using PagedList;

namespace PlanningForm.Controllers
{
    public class PlanningApplicationsController : Controller
    {
        private PlanningApplicationDBContext db = new PlanningApplicationDBContext();

        //
        // GET: /PlanningApplications/

        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date desc" : "Date";

            if (Request.HttpMethod == "GET")
            {
                searchString = currentFilter;
            }
            else
            {
                page = 1;
            }
            ViewBag.CurrentFilter = searchString;

            var planningapplications = from s in db.PlanningApplications
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                planningapplications = planningapplications.Where(s => s.name.ToUpper().Contains(searchString.ToUpper())
                                      );
            }
            switch (sortOrder)
            {
                case "Name desc":
                    planningapplications = planningapplications.OrderByDescending(s => s.name);
                    break;
                case "Date":
                    planningapplications = planningapplications.OrderBy(s => s.ApplicationDate);
                    break;
                case "Date desc":
                    planningapplications = planningapplications.OrderByDescending(s => s.ApplicationDate);
                    break;
                default:
                    planningapplications = planningapplications.OrderBy(s => s.name);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(planningapplications.ToPagedList(pageNumber, pageSize));
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
        [Authorize(Roles = "Administrator")] 
        public ActionResult SearchIndex(string searchString)
        {
            
            var planningapplications = from m in db.PlanningApplications
            select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                planningapplications = planningapplications.Where(s => s.name.Contains(searchString));
            }

            return View(planningapplications);
        }

        //
        // GET: /PlanningApplications/Create
        [Authorize]
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