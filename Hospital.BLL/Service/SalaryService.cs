using AutoMapper;
using Hospital.BLL.DTO;
using Hospital.BLL.Repo.IRepo;
using Hospital.BLL.Service.IService;
using Hospital.DAL.Entities;
using Hospital.DAL.Repo.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL.Service
{
    public class SalaryService : ISalaryService
    {
        private readonly ISalaryRepo _salaryRepo;
        private readonly IMapper _mapper;
        private readonly EmailService _emailService;
        private readonly IAppuserRepo _appuserRepo;


        public SalaryService(ISalaryRepo salaryRepo, IMapper mapper, EmailService emailService, IAppuserRepo appuserRepo)
        {
            _salaryRepo = salaryRepo;
            _mapper = mapper;
            _emailService = emailService;
            _appuserRepo = appuserRepo;
        }
        public async Task AddSalaryAsync(Salarydto dto)
        {
            var salary = _mapper.Map<Salary>(dto);
            _salaryRepo.AddSalary(salary);
            //var userObject = await _appuserRepo.GetByIdAsync(dto.AppUserId);
            //var user = userObject as Appuser;
            //if (user != null)
            //{
            //    string toEmail = user.Email;
            //    string subject = "تم إيداع الراتب";
            //    string body = $"تم إيداع راتبك بقيمة {salary.Amount} بتاريخ {salary.PaymentDate.ToShortDateString()}";

            //    await _emailService.SendEmailAsync(toEmail, subject, body);
            //}
        }
        public IEnumerable<Salarydto> GetAllSalaries()
        {
            var salaries = _salaryRepo.GetAllSalarys();
            return _mapper.Map<IEnumerable<Salarydto>>(salaries);

        }
        public async Task<IEnumerable<Salarydto>> GetSalaryByUserNameAsync(string username)
        {
            var salaries = await _salaryRepo.GetSalaryByUserName(username);
            return _mapper.Map<IEnumerable<Salarydto>>(salaries);
        }
        public void UpdateSalary(Salarydto dto)
        {
            var salary = _mapper.Map<Salary>(dto);
            _salaryRepo.UpdateSalary(salary);
        }
        public void DeleteSalary(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid salary ID");
            }
            var salary = _salaryRepo.GetAllSalarys().FirstOrDefault(s => s.salaryId == id);
            if (salary == null)
            {
                throw new KeyNotFoundException("Salary not found");
            }
            _salaryRepo.DeleteSalary(id);

        }
    }
}
