using DemoMemoryCache.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DemoMemoryCache.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCache _cache;
        private const string _cacheKey = "person";
        public HomeController(ILogger<HomeController> logger, IMemoryCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        public IActionResult Index()
        {
            var user = _cache.Get(_cacheKey);

            if (user != null)
            {
                ViewBag.Data = user.ToString();
                return View();
            }

            user = new
            {
                Name = "Long",
                Age = 18
            };
            _cache.Set(_cacheKey, user);
            ViewBag.Data = user.ToString();
            return View();
        }

        public IActionResult Privacy()
        {
            var user = _cache.Get(_cacheKey);
            ViewBag.Data = user.ToString();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
