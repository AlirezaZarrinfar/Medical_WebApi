using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital_WebApi.Persistance.Migrations
{
    public partial class commit8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDiscounted",
                table: "Receptions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "Receptions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalPriceDiscounted",
                table: "Receptions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDiscounted",
                table: "Receptions");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Receptions");

            migrationBuilder.DropColumn(
                name: "TotalPriceDiscounted",
                table: "Receptions");
        }
    }
}
