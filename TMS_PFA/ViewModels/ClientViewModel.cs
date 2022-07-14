using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TMS_PFA.ViewModels
{
    public class ClientViewModel : UserViewModel
    {

        [Required]
        [Display(Name = "Type")]
        [UIHint("Entrer le type de client : (Particulier,Société)")]
        public string Type { get; set; }

        public string Address { get; set; }




    }
}
