using Microsoft.AspNetCore.Mvc;
using ApnaGharV2.Models;
using ApnaGharV2.Models.Repositories;
using ApnaGharV2.Models.Interfaces;

namespace ApnaGharV2.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserRepository userRepo;    //reference of interface at class level
        private readonly IAgencyRepository agencyRepo;    //reference of interface at class level
        private readonly IPropertyRepository propRepo;    //reference of interface at class level
        private readonly IEnquiryRepository enquiryRepo;    //reference of interface at class level

        public AdminController(IUserRepository userRepo,
            IAgencyRepository agencyRepo, IPropertyRepository propRepo, IEnquiryRepository enquiryRepo)
        {
            //this.userManager = userManager;     //manages user add,delete
            //this.signInManager = signInManager;   //manages signin, signout
            this.userRepo = userRepo;       //refernce of interface at class level
            this.agencyRepo = agencyRepo;
            this.propRepo = propRepo;
            this.enquiryRepo = enquiryRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewAllProperties()
        {
            return View();
        }
    }
}
