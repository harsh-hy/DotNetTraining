using Microsoft.AspNetCore.Mvc;
using AjaxDemo.Models;

namespace AjaxDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SayHello(UserModel user)
        {
            var message = "Hello " + user.Name + " 👋 Welcome to AJAX in ASP.NET Core!";
            return Json(message);
        }
    }
}