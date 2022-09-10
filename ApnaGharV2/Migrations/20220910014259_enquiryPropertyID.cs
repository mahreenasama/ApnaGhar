using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApnaGharV2.Migrations
{
    public partial class enquiryPropertyID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Enquiries",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                table: "Enquiries",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "Enquiries");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Enquiries",
                newName: "UserID");
        }
    }
}
