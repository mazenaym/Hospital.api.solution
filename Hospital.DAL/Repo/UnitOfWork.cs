using Hospital.BLL.Repo.IRepo;
using Hospital.DAL.Database;
using Hospital.DAL.Repo.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IAppuserRepo Appusers { get; }

        public ISalaryRepo Salaries { get; }
        public IClinicRepo Clinics { get; }
        public IAppointmentRepo Appointments { get; }

        public UnitOfWork(ApplicationDbContext context,
                          IAppuserRepo appuserRepo,

                          ISalaryRepo salaryRepo,
                          IClinicRepo clinicRepo)
        {
            _context = context;
            Appusers = appuserRepo;

            Salaries = salaryRepo;
            Clinics = clinicRepo;
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
    }
}

