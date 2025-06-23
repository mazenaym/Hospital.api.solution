using Hospital.BLL.Repo.IRepo;
using Hospital.DAL.Database;
using Hospital.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL.Repo
{
    public class RoomRepo : IRoomRepo
    {
        private readonly ApplicationDbContext _context;
        public RoomRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddRoom(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
        }
        public IEnumerable<Room> GetAllRooms()
        {
            return _context.Rooms.ToList();
        }
        public Room GetRoomById(int id)
        {
            return _context.Rooms.FirstOrDefault(r => r.roomId == id);
        }
        public void UpdateRoom(Room room)
        {
            var existingRoom = _context.Rooms.FirstOrDefault(r => r.roomId == room.roomId);
            if (existingRoom != null)
            {
                existingRoom.roomType = room.roomType;
                existingRoom.roomStatus = room.roomStatus;
                existingRoom.roomPrice = room.roomPrice;
                existingRoom.roomNum = room.roomNum;
                existingRoom.roomFloor = room.roomFloor;
                _context.SaveChanges();
            }
        }
        public void DeleteRoom(int id)
        {
            var room = _context.Rooms.FirstOrDefault(r => r.roomId == id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                _context.SaveChanges();
            }
        }
        public IEnumerable<Room> GetRoomsByStatus(bool status)
        {
            return _context.Rooms.Where(r => r.roomStatus == status).ToList();
        }
    }
}
