using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL.Entities
{
   public class Appointment
    {
        public int appointmentId { get; set; }
        public int consultation_num { get; set; }
        public DateTime appointmentDate { get; set; }
        public string reason { get; set; }
        public bool status { get; set; }
        public string PatientId { get; set; }
        public Patient Patient { get; set; }

        public string DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
