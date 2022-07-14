using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TMS_PFA.ViewModels
{
    public class UserViewModel
    {

        [Key]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Nom")]
        [UIHint("Entrer votre nom")]
        public string Name { get; set; }
        public string FirstName { get; set; }
        

        [Required]
        [Phone(ErrorMessage = "Format incorrect")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Email invalide")]
        public string Email { get; set; }

        public string Role { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Minimum 8 caractères")]
        public string Password { get; set; }


        [Compare("Password")]
        public string Confirmation { get; set; }


        public string AccountId { get; set; }
    }
}
