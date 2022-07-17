using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TMS_PFA.Models;

namespace TMS_PFA.ViewModels
{
    public class VehicleViewModel
    {
        [Key]
        public string Id { get; set; }
        [Display(Name = "Numéro d'immatriculation")]
        public string NumberPlate { get; set; }
        [Display(Name = "Type")]
        public string Type { get; set; }
        [Display(Name = "Poids")]
        public double Weight { get; set; }
        [Display(Name = "Hauteur")]
        public double Height { get; set; }
        [Display(Name = "Largeur")]
        public double Width { get; set; }

        [Display(Name = "Date d'achat")]
        public DateTime PurchaseDate { get; set; }
        [Display(Name = "Capacité")]
        public double Capacity { get; set; }

        [Display(Name = "Capacité du réservoir")]
        public double TankCapacity { get; set; }
        [Display(Name = "Kilometrage")]
        public long Mileage { get; set; }

        [Display(Name = "Assurance")]
        public DateTime Insurance { get; set; }

        [Display(Name = "Visite technique")]
        public DateTime TechnicalVisit { get; set; }

        //public List<Delivery> Deliveries { get; set; }
    }
}
