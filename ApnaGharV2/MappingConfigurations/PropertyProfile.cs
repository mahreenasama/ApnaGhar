using AutoMapper;
using ApnaGharV2.Models.Classes;
using ApnaGharV2.Models.ViewModels;

namespace ApnaGharV2.MappingConfigurations
{
    public class PropertyProfile : Profile
    {
        public PropertyProfile()
        {

            // Default mapping when property names are same
            CreateMap<Property, PropertyViewModel>();

            // Mapping when property names are different
            /* CreateMap<User, UserViewModel>()
                 .ForMember(dest =>
                 dest.FName,+
                 opt => opt.MapFrom(src => src.FirstName))
                 .ForMember(dest =>
                 dest.LName,
                 opt => opt.MapFrom(src => src.LastName));*/
        }
    }
}
