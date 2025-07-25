using Hospital.BLL.DTO;

namespace Hospital.BLL.Service.IService
{
    public interface IRoomService
    {
        void AddRoom(Roomdto dto);
        void DeleteRoom(int id);
        IEnumerable<Roomdto> GetAllRooms();
        Roomdto GetRoomById(int id);
        void UpdateRoom(Roomdto dto);
    }
}