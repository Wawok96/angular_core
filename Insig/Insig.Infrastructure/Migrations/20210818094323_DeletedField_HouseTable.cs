using Microsoft.EntityFrameworkCore.Migrations;

namespace Insig.Infrastructure.Migrations
{
    public partial class DeletedField_HouseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Removed",
                table: "House",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Removed",
                table: "House");
        }
    }
}
