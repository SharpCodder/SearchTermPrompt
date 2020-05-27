using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SearchTermPrompt.Services;
using SearchTermPrompt.Website.Models;

namespace SearchTermPrompt.Website.Controllers
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
            SearchTermService service = new SearchTermService(new SystemCacheService());
            ViewBag.NumberOfTerms = service.GetSearchTerms().Count();
            return View();
        }

        public IActionResult RawSearchTermData()
        {
            return View();
        }

        public IActionResult SearchTermDataObject()
        {
            SearchTermService service = new SearchTermService(new SystemCacheService());
            return View(service.GetSearchTerms());
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
