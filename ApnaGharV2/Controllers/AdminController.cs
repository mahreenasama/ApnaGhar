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
        private readonly IPropertyRepository propertyRepo;    //reference of interface at class level
        private readonly IEnquiryRepository enquiryRepo;    //reference of interface at class level

        public AdminController(IUserRepository userRepo,
            IAgencyRepository agencyRepo, IPropertyRepository propertyRepo, IEnquiryRepository enquiryRepo)
        {
            //this.userManager = userManager;     //manages user add,delete
            //this.signInManager = signInManager;   //manages signin, signout
            this.userRepo = userRepo;       //refernce of interface at class level
            this.agencyRepo = agencyRepo;
            this.propertyRepo = propertyRepo;
            this.enquiryRepo = enquiryRepo;
        }

        public IActionResult Index()
        {

            return View("dashboard");
        }

        //------------------------------------propeties---------------------------------
        public IActionResult ListProperties()
        {
            List<PropertyInfo> properties = propertyRepo.ViewAllProperties();

            return View(properties);
        }

        [HttpGet]
        public ViewResult AddProperty()
        {
            return View();
        }
        [HttpPost]
        public ViewResult AddProperty(PropertyInfo property, List<IFormFile> PropertyImages)
        {

            if (propertyRepo.AddProperty(property, PropertyImages))
            {
                Console.WriteLine("propety added");
            }
            else
            {
                Console.WriteLine("proprty not added");
            }

            return View();
        }

        [HttpGet]
        public ViewResult PropertyDetails(int id)
        {
            PropertyInfo p = propertyRepo.ViewProperty(id);
            return View(p);
        }
        public void EditProperty()
        {
            //return View();
        }
        public void RemoveProperty()
        {
            //return View();
        }

        //------------------------------------enquiries---------------------------------
        public IActionResult ListEnquiries()
        {
            List<Enquiry> enquiries = enquiryRepo.GetAllEnquiries();

            return View(enquiries);
        }
    }
}
