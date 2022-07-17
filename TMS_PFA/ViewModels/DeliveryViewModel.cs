using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TMS_PFA.Models;

namespace TMS_PFA.ViewModels
{
    public class DeliveryViewModel
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

        [Display(Name = "ID du véhicule")]
        public Guid VehicleId { get; set; }

        [Display(Name = "ID du chauffeur")]
        public Guid DriverId { get; set; }

        [Display(Name = "ID du bon de livraison")]
        public Guid? DeliveryFormId { get; set; }


    }
}
