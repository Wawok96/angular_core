using Microsoft.EntityFrameworkCore.Migrations;

namespace Insig.Infrastructure.Migrations
{
    public partial class palindrome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Palindrome",
                table: "Sample",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Palindrome",
                table: "Sample");
        }
    }
}
