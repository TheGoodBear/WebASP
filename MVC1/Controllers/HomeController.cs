using Microsoft.AspNetCore.Mvc;
using MVC1.Models;
using System.Diagnostics;

namespace MVC1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // GET: Index
        //[HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // GET: Privacy
        //[HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult View1()
        {
            return View();
        }

        public IActionResult Page1()
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