namespace ApnaGharV2.Models
{
    public class PropertyBO
    {
        public int Id { get; set; }

        public string Purpose { get; set; } //sale, rent

        public string Type { get; set; } //house, plot, commercial

        public string SubType { get; set; } //from each type there is a sub type

        public string City { get; set; } //in which city this property reside

        public string Area { get; set; } //where property is located
        public string Address { get; set; } //full address

        public string Title { get; set; }

        public string Description { get; set; }

        public string Price { get; set; }   //save as 45 Lakh

        public string Size { get; set; }    //save as 12 Sqft

        public int Bedrooms { get; set; }

        public int Bathrooms { get; set; }


        public string Image { get; set; }

        public int OwnerId { get; set; }

    }
}
