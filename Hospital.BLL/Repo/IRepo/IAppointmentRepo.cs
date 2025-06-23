using Hospital.DAL.Entities;

namespace Hospital.BLL.Repo.IRepo
{
    public interface IAppointmentRepo
    {
        void AddAppointment(Appointment appointment);
        void DeleteAppointment(int id);
        IEnumerable<Appointment> GetAllAppointment();
        Appointment GetAppointmentByid(int id);
        void UpdateAppointment(Appointment appointment);
    }
}