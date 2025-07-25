using Hospital.BLL.Service.IService;
using Hospital.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppuserController : ControllerBase
    {
        private readonly IAppuserService _appuserService;
        public AppuserController(IAppuserService appuserService)
        {
            _appuserService = appuserService;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _appuserService.GetAllAsync();
            return Ok(users);
        }
        [HttpGet("type")]
        public async Task<IActionResult> GetByType(string userType)
        {
            var users = await _appuserService.GetAllByTypeAsync(userType);
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _appuserService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] Appuser user)
        {
            if (user == null)
            {
                return BadRequest("User data is null.");
            }
            await _appuserService.AddAsync(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] Appuser user)
        {
            if (user == null)
            {
                return BadRequest("User data is null.");
            }
            await _appuserService.UpdateAsync(user);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _appuserService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            await _appuserService.DeleteAsync(id);
            return NoContent();
        }

    }
}
