using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL.Entities
{
   public class Clinc
    {
        public int clincId { get; set; }
        public string clincName { get; set; }
        public int clincNum { get; set; }
        public string doctorslist { get; set; }
    }
}
