using Hospital.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL.Database
{
   public class ApplicationDbContext: IdentityDbContext<Appuser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        {
        }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Appuser> Appusers { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<ClinicAvailableDay> ClinicAvailableDays { get; set; }
        public DbSet<Ray> Rays { get; set; }    
      
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Appuser>()
               .Property(u => u.usertype)
               .IsRequired();

            modelBuilder.Entity<ClinicAvailableDay>()
            .HasOne(c => c.Clinic)
            .WithMany(c => c.AvailableDays)
            .HasForeignKey(c => c.ClinicId);
           
            // Doctor - Appointments (1-M)
            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Appointments)
                .WithOne(a => a.Doctor)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict); 

            // Patient - Appointments (1-M)
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Appointments)
                .WithOne(a => a.Patient)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict); 

            // Clinic - Doctors (1-M)
            modelBuilder.Entity<Clinic>()
                .HasMany(c => c.Doctors)
                .WithOne(d => d.Clinic)
                .HasForeignKey(d => d.clinicId)
                .OnDelete(DeleteBehavior.Restrict); 

            // Clinic - Appointments (1-M)
            modelBuilder.Entity<Clinic>()
                .HasMany(c => c.Appointments)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);  // optional

            // HR - Salaries (1-M)
            modelBuilder.Entity<HR>()
                .HasMany(h => h.Salaries)
                .WithOne(s => s.HR)
                .HasForeignKey(s => s.HRId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Salary>()
    .Property(s => s.Amount)
    .HasPrecision(18, 2);

            // Room - Nurse (1-M)
            modelBuilder.Entity<Room>()
                .HasMany(r => r.Nurses)
                .WithOne(n => n.Room)
                .HasForeignKey(n => n.RoomId)
                .OnDelete(DeleteBehavior.Restrict); 

            // Room - Patients (1-M)
            modelBuilder.Entity<Room>()
                .HasMany(r => r.Patients)
                .WithMany(p => p.Rooms); // if many-to-many is acceptable

            // Reception - Rays
            modelBuilder.Entity<Ray>()
     .HasOne(r => r.Patient)
     .WithMany(p => p.Rays)
     .HasForeignKey(r => r.PatientId)
     .OnDelete(DeleteBehavior.Restrict); 
            modelBuilder.Entity<Ray>()
                .HasOne(r => r.Reception)
                .WithMany(r => r.BookedRays)
                .HasForeignKey(r => r.ReceptionId)
                .OnDelete(DeleteBehavior.Restrict);
        }



    }
}
