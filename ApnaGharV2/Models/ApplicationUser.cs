using Microsoft.AspNetCore.Identity;

namespace ApnaGharV2.Models
{
    public class ApplicationUser:IdentityUser
    {
        //This class will be used istead of IdentityUSer class in our app, 
        // because, we want our custom columns in identity user table


        //ou cannot make any changes in identityUser class, so we have inherited
        //it to Application user and added new properties 

        public string Name { get; set; }
        public string City { get; set; }
        public string RegisterAs { get; set; }


    }
}
