using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL.Entities
{
   public class Reception
    {
        public string emergencylevel { get; set; }
        public bool status { get; set; }
        public DateTime checkintime { get; set; }
    }
}
