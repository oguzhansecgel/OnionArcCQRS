﻿using Microsoft.AspNetCore.Mvc;

namespace OnionArcCQRS.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}