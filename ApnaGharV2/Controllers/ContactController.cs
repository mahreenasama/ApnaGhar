using Microsoft.AspNetCore.Mvc;
using ApnaGharV2.Models.Classes;

namespace ApnaGharV2.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
