using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital_WebApi.Persistance.Migrations
{
    public partial class commit7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReceotionsCount",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceotionsCount",
                table: "Patients");
        }
    }
}
