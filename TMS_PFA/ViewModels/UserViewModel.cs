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

        [Display(Name = "Prénom")]
        public string FirstName { get; set; }
        

        [Required]
        [Phone(ErrorMessage = "Format incorrect")]
        [Display(Name = "Téléphone")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Adresse mail")]
        [EmailAddress(ErrorMessage = "Email invalide")]
        public string Email { get; set; }

        public string Role { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Minimum 8 caractères")]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }


        [Compare("Password")]
        [UIHint("Entrer à nouveau votre mot de passe")]
        [Display(Name = "Confirmer le mot de passe")]
        public string Confirmation { get; set; }


        [Display(Name = "Numéro de compte")]
        public string AccountId { get; set; }
    }
}
