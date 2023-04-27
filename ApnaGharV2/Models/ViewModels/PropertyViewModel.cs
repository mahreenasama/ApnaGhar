namespace ApnaGharV2.Models.ViewModels
{
    public class PropertyViewModel
    {
        
        public int Id { get; set; }
        public string? Title { get; set; }
        public int? Size { get; set; }    //save as 12 Sqft
        public string? SizeUnit { get; set; }    //save as 12 Sqft
        public int? Price { get; set; }  
        public string? PriceUnit { get; set; }
        public string? Area { get; set; } //where property is located
        public string? City { get; set; } //in which city this property reside
        public string? Purpose { get; set; } //sale, rent
        public string? Type { get; set; } //house, plot, commercial
        //public string? SubType { get; set; } //from each type there is a sub type
        public int? ImagesCount { get; set; } //from each type there is a sub type

    }
}
