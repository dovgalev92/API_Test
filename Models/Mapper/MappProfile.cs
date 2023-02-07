using API_Test.Dtos;
using API_Test.Models.Entity;
using AutoMapper;
namespace API_Test.Models.Mapper
{
    public class MappProfile : Profile
    {
        public MappProfile()
        {
            CreateMap<Warehouse, WarehouseReadDto>();
            CreateMap<Warehouse, WarehouseReadDto_Id>();
            CreateMap<WarehouseUpdateDto, Warehouse>();
            CreateMap<WarehouseCreatDto, Warehouse>();
            CreateMap<CreateRoomDto, WarehouseRoom>();

        }
    }
}
