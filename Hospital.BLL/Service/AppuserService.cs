using Hospital.BLL.Repo.IRepo;
using Hospital.BLL.Service.IService;
using Hospital.DAL.Entities;
using Hospital.DAL.Repo.IRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL.Service
{
    public class AppuserService : IAppuserService
    {
        private readonly IAppuserRepo _appuserRepo;
        public AppuserService(IAppuserRepo appuserRepo)
        {
            _appuserRepo = appuserRepo;
        }
        public async Task AddAsync(Appuser user)
        {
            await _appuserRepo.AddAsync(user);
        }



        public async Task DeleteAsync(Guid id)
        {
            await _appuserRepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<object>> GetAllAsync()
        {
            var users = await _appuserRepo.GetAllAsync();

            var result = users.Select<Appuser, object>(user => user switch
            {
                Doctor doctor => new
                {
                    Type = "Doctor",
                    doctor.Id,
                    doctor.Email,
                    doctor.UserName,
                    doctor.PhoneNumber,
                    doctor.fullname,
                    doctor.Specialty,
                    doctor.ConsultationFee,
                    doctor.ClinicSchedule,
                    doctor.clinicId
                },

                Nurse nurse => new
                {
                    Type = "Nurse",
                    nurse.Id,
                    nurse.Email,
                    nurse.UserName,
                    nurse.PhoneNumber,
                    nurse.fullname,
                    nurse.medicaldepartment,
                    nurse.RoomId
                },

                Patient patient => new
                {
                    Type = "Patient",
                    patient.Id,
                    patient.Email,
                    patient.UserName,
                    patient.PhoneNumber,
                    patient.fullname,
                    patient.age,
                    patient.gender,
                    patient.bloodType,
                    patient.medicalHistory
                },

                HR hr => new
                {
                    Type = "HR",
                    hr.Id,
                    hr.Email,
                    hr.UserName,
                    hr.PhoneNumber,
                    hr.fullname,
                    hr.Department,
                    hr.Position,
                    hr.HireDate
                },

                Reception reception => new
                {
                    Type = "Reception",
                    reception.Id,
                    reception.Email,
                    reception.UserName,
                    reception.PhoneNumber,
                    reception.fullname,
                    reception.emergencylevel,
                    reception.status,
                    reception.checkintime
                },

                _ => new
                {
                    Type = "Unknown",
                    user.Id,
                    user.Email,
                    user.UserName
                }
            });

            return result;
        }


        public async Task<IEnumerable<object>> GetAllByTypeAsync(string userType)
        {
            var users = await _appuserRepo.GetAllByTypeAsync(userType.ToLower());

            var result = users.Select<Appuser, object>(user => user switch
            {
                Doctor doctor => new
                {
                    Type = "Doctor",
                    doctor.Id,
                    doctor.Email,
                    doctor.UserName,
                    doctor.PhoneNumber,
                    doctor.fullname,
                    doctor.Specialty,
                    doctor.ConsultationFee,
                    doctor.ClinicSchedule,
                    doctor.clinicId
                },

                Nurse nurse => new
                {
                    Type = "Nurse",
                    nurse.Id,
                    nurse.Email,
                    nurse.UserName,
                    nurse.PhoneNumber,
                    nurse.fullname,
                    nurse.medicaldepartment,
                    nurse.RoomId
                },

                Patient patient => new
                {
                    Type = "Patient",
                    patient.Id,
                    patient.Email,
                    patient.UserName,
                    patient.PhoneNumber,
                    patient.fullname,
                    patient.age,
                    patient.gender,
                    patient.bloodType,
                    patient.medicalHistory
                },

                HR hr => new
                {
                    Type = "HR",
                    hr.Id,
                    hr.Email,
                    hr.UserName,
                    hr.PhoneNumber,
                    hr.fullname,
                    hr.Department,
                    hr.Position,
                    hr.HireDate
                },

                Reception reception => new
                {
                    Type = "Reception",
                    reception.Id,
                    reception.Email,
                    reception.UserName,
                    reception.PhoneNumber,
                    reception.fullname,
                    reception.emergencylevel,
                    reception.status,
                    reception.checkintime
                },

                _ => new
                {
                    Type = "Unknown",
                    user.Id,
                    user.Email,
                    user.UserName
                }
            });

            return result;
        }


        public async Task<object?> GetByIdAsync(Guid id)
        {
            var user = await _appuserRepo.GetByIdAsync(id) as Appuser;
            if (user == null) return null;
            return user switch
            {
                Doctor doctor => new
                {
                    Type = "Doctor",
                    doctor.Id,
                    doctor.Email,
                    doctor.UserName,
                    doctor.PhoneNumber,
                    doctor.fullname,
                    doctor.Specialty,
                    doctor.ConsultationFee,
                    doctor.ClinicSchedule,
                    doctor.DoctorImage,
                    doctor.clinicId
                },

                Nurse nurse => new
                {
                    Type = "Nurse",
                    nurse.Id,
                    nurse.Email,
                    nurse.UserName,
                    nurse.PhoneNumber,
                    nurse.fullname,
                    nurse.medicaldepartment,
                    nurse.RoomId
                },

                Patient patient => new
                {
                    Type = "Patient",
                    patient.Id,
                    patient.Email,
                    patient.UserName,
                    patient.PhoneNumber,
                    patient.fullname,
                    patient.age,
                    patient.gender,
                    patient.bloodType,
                    patient.medicalHistory
                },

                HR hr => new
                {
                    Type = "HR",
                    hr.Id,
                    hr.Email,
                    hr.UserName,
                    hr.PhoneNumber,
                    hr.fullname,
                    hr.Department,
                    hr.Position,
                    hr.HireDate
                },

                Reception reception => new
                {
                    Type = "Reception",
                    reception.Id,
                    reception.Email,
                    reception.UserName,
                    reception.PhoneNumber,
                    reception.fullname,
                    reception.emergencylevel,
                    reception.status,
                    reception.checkintime
                },


            };
        }






        public async Task<Appuser> GetUserByEmailAsync(string email)
        {
            return await _appuserRepo.GetUserByEmailAsync(email);
        }

        public async Task UpdateAsync(Appuser user)
        {
            await _appuserRepo.UpdateAsync(user);
        }

    }
}
