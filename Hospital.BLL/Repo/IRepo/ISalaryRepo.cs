using Hospital.DAL.Entities;

namespace Hospital.BLL.Repo.IRepo
{
    public interface ISalaryRepo
    {
        void AddSalary(Salary salary);
        void DeleteSalary(int salaryId);
        IEnumerable<Salary> GetAllSalarys();
        Task<IEnumerable<Salary>> GetSalaryByUserName(string username);
        void UpdateSalary(Salary salary);
    }
}