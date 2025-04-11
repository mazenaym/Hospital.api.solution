using Hospital.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL.Database
{
   public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) :base(options)
        {

        }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Appuser> Appusers { get; set; }
        public DbSet<Clinc> Clincs { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<HR> HRs { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Ray> Rays { get; set; }    
        public DbSet<Reception> Receptions { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Salary> Salaries { get; set; }




    }
}
