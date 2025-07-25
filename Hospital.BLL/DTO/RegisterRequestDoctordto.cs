using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL.DTO
{
    public class RegisterRequestDoctordto
    {
        public IFormFile DoctorImage { get; set; }
        public string Specialty { get; set; }
        public string ConsultationFee { get; set; }
        public string ClinicSchedule { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public required string fullname { get; set; }
        public required string PhoneNumber { get; set; }
        public required int age { get; set; }
        public required string gender { get; set; }
    }
}
