using API_Test.Models.Entity;

namespace API_Test.Data
{
    public interface ICommand
    {
        Task CreateCommand(Warehouse warehouse);
        Task <List<Warehouse>> GetAllCommand();
        Task <Warehouse> GetCommandById(int? id);
        Task UpdateCommand(Warehouse warehouse);
        void DeleteCommand(int? id);
        
        
    }
}
