using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL.DTO
{
    public class Salarydto
    {
        public int salaryId { get; set; }

        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? PaymentMethod { get; set; }
        public string? Status { get; set; }
        public Guid AppUserId { get; set; }
        public string? HRId { get; set; }
    }
}
