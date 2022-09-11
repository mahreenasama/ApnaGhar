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
        //RegisterViewModel vm = new RegisterViewModel();
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new ApplicationUser
            {
                UserName = model.Username,
                EmailConfirmed = true,
                LockoutEnabled = false,
                Role = model.Role,
            };
            var result = await userManager.CreateAsync(user,
                                                     model.Password);

            if (result.Succeeded)
            {
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
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
    {
        if (ModelState.IsValid)
        {
            var result = await
            signInManager.PasswordSignInAsync(model.Username,
                                          model.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("addproperty", "property");
                /*if (!string.IsNullOrEmpty(returnUrl))
                {
                    
                }
                else
                {
                    return RedirectToAction("Home", "index");
                }*/
            }
            ModelState.AddModelError(string.Empty, "Invalid Username or Password");

        }

        return View(model);
    }



    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return RedirectToAction("index", "home");
    }
}
