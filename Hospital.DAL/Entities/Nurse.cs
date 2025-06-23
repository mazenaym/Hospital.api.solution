using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL.Entities
{
   public class Nurse: Appuser
    {
        public string medicaldepartment { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }

    }
}
