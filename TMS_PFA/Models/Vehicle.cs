
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMS_PFA.Models
{
    public class Vehicle : BaseEntity
    {
        public string NumberPlate { get; set; }
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

        public List<Delivery> Deliveries { get; set; }
    }
}
