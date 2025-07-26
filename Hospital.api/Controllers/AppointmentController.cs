using Hospital.BLL.DTO;
using Hospital.BLL.Service.IService;
using Hospital.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentservice;
        public AppointmentController(IAppointmentService appointmentservice)
        {
            _appointmentservice = appointmentservice;
        }
        [Authorize(Roles = "Admin,Reception")]
        [HttpGet]
        public IActionResult GetAllAppointments()
        {
            var appointments = _appointmentservice.GetAllAppointments();
            if (appointments == null || !appointments.Any())
            {
                return NotFound("No appointments found.");
            }
            return Ok(appointments);
        }
        [Authorize(Roles = "Doctor,Reception")]
        [HttpGet("{id}")]
        public IActionResult GetAppointmentById(int id)
        {
            var appointment = _appointmentservice.GetAppointmentById(id);
            if (appointment == null)
            {
                return NotFound($"Appointment with ID {id} not found.");
            }
            return Ok(appointment);
        }
        [Authorize(Roles = "Reception,Patient")]
        [HttpPost]
        public async Task<IActionResult> AddAppointmentAsync([FromBody] Appointmentdto dto)
        {
            if (dto == null)
            {
                return BadRequest("Appointment data is null.");
            }
            if (User.IsInRole("Patient"))
            {
                var patientId = User.FindFirst("userId")?.Value;
                if (string.IsNullOrEmpty(patientId))
                    return Unauthorized("Invalid user token.");

                dto.PatientId = patientId;
            }

            await _appointmentservice.AddAppointmentAsync(dto);
            return CreatedAtAction(nameof(GetAppointmentById), new { id = dto.appointmentId }, dto);
        }
        [Authorize(Roles = "Reception")]
        [HttpPut("{id}")]
        public IActionResult UpdateAppointment(int id, [FromBody] Appointmentdto dto)
        {
            if (dto == null || dto.appointmentId != id)
            {
                return BadRequest("Invalid appointment data.");
            }
            var existingAppointment = _appointmentservice.GetAppointmentById(id);
            if (existingAppointment == null)
            {
                return NotFound($"Appointment with ID {id} not found.");
            }
            _appointmentservice.UpdateAppointment(dto);
            return NoContent();
        }
        [Authorize(Roles = "Reception,Patient")]
        [HttpDelete("{id}")]
        public IActionResult DeleteAppointment(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Appointment ID");
            }
            var existingAppointment = _appointmentservice.GetAppointmentById(id);
            if (existingAppointment == null)
            {
                return NotFound($"Appointment with ID {id} not found.");
            }
            _appointmentservice.DeleteAppointment(id);
            return NoContent();
        }
        }
}
