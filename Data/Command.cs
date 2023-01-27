using Microsoft.EntityFrameworkCore;
using API_Test.Models.Entity;
using Microsoft.VisualBasic;
using API_Test.Dtos;
using System.Runtime.CompilerServices;

namespace API_Test.Data
{
    public class Command : ICommand
    {
        private readonly ApplicationDbContext _context;
        public Command(ApplicationDbContext context) { _context = context; }
        public async Task CreateCommand(Warehouse create)
        {
            if(create == null)
            {
                throw new ArgumentNullException(nameof(create));
            }

            await _context.Warehouses.AddAsync(create);
            await _context.SaveChangesAsync();
            
        }

        public async Task<List<Warehouse>> GetAllCommand()
        {
            var list_warehouse = _context.Warehouses.Include(r => r.Region).Include(c => c.Company);

            var room_warehouses = await _context.WarehouseRooms.ToListAsync();

            List<Warehouse> warehouses = new List<Warehouse>();
            foreach (var item in list_warehouse)
            {
                var roomCount = room_warehouses.Where(x => x.WarehouseId == item.Id).Count();

                Warehouse newWarehouse = new Warehouse()
                {
                    Id = item.Id,
                    Name = item.Name,
                    CompanyId = item.CompanyId,
                    RegionId = item.RegionId,
                    roomCount = roomCount
                };
                warehouses.Add(newWarehouse);
            }
            return warehouses;
        }
        public async Task<Warehouse> GetCommandById(int? id)
        {
            if(id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var command = await _context.Warehouses.Where(c => c.Id == id)
                .Select(warehouse => new Warehouse()
                {
                    Name = warehouse.Name,
                    CompanyId = warehouse.CompanyId,
                    RegionId = warehouse.RegionId,
                    name_compartment = string.Join(",", warehouse.WarehouseRooms
                    .OrderBy(n => n.WarehouseId == warehouse.Id)
                    .Select(name => name.Name))
                }).FirstAsync();
            return command;

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
