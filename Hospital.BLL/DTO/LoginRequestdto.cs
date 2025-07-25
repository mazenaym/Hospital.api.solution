using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL.DTO
{
    public class LoginRequestdto
    {
      
            public required string Email { get; set; }
            public required string Password { get; set; }
        
    }
}
