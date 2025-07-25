using Hospital.BLL.DTO;
using Hospital.DAL.Entities;

namespace Hospital.BLL.Service.IService
{
    public interface IRayService
    {
        Task AddRay(Raydto dto);
        void DeleteRay(int id);
        IEnumerable<Ray> GetAllRays();
        Ray GetRayById(int id);
        void UpdateRay(Raydto dto);
    }
}