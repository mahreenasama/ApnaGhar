using Microsoft.AspNetCore.Mvc;
using ApnaGharV2.Models.Interfaces;
using ApnaGharV2.Models.Classes;
using ApnaGharV2.Models.ViewModels;

namespace ApnaGharV2.ViewCompnents
{
    public class PropertiesComponent:ViewComponent
    {
        private readonly IPropertyRepository propertyRepo;    //reference of interface at class level

        public PropertiesComponent(IPropertyRepository propertyRepo)
        {
            Console.WriteLine("cmpt controuct 8888888888888");
            this.propertyRepo = propertyRepo;
        }
        public IViewComponentResult Invoke()
        {
            Console.WriteLine("cmpt invoke 8888888888888");

            List<Property> pops = propertyRepo.ViewAllProperties(0);
            List<Property> pops2 = new List<Property>();

            int c = 0;
            for(int i=pops.Count-1; i>=0; i--)
            {
                if (c == 8)
                {
                    break;
                }
                Property p = new Property();
                p = pops[i];
                pops2.Add(p);
                c++;
            }
            return View(pops);
        }
    }
}
