using Hospital.DAL.Entities;

namespace Hospital.BLL.Service.TokenService
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(Appuser user);
    }
}