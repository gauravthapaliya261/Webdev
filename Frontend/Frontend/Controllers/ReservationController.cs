﻿using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class ReservationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
