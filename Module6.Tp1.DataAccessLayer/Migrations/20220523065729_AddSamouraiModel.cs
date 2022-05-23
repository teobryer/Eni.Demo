using Microsoft.EntityFrameworkCore.Migrations;

namespace Module6.Tp1.DataAccessLayer.Migrations
{
    public partial class AddSamouraiModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Samourais",
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
                    table.PrimaryKey("PK_Samourais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Samourais_Armes_ArmeId",
                        column: x => x.ArmeId,
                        principalTable: "Armes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Samourais_ArmeId",
                table: "Samourais",
                column: "ArmeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Samourais");
        }
    }
}
