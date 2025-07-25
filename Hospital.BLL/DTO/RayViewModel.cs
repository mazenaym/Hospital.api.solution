using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL.DTO
{
    public class RayViewModel
    {
        public int RayId { get; set; }
        public string RayName { get; set; }
        public string RayType { get; set; }
        public string RayDate { get; set; }
        public string RayImageBase64 { get; set; }
        public string PatientId { get; set; }
        public string ReceptionId { get; set; }
    }
}
