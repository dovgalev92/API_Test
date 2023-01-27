namespace API_Test.Dtos
{
    public class WarehouseUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// id компании
        /// </summary>
        public int? CompanyId { get; set; }
        /// <summary>
        /// название региона
        /// </summary>
        public int? RegionId { get; set; }
       
    }
}
