using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Plan1.Models
{
    public class Permission
    {
        [Key] public int Id { get; set; }

        [Required(ErrorMessage = "Permission Type is required")]
        [Range(10, 100, ErrorMessage = "Permission Type must be between 10 and 100")]
        public int permType { get; set; }

        [Required(ErrorMessage = "Postal Address is required")]
        [RegularExpression(@"^[a-z0-9-\u0020]{1,50}$", ErrorMessage =
            "Only lower case letters and numbers are allowed here")]        
        public string postalAddr { get; set; }

        [Required(ErrorMessage = "Applicant Name is required")]
        [RegularExpression(@"^[^\u003c\u003e\u0026\u0022\u0027\u002f]{1,50}$", ErrorMessage =
            "Characters < > & \u0022 ' / are not allowed here")]
        public string appName { get; set; }

        [Required(ErrorMessage = "Application Date is required")]        
        [RegularExpression(@"^((((0[1-9])|([1-2][0-9])|(3[0-1]))|([1-9]))\x2d(((0[1-9])|(1[0-2]))|([1-9]))\x2d(([0-9]{2})|(((19)|([2]([0]{1})))([0-9]{2}))))$", ErrorMessage =
            "Invalid characters used in the Date")]
        public string appDate { get; set; }

        [StringLength(20)]
        [RegularExpression(@"^[^\u003c\u003e\u0026\u0022\u0027\u002f]{1,50}$", ErrorMessage =
            "Characters < > & \u0022 ' / are not allowed here")]
        public string archName { get; set; }

        [Required(ErrorMessage = "Development Description is required")]
        [RegularExpression(@"^[^\u003c\u003e\u0026\u0022\u0027\u002f]{1,50}$", ErrorMessage =
             "Characters < > & \u0022 ' / are not allowed here")]
        public string devDesc { get; set; }

        [StringLength(20)]
        [RegularExpression(@"^[^\u003c\u003e\u0026\u0022\u0027\u002f]{1,50}$", ErrorMessage =
            "Characters < > & \u0022 ' / are not allowed here")]
        public string ownerName { get; set; }

        [Required(ErrorMessage = "Retained Building Address is required")]
        [RegularExpression(@"^[a-zA-Z0-9-\u002e\u0020]{1,50}$", ErrorMessage =
            "Only letters and numbers are allowed here")]
        public string retBldAddr { get; set; }

        [Required(ErrorMessage = "Address of Architect is required")]
        [RegularExpression(@"^[a-zA-Z0-9-\u002e\u0020]{1,50}$", ErrorMessage =
            "Only letters and numbers are allowed here")]
        public string addrDrawer { get; set; }
           

    }

    public class PermissionDBContext : DbContext
    {
        public DbSet<Permission> Permissions { get; set; }
    }
}