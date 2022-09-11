using Microsoft.AspNetCore.Mvc;


namespace ApnaGharV2.ViewCompnents
{
    public class AmenitiesComponent:ViewComponent
    {
        public IViewComponentResult Invoke(int? propertyId)
        {
            return View();
        }
    }
}
