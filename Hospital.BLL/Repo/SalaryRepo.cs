using Hospital.DAL.Database;
using Hospital.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL.Repo
{
   public class SalaryRepo
    {
        private readonly ApplicationDbContext _context;
        public SalaryRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddSalary (Salary salary)
        {
            _context.Add(salary);
            _context.SaveChanges();
        }
        public IEnumerable<Salary> GetAllSalarys()
        {
            return _context.Salaries.ToList();
        }
        public async Task<IEnumerable<Salary>> GetSalaryByUserName(string username)
        {
            return await _context.Salaries
                .Include(s => s.AppUser)
                .Where(s => s.AppUser.UserName == username)
                .ToListAsync();
        }
        public void UpdateSalary(Salary salary)
        {
            var existingSalary = _context.Salaries.FirstOrDefault(s => s.salaryId == salary.salaryId);
            if (existingSalary != null)
            {
                existingSalary.Amount = salary.Amount;
                existingSalary.PaymentDate = salary.PaymentDate;
                existingSalary.PaymentMethod = salary.PaymentMethod;
                existingSalary.Status = salary.Status;
                
            }
            _context.SaveChanges();
        }
        public void DeleteSalary(int salaryId)
        {
            var salary = _context.Salaries.FirstOrDefault(s => s.salaryId == salaryId);
            if (salary != null)
            {
                _context.Salaries.Remove(salary);
                _context.SaveChanges();
            }
        }
    }
}
