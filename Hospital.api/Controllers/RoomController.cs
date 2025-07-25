using Hospital.BLL.DTO;
using Hospital.BLL.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }
       
        [HttpGet]
        public IActionResult GetAllRooms()
        {
            var rooms = _roomService.GetAllRooms();
            if (rooms == null || !rooms.Any())
            {
                return NotFound("No rooms found.");
            }
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public IActionResult GetRoomById (int id)
        {
            var room = _roomService.GetRoomById(id);
            if (room == null)
            {
                return NotFound($"Room with ID {id} not found.");
            }
            return Ok(room);
        }
        [HttpPost]
        public IActionResult AddRoom([FromBody] Roomdto dto)
        {
            if (dto == null)
            {
                return BadRequest("Room data is null.");
            }
            _roomService.AddRoom(dto);
            return CreatedAtAction(nameof(GetRoomById), new { id = dto.roomId }, dto);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateRoom(int id, [FromBody] Roomdto dto)
        {
            if (dto == null || dto.roomId != id)
            {
                return BadRequest("Invalid room data.");
            }
            var existingRoom = _roomService.GetRoomById(id);
            if (existingRoom == null)
            {
                return NotFound($"Room with ID {id} not found.");
            }
            _roomService.UpdateRoom(dto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Room ID");
            }
            var room = _roomService.GetRoomById(id);
            if (room == null)
            {
                return NotFound("Room not found");
            }
            _roomService.DeleteRoom(id);
            return NoContent();
        }

    }
}
