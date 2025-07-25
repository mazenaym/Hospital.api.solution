using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL.Entities
{
   public class Appuser: IdentityUser
    {
        public string fullname { get; set; }
        public string usertype { get; set; }
        public int age { get; set; }
        public string gender { get; set; }



    }
}
