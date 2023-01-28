using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Test.Migrations
{
    public partial class DelRegionId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "Regions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "Regions",
                type: "int",
                nullable: true);
        }
    }
}
