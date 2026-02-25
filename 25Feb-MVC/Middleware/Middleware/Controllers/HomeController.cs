using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Middleware.Models;
using MiddlewareDemo.Middleware;
namespace Middleware.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Echo(string q)
        {
            return Content($"You sent q = {q}");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
