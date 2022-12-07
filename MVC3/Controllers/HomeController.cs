using Microsoft.AspNetCore.Mvc;
using MVC3.Models;
using MVC3.ViewModels.Home;
using System.Diagnostics;

namespace MVC3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var VM = new IndexVM(
                "Alain",
                "https://www.linkedin.com/in/alain-micalaudie",
                "C#, Python");

            return View(VM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Infos()
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