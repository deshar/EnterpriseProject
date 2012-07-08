using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlanningForm.Controllers
{
   
        public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Create your Planning Application";

            return View();
        }
         public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
                        

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
            [Authorize]
            public ActionResult ApplicationForm()
        {
            ViewBag.Message = "New Application Form.";

            return View();
        }
            [Authorize(Roles = "Administrator")] 
            public ActionResult Search()
            {
                ViewBag.Message = "Search Index";

                return View();
            }
    }
}
