﻿using Microsoft.AspNetCore.Mvc;

namespace ApnaGharV2.Controllers
{
    public class AccountController : Controller
    {
        /* public IActionResult Index()
         {
             return View();
         }*/

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
