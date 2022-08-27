using Microsoft.AspNetCore.Mvc;
using ApnaGharV2.Models;
using ApnaGharV2.Models.Repositories;
using ApnaGharV2.Models.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ApnaGharV2.Controllers
{
    public class AccountController : Controller
    {
        /* public IActionResult Index()
         {
             return View();
         }*/

        //private readonly UserManager<ApplicationUser> userManager;
        //rivate readonly SignInManager<ApplicationUser> signInManager;
        private readonly IUserRepository userRepo;    //reference of interface at class level


        public AccountController(
                                 IUserRepository userRepo)
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
        public async Task<IActionResult> Register(User u)
        {
            /*if (ModelState.IsValid)
            { 
                //email will be used as Username
                var user = new ApplicationUser
                {
                    UserName = u.Email,
                    Name = u.Name,
                    PhoneNumber = u.PhoneNumber,
                    City = u.City,
                    RegisterAs = u.Role,
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                };
                //CreateAsync method is used to create that user in DB
                var result = await userManager.CreateAsync(user, u.Password);


                if (result.Succeeded)   //checking if user is added in table
                {
                    if (signInManager.IsSignedIn(User)) // then check if someone is already Signed in then do not signing the registered user
                    {
                        Console.WriteLine("home index");
                        return RedirectToAction("index", "home");
                    }
                    Console.WriteLine("login account");
                    return RedirectToAction("login", "account");
                }
                foreach (var error in result.Errors)
                {
                    Console.WriteLine("a lot of errors");
                    ModelState.AddModelError("Error here", error.Description);
                }
            }*/

            Console.WriteLine("model state not valid");
            return View();



            /*string msg = string.Empty;
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
            }*/
        }


        //---------------------- sign in------------------------

        [HttpPost]
        public async Task<IActionResult> Login(User u, string returnUrl)
        {
            /*if (ModelState.IsValid)
            {
                var result = await
                signInManager.PasswordSignInAsync(u.Email,
                                              u.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }
                ModelState.AddModelError(string.Empty, "Invalid Username or Password");


            }*/
            return View(u);

            /*if (ModelState.IsValid)   //if all input is correct
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
            }*/
        }



        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            //await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
    }
}
