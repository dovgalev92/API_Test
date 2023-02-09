using API_Test.Data;
using API_Test.Dtos;
using API_Test.Models.Entity;
using AutoMapper;
namespace API_Test.Models.Mapper
{
    public class MappProfile : Profile
    {
        public MappProfile()
        {
            CreateMap<Warehouse, WarehouseReadDto>()
                        .ForMember(p => p.RoomCount, x => x.MapFrom(x => x.WarehouseRooms.Where(c => c.WarehouseId == c.Warehouse.Id).Count()));
            CreateMap<WarehouseUpdateDto, Warehouse>();
            CreateMap<Warehouse, WarehouseReadDto_Id>()
                .ForMember(p => p.name_compartment, m => m.MapFrom(x => string.Join(",", x.WarehouseRooms.OrderBy(s => s.WarehouseId == x.Id)
                .Select(name => name.Name))));
            CreateMap<WarehouseCreatDto, Warehouse>();
            CreateMap<CreateRoomDto, WarehouseRoom>();
        }
        
    }

      
}
