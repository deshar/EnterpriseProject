using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;
using Plan1.Models;
using System.Web.Helpers;

namespace Plan1
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            Database.SetInitializer<PermissionDBContext>(new PermissionInitialiser());
            
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            // Initialize WebMail helper
            //WebMail.SmtpServer = "mail1.eircom.net";
            //WebMail.SmtpPort = 25;
            //WebMail.UserName = "deshar";
            //WebMail.Password = "dhar1111";
            //WebMail.From = "deshar@eircom.net";

            // Initialize WebMail helper
            //WebMail.SmtpServer = "pod51007.outlook.com";
            //WebMail.SmtpPort = 587;
            //WebMail.UserName = "x11106506@student.ncirl.ie";
            //WebMail.Password = "dhar4444";
            //WebMail.From = "deshar@eircom.net";
        }
    }
}