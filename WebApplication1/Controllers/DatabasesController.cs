﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class DatabasesController : Controller
    {
        public IActionResult Vehicles()
        {
            return View();
        }

        public IActionResult Workers()
        {
            return View();
        }
    }
}
