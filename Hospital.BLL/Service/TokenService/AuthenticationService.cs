using Hospital.BLL.DTO;
using Hospital.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL.Service.TokenService
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ILogger<AuthenticationService> _logger;
        private readonly UserManager<Appuser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;
        public AuthenticationService(
            ILogger<AuthenticationService> logger,
            UserManager<Appuser> userManager,
            IConfiguration configuration,
            ITokenService tokenService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userManager = userManager;
            _configuration = configuration;
            _tokenService = tokenService;
        }
        public async Task<string?> RegisterPatientAsync(RegisterRequestPatientdto request)
        {
            var user = new Patient
            {
                UserName = request.Username,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                usertype = "Patient",
                fullname = request.fullname,
                age = request.age,
                gender = request.gender,
                bloodType = request.bloodType,
                medicalHistory = request.medicalHistory,


            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                return null;
            }
            return await _tokenService.CreateTokenAsync(user);
        }
        public async Task<string?> RegisterDoctorAsync(RegisterRequestDoctordto request)
        {
            if (request.DoctorImage == null || request.DoctorImage.Length == 0)
            {
                throw new ArgumentException("Doctor Image is required");
            }
            using var memoryStream = new MemoryStream();
            await request.DoctorImage.CopyToAsync(memoryStream);

            var user = new Doctor
            {
                UserName = request.Username,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                usertype = "Doctor",
                age = request.age,
                gender = request.gender,
                fullname = request.fullname,
                Specialty = request.Specialty,
                ConsultationFee = request.ConsultationFee,
                ClinicSchedule = request.ClinicSchedule,
                DoctorImage = memoryStream.ToArray(),
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                return null;
            }
            return await _tokenService.CreateTokenAsync(user);
        }
        public async Task<string?> RegisterNurseAsync(RegisterRequestNursedto request)
        {
            var user = new Nurse
            {
                UserName = request.Username,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                age =request.age,
                gender = request.gender,
                usertype = "Nurse",
                fullname = request.fullname,
                medicaldepartment = request.medicaldepartment,

            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                return null;
            }
            return await _tokenService.CreateTokenAsync(user);
        }
        public async Task<string?> RegisterHrAsync(RegisterRequestHrdto request)
        {
            var user = new HR
            {
                UserName = request.Username,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                usertype = "HR",
                fullname = request.fullname,
                age = request.age,
                gender=request.gender,
                Department = request.Department,
                Position = request.Position,
                HireDate = request.HireDate,
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                return null;
            }
            return await _tokenService.CreateTokenAsync(user);
        }
        public async Task<string?> RegisterReceptionAsync(RegisterRequestRecptiondto request)
        {
            var user = new Reception
            {
                UserName = request.Username,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                usertype = "Reception",
                fullname = request.fullname,
                age = request.age,
                gender = request.gender,
                emergencylevel = request.emergencylevel,
                status = request.status,
                checkintime = request.checkintime,
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                return null;
            }
            return await _tokenService.CreateTokenAsync(user);
        }
        public async Task<string?> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, password))
            {
                return null;
            }
            return await _tokenService.CreateTokenAsync(user);
        }
    }
}
