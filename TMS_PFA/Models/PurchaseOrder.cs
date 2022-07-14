
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TMS_PFA.Models
{
    public class PurchaseOrder : BaseEntity 
    {
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Quantity { get; set; }

        public String Destination { get; set; }
        public string Details { get; set; }
        public List<Receipt> Receipts { get; set; }

        public List<Delivery> Deliveries { get; set; }

        [ForeignKey("Client")]
        public Guid ClienId { get; set; }
        public virtual Client Client { get; set; }
    }
}
