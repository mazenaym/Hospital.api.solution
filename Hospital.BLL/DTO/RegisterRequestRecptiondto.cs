using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL.DTO
{
    public class RegisterRequestRecptiondto
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }

        public required string fullname { get; set; }
        public required string PhoneNumber { get; set; }
        public required int age { get; set; }
        public required string gender { get; set; }
        public string emergencylevel { get; set; }
        public bool status { get; set; }
        public DateTime checkintime { get; set; }
    }
}
