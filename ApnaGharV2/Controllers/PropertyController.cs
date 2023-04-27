using Microsoft.AspNetCore.Mvc;

using ApnaGharV2.Models;
using ApnaGharV2.Models.ViewModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using ApnaGharV2.Models.Classes;

using ApnaGharV2.Models.Interfaces;
using ApnaGharV2.Models.Repositories;

namespace ApnaGharV2.Controllers
{ 
    public class PropertyController : Controller
    {
        private IWebHostEnvironment Environment;
        private readonly IPropertyRepository propertyRepo;    //reference of interface at class level

        private static int loggedinAdminId;
        private static string loggedinAdminUname, loggedinAdminRole;

        public PropertyController(IWebHostEnvironment _e, IPropertyRepository propertyRepo)
        {
            Environment = _e;       //inject service using constructor
            this.propertyRepo = propertyRepo;
        }

        [HttpGet]
        public ViewResult ViewProperty(int id)
        {
            Property p = propertyRepo.ViewProperty(id);
            if (HttpContext.Request.Cookies.ContainsKey("loggedinUserId"))
            {
                ViewBag.loggedinUserRole = HttpContext.Request.Cookies["loggedinUserRole"].ToString();
                ViewBag.loggedinUserUname = HttpContext.Request.Cookies["loggedinUserUname"].ToString();
                ViewBag.loggedinUserId = HttpContext.Request.Cookies["loggedinUserId"].ToString();
            }
            return View(p);
        }

        [HttpGet]
        public ViewResult ViewAllProperties(int num)
        {
            List<Property> properties = propertyRepo.ViewAllProperties(num);

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

            return View(properties);
        }
        public PartialViewResult FilterProperties(string city, string purpose, string type)
        {
            List<Property> properties = propertyRepo.FilterProperties(city,purpose,type);
            Console.WriteLine("fitkered props: " + properties.Count());
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

            return PartialView("_FilterProperties",properties);
        }


        //locations of a particular city

        public List<string> GetCityLocations(string city)
        {
            List<string>? locations = new List<string>();
            if (city == "Lahore")
            {
                locations.Add("Allama Iqbal Town");
                locations.Add("Bahria Town");
                locations.Add("DHA");
                locations.Add("DHA Phase 1");
                locations.Add("DHA Phase 2");
                locations.Add("DHA Phase 3");
                locations.Add("DHA Phase 4");
                locations.Add("DHA Phase 5");
                locations.Add("DHA Phase 6");
                locations.Add("DHA Phase 7");
                locations.Add("DHA Phase 8");
                locations.Add("Faisal Town");
                locations.Add("Garden Town");
                locations.Add("Gulberg");
                locations.Add("Johar Town");
                locations.Add("Lahore Cantt");
                locations.Add("Model Town");
                locations.Add("Shahdara Town");
                locations.Add("Wapda Town");
                locations.Add("Other");
            }
            else if (city == "Karachi")
            {
                locations.Add("Bahria Town");
                locations.Add("Garden East");
                locations.Add("Jahangir Town");
                locations.Add("DHA Defence");
                locations.Add("DHA Clifton");
                locations.Add("Gulshan-e-Iqbal");
                locations.Add("Nazimabad");
                locations.Add("Other");
            }
            else if (city == "Islamabad")
            {
                locations.Add("Bahria Town");
                locations.Add("DHA");
                locations.Add("DHA Phase 1");
                locations.Add("DHA Phase 2");
                locations.Add("DHA Phase 3");
                locations.Add("DHA Phase 4");
                locations.Add("DHA Phase 5");
                locations.Add("Gulberg");
                locations.Add("Shalimar Town");
                locations.Add("Wapda Town");
                locations.Add("Iqbal Town");
                locations.Add("Pakistan Town");
                locations.Add("Madina Town");
                locations.Add("Bani Gala");
                locations.Add("Media Town");
                locations.Add("Shalimar Town");
                locations.Add("Other");
            }
            return locations;
        }
    }
}
