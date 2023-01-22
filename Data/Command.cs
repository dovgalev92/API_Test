using Microsoft.EntityFrameworkCore;
using API_Test.Models.Entity;

namespace API_Test.Data
{
    public class Command : ICommand
    {
        private readonly ApplicationDbContext _context;
        public Command(ApplicationDbContext context) { _context = context; }
        public async Task CreateCommand(Warehouse warehouse)
        {
            if(warehouse == null)
            {
                throw new ArgumentNullException(nameof(warehouse));
            }
            await _context.AddAsync(warehouse);
            await _context.SaveChangesAsync();
            
           
        }

        public async Task<List<Warehouse>> GetAllCommand()
        {
            var query = from item in _context.Warehouses select item;

            var queryCountItems = await _context.WarehouseRooms.AsNoTracking().ToListAsync();

            List<Warehouse> newWarehouses = new();
            foreach(var item in query)
            {
                Warehouse listItem_warehouse= new Warehouse();
                listItem_warehouse.Id = item.Id;
                listItem_warehouse.Name = item.Name;
                listItem_warehouse.RegionId= item.RegionId;

                var resultRoomCount = queryCountItems.Where(x => x.WarehouseId.Equals(item.Id));
                listItem_warehouse.roomCount = resultRoomCount.Count();

                newWarehouses.Add(listItem_warehouse);
            }

            return newWarehouses;
        }

        public async Task GetCommandById(int? id)
        {
            if(id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            await _context.Warehouses.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateCommand(Warehouse warehouse)
        {
            if(warehouse == null)
            {
                throw new ArgumentNullException(nameof(warehouse));
            }
            _context.Entry(warehouse).State= EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public void DeleteCommand(int? id)
        {
            var deleteItem = _context.Warehouses.Find(id);
            if(deleteItem == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            _context.Warehouses.Remove(deleteItem);
            _context.SaveChanges();
        }
    }
}
