using Hospital.DAL.Entities;

namespace Hospital.BLL.Service.IService
{
    public interface IAppuserService
    {
        Task AddAsync(Appuser user);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<object>> GetAllAsync();
        Task<IEnumerable<object>> GetAllByTypeAsync(string userType);
        Task<object?> GetByIdAsync(Guid id);
        Task<Appuser> GetUserByEmailAsync(string email);
        Task UpdateAsync(Appuser user);
    }
}