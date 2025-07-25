using Hospital.BLL.DTO;
using Hospital.DAL.Entities;

namespace Hospital.BLL.Service.IService
{
    public interface IAppointmentService
    {
        Task AddAppointmentAsync(Appointmentdto dto);
        void DeleteAppointment(int id);
        IEnumerable<Appointmentdto> GetAllAppointments();
        Appointment GetAppointmentById(int id);
        void UpdateAppointment(Appointmentdto dto);
    }
}