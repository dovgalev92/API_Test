namespace API_Test.Dtos
{
    public class CreateRoomDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Square { get; set; }
        public int WarehouseId { get; set; }
    }
}
