using ApnaGharV2.Models.Interfaces;
using ApnaGharV2.Models.Repositories;
using ApnaGharV2.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApnaGharV2.Controllers
{
    public class EnquiryController : Controller
    {
        private readonly IEnquiryRepository enquiryRepo;    //reference of interface at class level

        public EnquiryController(IEnquiryRepository enquiryRepo)
        {
            this.enquiryRepo = enquiryRepo;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult SubmitEnquiry(Enquiry enquiry)
        {
            if (enquiryRepo.SubmitEnquiry(enquiry))
            {
                return RedirectToAction("ViewProperty", "Property");
            }
            return null;
        }

        public void GetAllEnquiries(Enquiry enquiry)
        {
            
        }
    }
}
