using API_Test.Dtos;
using API_Test.Models.Entity;

namespace API_Test.Data
{
    public interface ICommand
    {
        void CreateCommand(WarehouseCreatDto dto);
        Task <List<Warehouse>> GetAllCommand();
        Warehouse GetCommandById(int? id);
        Task UpdateCommand(Warehouse update);
        void DeleteCommand(int? id);
        
    }
}
