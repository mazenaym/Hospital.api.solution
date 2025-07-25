using Hospital.DAL.Entities;

namespace Hospital.BLL.Repo.IRepo
{
    public interface IRoomRepo
    {
        void AddRoom(Room room);
        void DeleteRoom(int id);
        IEnumerable<Room> GetAllRooms();
        Room GetRoomById(int id);
        IEnumerable<Room> GetRoomsByStatus(bool status);
        void UpdateRoom(Room room);
    }
}