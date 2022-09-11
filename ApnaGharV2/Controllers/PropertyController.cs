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

        public PropertyController(IWebHostEnvironment _e, IPropertyRepository propertyRepo)
        {
            Environment = _e;       //inject service using constructor
            this.propertyRepo = propertyRepo;
        }

        //--------------------------methods---------------
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ViewResult AddProperty()
        {
            return View();
        }

        [HttpPost]
        public ViewResult AddProperty(Models.ViewModels.PropertyViewModel property, List<IFormFile> PropertyImages)
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
        public ViewResult ViewProperty(int id)
        {
            Property p = propertyRepo.ViewProperty(id);
            return View(p);
        }

        [HttpGet]
        public ViewResult ViewAllProperties()
        {
            List<Property> properties = propertyRepo.ViewAllProperties();

            /*Property obj1 = new Property();
            obj1.Title = "5 Marla House";
            obj1.Description = "Five marla house located in shahdara town lahore.";
            //obj1.Image = "/images/zahida.jpg";
            obj1.Price = 4000;
            obj1.Bedrooms = 3;
            obj1.Bathrooms = 2;

            properties.Add(obj1);
            properties.Add(obj1);
            properties.Add(obj1);
            properties.Add(obj1);
            properties.Add(obj1);
            properties.Add(obj1);
            properties.Add(obj1);
            properties.Add(obj1);*/

            return View(properties);
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
