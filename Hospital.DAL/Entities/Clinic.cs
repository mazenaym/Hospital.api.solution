using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL.Entities
{
   public class Clinic
    {
        public int clinicId { get; set; }
        public string clinicName { get; set; }
        public int clinicNum { get; set; }
        //public string doctorslist { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<ClinicAvailableDay> AvailableDays { get; set; }
    }
}
