using Hospital.BLL.Repo.IRepo;
using Hospital.DAL.Database;
using Hospital.DAL.Entities;
using Hospital.DAL.Repo.IRepo;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL.Repo
{
    public class RayRepo : IRayRepo
    {
        private readonly ApplicationDbContext _context;
        public RayRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddRay(Ray ray)
        {
            _context.Rays.Add(ray);
            _context.SaveChanges();
        }
        public IEnumerable<Ray> GetAllRays()
        {
            return _context.Rays.ToList();
        }
        public Ray GetRayById(int id)
        {
            return _context.Rays.FirstOrDefault(r => r.RayId == id);
        }
        public void UpdateRay(Ray ray)
        {
            var existingRay = _context.Rays.FirstOrDefault(r => r.RayId == ray.RayId);
            if (existingRay != null)
            {
                existingRay.RayName = ray.RayName;
                existingRay.RayType = ray.RayType;
                existingRay.RayDate = ray.RayDate;
                existingRay.RayImage = ray.RayImage;
                existingRay.PatientId = ray.PatientId;
                existingRay.ReceptionId = ray.ReceptionId;
            }
            _context.SaveChanges();
        }
        public void DeleteRay(int id)
        {
            var ray = _context.Rays.FirstOrDefault(r => r.RayId == id);
            if (ray != null)
            {
                _context.Rays.Remove(ray);
                _context.SaveChanges();
            }
        }
    }
}
