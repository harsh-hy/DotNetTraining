using Microsoft.AspNetCore.Mvc;
using BuisnessLogic;

namespace FrontEndMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            BL bl = new BL();

            string data = bl.GetData();

            return View("Index", data);
        }
    }
}