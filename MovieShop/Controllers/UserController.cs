﻿using Microsoft.AspNetCore.Mvc;

namespace MovieShop.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
