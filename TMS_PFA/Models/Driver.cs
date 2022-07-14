using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TMS_PFA.Models
{
    public enum LicenseType{A,B,C,D}

    public class Driver : Employee
    {
        public string LicenseId { get; set; }

        [Column(TypeName = "nvarchar(24)")]
        public LicenseType LicenseType { get; set; }

        public List<Delivery> Deliveries { get; set; }
    }
}
