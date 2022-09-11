using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApnaGharV2.Migrations.AccountsDb
{
    public partial class PropertyEnquiryRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                table: "Enquiries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enquiries_PropertyId",
                table: "Enquiries",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enquiries_Properties_PropertyId",
                table: "Enquiries",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enquiries_Properties_PropertyId",
                table: "Enquiries");

            migrationBuilder.DropIndex(
                name: "IX_Enquiries_PropertyId",
                table: "Enquiries");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "Enquiries");
        }
    }
}
