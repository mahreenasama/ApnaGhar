using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApnaGharV2.Models;

namespace ApnaGharV2.Controllers
{
    public class UserController : Controller
    {
        //---------------------- sign in------------------------

        [HttpPost]
        public ActionResult SignIn(User user)
        {
            if (ModelState.IsValid)   //if all input is correct
            {
                if (UserRepository.LoginUser(user))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        //---------------------- sign up------------------------
        [HttpGet]
        public ViewResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User user)
        {
            string msg = string.Empty;

            if (UserRepository.UserAlreadyExist(user))
            {
                TempData["duplicate_email"] = "This email already exists";
                return View("SignUp", msg);
            }
            else
            {
                TempData["duplicate_email"] = string.Empty;

                if (ModelState.IsValid)   //if all input is correct
                {
                    UserRepository.SaveUser(user);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();
                }
            }
        }

        //---------------------- view users ------------------------

        [HttpGet]
        public IActionResult ViewAllUsers()
        {
            UserRepository.GetAllUsers();
            return View(UserRepository.users);
        }

    }
}
