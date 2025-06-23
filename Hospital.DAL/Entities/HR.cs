using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL.Entities
{
   public class HR: Appuser
    {
         public string Department { get; set; }
        public string Position { get; set; }
        public DateTime HireDate { get; set; }
        public ICollection<Salary> Salaries { get; set; }
    }
}
