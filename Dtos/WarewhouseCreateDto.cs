namespace API_Test.Dtos
{
    public class WarewhouseCreateDto
    {
        public int Id { get; set; }
        /// <summary>
        /// название склада
        /// </summary>
        public string NameWarehouse { get; set; } = string.Empty;
        /// <summary>
        /// id компании
        /// </summary>
        public int? CompanyId { get; set; }
        /// <summary>
        /// название региона
        /// </summary>
        public string NameRegion { get; set; } = string.Empty;
        /// <summary>
        /// название помещения
        /// </summary>
        public string? Name { get; set;}
        /// <summary>
        /// размер комнаты
        /// </summary>
        public double Square { get; set; }

    }
}
