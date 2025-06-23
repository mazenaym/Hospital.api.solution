using Hospital.DAL.Entities;

namespace Hospital.BLL.Repo.IRepo
{
    public interface IAppuserRepo
    {
        Task AddAsync(Appuser user);
        Task AddUserAsync(Appuser newUser);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Appuser>> GetAllAsync();
        Task<IEnumerable<Appuser>> GetAllByTypeAsync(string userType);
        Task<Appuser?> GetByIdAsync(Guid id);
        Task<Appuser?> GetByStringIdIdAsync(string id);
        Task<Appuser> GetUserByEmailAsync(string email);
        Task UpdateAsync(Appuser user);
    }
}