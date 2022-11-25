using Microsoft.AspNetCore.Mvc;
using Outsources.Models;
using System.Diagnostics;
using Outsources.Enum;

namespace Outsources.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        #region Outsource Element

        public IActionResult Trend()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveTrendResult(IFormCollection collection)
        {
            Trend trend = (Trend)Int16.Parse(collection["trendIndicator"]);
            return View();
        }
        #endregion

        public IActionResult Index()
        {
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
