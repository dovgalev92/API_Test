﻿using API_Test.Models.Entity;

namespace API_Test.Dtos
{
    public class WarehouseReadDto
    {
        public int Id { get; set; } 
        public string? Name { get; set; }
        public int? RegionId { get; set; }
        public int roomCount { get; set; }

    }
}
