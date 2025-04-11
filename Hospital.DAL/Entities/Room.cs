using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL.Entities
{
   public class Room
    {
        public int roomId { get; set; }
        public string roomType { get; set; }
        public bool roomStatus { get; set; }
        public int roomPrice { get; set; }
        public int roomNum { get; set; }
        public int roomFloor { get; set; }
    }
}
