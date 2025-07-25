﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL.Entities
{
   public class Doctor:Appuser
    {
        public byte[] DoctorImage { get; set; }
        public string Specialty { get; set; }
        public string ConsultationFee { get; set; }
        public string ClinicSchedule { get; set; }
        public int clinicId { get; set; }
        public Clinic Clinic { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
