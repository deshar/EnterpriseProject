using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plan1.Models;

namespace Plan1.Controllers
{
    public class NotTDDController : Controller
    {

        PermissionDBContext _db = new PermissionDBContext();

        public ActionResult Index()
        {
            var dn = _db.Permissions;
            return View(dn);
        }

        public ActionResult Edit(int id)
        {
            Permission prd = _db.Permissions.FirstOrDefault(d => d.Id == id);
            return View(prd);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Permission prd = _db.Permissions.FirstOrDefault(d => d.Id == id);
            UpdateModel(prd);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    } 

}
