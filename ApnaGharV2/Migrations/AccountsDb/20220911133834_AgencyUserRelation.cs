using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApnaGharV2.Migrations.AccountsDb
{
    public partial class AgencyUserRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgencyID",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Agencies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Agencies_UserId",
                table: "Agencies",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Agencies_Users_UserId",
                table: "Agencies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agencies_Users_UserId",
                table: "Agencies");

            migrationBuilder.DropIndex(
                name: "IX_Agencies_UserId",
                table: "Agencies");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Agencies");

            migrationBuilder.AddColumn<int>(
                name: "AgencyID",
                table: "Users",
                type: "int",
                nullable: true);
        }
    }
}
