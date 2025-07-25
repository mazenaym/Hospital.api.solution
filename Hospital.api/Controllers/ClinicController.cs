using Hospital.BLL.DTO;
using Hospital.BLL.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        private readonly IClinicService _clinicService;
        public ClinicController(IClinicService clinicService)
        {
            _clinicService = clinicService;
        }
        [HttpGet]
        public IActionResult GetAllClinics()
        {
            var clinics = _clinicService.GetAllClinc();
            if (clinics == null || !clinics.Any())
            {
                return NotFound("No clinics found.");
            }
            return Ok(clinics);
        }
        [HttpGet("{id}")]
        public IActionResult GetClinicById(int id)
        {
            var clinic = _clinicService.GetClinicById(id);
            if (clinic == null)
            {
                return NotFound($"Clinic with ID {id} not found.");
            }
            return Ok(clinic);
        }
        [HttpPost]
        public IActionResult AddClinic([FromBody] Clinicdto dto)
        {
            if (dto == null)
            {
                return BadRequest("Clinic data is null.");
            }
            _clinicService.AddClinic(dto);
            return CreatedAtAction(nameof(GetClinicById), new { id = dto.clinicId }, dto);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateClinic(int id, [FromBody] Clinicdto dto)
        {
            if (dto == null || dto.clinicId != id)
            {
                return BadRequest("Invalid clinic data.");
            }
            var existingClinic = _clinicService.GetClinicById(id);
            if (existingClinic == null)
            {
                return NotFound($"Clinic with ID {id} not found.");
            }
            _clinicService.UpdateClinic(dto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteClinic(int id)
        {
            var existingClinic = _clinicService.GetClinicById(id);
            if (existingClinic == null)
            {
                return NotFound($"Clinic with ID {id} not found.");
            }
            _clinicService.DeleteClinic(id);
            return NoContent();
        }
        [HttpPost("available-days")]
        public IActionResult AddClinicAvailableDays([FromBody] IEnumerable<ClinicAvailableDaydto> days)
        {
            if (days == null || !days.Any())
                return BadRequest("Days list is required.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            foreach (var day in days)
            {
                if (day.StartTime >= day.EndTime)
                    return BadRequest($"Start time must be before end time for {day.DayOfWeek}.");

                if (day.ClinicId <= 0)
                    return BadRequest("Invalid ClinicId.");
            }

            _clinicService.AddClinicAvailableDays(days);
            return Ok("Available days added successfully.");
        }
        [HttpGet("{clinicId}/available-days")]
        public IActionResult GetClinicAvailableDaysByClinicId(int clinicId)
        {
            var result = _clinicService.GetClinicAvailableDaysByClinicId(clinicId);
            return Ok(result);
        }
        [HttpDelete("{clinicId}/available-days")]
        public IActionResult DeleteClinicAvailableDays(int clinicId)
        {
            try
            {
                _clinicService.DeleteClinicAvailableDays(clinicId);
                return Ok("Available days deleted successfully.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
