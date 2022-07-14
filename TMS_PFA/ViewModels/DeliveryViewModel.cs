using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TMS_PFA.Models;

namespace TMS_PFA.ViewModels
{
    public class DeliveryViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string Details { get; set; }

        public DateTime EstimatedReceiptDate { get; set; }
        public string Progression { get; set; }

        public Guid PurchaseId { get; set; }

        public Guid VehicleId { get; set; }

        public Guid DriverId { get; set; }

        public Guid? DeliveryFormId { get; set; }


    }
}
