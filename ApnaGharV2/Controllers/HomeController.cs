using ApnaGharV2.Models;
using ApnaGharV2.Models.Interfaces;
using ApnaGharV2.Models.Classes;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ApnaGharV2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly IPropertyRepository propertyRepo;    //reference of interface at class level
        private static int loggedinAdminId;
        private static string loggedinAdminUname, loggedinAdminRole;

        public HomeController(ILogger<HomeController> logger, IPropertyRepository propertyRepo)
        {
            _logger = logger;
            //this.propertyRepo = propertyRepo;

        }

        /*public IActionResult SearchBar(string city, string size)
        {
            List<Property> props = propertyRepo.SearchBar(city, size);
            return RedirectToAction("ViewAllProperties", "Property");
        }*/

       
        public IActionResult Index()
        {
            string data = String.Empty;
            if (HttpContext.Session.Keys.Contains("first_request"))
            {
                string firstVisitedDateTime = HttpContext.Session.GetString("first_request");
                data = "Last Visit: " + firstVisitedDateTime;
            }
            else
            {
                data = "you visited first time";
                HttpContext.Session.SetString("first_request", System.DateTime.Now.ToString());
            }
            //------------------------
            if (HttpContext.Request.Cookies.ContainsKey("loggedinUserId"))
            {
                ViewBag.loggedinUserRole = HttpContext.Request.Cookies["loggedinUserRole"].ToString();
                ViewBag.loggedinUserUname = HttpContext.Request.Cookies["loggedinUserUname"].ToString();
                ViewBag.loggedinUserId = HttpContext.Request.Cookies["loggedinUserId"].ToString();

                loggedinAdminId = int.Parse(ViewBag.loggedinUserId);
                loggedinAdminUname = ViewBag.loggedinUserUname;
                loggedinAdminRole = ViewBag.loggedinUserRole;

            }
            return View("index", data);
        }

        public IActionResult Privacy()
        {
            if (HttpContext.Request.Cookies.ContainsKey("loggedinUserId"))
            {
                ViewBag.loggedinUserRole = HttpContext.Request.Cookies["loggedinUserRole"].ToString();
                ViewBag.loggedinUserUname = HttpContext.Request.Cookies["loggedinUserUname"].ToString();
                ViewBag.loggedinUserId = HttpContext.Request.Cookies["loggedinUserId"].ToString();
            }
            return View();
        }
        public IActionResult Team()
        {
            if (HttpContext.Request.Cookies.ContainsKey("loggedinUserId"))
            {
                ViewBag.loggedinUserRole = HttpContext.Request.Cookies["loggedinUserRole"].ToString();
                ViewBag.loggedinUserUname = HttpContext.Request.Cookies["loggedinUserUname"].ToString();
                ViewBag.loggedinUserId = HttpContext.Request.Cookies["loggedinUserId"].ToString();
            }
            return View();
        }
        public IActionResult TermsOfUse()
        {
            if (HttpContext.Request.Cookies.ContainsKey("loggedinUserId"))
            {
                ViewBag.loggedinUserRole = HttpContext.Request.Cookies["loggedinUserRole"].ToString();
                ViewBag.loggedinUserUname = HttpContext.Request.Cookies["loggedinUserUname"].ToString();
                ViewBag.loggedinUserId = HttpContext.Request.Cookies["loggedinUserId"].ToString();
            }
            return View();
        }
        public IActionResult About()
        {
            if (HttpContext.Request.Cookies.ContainsKey("loggedinUserId"))
            {
                ViewBag.loggedinUserRole = HttpContext.Request.Cookies["loggedinUserRole"].ToString();
                ViewBag.loggedinUserUname = HttpContext.Request.Cookies["loggedinUserUname"].ToString();
                ViewBag.loggedinUserId = HttpContext.Request.Cookies["loggedinUserId"].ToString();
            }
            return View();
        }

        public IActionResult Contact()
        {
            if (HttpContext.Request.Cookies.ContainsKey("loggedinUserId"))
            {
                ViewBag.loggedinUserRole = HttpContext.Request.Cookies["loggedinUserRole"].ToString();
                ViewBag.loggedinUserUname = HttpContext.Request.Cookies["loggedinUserUname"].ToString();
                ViewBag.loggedinUserId = HttpContext.Request.Cookies["loggedinUserId"].ToString();
            }
            return View();
        }

        public IActionResult HelpSupport()
        {
            if (HttpContext.Request.Cookies.ContainsKey("loggedinUserId"))
            {
                ViewBag.loggedinUserRole = HttpContext.Request.Cookies["loggedinUserRole"].ToString();
                ViewBag.loggedinUserUname = HttpContext.Request.Cookies["loggedinUserUname"].ToString();
                ViewBag.loggedinUserId = HttpContext.Request.Cookies["loggedinUserId"].ToString();
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult FoF()
        {
            if (HttpContext.Request.Cookies.ContainsKey("loggedinUserId"))
            {
                ViewBag.loggedinUserRole = HttpContext.Request.Cookies["loggedinUserRole"].ToString();
                ViewBag.loggedinUserUname = HttpContext.Request.Cookies["loggedinUserUname"].ToString();
                ViewBag.loggedinUserId = HttpContext.Request.Cookies["loggedinUserId"].ToString();
            }
            return View();
        }
    }
}