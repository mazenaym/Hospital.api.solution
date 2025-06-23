using Hospital.BLL.Repo.IRepo;
using Hospital.DAL.Database;
using Hospital.DAL.Entities;
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
                existingClinic.doctorslist = clinic.doctorslist;
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
