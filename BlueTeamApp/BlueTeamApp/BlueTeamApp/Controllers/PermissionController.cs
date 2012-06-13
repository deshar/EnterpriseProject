using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlueTeamApp.Controllers
{
    public class PermissionController : Controller
    {
        //
        // GET: /Permission/

        public ActionResult Index()
        {        
            return View();
        }
        //
        // GET: /Permission/Welcome/

        public ActionResult Welcome(string name, int numTimes = 1)
        {
            ViewBag.Message = "Hello " + name;
            ViewBag.NumTimes = numTimes;

            return View();
        }
    }
}
