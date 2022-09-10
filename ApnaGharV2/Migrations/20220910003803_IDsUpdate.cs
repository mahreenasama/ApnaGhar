using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApnaGharV2.Migrations
{
    public partial class IDsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PropertyID",
                table: "Properties",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EnquiryID",
                table: "Enquiries",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AmenitiesId",
                table: "Amenities",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AgencyID",
                table: "Agencies",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Properties",
                newName: "PropertyID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Enquiries",
                newName: "EnquiryID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Amenities",
                newName: "AmenitiesId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Agencies",
                newName: "AgencyID");
        }
    }
}
