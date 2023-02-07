using Microsoft.EntityFrameworkCore;
using API_Test.Models.Entity;
using Microsoft.VisualBasic;
using API_Test.Dtos;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging.Abstractions;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace API_Test.Data
{
    public class Command : ICommand
    {
        private readonly ApplicationDbContext _context;
        public Command(ApplicationDbContext context, IMapper mapper) 
        { 
            _context = context; 
        }
        public void CreateCommand(Warehouse warehouse)
        {
            _context.Entry(warehouse).State= EntityState.Added;
            _context.SaveChanges();
        }
        public void CreateCommandRoom(int id, WarehouseRoom room)
        {
            var searchItem = _context.Warehouses.SingleOrDefault(x => x.Id == id);

            var addItemRoom = searchItem != null ? _context.WarehouseRooms
                .Add(new WarehouseRoom()
                {
                    Name = room.Name,
                    Square = room.Square,
                    WarehouseId = searchItem.Id
                }) : throw new ArgumentException(nameof(searchItem), "Ошибка при вставке данных");

            _context.SaveChanges();       
        }
        public async Task<List<Warehouse>> GetAllCommand()
        {
            var list_warehouse = await _context.Warehouses.Include(w =>w.WarehouseRooms).ToListAsync();


            List<Warehouse> warehouses = new List<Warehouse>();
            foreach (var item in list_warehouse)
            {
                Warehouse newWarehouse = new Warehouse()
                {
                    Id = item.Id,
                    Name = item.Name,
                    CompanyId = item.CompanyId,
                    RegionId = item.RegionId,
                    WarehouseRooms = item.WarehouseRooms
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
