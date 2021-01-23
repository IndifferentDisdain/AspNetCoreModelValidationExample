using F23.ModelValidationExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace F23.ModelValidationExample.Controllers
{
    public class HomeController : ControllerBase
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(SimpleValidationViewModel model)
        {
            Debug.WriteLine("Entering Index Post");
            if (!ModelState.IsValid)
            {
                Debug.WriteLine("ModelsState is not valid");
                return View(model);
            }

            AddSuccessMessage("Simple model posted successfully!");
            return View();
        }

        public IActionResult Better()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Better(BetterValidationViewModel model)
        {
            Debug.WriteLine("Entering Better Post");
            if (!ModelState.IsValid)
            {
                Debug.WriteLine("ModelsState is not valid");
                return View(model);
            }

            AddSuccessMessage("Better model posted successfully!");
            return View();
        }

        public IActionResult Best()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Best(BetterValidationViewModel model)
        {
            Debug.WriteLine("Entering Index Post");
            if (!ModelState.IsValid)
            {
                Debug.WriteLine("ModelsState is not valid");
                return View(model);
            }

            AddSuccessMessage("Best model posted successfully!");
            return View();
        }

        public IActionResult Privacy()
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
