using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL.DTO
{
    public class RegisterRequestPatientdto
    {
        //patient
        public required  string Username { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        //public  string usertype { get; set; } = "Patient";
        public required string fullname { get; set; }
        public required string PhoneNumber { get; set; }
        public required int age { get; set; }
        public required string gender { get; set; }
        public required string bloodType { get; set; }
        public required string medicalHistory { get; set; }
     

    }
}
