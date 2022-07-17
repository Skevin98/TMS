using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TMS_PFA.ViewModels
{
    public class PurchaseOrderViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Type de marchandise")]
        public string Type { get; set; }

        [Display(Name = "Date de la commande")]
        public DateTime Date { get; set; }
        [Display(Name = "Poids")]
        public double Weight { get; set; }
        [Display(Name = "Taille")]
        public double Height { get; set; }
        [Display(Name = "Largeur")]
        public double Width { get; set; }
        [Display(Name = "Quantité")]
        public double Quantity { get; set; }
        [Display(Name = "Point de réception")]
        public String Starting { get; set; }
        [Display(Name = "Point de destination")]
        public String Destination { get; set; }
        [Display(Name = "Details")]
        public string Details { get; set; }
        [Display(Name = "ID du client")]
        public Guid ClientId { get; set; }

    }
}
