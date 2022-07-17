using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TMS_PFA.ViewModels
{
    public class LoginViewModel
    {

        [Key]
        public string Id { get; set; }
        [Required]
        [Display(Name = "Nom d'utilisateur")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }
    }
}
