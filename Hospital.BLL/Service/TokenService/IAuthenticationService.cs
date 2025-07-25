using Hospital.BLL.DTO;

namespace Hospital.BLL.Service.TokenService
{
    public interface IAuthenticationService
    {
        Task<string?> LoginAsync(string email, string password);
        Task<string?> RegisterDoctorAsync(RegisterRequestDoctordto request);
        Task<string?> RegisterHrAsync(RegisterRequestHrdto request);
        Task<string?> RegisterNurseAsync(RegisterRequestNursedto request);
        Task<string?> RegisterPatientAsync(RegisterRequestPatientdto request);
        Task<string?> RegisterReceptionAsync(RegisterRequestRecptiondto request);
    }
}