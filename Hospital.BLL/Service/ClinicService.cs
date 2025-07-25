using AutoMapper;
using Hospital.BLL.DTO;
using Hospital.BLL.Repo.IRepo;
using Hospital.BLL.Service.IService;
using Hospital.DAL.Entities;
using Hospital.DAL.Repo.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL.Service
{
    public class ClinicService : IClinicService
    {
        private readonly IClinicRepo _clinicRepo;
        private readonly IMapper _mapper;
        public ClinicService(IClinicRepo clinicRepo, IMapper mapper)
        {
            _clinicRepo = clinicRepo;
            _mapper = mapper;
        }
        public void AddClinic(Clinicdto dto)
        {
            var clinic = _mapper.Map<Clinic>(dto);
            _clinicRepo.AddClinic(clinic);
        }

        public void DeleteClinic(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid Clinic ID");
            }
            var clinic = _clinicRepo.GetAllClinc().FirstOrDefault(s => s.clinicId == id);
            if (clinic == null)
            {
                throw new KeyNotFoundException("Clinic not found");
            }
            _clinicRepo.DeleteClinic(id);
        }

        public IEnumerable<Clinicdto> GetAllClinc()
        {
            var clinics = _clinicRepo.GetAllClinc();
            return _mapper.Map<IEnumerable<Clinicdto>>(clinics);
        }

        public Clinicdto GetClinicById(int id)
        {
            var clinic = _clinicRepo.GetClinicById(id);
            if (clinic == null)
            {
                return null;
            }
            return _mapper.Map<Clinicdto>(clinic);

        }

        public void UpdateClinic(Clinicdto dto)
        {
            var clinic = _mapper.Map<Clinic>(dto);
            _clinicRepo.UpdateClinic(clinic);
        }
        public void AddClinicAvailableDays(IEnumerable<ClinicAvailableDaydto> days)
        {
            var clinicDays = _mapper.Map<IEnumerable<ClinicAvailableDay>>(days);
            _clinicRepo.AddClinicAvailableDays(clinicDays);

        }
        public IEnumerable<ClinicAvailableDaydto> GetClinicAvailableDaysByClinicId(int clinicId)
        {
            var clinicDays = _clinicRepo.GetClinicAvailableDaysByClinicId(clinicId);
            if (clinicDays == null || !clinicDays.Any())
            {
                return Enumerable.Empty<ClinicAvailableDaydto>();
            }
            return _mapper.Map<IEnumerable<ClinicAvailableDaydto>>(clinicDays);
        }
        public void DeleteClinicAvailableDays(int clinicId)
        {
            if (clinicId <= 0)
            {
                throw new ArgumentException("Invalid Clinic ID");
            }
            var clinicDays = _clinicRepo.GetClinicAvailableDaysByClinicId(clinicId);
            if (clinicDays == null || !clinicDays.Any())
            {
                throw new KeyNotFoundException("Clinic available days not found");
            }
            _clinicRepo.DeleteAvailableDayById(clinicId);
        }
    }

}
