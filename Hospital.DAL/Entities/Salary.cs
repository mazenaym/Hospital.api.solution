using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL.Entities
{
   public class Salary
    {
        public int salaryId { get; set; }

        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public string HRId { get; set; }
        public HR HR { get; set; }
        public string AppUserId { get; set; }
        public Appuser AppUser { get; set; }
    }
}
