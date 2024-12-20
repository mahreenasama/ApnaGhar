﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApnaGharV2.Migrations.AccountsDb
{
    public partial class ManytoMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Users_UserId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_UserId",
                table: "Properties");

            migrationBuilder.CreateTable(
                name: "PropertyUser",
                columns: table => new
                {
                    FavouriteForUsersId = table.Column<int>(type: "int", nullable: false),
                    UserFavouritePropertiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyUser", x => new { x.FavouriteForUsersId, x.UserFavouritePropertiesId });
                    table.ForeignKey(
                        name: "FK_PropertyUser_Properties_UserFavouritePropertiesId",
                        column: x => x.UserFavouritePropertiesId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyUser_Users_FavouriteForUsersId",
                        column: x => x.FavouriteForUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertyUser_UserFavouritePropertiesId",
                table: "PropertyUser",
                column: "UserFavouritePropertiesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyUser");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_UserId",
                table: "Properties",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Users_UserId",
                table: "Properties",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
