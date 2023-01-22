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
            var list_warehouse = from items in _context.Warehouses.Include(r =>r.Region) select items;

            var room_warehouses = await _context.WarehouseRooms.ToListAsync();

            List<Warehouse> warehouses = new List<Warehouse>();
            foreach (var item in list_warehouse)
            {
                Warehouse newWarehouse = new Warehouse();
                newWarehouse.Id = item.Id;
                newWarehouse.Name = item.Name;
                newWarehouse.RegionId= item.RegionId;

                var roomCount = room_warehouses.Where(x => x.WarehouseId == item.Id);

                newWarehouse.roomCount = roomCount.Count();

                warehouses.Add(newWarehouse);
            }

            return warehouses;
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
