using API_Test.Models.Entity;

namespace API_Test.Data
{
    public interface ICommand
    {
        Task CreateCommand(Warehouse create);
        Task <List<Warehouse>> GetAllCommand();
        Warehouse GetCommandById(int? id);
        Task UpdateCommand(Warehouse update);
        Task DeleteCommand(int? id);
        
    }
}
