using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TMS_PFA.ViewModels
{
    public class ReceiptViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Type de marchandise")]
        public string Type { get; set; }
        [Display(Name = "Date de réception")]
        public DateTime Date { get; set; }
        [Display(Name = "Poids")]
        public double Weight { get; set; }
        [Display(Name = "Hauteur")]
        public double Height { get; set; }
        [Display(Name = "Largeur")]
        public double Width { get; set; }
        [Display(Name = "Quantité")]
        public double Quantity { get; set; }
        [Display(Name = "Détails")]
        public string Details { get; set; }

        [Display(Name = "Formulaire")]
        public string ImageName { get; set; }

        [NotMapped]
        [Display(Name = "Formulaire")]
        public IFormFile ImageFile { get; set; }

        [Display(Name = "ID de la commande")]
        public Guid PurchaseId { get; set; }
    }
}
