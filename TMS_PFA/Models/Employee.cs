
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TMS_PFA.Models
{

    public enum Sexe { Man, Woman }
    public class Employee : BaseEntity 
    {
        public string Nid { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime Birth { get; set; }

        [Column(TypeName = "nvarchar(24)")]
        public Sexe Sexe { get; set; }

        public DateTime HiringDate { get; set; }
        public double Salary { get; set; }




        [ForeignKey("Account")]
        public string AccountId { get; set; }
        public virtual Account Account { get; set; }

    }
}
