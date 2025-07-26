using Hospital.BLL.DTO;
using Hospital.BLL.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private readonly ISalaryService _salaryService;
        public SalaryController(ISalaryService salaryService)
        {
            _salaryService = salaryService;
        }
        [Authorize(Roles = "Admin,HR")]
        [HttpGet]
        public IActionResult GetAllSalaries()
        {
            var salaries = _salaryService.GetAllSalaries();
            if (salaries == null || !salaries.Any())
            {
                return NotFound("No salaries found.");
            }
            return Ok(salaries);
        }
        [Authorize(Roles = "Admin,HR,Doctor,Nurse")]
        [HttpGet("{username}")]
        public async Task<IActionResult> GetSalaryByUserNameAsync(string username)
        {
            var salaries = await _salaryService.GetSalaryByUserNameAsync(username);
            if (salaries == null || !salaries.Any())
            {
                return NotFound($"No salaries found for user {username}.");
            }
            return Ok(salaries);
        }
        [Authorize(Roles = "HR")]
        [HttpPost]
        public async Task<IActionResult> AddSalaryAsync([FromBody] Salarydto dto)
        {
            if (dto == null)
            {
                return BadRequest("Salary data is null.");
            }
            if (User.IsInRole("HR"))
            {
                var hrId = User.FindFirst("userId")?.Value;
                if (string.IsNullOrEmpty(hrId))
                    return Unauthorized("Invalid user token.");

                dto.HRId = hrId;
            }
            await _salaryService.AddSalaryAsync(dto);
            return CreatedAtAction(nameof(GetAllSalaries), new { id = dto.salaryId }, dto);
        }
        [Authorize(Roles = "HR")]
        [HttpPut("{username}")]
        public IActionResult UpdateSalary(string username, [FromBody] Salarydto dto)
        {
            if (dto == null || dto.AppUserId.ToString() != username)
            {
                return BadRequest("Invalid salary data.");
            }
            var existingSalaries = _salaryService.GetAllSalaries().FirstOrDefault(s => s.AppUserId.ToString() == username);
            if (existingSalaries == null)
            {
                return NotFound($"No salary found for user {username}.");
            }
            _salaryService.UpdateSalary(dto);
            return NoContent();
        }
        [Authorize(Roles = "Admin,HR")]
        [HttpDelete("{username}")]
        public IActionResult DeleteSalary(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return BadRequest("Invalid username.");
            }
            var salaries = _salaryService.GetAllSalaries().Where(s => s.AppUserId.ToString() == username);
            if (!salaries.Any())
            {
                return NotFound($"No salary found for user {username}.");
            }
            foreach (var salary in salaries)
            {
                _salaryService.DeleteSalary(salary.salaryId);
            }
            return NoContent();

        }
    }
}
