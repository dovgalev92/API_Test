using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace API_Test.Models.Entity
{
    public class Warehouse
    {
        public int Id { get; set; }
        [DisplayName("Название склада")]
        public string? Name { get; set; }
        [DisplayName("Собственник склада")]
        public int? CompanyId { get; set; }
        [DisplayName("Место расположения")]
        public int? RegionId { get; set; }
        
        public Company? Company { get; set; }
        
        public Region? Region { get; set; }

        public List<WarehouseRoom>? WarehouseRooms { get; set; }
    }
}
