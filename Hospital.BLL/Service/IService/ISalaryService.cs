using Hospital.BLL.DTO;

namespace Hospital.BLL.Service.IService
{
    public interface ISalaryService
    {
        Task AddSalaryAsync(Salarydto dto);
        void DeleteSalary(int id);
        IEnumerable<Salarydto> GetAllSalaries();
        Task<IEnumerable<Salarydto>> GetSalaryByUserNameAsync(string username);
        void UpdateSalary(Salarydto dto);
    }
}