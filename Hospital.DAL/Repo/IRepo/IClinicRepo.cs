using Hospital.DAL.Entities;

namespace Hospital.DAL.Repo.IRepo
{
    public interface IClinicRepo
    {
        void AddClinic(Clinic clinic);
        void AddClinicAvailableDays(IEnumerable<ClinicAvailableDay> clinicAvailableDay);
        void DeleteAvailableDayById(int dayId);
        void DeleteClinic(int id);
        IEnumerable<Clinic> GetAllClinc();
        IEnumerable<ClinicAvailableDay> GetClinicAvailableDaysByClinicId(int clinicId);
        Clinic GetClinicById(int id);
        void UpdateClinic(Clinic clinic);
        void UpdateClinicAvailableDays(int clinicId, IEnumerable<ClinicAvailableDay> newDays);
    }
}