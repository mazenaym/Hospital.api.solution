using Hospital.BLL.Repo.IRepo;
using Hospital.DAL.Database;
using Hospital.DAL.Entities;
using Hospital.DAL.Repo.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL.Repo
{
    public class ClinicRepo : IClinicRepo
    {
        private readonly ApplicationDbContext _context;
        public ClinicRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<ClinicAvailableDay> GetClinicAvailableDaysByClinicId(int clinicId)
        {
            return _context.ClinicAvailableDays
                           .Where(d => d.ClinicId == clinicId)
                           .ToList();
        }
        public void AddClinicAvailableDays(IEnumerable<ClinicAvailableDay> clinicAvailableDay)
        {

            _context.ClinicAvailableDays.AddRange(clinicAvailableDay);
            _context.SaveChanges();
        }
        public void UpdateClinicAvailableDays(int clinicId, IEnumerable<ClinicAvailableDay> newDays)
        {
            var existingDays = _context.ClinicAvailableDays
                                       .Where(d => d.ClinicId == clinicId)
                                       .ToList();

            _context.ClinicAvailableDays.RemoveRange(existingDays);
            _context.ClinicAvailableDays.AddRange(newDays);

            _context.SaveChanges();
        }
        public void DeleteAvailableDayById(int dayId)
        {
            var day = _context.ClinicAvailableDays.Find(dayId);
            if (day != null)
            {
                _context.ClinicAvailableDays.Remove(day);
                _context.SaveChanges();
            }
        }
        public void AddClinic(Clinic clinic)
        {
            _context.Clinics.Add(clinic);
            _context.SaveChanges();

        }
        public IEnumerable<Clinic> GetAllClinc()
        {
            return _context.Clinics.ToList();
        }
        public Clinic GetClinicById(int id)
        {
            return _context.Clinics.FirstOrDefault(c => c.clinicId == id);
        }
        public void UpdateClinic(Clinic clinic)
        {
            var existingClinic = _context.Clinics.FirstOrDefault(c => c.clinicId == clinic.clinicId);
            if (existingClinic != null)
            {
                existingClinic.clinicName = clinic.clinicName;
                existingClinic.clinicNum = clinic.clinicNum;

            }
            _context.SaveChanges();
        }
        public void DeleteClinic(int id)
        {
            var clinic = _context.Clinics.FirstOrDefault(c => c.clinicId == id);
            if (clinic != null)
            {
                _context.Clinics.Remove(clinic);
                _context.SaveChanges();
            }
        }
    }
}
