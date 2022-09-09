using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApnaGharV2.Models
{
    public class PropertyAmenities:AdditiveInformation
    {
        //primary, foreign key
        [Key,ForeignKey("PropertyInfo")]
        public int Id { get; set; }

        //Main Features
        public int? BuiltYear { get; set; }
        public string? View { get; set; }
        public int? ParkingSpaces { get; set; }
        public bool? AirConditioning { get; set; }
        public string? Flooring { get; set; }
        public string? ElectricityBackup { get; set; }
        public int? Floors { get; set; }
        public bool? Furnished { get; set; }
        public bool? OtherMainFeatures  { get; set; }

        //busines sand communication
        public bool? InternetAccess { get; set; }
        public bool? SatellitetOrCable { get; set; }
        public bool? OtherBCFacilities { get; set; }

        //nearby locations
        public int? NearbySchools { get; set; }
        public int? NearbyHospitals { get; set; }
        public int? NearbyShoppingMalls { get; set; }
        public int? NearbyRestaurants { get; set; }
        public int? NearbyMosques { get; set; }
        public int? NearbyPublicTransport { get; set; }
        public bool? OtherNBFacilities { get; set; }

        //Rooms
        public int? Bedrooms { get; set; }
        public int? Bathrooms { get; set; }
        public int? ServantQuarters { get; set; }
        public bool? DrawingRoom { get; set; }
        public bool? DiningRoom { get; set; }
        public int? Kitchens { get; set; }
        public bool? StudyRoom { get; set; }
        public bool? PrayerRoom { get; set; }
        public int? StoreRooms { get; set; }
        public bool? LoungeOrSittingRoom { get; set; }
        public bool? LaundryRoom { get; set; }
        public bool? OtherRooms { get; set; }

        //health and recreational
        public bool? LawnOrGarden { get; set; }
        public bool? SwimmingPool { get; set; }
        public bool? OtherHRFacilities { get; set; }


        //other facilities
        public bool? MaintenanceStaff { get; set; }
        public bool? SecurityStaff { get; set; }
        public bool? FacilitiesForDisabled { get; set; }
        public bool? OtherFacilities { get; set; }


        public int PropertyID { get; set; }
    }
}
