
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TMS_PFA.Models
{
    public class Client : BaseEntity
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public List<PurchaseOrder> PurchaseOrders { get; set; }

        [ForeignKey("Account")]
        public string AccountId { get; set; }
        public virtual Account Account { get; set; }


    }
}
