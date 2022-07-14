using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TMS_PFA.ViewModels
{
    public class ReceiptViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Quantity { get; set; }
        public string Details { get; set; }

        public Guid PurchaseId { get; set; }
    }
}
