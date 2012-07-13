using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plan1.Models;

namespace Plan1.Controllers
{ 
    public class PermissionController : Controller
    {
        private PermissionDBContext db = new PermissionDBContext();

        //
        // GET: /Permission/
        [Authorize]
        public ViewResult Index()
        {
            return View(db.Permissions.Take(8).ToList());
        }

        //
        // GET: /Permission/Details/5

        public ActionResult Details(int id = 0)
        {
            Permission permission = db.Permissions.Find(id);
            if (permission == null)
            {
                return HttpNotFound();
            }
            return View(permission);
        }

        //
        // GET: /Permission/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Permission/Create

        [HttpPost]
        public ActionResult Create(Permission permission)
        {
            if (ModelState.IsValid)
            {
                db.Permissions.Add(permission);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(permission);
        }
        
        //
        // GET: /Permission/Edit/5
 
        public ActionResult Edit(int id = 0)
        {
            Permission permission = db.Permissions.Find(id);
            if (permission == null)
            {
                return HttpNotFound();
            }
            return View(permission);
        }

        //
        // POST: /Permission/Edit/5

        [HttpPost]
        public ActionResult Edit(Permission permission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(permission).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(permission);
        }

        //
        // GET: /Permission/Delete/5
 
        public ActionResult Delete(int id = 0)
        {
            Permission permission = db.Permissions.Find(id);
            if (permission == null)
            {
                return HttpNotFound();
            }
            return View(permission);
        }

        //
        // POST: /Permission/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id = 0)
        {            
            Permission permission = db.Permissions.Find(id);
            if (permission == null)
            {
                return HttpNotFound();
            }
            db.Permissions.Remove(permission);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        [Authorize]
        public ActionResult SearchIndex( string planAddr, string searchString)
        {   
            var AddrLst = new List<string>();

            var AddrQry = from d in db.Permissions
                   orderby d.postalAddr
                   select d.postalAddr;
            AddrLst.AddRange(AddrQry.Distinct());
            ViewBag.planAddr = new SelectList(AddrLst);
 
            var permissions = from m in db.Permissions
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                permissions = permissions.Where(s => s.appName.Contains(searchString)).Take(3);
            }

            if (string.IsNullOrEmpty(planAddr))
                return View(permissions.Take(3));
            else
            {
                return View(permissions.Where(x => x.postalAddr == planAddr));
            }

        }
    }
}