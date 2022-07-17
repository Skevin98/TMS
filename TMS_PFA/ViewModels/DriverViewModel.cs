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
        [Display(Name = "Numéro de carte d'identité")]
        public string Nid { get; set; }


        [Display(Name = "Date de naissance")]
        public DateTime Birth { get; set; }

        [Display(Name = "Sexe")]
        public Sexe Sexe { get; set; }


        [Display(Name = "Date d'embauche")]
        public DateTime HiringDate { get; set; }

        [Display(Name = "Salaire")]
        public double Salary { get; set; }

        [Required]
        [Display(Name = "Numéro de permis")]
        public string LicenseId { get; set; }
        [Required]
        [Display(Name = "Type de permis")]
        public LicenseType LicenseType { get; set; }

    }
}
