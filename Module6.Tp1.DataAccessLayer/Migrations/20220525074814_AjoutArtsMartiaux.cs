using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Module6.Tp1.DataAccessLayer.Migrations
{
    public partial class AjoutArtsMartiaux : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Samourais_Armes_ArmeId",
                table: "Samourais");

            migrationBuilder.DropIndex(
                name: "IX_Samourais_ArmeId",
                table: "Samourais");

            migrationBuilder.AddColumn<int>(
                name: "SamouraiId",
                table: "Armes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ArtMartiaux",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtMartiaux", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArtMartialSamourai",
                columns: table => new
                {
                    ArtsMartiauxId = table.Column<int>(type: "int", nullable: false),
                    SamouraisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtMartialSamourai", x => new { x.ArtsMartiauxId, x.SamouraisId });
                    table.ForeignKey(
                        name: "FK_ArtMartialSamourai_ArtMartiaux_ArtsMartiauxId",
                        column: x => x.ArtsMartiauxId,
                        principalTable: "ArtMartiaux",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtMartialSamourai_Samourais_SamouraisId",
                        column: x => x.SamouraisId,
                        principalTable: "Samourais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Armes_SamouraiId",
                table: "Armes",
                column: "SamouraiId",
                unique: true,
                filter: "[SamouraiId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ArtMartialSamourai_SamouraisId",
                table: "ArtMartialSamourai",
                column: "SamouraisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Armes_Samourais_SamouraiId",
                table: "Armes",
                column: "SamouraiId",
                principalTable: "Samourais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Armes_Samourais_SamouraiId",
                table: "Armes");

            migrationBuilder.DropTable(
                name: "ArtMartialSamourai");

            migrationBuilder.DropTable(
                name: "ArtMartiaux");

            migrationBuilder.DropIndex(
                name: "IX_Armes_SamouraiId",
                table: "Armes");

            migrationBuilder.DropColumn(
                name: "SamouraiId",
                table: "Armes");

            migrationBuilder.CreateIndex(
                name: "IX_Samourais_ArmeId",
                table: "Samourais",
                column: "ArmeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Samourais_Armes_ArmeId",
                table: "Samourais",
                column: "ArmeId",
                principalTable: "Armes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
