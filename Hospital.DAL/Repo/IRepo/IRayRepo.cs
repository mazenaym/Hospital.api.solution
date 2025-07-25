using Hospital.DAL.Entities;

namespace Hospital.DAL.Repo.IRepo
{
    public interface IRayRepo
    {
        void AddRay(Ray ray);
        void DeleteRay(int id);
        IEnumerable<Ray> GetAllRays();
        Ray GetRayById(int id);
        void UpdateRay(Ray ray);
    }
}