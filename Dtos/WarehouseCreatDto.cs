using API_Test.Models.Entity;

namespace API_Test.Dtos
{
    public class WarehouseCreatDto
    {
        public Warehouse? Warehouse { get; set; }
        public List<WarehouseRoom>? WarehouseRoom { get; set; }
    }
}
