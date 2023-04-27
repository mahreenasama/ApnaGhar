using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApnaGharV2.Migrations.AccountsDb
{
    public partial class DbContainer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amenities");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AirConditioning = table.Column<bool>(type: "bit", nullable: false),
                    Bathrooms = table.Column<int>(type: "int", nullable: true),
                    Bedrooms = table.Column<int>(type: "int", nullable: true),
                    BuiltYear = table.Column<int>(type: "int", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DiningRoom = table.Column<bool>(type: "bit", nullable: false),
                    DrawingRoom = table.Column<bool>(type: "bit", nullable: false),
                    ElectricityBackup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacilitiesForDisabled = table.Column<bool>(type: "bit", nullable: false),
                    Flooring = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Floors = table.Column<int>(type: "int", nullable: true),
                    Furnished = table.Column<bool>(type: "bit", nullable: false),
                    InternetAccess = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Kitchens = table.Column<int>(type: "int", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModifiedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaundryRoom = table.Column<bool>(type: "bit", nullable: false),
                    LawnOrGarden = table.Column<bool>(type: "bit", nullable: false),
                    LoungeOrSittingRoom = table.Column<bool>(type: "bit", nullable: false),
                    MaintenanceStaff = table.Column<bool>(type: "bit", nullable: false),
                    NearbyHospitals = table.Column<int>(type: "int", nullable: true),
                    NearbyMosques = table.Column<int>(type: "int", nullable: true),
                    NearbyPublicTransport = table.Column<int>(type: "int", nullable: true),
                    NearbyRestaurants = table.Column<int>(type: "int", nullable: true),
                    NearbySchools = table.Column<int>(type: "int", nullable: true),
                    NearbyShoppingMalls = table.Column<int>(type: "int", nullable: true),
                    OtherBCFacilities = table.Column<bool>(type: "bit", nullable: false),
                    OtherFacilities = table.Column<bool>(type: "bit", nullable: false),
                    OtherHRFacilities = table.Column<bool>(type: "bit", nullable: false),
                    OtherMainFeatures = table.Column<bool>(type: "bit", nullable: false),
                    OtherNBFacilities = table.Column<bool>(type: "bit", nullable: false),
                    OtherRooms = table.Column<bool>(type: "bit", nullable: false),
                    ParkingSpaces = table.Column<int>(type: "int", nullable: true),
                    PrayerRoom = table.Column<bool>(type: "bit", nullable: false),
                    SatellitetOrCable = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStaff = table.Column<bool>(type: "bit", nullable: false),
                    ServantQuarters = table.Column<int>(type: "int", nullable: true),
                    StoreRooms = table.Column<int>(type: "int", nullable: true),
                    StudyRoom = table.Column<bool>(type: "bit", nullable: false),
                    SwimmingPool = table.Column<bool>(type: "bit", nullable: false),
                    View = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Amenities_Properties_Id",
                        column: x => x.Id,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
