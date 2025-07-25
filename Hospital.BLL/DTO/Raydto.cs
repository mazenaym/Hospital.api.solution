using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL.DTO
{
    public class Raydto
    {
        public int RayId { get; set; }
        public string RayName { get; set; }
        public string RayType { get; set; }
        public string RayDate { get; set; }
        public IFormFile RayImage { get; set; }
        public string PatientId { get; set; }
        public string ReceptionId { get; set; }
    }
}
