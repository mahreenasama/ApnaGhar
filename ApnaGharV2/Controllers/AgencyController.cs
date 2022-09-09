using ApnaGharV2.Models.Interfaces;
using ApnaGharV2.Models.Repositories;

using Microsoft.AspNetCore.Mvc;

namespace ApnaGharV2.Controllers
{
    public class AgencyController : Controller
    {
        private readonly IAgencyRepository agencyRepo;    //reference of interface at class level

        public AgencyController(IAgencyRepository agencyRepo)
        {
            this.agencyRepo = agencyRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewAgency()
        {
            return View();
        }
    }
}
