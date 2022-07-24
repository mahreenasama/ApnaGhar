using Microsoft.AspNetCore.Mvc;

using ApnaGharV2.Models;
using System.Collections.Generic;

namespace ApnaGharV2.Controllers
{ 
    public class PropertyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult ViewProperty(int id)
        {
            return View();
        }

        [HttpGet]
        public ViewResult ViewAllProperties()
        {
            List<PropertyBO> properties = new List<PropertyBO>();
            PropertyBO obj1 = new PropertyBO();
            obj1.Name = "5 Marla House";
            obj1.Description = "Five marla house located in shahdara town lahore.";
            obj1.Image = "/images/zahida.jpg";
            obj1.Price = 40000;
            obj1.Bedrooms = 3;
            obj1.Bathrooms = 2;

            properties.Add(obj1);
            properties.Add(obj1);
            properties.Add(obj1);
            properties.Add(obj1);
            properties.Add(obj1);
            properties.Add(obj1);
            properties.Add(obj1);
            properties.Add(obj1);

            return View(properties);
        }

        [HttpGet]
        public ViewResult AddProperty()
        {
            return View();
        }

        [HttpPost]
        public ViewResult AddProperty(PropertyBO property)
        {
            return View();
        }

        //partial view return for ajax

        //[HttpGet]
        public PartialViewResult GetSubCategories(string id)
        {
            string[]? subCategories = null;
            if (id.Equals("homes"))
            {
                subCategories = new string[] { "House", "Flat", "Room", "Upper Portion", "Lower Portion", "Farm House", "Pent House" };
            }
            else if (id.Equals("plots"))
            {
                subCategories = new string[] { "Residential Plot", "Commercial Plot", "Agricultural Land", "Industrial Land", "Plot File", "Plot Form" };
            }
            else if (id.Equals("commercial"))
            {
                subCategories = new string[] { "Office", "Shop", "Warehouse", "Factory", "Building", "Other" };
            }
            return PartialView("_PropertySubCategories", subCategories);
        }

        //locations of a particular city

        //[HttpGet]
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
