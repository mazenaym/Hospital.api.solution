using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL.Entities
{
  public  class Patient
    {
        public int age { get; set; }
        public string gender { get; set; }
        public string bloodType { get; set; }
        public string medicalHistory { get; set; }
    }
}
