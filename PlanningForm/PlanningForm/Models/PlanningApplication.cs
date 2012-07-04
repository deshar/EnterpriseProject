using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PlanningForm.Models
{
    public class PlanningApplication
    {
        public int ID { get; set; }
        public string Apptype { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string town { get; set; }
        public string email {get; set;}
        public string telephone { get; set; }
        public string LegalInterest { get; set; }
            }
    public class PlanningApplicationDBContext : DbContext
    {
        public DbSet<PlanningApplication> PlanningApplications { get; set; }
    }
}