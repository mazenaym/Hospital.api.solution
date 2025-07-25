using AutoMapper;
using Hospital.BLL.DTO;
using Hospital.BLL.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hospital.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RayController : ControllerBase
    {
       private readonly IRayService _rayService;
        private readonly IMapper _mapper;
        public RayController(IRayService rayService , IMapper mapper)
        {
            _rayService = rayService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllRays()
        {
            var rays = _rayService.GetAllRays();
            if (rays == null || !rays.Any())
            {
                return NotFound("No rays found.");
            }
            var result = _mapper.Map<RayViewModel>(rays);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetRayById(int id)
        {
            var ray = _rayService.GetRayById(id);
            if (ray == null)
            {
                return NotFound($"Ray with ID {id} not found.");
            }
            //var result = __rayService.GetRayById(id);
            return Ok(ray);
        }
        [HttpPost("add-ray")]
        public async Task<IActionResult> AddRay([FromForm] Raydto dto)
        {
            if (dto == null || dto.RayImage == null || dto.RayImage.Length == 0)
            {
                return BadRequest("Ray data or image is missing.");
            }

            await _rayService.AddRay(dto);

            return CreatedAtAction(nameof(GetRayById), new { id = dto.RayId }, dto);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateRay(int id, [FromBody] Raydto dto)
        {
            if (dto == null || dto.RayId != id)
            {
                return BadRequest("Invalid ray data.");
            }
            var existingRay = _rayService.GetRayById(id);
            if (existingRay == null)
            {
                return NotFound($"Ray with ID {id} not found.");
            }
            _rayService.UpdateRay(dto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteRay(int id)
        {
            var existingRay = _rayService.GetRayById(id);
            if (existingRay == null)
            {
                return NotFound($"Ray with ID {id} not found.");
            }
            _rayService.DeleteRay(id);
            return NoContent();
        }
    }
}
