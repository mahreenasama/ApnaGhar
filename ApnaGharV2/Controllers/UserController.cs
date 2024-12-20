﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApnaGharV2.Models;
using ApnaGharV2.Models.Repositories;
using ApnaGharV2.Models.Interfaces;
using ApnaGharV2.Models.Classes;
using Microsoft.AspNetCore.Identity;

namespace ApnaGharV2.Controllers
{
    public class UserController : Controller
    {
        //private readonly UserManager<ApplicationUser> userManager;
        //private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IUserRepository userRepo;    //reference of interface at class level


        public UserController(IUserRepository userRepo)
        {
            //this.userManager = userManager;     //manages user add,delete
            //this.signInManager = signInManager;   //manages signin, signout
            this.userRepo = userRepo;       //refernce of interface at class level
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("Dashboard");
        }

        





        //---------------------- view users ------------------------

        public IActionResult FavouriteListings()
        {
            return View();
        }

    }
}
