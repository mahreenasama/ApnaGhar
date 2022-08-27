using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApnaGharV2.Migrations
{
    public partial class AmenitiesTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Purpose",
                table: "Properties",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    AmenitiesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuiltYear = table.Column<int>(type: "int", nullable: true),
                    View = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParkingSpaces = table.Column<int>(type: "int", nullable: true),
                    AirConditioning = table.Column<bool>(type: "bit", nullable: true),
                    Flooring = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElectricityBackup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Floors = table.Column<int>(type: "int", nullable: true),
                    Furnished = table.Column<bool>(type: "bit", nullable: true),
                    OtherMainFeatures = table.Column<bool>(type: "bit", nullable: true),
                    InternetAccess = table.Column<bool>(type: "bit", nullable: true),
                    SatellitetOrCable = table.Column<bool>(type: "bit", nullable: true),
                    OtherBCFacilities = table.Column<bool>(type: "bit", nullable: true),
                    NearbySchools = table.Column<int>(type: "int", nullable: true),
                    NearbyHospitals = table.Column<int>(type: "int", nullable: true),
                    NearbyShoppingMalls = table.Column<int>(type: "int", nullable: true),
                    NearbyRestaurants = table.Column<int>(type: "int", nullable: true),
                    NearbyMosques = table.Column<int>(type: "int", nullable: true),
                    NearbyPublicTransport = table.Column<int>(type: "int", nullable: true),
                    OtherNBFacilities = table.Column<bool>(type: "bit", nullable: true),
                    Bedrooms = table.Column<int>(type: "int", nullable: true),
                    Bathrooms = table.Column<int>(type: "int", nullable: true),
                    ServantQuarters = table.Column<int>(type: "int", nullable: true),
                    DrawingRoom = table.Column<bool>(type: "bit", nullable: true),
                    DiningRoom = table.Column<bool>(type: "bit", nullable: true),
                    Kitchens = table.Column<int>(type: "int", nullable: true),
                    StudyRoom = table.Column<bool>(type: "bit", nullable: true),
                    PrayerRoom = table.Column<bool>(type: "bit", nullable: true),
                    StoreRooms = table.Column<int>(type: "int", nullable: true),
                    LoungeOrSittingRoom = table.Column<bool>(type: "bit", nullable: true),
                    LaundryRoom = table.Column<bool>(type: "bit", nullable: true),
                    OtherRooms = table.Column<bool>(type: "bit", nullable: true),
                    LawnOrGarden = table.Column<bool>(type: "bit", nullable: true),
                    SwimmingPool = table.Column<bool>(type: "bit", nullable: true),
                    OtherHRFacilities = table.Column<bool>(type: "bit", nullable: true),
                    MaintenanceStaff = table.Column<bool>(type: "bit", nullable: true),
                    SecurityStaff = table.Column<bool>(type: "bit", nullable: true),
                    FacilitiesForDisabled = table.Column<bool>(type: "bit", nullable: true),
                    OtherFacilities = table.Column<bool>(type: "bit", nullable: true),
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.AmenitiesId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amenities");

            migrationBuilder.AlterColumn<string>(
                name: "Purpose",
                table: "Properties",
                type: "varchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)");
        }
    }
}
