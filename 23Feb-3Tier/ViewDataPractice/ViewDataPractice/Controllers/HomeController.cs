using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ViewDataPractice.Models;

namespace ViewDataPractice.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["MyVariable"] = "Finland,Ireland,Iceland,Denmark,Norway,Sweden";
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
