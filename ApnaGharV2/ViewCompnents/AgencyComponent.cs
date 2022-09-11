using Microsoft.AspNetCore.Mvc;
using ApnaGharV2.Models.Interfaces;
using ApnaGharV2.Models;

namespace ApnaGharV2.ViewCompnents
{
    public class AgencyComponent:ViewComponent
    {
        private readonly IUserRepository userRepo;    //reference of interface at class level
        private readonly IAgencyRepository agencyRepo;    //reference of interface at class level

        public AgencyComponent(IUserRepository userRepo, IAgencyRepository agencyRepo)
        {
            Console.WriteLine("agent vc constrctor called");
            this.userRepo = userRepo;
            this.agencyRepo = agencyRepo;
        }

        public IViewComponentResult Invoke(int? userId)
        {
            /*//check if this user(who added this property) is agent or not

            //first get that user
            User u = userRepo.SearchUser(userId);
            if (u.Role == "agent")
            {
                Agency a = agencyRepo.SearchAgencyByUserId(userId);
                return View(a);
            }

            //we will send agency object in view, bcz we need to show name& data of agency there
            Console.WriteLine("----------returning null");
            return View(null);*/

            return View();
        }
    }
}
