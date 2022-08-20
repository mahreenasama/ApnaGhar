using Microsoft.AspNetCore.Mvc;

using ApnaGharV2.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace ApnaGharV2.Controllers
{ 
    public class PropertyController : Controller
    {
        private IWebHostEnvironment Environment;
        public PropertyController(IWebHostEnvironment _e)
        {
            Environment = _e;       //inject service using constructor
        }

        //--------------------------methods---------------
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult AddProperty()
        {
            return View();
        }

        [HttpPost]
        public ViewResult AddProperty(Property property)
        {
            //---------save images-----------
            string wwwPath = this.Environment.WebRootPath;
            string path = Path.Combine(wwwPath, "images");  //images folder
            path = Path.Combine(path, "properties");    //properties folder
            if (!Directory.Exists(path))
            {
                //if folder already not exists, then create new folder
                Directory.CreateDirectory(path);
            }
            //now properties folder exist, now create one folder for each
            int c = 0;
            foreach(IFormFile file in property.images)
            {
                using (FileStream stream = new FileStream(
                    Path.Combine(path, $"abc.jpg"), FileMode.OpenOrCreate))
                {
                    file.CopyTo(stream);
                }
                c += 1;
            }

            Console.WriteLine(path);

            property.ImagesPath = path;             //assign path to db property

            PropertyRepository pr = new PropertyRepository();
            if (pr.AddProperty(property))
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
            return View();
        }

        [HttpGet]
        public ViewResult ViewAllProperties()
        {
            List<Property> properties = new List<Property>();
            Property obj1 = new Property();
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
            properties.Add(obj1);

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
