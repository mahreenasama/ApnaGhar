using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApnaGharV2.Migrations
{
    public partial class ForeignKeyTry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PropertyId",
                table: "Properties",
                newName: "PropertyID");

            migrationBuilder.RenameColumn(
                name: "PropertyId",
                table: "Amenities",
                newName: "PropertyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PropertyID",
                table: "Properties",
                newName: "PropertyId");

            migrationBuilder.RenameColumn(
                name: "PropertyID",
                table: "Amenities",
                newName: "PropertyId");
        }
    }
}
