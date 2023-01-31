using Microsoft.EntityFrameworkCore;
using API_Test.Models.Entity;
using Microsoft.VisualBasic;
using API_Test.Dtos;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging.Abstractions;

namespace API_Test.Data
{
    public class Command : ICommand
    {
        private readonly ApplicationDbContext _context;
        public Command(ApplicationDbContext context) { _context = context; }
        public void CreateCommand(WarehouseCreatDto dto)
        {
            var warehouseItem = new Warehouse()
            {
                Name = dto.Warehouse.Name,
                CompanyId = dto.Warehouse.CompanyId,
                RegionId = dto.Warehouse.RegionId
            };
            _context.Add(warehouseItem);
            _context.SaveChanges();

            var rooms = new WarehouseRoom()
            {
                Name = dto.WarehouseRoom.Name,
                Square = dto.WarehouseRoom.Square,
                WarehouseId = warehouseItem.Id,
            };

            if (rooms == null)
            {
                throw new ArgumentNullException(nameof(rooms), nameof(warehouseItem));
            }

            _context.Add(rooms);
            _context.SaveChanges();

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
        public Warehouse GetCommandById(int? id)
        {
            if(id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var command = _context.Warehouses.Where(c => c.Id == id)
                .Select(warehouse => new Warehouse()
                {
                    Id = warehouse.Id,
                    Name = warehouse.Name,
                    CompanyId = warehouse.CompanyId,
                    RegionId = warehouse.RegionId,
                    name_compartment = string.Join(",", warehouse.WarehouseRooms
                    .OrderBy(n => n.WarehouseId == warehouse.Id)
                    .Select(name => name.Name))
                }).FirstOrDefault();

            return command;

        }

        public  Task UpdateCommand(Warehouse warehouse)
        {
            if(warehouse == null)
            {
                throw new ArgumentNullException(nameof(warehouse));
            }

            _context.Entry(warehouse).State= EntityState.Modified;
            return _context.SaveChangesAsync();
        }

        public void DeleteCommand(int? id)
        {
            var deleteItem = _context.Warehouses.Find(id);
            if (deleteItem == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            _context.Warehouses.Remove(deleteItem);
            _context.SaveChanges();
        }
    }
}
