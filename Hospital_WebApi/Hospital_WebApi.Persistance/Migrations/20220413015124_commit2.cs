using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital_WebApi.Persistance.Migrations
{
    public partial class commit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestsGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestsGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubTests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    TestsGroupId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubTests_TestsGroups_TestsGroupId",
                        column: x => x.TestsGroupId,
                        principalTable: "TestsGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubTests_TestsGroupId",
                table: "SubTests",
                column: "TestsGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubTests");

            migrationBuilder.DropTable(
                name: "TestsGroups");
        }
    }
}
