using Microsoft.AspNetCore.Mvc;

using ApnaGharV2.Models;
using System.Collections.Generic;

namespace ApnaGharV2.Controllers
{
    public class PropertyController : Controller
    {
        /*public IActionResult Index()
        {
            return View();
        }*/

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
        [HttpGet]
        public PartialViewResult GetSubCategories(string id)
        {
            Console.WriteLine(id);
            string[] subCategories = null;
            if (id == "homes")
            {
                subCategories =new string[]{ "House","Flat","Upper Portion","Lower Portion","Room","Farm House","Pent House"};
            }
            else if (id == "plots")
            {
                subCategories = new string[] { "Residential Plot", "Commercial Plot", "Agricultural Land", "Industrial Land" };
            }
            else if (id == "commercial")
            {
                subCategories = new string[] { "Office", "Shop", "Warehouse", "Factory", "Building", "Other" };
            }
            return PartialView("_HomeSubCategories", subCategories);
        }
    }
}
