using CLDVapp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CLDVapp.Controllers
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
            return View();
        }

        public IActionResult signUp()
        {
            return View();
        }

        public IActionResult addWork()
        {
            return RedirectToAction("addWork", "Product");
        }

        public IActionResult loginPage()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult Work()
        {
            return RedirectToAction("Work", "Product");
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult transactionPage()
        {
            return RedirectToAction("transactionPage", "Transaction");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
