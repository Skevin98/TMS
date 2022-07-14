
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TMS_PFA.Models
{

    public enum Status { InProgress, Canceled, Delivered}

    public class Delivery : BaseEntity 
    {


        [Column(TypeName="nvarchar(24)")]
        public Status Status { get; set; }
        public string Details { get; set; }

        public DateTime EstimatedReceiptDate { get; set; }
        public string Progression { get; set; }

        [ForeignKey("PurchaseOrder")]
        public Guid PurchaseId { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }


        public virtual DeliveryForm DeliveryForm { get; set; }

        [ForeignKey("Vehicle")]
        public Guid VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        [ForeignKey("Driver")]
        public Guid DriverId { get; set; }
        public virtual Driver Driver { get; set; }
    }
}
