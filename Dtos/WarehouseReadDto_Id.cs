using API_Test.Models.Entity;
using Microsoft.Net.Http.Headers;

namespace API_Test.Dtos
{
    public class WarehouseReadDto_Id
    {   
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? CompanyId { get; set; }
        public int? RegionId { get; set; }
        public string? name_compartment { get; set; }

    }
}
