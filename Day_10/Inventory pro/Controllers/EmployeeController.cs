﻿using Microsoft.AspNetCore.Mvc;

namespace PRO.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
