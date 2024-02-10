using Microsoft.AspNetCore.Mvc;

namespace OnionArcCQRS.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
