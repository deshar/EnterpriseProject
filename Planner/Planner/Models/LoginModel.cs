using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Planner.Controllers
{
    public class LoginModel
            {
        [Required]
        [StringLength(10)]
        public string Username{get; set;}
        [Required]
        [StringLength(8)]
        public string Password { get; set; }
    }
}
