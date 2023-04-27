 using Microsoft.AspNetCore.Mvc;
using ApnaGharV2.Models;
using ApnaGharV2.Models.Repositories;
using ApnaGharV2.Models.Interfaces;
using ApnaGharV2.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace ApnaGharV2.Controllers;

public class AccountController : Controller
{
    /* public IActionResult Index()
     {
         return View();
     }*/

    private readonly UserManager<ApplicationUser> userManager;
    private readonly SignInManager<ApplicationUser> signInManager;
    private readonly IUserRepository userRepo;    //reference of interface at class level


    public AccountController(UserManager<ApplicationUser> userManager,
                         SignInManager<ApplicationUser> signInManager,
                             IUserRepository userRepo)
    {
        this.userManager = userManager;     //manages user add,delete
        this.signInManager = signInManager;   //manages signin, signout
        this.userRepo = userRepo;       //refernce of interface at class level
    }


    [HttpGet]
    public IActionResult Register()
    {
        RegisterViewModel vm = new RegisterViewModel();
        return View(vm);
    }
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            //--- first adding account ---
            var user = new ApplicationUser
            {
                UserName = model.Username,
                EmailConfirmed = true,
                LockoutEnabled = false,
                Role = "User",
            };
            var result = await userManager.CreateAsync(user,
                                                     model.Password);

            if (result.Succeeded)
            {
                //how to save its login credentials ????
                var loggedinUser = await userManager.FindByNameAsync(model.Username);

                var loggedinUserRole = loggedinUser.Role;
                var loggedinUserUname = loggedinUser.UserName;
                var loggedinUserId = loggedinUser.UserId;

                Console.WriteLine("role " + loggedinUserRole);
                Console.WriteLine("loggedinUserUname " + loggedinUserUname);
                Console.WriteLine("logged in id " + loggedinUserId);

                //go to admin dashboard, + sending loggid in used id via cookies(saving in cookies)

                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(1);      //expire after one day
                if (!HttpContext.Request.Cookies.ContainsKey("loggedinUserRole"))
                {
                    HttpContext.Response.Cookies.Append("loggedinUserRole", loggedinUserRole.ToString(), options);
                }
                if (!HttpContext.Request.Cookies.ContainsKey("loggedinUserUname"))
                {
                    HttpContext.Response.Cookies.Append("loggedinUserUname", loggedinUserUname.ToString(), options);
                }
                if (!HttpContext.Request.Cookies.ContainsKey("loggedinUserId"))
                {
                    HttpContext.Response.Cookies.Append("loggedinUserId", loggedinUserId.ToString(), options);
                }
                ViewBag.loggedinUserRole = loggedinUserRole;
                ViewBag.loggedinUserUname = loggedinUserUname;
                ViewBag.loggedinUserId = loggedinUserId;                    //to access in view

                if (signInManager.IsSignedIn(User))
                {
                    return RedirectToAction("index", "home");
                }
                return RedirectToAction("login", "account");
            }
            ModelState.AddModelError("", "Please enter required fields");
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
        return View();
    }


    //---------------------- sign in------------------------
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await
            signInManager.PasswordSignInAsync(model.Username,
                                          model.Password, false, false);
            if (result.Succeeded)
            {
                //how to save its login credentials ????
                var loggedinUser = await userManager.FindByNameAsync(model.Username);

                var loggedinUserRole = loggedinUser.Role;
                var loggedinUserUname = loggedinUser.UserName;
                var loggedinUserId = loggedinUser.UserId;

                Console.WriteLine("role "+ loggedinUserRole);
                Console.WriteLine("loggedinUserUname " + loggedinUserUname);
                Console.WriteLine("logged in id " + loggedinUserId);

                //go to admin dashboard, + sending loggid in used id via cookies(saving in cookies)

                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(1);      //expire after one day
                if (!HttpContext.Request.Cookies.ContainsKey("loggedinUserRole"))
                {
                    HttpContext.Response.Cookies.Append("loggedinUserRole", loggedinUserRole.ToString(),options);
                }
                if (!HttpContext.Request.Cookies.ContainsKey("loggedinUserUname"))
                {
                    HttpContext.Response.Cookies.Append("loggedinUserUname", loggedinUserUname.ToString(), options);
                }
                if (!HttpContext.Request.Cookies.ContainsKey("loggedinUserId"))
                {
                    HttpContext.Response.Cookies.Append("loggedinUserId", loggedinUserId.ToString(), options);
                }
                ViewBag.loggedinUserRole = loggedinUserRole;
                ViewBag.loggedinUserUname = loggedinUserUname;
                ViewBag.loggedinUserId = loggedinUserId;                    //to access in view

                if (loggedinUserRole=="Admin")
                {
                    Console.WriteLine("admin");

                    return RedirectToAction("index", "admin");
                }
                else if(loggedinUserRole == "User")
                {
                    return RedirectToAction("index", "home");   //go to user dashboard
                }
            }
            ModelState.AddModelError(string.Empty, "Invalid Username or Password");
        }

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();

        HttpContext.Response.Cookies.Delete("loggedinUserUname");   //deleting all cookies when logout
        HttpContext.Response.Cookies.Delete("loggedinUserId");

        if (HttpContext.Request.Cookies["loggedinUserRole"].ToString() == "Admin")
        {
            HttpContext.Response.Cookies.Delete("loggedinUserRole");
            return RedirectToAction("login", "account");
        }
        else if (HttpContext.Request.Cookies["loggedinUserRole"].ToString() == "User")
        {
            HttpContext.Response.Cookies.Delete("loggedinUserRole");
            return RedirectToAction("index", "home");
        }
        return RedirectToAction("FoF", "home");
    }

    
}
