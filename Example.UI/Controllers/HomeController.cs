using Example.UI.Models;
using Example.UI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace Example.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMathService _mathService;

        public HomeController(ILogger<HomeController> logger, IMathService mathService) => (_logger, _mathService) = (logger, mathService);

        public IActionResult Index()
        {
            try
            {
                decimal result = _mathService.Divide(5, 0);
            }
            catch (DivideByZeroException ex)
            {
                _logger.LogWarning(ex, "An exception occured while dividing two numbers");
            }

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
