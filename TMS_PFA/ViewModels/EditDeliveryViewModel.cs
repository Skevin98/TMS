using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TMS_PFA.Models;

namespace TMS_PFA.ViewModels
{
    public class EditDeliveryViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string Details { get; set; }

        public DateTime EstimatedReceiptDate { get; set; }
        public string Progression { get; set; }


        public Guid PurchaseId { get; set; }




        [Required]
        public Guid SelectedVehicle { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> Vehicles { get; set; }

        [Required]
        public Guid SelectedDriver { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> Drivers { get; set; }


    }
}
