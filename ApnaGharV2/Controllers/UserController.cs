using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User u)
        {
            Console.WriteLine("in method");
            if (ModelState.IsValid)   //if all input is correct
            {
                Console.WriteLine("model state valid");

                if (userRepo.UserAlreadyExist(u))
                {
                    Console.WriteLine("user already exist");

                    TempData["duplicate_email"] = "This email already exists";
                    return View("Register");
                }
                else
                {
                    Console.WriteLine("user adding");

                    TempData["duplicate_email"] = string.Empty;
                    userRepo.AddUser(u);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                Console.WriteLine("model state not valid");
                return View();
            }
        }





        //---------------------- view users ------------------------

        [HttpGet]
        public IActionResult ViewAllUsers()
        {
            userRepo.GetAllUsers();
            return View(UserRepository.users);
        }

    }
}
