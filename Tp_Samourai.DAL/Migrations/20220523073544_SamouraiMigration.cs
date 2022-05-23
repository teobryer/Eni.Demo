using Microsoft.EntityFrameworkCore.Migrations;

namespace Tp_Samourai.DAL.Migrations
{
    public partial class SamouraiMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Samourai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Force = table.Column<int>(type: "int", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArmeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samourai", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Samourai_Armes_ArmeId",
                        column: x => x.ArmeId,
                        principalTable: "Armes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Samourai_ArmeId",
                table: "Samourai",
                column: "ArmeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Samourai");
        }
    }
}
