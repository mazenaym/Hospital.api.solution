using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL.Entities
{
   public class Doctor
    {
        public string Specialty { get; set; }
        public string ConsultationFee { get; set; }
        public string ClinicSchedule { get; set; }
    }
}
