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
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepo _appointmentRepo;
        private readonly IMapper _mapper;
        private readonly EmailService _emailService;
        private readonly IAppuserRepo _appuserRepo;
        private readonly IClinicRepo _clinicRepo;
        public AppointmentService(IAppointmentRepo appointmentRepo, IMapper mapper, EmailService emailService, IAppuserRepo appuserRepo, IClinicRepo clinicRepo)
        {
            _appointmentRepo = appointmentRepo;
            _mapper = mapper;
            _emailService = emailService;
            _appuserRepo = appuserRepo;
            _clinicRepo = clinicRepo;
        }
        public async Task AddAppointmentAsync(Appointmentdto dto)
        {
            var appointmentTime= dto.appointmentDate.TimeOfDay;
            var appontmentDay = dto.appointmentDate.DayOfWeek;
            var clinicAvailableDays =  _clinicRepo.GetClinicAvailableDaysByClinicId(dto.ClinicId);
            var matchingSlot = clinicAvailableDays.FirstOrDefault(day => day.DayOfWeek == appontmentDay && 
                                                              day.StartTime <= appointmentTime && 
                                                              day.EndTime >= appointmentTime);
            if (matchingSlot == null)
            {
                throw new InvalidOperationException("The selected appointment time is not available in the clinic's schedule.");
            }
            var appointment = _mapper.Map<Appointment>(dto);
            _appointmentRepo.AddAppointment(appointment);

            // Get Doctor & Patient
            //var doctor = await _appuserRepo.GetByStringIdIdAsync(dto.DoctorId);
            //var patient = await _appuserRepo.GetByStringIdIdAsync(dto.PatientId);

            //string date = appointment.appointmentDate.ToString("dd-MM-yyyy HH:mm");

            //if (doctor != null)
            //{
            //    string subject = "ميعاد المقابلة";
            //    string body = $"تم حجز مقابلة مع مريض بتاريخ {date}";
            //    await _emailService.SendEmailAsync(doctor.Email, subject, body);
            //}

            //if (patient != null)
            //{
            //    string subject = "تأكيد ميعاد المقابلة";
            //    string body = $"تم حجز مقابلة مع الدكتور بتاريخ {date}";
            //    await _emailService.SendEmailAsync(patient.Email, subject, body);
            //}
        }

        public IEnumerable<Appointmentdto> GetAllAppointments()
        {
            var appointments = _appointmentRepo.GetAllAppointment();
            return _mapper.Map<IEnumerable<Appointmentdto>>(appointments);
        }
        public Appointment GetAppointmentById(int id)
        {
            var appointment = _appointmentRepo.GetAppointmentByid(id);
            if (appointment == null)
            {
                return null;
            }
            return _mapper.Map<Appointment>(appointment);

        }
        public void UpdateAppointment(Appointmentdto dto)
        {
            var appointment = _mapper.Map<Appointment>(dto);
            _appointmentRepo.UpdateAppointment(appointment);

        }
        public void DeleteAppointment(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid Appointment ID");
            }
            var appointments = _appointmentRepo.GetAllAppointment().FirstOrDefault(s => s.appointmentId == id);
            if (appointments == null)
            {
                throw new KeyNotFoundException("Appointment not found");
            }
            _appointmentRepo.DeleteAppointment(id);
        }

    }
}
