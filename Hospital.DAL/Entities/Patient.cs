using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL.Entities
{
  public  class Patient: Appuser
    {
       
        public string bloodType { get; set; }
        public string medicalHistory { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Ray> Rays { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}
