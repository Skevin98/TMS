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
        public string Type { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }

        public DateTime PurchaseDate { get; set; }
        public double Capacity { get; set; }

        public double TankCapacity { get; set; }
        public long Mileage { get; set; }

        public DateTime Insurance { get; set; }

        public DateTime TechnicalVisit { get; set; }

        //public List<Delivery> Deliveries { get; set; }
    }
}
