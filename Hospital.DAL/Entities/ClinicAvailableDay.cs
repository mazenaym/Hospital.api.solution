using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL.Entities
{
    public class ClinicAvailableDay
    {
        public int Id { get; set; }

        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

    }
}
