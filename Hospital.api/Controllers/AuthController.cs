using Hospital.BLL.DTO;
using Hospital.BLL.Service.TokenService;
using Hospital.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

namespace Hospital.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authService;
        private readonly UserManager<Appuser> _userManager;
        private readonly RegisterRequestPatientdto registerRequestdto;
        private readonly ILogger<AuthenticationService> _logger;
        public AuthController(
            IAuthenticationService authService,
            UserManager<Appuser> userManager,
            ILogger<AuthenticationService> logger)
        {
            _authService = authService;
            _userManager = userManager;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestdto request)
        {
            if (request == null)
            {
                return BadRequest("Login data is null.");
            }
            var token = await _authService.LoginAsync(request.Email, request.Password);
            if (token == null)
            {
                return Unauthorized("Invalid username or password.");
            }
            return Ok(new { Token = token });
        }
        [HttpPost("register patient")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestPatientdto request)
        {
            var registerRequest = new RegisterRequestPatientdto
            {
                Username = request.Username,
                Password = request.Password,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,

                fullname = request.fullname,
                age = request.age,
                gender = request.gender,
                bloodType = request.bloodType,
                medicalHistory = request.medicalHistory,

            };

            var token = await _authService.RegisterPatientAsync(registerRequest);
            if (token == null)
            {
                return BadRequest("Registration failed.");
            }
            return Ok(new { Token = token });
        }
        [HttpPost("register doctor")]
        public async Task<IActionResult> RegisterDoctor([FromForm] RegisterRequestDoctordto request)
        {
            if (request == null)
            {
                return BadRequest("Registration data is null.");
            }
            var token = await _authService.RegisterDoctorAsync(request);
            if (token == null)
            {
                return BadRequest("Registration failed.");
            }
            return Ok(new { Token = token });
        }
        [HttpPost("register hr")]
        public async Task<IActionResult> RegisterHR([FromBody] RegisterRequestHrdto request)
        {
            if (request == null)
            {
                return BadRequest("Registration data is null.");
            }
            var token = await _authService.RegisterHrAsync(request);
            if (token == null)
            {
                return BadRequest("Registration failed.");
            }
            return Ok(new { Token = token });
        }
        [HttpPost("register reception")]
        public async Task<IActionResult> RegisterReception([FromBody] RegisterRequestRecptiondto request)
        {
            if (request == null)
            {
                return BadRequest("Registration data is null.");
            }
            var token = await _authService.RegisterReceptionAsync(request);
            if (token == null)
            {
                return BadRequest("Registration failed.");
            }
            return Ok(new { Token = token });


        }
        [HttpPost("register nurse")]
        public async Task<IActionResult> RegisterNurse([FromBody] RegisterRequestNursedto request)
        {
            if (request == null)
            {
                return BadRequest("Registration data is null.");
            }
            var token = await _authService.RegisterNurseAsync(request);
            if (token == null)
            {
                return BadRequest("Registration failed.");
            }
            return Ok(new { Token = token });
        }

       }
    }
