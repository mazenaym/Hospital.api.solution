using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL.DTO
{
    public class Clinicdto
    {
        public int clinicId { get; set; }
        public string? clinicName { get; set; }
        public int clinicNum { get; set; }
        public string? doctorslist { get; set; }
    }
}
