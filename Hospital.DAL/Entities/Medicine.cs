using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL.Entities
{
    public class Medicine
    {
        public int medicineId { get; set; }
        public string medicineName { get; set; }
        public string time { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }

    }
}
