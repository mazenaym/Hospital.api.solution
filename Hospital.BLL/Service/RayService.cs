using AutoMapper;
using Hospital.BLL.DTO;
using Hospital.BLL.Repo.IRepo;
using Hospital.BLL.Service.IService;
using Hospital.DAL.Entities;
using Hospital.DAL.Repo.IRepo;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL.Service
{
    public class RayService : IRayService
    {
        private readonly IRayRepo _rayRepo;

        public RayService(IRayRepo rayRepo)
        {
            _rayRepo = rayRepo;

        }
        public async Task AddRay(Raydto dto)
        {
            if (dto.RayImage == null || dto.RayImage.Length == 0)
                throw new ArgumentException("Ray Image Is Required");
            using var memoryStream = new MemoryStream();
            await dto.RayImage.CopyToAsync(memoryStream);
            var ray = new Ray
            {
                RayImage = memoryStream.ToArray(),
                RayType = dto.RayType,
                RayDate = dto.RayDate,
                RayName = dto.RayName,
                PatientId = dto.PatientId,
                ReceptionId = dto.ReceptionId
            };

            _rayRepo.AddRay(ray);
        }
        public void DeleteRay(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid Ray ID");
            }
            var ray = _rayRepo.GetAllRays().FirstOrDefault(s => s.RayId == id);
            if (ray == null)
            {
                throw new KeyNotFoundException("Ray not found");
            }
            _rayRepo.DeleteRay(id);
        }
        public IEnumerable<Ray> GetAllRays()
        {

            return _rayRepo.GetAllRays();
        }
        public Ray GetRayById(int id)
        {
            var ray = _rayRepo.GetRayById(id);
            if (ray == null)
            {
                return null;
            }
            return _rayRepo.GetRayById(id);
        }
        public void UpdateRay(Raydto dto)
        {
            var existingRay = _rayRepo.GetRayById(dto.RayId);
            if (existingRay == null)
            {
                throw new KeyNotFoundException("Ray not found");
            }
            existingRay.RayName = dto.RayName;
            existingRay.RayType = dto.RayType;
            existingRay.RayDate = dto.RayDate;
            if (dto.RayImage != null && dto.RayImage.Length > 0)
            {
                using var memoryStream = new MemoryStream();
                dto.RayImage.CopyTo(memoryStream);
                existingRay.RayImage = memoryStream.ToArray();
            }
            existingRay.PatientId = dto.PatientId;
            existingRay.ReceptionId = dto.ReceptionId;
            _rayRepo.UpdateRay(existingRay);

        }

    }
}
