using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TMS_PFA.Models;

namespace TMS_PFA.ViewModels
{
    public class EditDeliveryViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Display(Name = "Statut")]
        public Status Status { get; set; }
        [Display(Name = "Détails")]
        public string Details { get; set; }

        [Display(Name = "Date de livraison estimée")]
        public DateTime EstimatedReceiptDate { get; set; }
        [Display(Name = "Progression")]
        public string Progression { get; set; }

        [Display(Name = "ID de la commande")]
        public Guid PurchaseId { get; set; }




        [Required]
        [Display(Name = "Véhicule affecté")]
        public Guid SelectedVehicle { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> Vehicles { get; set; }

        [Required]
        [Display(Name = "Chauffeur affecté")]
        public Guid SelectedDriver { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> Drivers { get; set; }


    }
}
