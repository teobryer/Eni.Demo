using Microsoft.EntityFrameworkCore.Migrations;

namespace Module6.Tp1.DataAccessLayer.Migrations
{
    public partial class ModificationsRelationsArmeSamourai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArmeId",
                table: "Samourais");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArmeId",
                table: "Samourais",
                type: "int",
                nullable: true);
        }
    }
}
