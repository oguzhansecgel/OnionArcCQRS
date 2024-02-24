using Microsoft.AspNetCore.Mvc;

namespace OnionArcCQRS.WebUI.ViewComponents.RentACarFilterComponents
{
    public class _RentACarFilterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke(string v)
        {
            TempData["value"] = v;
            return View();
        }
    }
}
