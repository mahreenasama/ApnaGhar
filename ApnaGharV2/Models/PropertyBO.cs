namespace ApnaGharV2.Models
{
    public class PropertyBO
    {
        public int Id { get; set; }

        public string Purpose { get; set; } //sale, rent

        public string Type { get; set; } //house, plot, commercial

        public string SubType { get; set; } //from each type there is a sub type

        public string City { get; set; } //in which city this property reside

        public string Location { get; set; } //full map location

        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public int Bedrooms { get; set; }

        public int Bathrooms { get; set; }

        public int ExpiresAfter { get; set; }

        public string Image { get; set; }

        /*public string owner { get; set; }*/

    }
}
