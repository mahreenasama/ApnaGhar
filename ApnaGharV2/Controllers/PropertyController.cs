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
    }
}
