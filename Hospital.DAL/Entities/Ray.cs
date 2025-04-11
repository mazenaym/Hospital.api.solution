using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL.Entities
{
   public class Ray
    {
        public int RayId { get; set; }
        public string RayName { get; set; }
        public string RayType { get; set; }
        public string RayDate { get; set; }
        public byte[] RayImage { get; set; }
    }
}
