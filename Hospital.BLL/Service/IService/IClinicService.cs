using Hospital.BLL.DTO;

namespace Hospital.BLL.Service.IService
{
    public interface IClinicService
    {
        void AddClinic(Clinicdto dto);
        void AddClinicAvailableDays(IEnumerable<ClinicAvailableDaydto> days);
        void DeleteClinic(int id);
        void DeleteClinicAvailableDays(int clinicId);
        IEnumerable<Clinicdto> GetAllClinc();
        IEnumerable<ClinicAvailableDaydto> GetClinicAvailableDaysByClinicId(int clinicId);
        Clinicdto GetClinicById(int id);
        void UpdateClinic(Clinicdto dto);
    }
}