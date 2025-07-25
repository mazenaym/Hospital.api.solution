using Hospital.BLL.Repo.IRepo;

namespace Hospital.DAL.Repo.IRepo
{
    public interface IUnitOfWork
    {
        IAppointmentRepo Appointments { get; }
        IAppuserRepo Appusers { get; }
        IClinicRepo Clinics { get; }
        ISalaryRepo Salaries { get; }

        Task<int> SaveAsync();
    }
}