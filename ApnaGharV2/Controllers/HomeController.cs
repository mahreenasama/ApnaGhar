using ApnaGharV2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ApnaGharV2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [HttpPost]
        public IActionResult Index()
        {
            /*List<CardHome> cards1=new List<CardHome>();

            CardHome c = new CardHome();
            c.Image = "~/images/karachi.jpeg";
            c.Title = "City Comfort";
            c.Description = "Karachi";
            cards1.Add(c);
            CardHome c1 = new CardHome();
            c.Image = "~/images/emiratesmall.jpg";
            c.Title = "City Comfort";
            c.Description = "Karachi";
            cards1.Add(c1);
            CardHome c2 = new CardHome();
            c.Image = "~/images/zahida.jpeg";
            c.Title = "City Comfort";
            c.Description = "Karachi";
            cards1.Add(c2);*/

            List<String> vs = new List<String>();
            vs.Add("Houses for sale in Shahdara");
            vs.Add("Rent Areas in Shahdara");
            vs.Add("Commercial Areas in Shahdara");

            List<String> vs2 = new List<String>();
            vs2.Add("Houses for sale in Gulberg");
            vs2.Add("Rent Areas in Gulberg");
            vs2.Add("Commercial Areas in Gulberg");

            List<String> vs3 = new List<String>();
            vs3.Add("Houses for sale in DHA");
            vs3.Add("Rent Areas in DHA");
            vs3.Add("Commercial Areas in DHA");

            List<String> vs4 = new List<String>();
            vs4.Add("Houses for sale in Shahdara");
            vs4.Add("Rent Areas in Shahdara");
            vs4.Add("Commercial Areas in Shahdara");

            List<String> vs5 = new List<String>();
            vs5.Add("Houses for sale in Shahdara");
            vs5.Add("Rent Areas in Shahdara");
            vs5.Add("Commercial Areas in Shahdara");

            List<String> vs6 = new List<String>();
            vs6.Add("Houses for sale in Shahdara");
            vs6.Add("Rent Areas in Shahdara");
            vs6.Add("Commercial Areas in Shahdara");

            List<List<String>> vs22 = new List<List<String>>();
            vs22.Add(vs);
            vs22.Add(vs2);
            vs22.Add(vs3);
            vs22.Add(vs4);
            vs22.Add(vs5);
            vs22.Add(vs6);

            return View(vs22);
        }

        public IActionResult PlotFinder()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            List<String> vs = new List<String>();
            vs.Add("/images/active.png");
            vs.Add("Rent Areas in Shahdara");
            vs.Add("/images/about-us-block.png");

            List<String> vs2 = new List<String>();
            vs2.Add("Houses for sale in Gulberg");
            vs2.Add("Rent Areas in Gulberg");
            vs2.Add("Commercial Areas in Gulberg");

            List<String> vs3 = new List<String>();
            vs3.Add("Houses for sale in DHA");
            vs3.Add("Rent Areas in DHA");
            vs3.Add("Commercial Areas in DHA");

            List<String> vs4 = new List<String>();
            vs4.Add("Houses for sale in Shahdara");
            vs4.Add("Rent Areas in Shahdara");
            vs4.Add("Commercial Areas in Shahdara");

            List<String> vs5 = new List<String>();
            vs5.Add("Houses for sale in Shahdara");
            vs5.Add("Rent Areas in Shahdara");
            vs5.Add("Commercial Areas in Shahdara");

            List<String> vs6 = new List<String>();
            vs6.Add("Houses for sale in Shahdara");
            vs6.Add("Rent Areas in Shahdara");
            vs6.Add("Commercial Areas in Shahdara");

            List<List<String>> vs22 = new List<List<String>>();
            vs22.Add(vs);
            vs22.Add(vs2);
            vs22.Add(vs3);
            vs22.Add(vs4);
            vs22.Add(vs5);
            vs22.Add(vs6);

            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult HelpSupport()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}