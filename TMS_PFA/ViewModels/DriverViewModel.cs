using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TMS_PFA.Models;

namespace TMS_PFA.ViewModels
{



    public class DriverViewModel : UserViewModel
    {
        public string Nid { get; set; }
        
        public DateTime Birth { get; set; }

        public Sexe Sexe { get; set; }

        public DateTime HiringDate { get; set; }
        public double Salary { get; set; }

        [Required]
        public string LicenseId { get; set; }
        [Required]
        public LicenseType LicenseType { get; set; }

    }
}
