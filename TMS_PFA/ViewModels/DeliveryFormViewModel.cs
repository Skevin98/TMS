using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMS_PFA.ViewModels
{
    public class DeliveryFormViewModel
    {
        public Guid Id { get; set; }
        public DateTime ReceiptDate { get; set; }
        public string DestinationAddress { get; set; }
        public double Price { get; set; }

        public Guid DeliveryId { get; set; }

    }
}
