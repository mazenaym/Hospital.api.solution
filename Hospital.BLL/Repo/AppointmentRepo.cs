using Hospital.DAL.Database;
using Hospital.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL.Repo
{
   public class AppointmentRepo
    {
        private readonly ApplicationDbContext _context;
        public AppointmentRepo(ApplicationDbContext context)
        {
            _context = context;
            
        }
        public void AddAppointment (Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }
        public IEnumerable<Appointment> GetAllAppointment()
        {
            return _context.Appointments.ToList();
        }
        public Appointment GetAppointmentByid(int id)
        {
            return _context.Appointments.FirstOrDefault(a => a.appointmentId == id);
        }
        public void UpdateAppointment(Appointment appointment)
        {
            var existingAppointment = _context.Appointments.FirstOrDefault(a => a.appointmentId == appointment.appointmentId);
            if (existingAppointment != null)
            {
                existingAppointment.consultation_num = appointment.consultation_num;
                existingAppointment.appointmentDate = appointment.appointmentDate;
                existingAppointment.reason = appointment.reason;
                existingAppointment.status = appointment.status;
                existingAppointment.PatientId = appointment.PatientId;
                existingAppointment.DoctorId = appointment.DoctorId;
                _context.SaveChanges();
            }
        }
        public void DeleteAppointment(int id)
        {
            var appointment = _context.Appointments.FirstOrDefault(a => a.appointmentId == id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                _context.SaveChanges();
            }
        }
        }
}
