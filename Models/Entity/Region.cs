using System.ComponentModel.DataAnnotations.Schema;

namespace API_Test.Models.Entity
{
    public class Region
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? WarehouseId { get; set; }
       
        public List<Warehouse>? Warehouse { get; set; }
    }
}
