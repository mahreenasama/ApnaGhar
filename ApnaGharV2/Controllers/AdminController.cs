using Microsoft.AspNetCore.Mvc;
using ApnaGharV2.Models;
using ApnaGharV2.Models.ViewModels;
using ApnaGharV2.Models.Repositories;
using ApnaGharV2.Models.Interfaces;
using ApnaGharV2.Models.Classes;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Diagnostics;

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
            List<Property> properties = propertyRepo.ViewAllProperties();

            return View(properties);
        }
        [HttpGet]
        public ViewResult AddProperty()
        {
            System.Diagnostics.Debug.WriteLine("outside");

            return View();
        }
        [HttpPost]
        public IActionResult AddProperty(Models.ViewModels.PropertyViewModel property, List<IFormFile> PropertyImages)
        {
            System.Diagnostics.Debug.WriteLine("outside");

            if (ModelState.IsValid)
            {
                if (propertyRepo.AddProperty(property, PropertyImages))
                {
                    Debug.WriteLine("propety added");
                }
                else
                {
                    Debug.WriteLine("proprty not added");
                }
                return RedirectToAction("Admin", "Dashboard");
                //return this.Ok($"Form Data received!");
            }
            else
            {
                ModelState.AddModelError(String.Empty, "Please enter required fields");
                //return BadRequest("Enter required fields");
                Debug.WriteLine("admin p add state not valid");
                Debug.WriteLine(ModelState.ErrorCount);
                return View();
            }
            Debug.WriteLine("outside");
            //return View();
        }

        [HttpGet]
        public ViewResult PropertyDetails(int id)
        {
            Property p = propertyRepo.ViewProperty(id);
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
