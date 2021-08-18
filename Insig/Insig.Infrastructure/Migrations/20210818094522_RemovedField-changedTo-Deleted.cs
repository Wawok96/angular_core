using Microsoft.EntityFrameworkCore.Migrations;

namespace Insig.Infrastructure.Migrations
{
    public partial class RemovedFieldchangedToDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Removed",
                table: "House",
                newName: "Deleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "House",
                newName: "Removed");
        }
    }
}
