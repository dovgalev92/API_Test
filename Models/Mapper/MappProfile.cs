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
            CreateMap<WarehouseRoom, WarewhouseCreateDto>()
                .ForMember(region => region.NameRegion, x => x.MapFrom(cls => cls.Warehouse.Region.Name))
                .ForMember(company => company.CompanyId, x => x.MapFrom(entity => entity.Warehouse.Company.Id));
                
        }
    }
}
