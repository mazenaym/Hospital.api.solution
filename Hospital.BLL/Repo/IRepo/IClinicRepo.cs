using Hospital.DAL.Entities;

namespace Hospital.BLL.Repo.IRepo
{
    public interface IClinicRepo
    {
        void AddClinic(Clinic clinic);
        void DeleteClinic(int id);
        IEnumerable<Clinic> GetAllClinc();
        Clinic GetClinicById(int id);
        void UpdateClinic(Clinic clinic);
    }
}