
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TMS_PFA.Models
{
    public class Receipt : BaseEntity
    {
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Quantity { get; set; }
        public string Details { get; set; }

        public string ImageName { get; set; }

        [ForeignKey("PurchaseOrder")]

        public Guid PurchaseId { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}
