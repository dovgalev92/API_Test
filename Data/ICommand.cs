using API_Test.Dtos;
using API_Test.Models.Entity;

namespace API_Test.Data
{
    public interface ICommand
    {
        void CreateCommand(Warehouse warehouse);
        void CreateCommandRoom(int id, WarehouseRoom room);
        Task <List<Warehouse>> GetAllCommand();
        Warehouse GetCommandById(int? id);
        Task UpdateCommand(Warehouse update);
        void DeleteCommand(int? id);
        
    }
}
