using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TMS_PFA.ViewModels
{
    public class DeliveryFormViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Date de livraison")]
        public DateTime ReceiptDate { get; set; }

        [Display(Name = "Adresse de destination")]
        public string DestinationAddress { get; set; }
        //public double Price { get; set; }

        [Display(Name = "Formulaire")]
        public string ImageName { get; set; }

        [NotMapped]
        [Display(Name = "Formulaire")]
        public IFormFile ImageFile { get; set; }

        [Display(Name = "ID de la livraison")]
        public Guid DeliveryId { get; set; }

    }
}
