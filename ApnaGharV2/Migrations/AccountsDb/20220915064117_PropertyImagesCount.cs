using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApnaGharV2.Migrations.AccountsDb
{
    public partial class PropertyImagesCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagesPath",
                table: "Properties");

            migrationBuilder.AddColumn<int>(
                name: "ImagesCount",
                table: "Properties",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagesCount",
                table: "Properties");

            migrationBuilder.AddColumn<string>(
                name: "ImagesPath",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
