using API_Test.Models.Entity;

namespace API_Test.Dtos
{
    public class WarehouseCreatDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? CompanyId { get; set; }
        public int? RegionId { get; set; }
    }
}
