
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TMS_PFA.Models
{
    public class DeliveryForm : BaseEntity 
    {
        public DateTime ReceiptDate { get; set; }
        public string DestinationAddress { get; set; }
        public double Price { get; set; }
        
        [ForeignKey("Delivery")]
        public Guid DeliveryId { get; set; }
        public virtual Delivery Delivery { get; set; }
    }
}
