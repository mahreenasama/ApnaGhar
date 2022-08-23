using ApnaGharV2.Models.Interfaces;
using ApnaGharV2.Models.Repositories;

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
    }
}
