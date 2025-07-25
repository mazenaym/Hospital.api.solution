using AutoMapper;
using Hospital.BLL.DTO;
using Hospital.BLL.Repo;
using Hospital.BLL.Repo.IRepo;
using Hospital.BLL.Service.IService;
using Hospital.BLL.service_response;
using Hospital.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL.Service
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepo _roomRepo;
        private readonly IMapper _mapper;
        public RoomService(IRoomRepo roomRepo, IMapper mapper)
        {
            _roomRepo = roomRepo;
            _mapper = mapper;
        }
        public void AddRoom(Roomdto dto)
        {
            var room = _mapper.Map<Room>(dto);
            _roomRepo.AddRoom(room);
        }
        public IEnumerable<Roomdto> GetAllRooms()
        {
            var rooms = _roomRepo.GetAllRooms();
            return _mapper.Map<IEnumerable<Roomdto>>(rooms);
        }
        public Roomdto GetRoomById(int id)
        {
            var room = _roomRepo.GetRoomById(id);
            if (room == null)
            {
                return null;
            }
            return _mapper.Map<Roomdto>(room);
        }


        public void UpdateRoom(Roomdto dto)
        {
            var room = _mapper.Map<Room>(dto);
            _roomRepo.UpdateRoom(room);

        }
        public void DeleteRoom(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid Room ID");
            }
            var room = _roomRepo.GetAllRooms().FirstOrDefault(s => s.roomId == id);
            if (room == null)
            {
                throw new KeyNotFoundException("Room not found");
            }
            _roomRepo.DeleteRoom(id);
        }
    }
}
