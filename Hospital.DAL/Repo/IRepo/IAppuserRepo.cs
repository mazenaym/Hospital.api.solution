using Hospital.DAL.Entities;

namespace Hospital.DAL.Repo.IRepo
{
    public interface IAppuserRepo
    {
        Task AddAsync(Appuser user);
        Task AddUserAsync(Appuser newUser);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Appuser>> GetAllAsync();
        Task<IEnumerable<Appuser>> GetAllByTypeAsync(string userType);
        Task<object?> GetByIdAsync(Guid id);
        Task<Appuser?> GetByStringIdIdAsync(string id);
        Task<Appuser> GetUserByEmailAsync(string email);
        Task UpdateAsync(Appuser user);
    }
}