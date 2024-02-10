using Microsoft.AspNetCore.Mvc;

namespace OnionArcCQRS.WebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
