using Microsoft.AspNetCore.Mvc;

namespace ApnaGharV2.ViewCompnents
{
    public class EnquiryForm:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
