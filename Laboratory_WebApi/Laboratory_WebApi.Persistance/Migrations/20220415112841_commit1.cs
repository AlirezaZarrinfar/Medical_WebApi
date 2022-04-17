using Microsoft.EntityFrameworkCore.Migrations;

namespace Laboratory_WebApi.Persistance.Migrations
{
    public partial class commit1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "testsGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceptionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_testsGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "subTests",
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
                    table.PrimaryKey("PK_subTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_subTests_testsGroups_TestsGroupId",
                        column: x => x.TestsGroupId,
                        principalTable: "testsGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_subTests_TestsGroupId",
                table: "subTests",
                column: "TestsGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subTests");

            migrationBuilder.DropTable(
                name: "testsGroups");
        }
    }
}
