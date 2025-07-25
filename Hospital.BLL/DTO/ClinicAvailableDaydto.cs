using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL.DTO
{
    public class ClinicAvailableDaydto
    {
        public int ClinicId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }

       
        public TimeSpan StartTime { get; set; }

       
        public TimeSpan EndTime { get; set; }
    }
}
