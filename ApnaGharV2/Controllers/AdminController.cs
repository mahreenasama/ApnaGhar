using Microsoft.AspNetCore.Mvc;
using ApnaGharV2.Models;
using ApnaGharV2.Models.ViewModels;
using ApnaGharV2.Models.Repositories;
using ApnaGharV2.Models.Interfaces;
using ApnaGharV2.Models.Classes;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using AutoMapper;

namespace ApnaGharV2.Controllers
{
    public class AdminController : Controller
    {
        private static int loggedinAdminId;
        private static string loggedinAdminUname, loggedinAdminRole;

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IMapper _mapper;

        private readonly IUserRepository userRepo;    //reference of interface at class level
        private readonly IPropertyRepository propertyRepo;    //reference of interface at class level
        private readonly IEnquiryRepository enquiryRepo;    //reference of interface at class level
        private readonly IContactRepository contactRepo;    //reference of interface at class level

        public AdminController(UserManager<ApplicationUser> userManager,
                         SignInManager<ApplicationUser> signInManager,
                         IMapper mapper,
            IUserRepository userRepo,
            IPropertyRepository propertyRepo,
            IEnquiryRepository enquiryRepo, 
            IContactRepository contactRepo)
        {
            this.userManager = userManager;     //manages user add,delete
            this.signInManager = signInManager;   //manages signin, signout
            this._mapper=mapper;

            this.userRepo = userRepo;       //refernce of interface at class level
            this.propertyRepo = propertyRepo;
            this.enquiryRepo = enquiryRepo;
            this.contactRepo = contactRepo;


            Console.WriteLine("---------- admin counstrutor called --------------");
            Console.WriteLine("id is: " + loggedinAdminId);
           

        }

        //--------------------dashboard------------------------

        public IActionResult Index()      //receiving id of lggedin admin
        {
            Console.WriteLine("---------- admin index called --------------");

            if (!HttpContext.Request.Cookies.ContainsKey("loggedinUserId"))
            {
                //if cookies have expired
                return RedirectToAction("login", "account");
            }
            else
            {
                ViewBag.loggedinUserRole = HttpContext.Request.Cookies["loggedinUserRole"].ToString();
                ViewBag.loggedinUserUname = HttpContext.Request.Cookies["loggedinUserUname"].ToString();
                ViewBag.loggedinUserId = HttpContext.Request.Cookies["loggedinUserId"].ToString();

                loggedinAdminId = int.Parse(ViewBag.loggedinUserId);
                loggedinAdminUname = ViewBag.loggedinUserUname;
                loggedinAdminRole = ViewBag.loggedinUserRole;

                return View("dashboard");
            }
        }
        public IActionResult ProfilePage()      //receiving id of lggedin admin
        {
            if (!HttpContext.Request.Cookies.ContainsKey("loggedinUserId"))
            {
                //if cookies have expired
                return RedirectToAction("login", "account");
            }
            else
            {
                ViewBag.loggedinUserRole = HttpContext.Request.Cookies["loggedinUserRole"].ToString();
                ViewBag.loggedinUserUname = HttpContext.Request.Cookies["loggedinUserUname"].ToString();
                ViewBag.loggedinUserId = HttpContext.Request.Cookies["loggedinUserId"].ToString();

                return View();
            }
        }
        //--------------------users------------------------
        [HttpGet]
        public IActionResult AddUser()
        {
            if (!HttpContext.Request.Cookies.ContainsKey("loggedinUserId"))
            {
                //if cookies have expired
                return RedirectToAction("login", "account");
            }
            else
            {
                ViewBag.loggedinUserRole = HttpContext.Request.Cookies["loggedinUserRole"].ToString();
                ViewBag.loggedinUserUname = HttpContext.Request.Cookies["loggedinUserUname"].ToString();
                ViewBag.loggedinUserId = HttpContext.Request.Cookies["loggedinUserId"].ToString();

                RegisterViewModel vm = new RegisterViewModel();
                return View(vm);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(RegisterViewModel model, IFormFile ProfileImage)
        {
            if (!HttpContext.Request.Cookies.ContainsKey("loggedinUserId"))
            {
                //if cookies have expired
                return RedirectToAction("login", "account");
            }
            else
            {
                ViewBag.loggedinUserRole = HttpContext.Request.Cookies["loggedinUserRole"].ToString();
                ViewBag.loggedinUserUname = HttpContext.Request.Cookies["loggedinUserUname"].ToString();
                ViewBag.loggedinUserId = HttpContext.Request.Cookies["loggedinUserId"].ToString();

                //--- first add account---
                if (ModelState.IsValid)
                {
                    Console.WriteLine(model.Username);
                    Console.WriteLine(model.Password);
                    Console.WriteLine(model.ConfirmPassword);
                    Console.WriteLine("role is:" + model.Role);
                    Console.WriteLine(model.User.Name);
                    Console.WriteLine(model.User.Email);
                    Console.WriteLine(model.User.PhoneNumber);
                    Console.WriteLine(model.User.City);
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
                        //-- now add user info all
                        model.User.Role = model.Role;           //assigning same role
                        User recentUser = userRepo.AddUser(model.User, ProfileImage, loggedinAdminId);    //sending id

                        if (user != null)
                        {
                            //--- now add userID in accouts table ---
                            var userAccount = await userManager.FindByNameAsync(model.Username);  //finds by username

                            Console.WriteLine(userAccount);

                            Console.WriteLine("id is:" + recentUser.Id);
                            Console.WriteLine("cd is:" + recentUser.CreatedDate);
                            Console.WriteLine("cdi is:" + recentUser.CreatedByUserId);
                            Console.WriteLine("md is:" + recentUser.LastModifiedDate);
                            Console.WriteLine("mdi is:" + recentUser.LastModifiedUserId);
                            Console.WriteLine("active is:" + recentUser.IsActive);

                            userAccount.UserId = recentUser.Id;
                            userAccount.CreatedByUserId = recentUser.CreatedByUserId;
                            userAccount.CreatedDate = recentUser.CreatedDate;
                            userAccount.LastModifiedUserId = recentUser.LastModifiedUserId;
                            userAccount.LastModifiedDate = recentUser.LastModifiedDate;
                            userAccount.IsActive = recentUser.IsActive;


                            await userManager.UpdateAsync(userAccount);

                            Console.WriteLine("User added successfully");
                            return RedirectToAction("ListUsers", "Admin");  //if add succesfully
                        }
                        Console.WriteLine("account ok but user not");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                Console.WriteLine("model invalid");
                RegisterViewModel vm = new RegisterViewModel();
                return View(vm);
            }
        }
        [HttpGet]
        public IActionResult EditUser(int uid)
        {
            if (!HttpContext.Request.Cookies.ContainsKey("loggedinUserId"))
            {
                //if cookies have expired
                return RedirectToAction("login", "account");
            }
            else
            {
                ViewBag.loggedinUserRole = HttpContext.Request.Cookies["loggedinUserRole"].ToString();
                ViewBag.loggedinUserUname = HttpContext.Request.Cookies["loggedinUserUname"].ToString();
                ViewBag.loggedinUserId = HttpContext.Request.Cookies["loggedinUserId"].ToString();

                Console.WriteLine("id isssss:" + uid);

                /*var userAccount = await userManager.FindByIdAsync(uid.ToString());
                Console.WriteLine("id is:" + userAccount.Id);
                Console.WriteLine("id is:" + userAccount.UserName);
                Console.WriteLine("id is:" + userAccount.PasswordHash);
                Console.WriteLine("id is:" + userAccount.Role);
                Console.WriteLine("cd is:" + userAccount.CreatedDate);
                Console.WriteLine("cdi is:" + userAccount.CreatedByUserId);
                Console.WriteLine("md is:" + userAccount.LastModifiedDate);
                Console.WriteLine("mdi is:" + userAccount.LastModifiedUserId);
                Console.WriteLine("active is:" + userAccount.IsActive);*/


                User u = userRepo.SearchUser(uid);
                Console.WriteLine("id is:" + u.Id);
                Console.WriteLine("id is:" + u.Name);
                Console.WriteLine("id is:" + u.Email);
                Console.WriteLine("id is:" + u.City);
                Console.WriteLine("cd is:" + u.PhoneNumber);

                return View(u);
            }
        }
        [HttpPost]
        public IActionResult EditUser(User u, IFormFile ProfileImage, int uid)
        {
            if (!HttpContext.Request.Cookies.ContainsKey("loggedinUserId"))
            {
                //if cookies have expired
                return RedirectToAction("login", "account");
            }
            else
            {
                ViewBag.loggedinUserRole = HttpContext.Request.Cookies["loggedinUserRole"].ToString();
                ViewBag.loggedinUserUname = HttpContext.Request.Cookies["loggedinUserUname"].ToString();
                ViewBag.loggedinUserId = HttpContext.Request.Cookies["loggedinUserId"].ToString();

                Console.WriteLine("id iiiias:" + uid);
                Console.WriteLine("updated porf:" + ProfileImage);


                if (userRepo.UpdateUser(u, ProfileImage, uid, loggedinAdminId))
                {
                    return RedirectToAction("ListUsers", "Admin");
                }
                return View();
            }
        }
        public IActionResult ListUsers()
        {
            if (!HttpContext.Request.Cookies.ContainsKey("loggedinUserId"))
            {
                //if cookies have expired
                return RedirectToAction("login", "account");
            }
            else
            {
                ViewBag.loggedinUserRole = HttpContext.Request.Cookies["loggedinUserRole"].ToString();
                ViewBag.loggedinUserUname = HttpContext.Request.Cookies["loggedinUserUname"].ToString();
                ViewBag.loggedinUserId = HttpContext.Request.Cookies["loggedinUserId"].ToString();

                List<User> users = userRepo.GetAllUsers();
                return View(users);
            }
        }
        public IActionResult RemoveUser(int uid)
        {
            if (!HttpContext.Request.Cookies.ContainsKey("loggedinUserId"))
            {
                //if cookies have expired
                return RedirectToAction("login", "account");
            }
            else
            {
                ViewBag.loggedinUserRole = HttpContext.Request.Cookies["loggedinUserRole"].ToString();
                ViewBag.loggedinUserUname = HttpContext.Request.Cookies["loggedinUserUname"].ToString();
                ViewBag.loggedinUserId = HttpContext.Request.Cookies["loggedinUserId"].ToString();

                //remove  code
                return RedirectToAction("ListUsers");
            }
        }
        //------------------------------------propeties---------------------------------
        public IActionResult ListProperties()
        {
            if (!HttpContext.Request.Cookies.ContainsKey("loggedinUserId"))
            {
                //if cookies have expired
                return RedirectToAction("login", "account");
            }
            else
            {
                ViewBag.loggedinUserRole = HttpContext.Request.Cookies["loggedinUserRole"].ToString();
                ViewBag.loggedinUserUname = HttpContext.Request.Cookies["loggedinUserUname"].ToString();
                ViewBag.loggedinUserId = HttpContext.Request.Cookies["loggedinUserId"].ToString();

                List<Property> properties = propertyRepo.ViewAllProperties(0);
                List<PropertyViewModel> propertiesViewModel = _mapper.Map<List<PropertyViewModel>>(properties);   //map by automapper
                return View(propertiesViewModel);
            }
        }
        [HttpGet]
        public IActionResult AddProperty()
        {
            if (!HttpContext.Request.Cookies.ContainsKey("loggedinUserId"))
            {
                //if cookies have expired
                return RedirectToAction("login", "account");
            }
            else
            {
                ViewBag.loggedinUserRole = HttpContext.Request.Cookies["loggedinUserRole"].ToString();
                ViewBag.loggedinUserUname = HttpContext.Request.Cookies["loggedinUserUname"].ToString();
                ViewBag.loggedinUserId = HttpContext.Request.Cookies["loggedinUserId"].ToString();

                System.Diagnostics.Debug.WriteLine("outside");
                AddPropertyViewModel pvm = new AddPropertyViewModel();
                return View(pvm);
            }
        }
        [HttpPost]
        public IActionResult AddProperty(AddPropertyViewModel property, List<IFormFile> PropertyImages)
        {
            if (!HttpContext.Request.Cookies.ContainsKey("loggedinUserId"))
            {
                //if cookies have expired
                return RedirectToAction("login", "account");
            }
            else
            {
                ViewBag.loggedinUserRole = HttpContext.Request.Cookies["loggedinUserRole"].ToString();
                ViewBag.loggedinUserUname = HttpContext.Request.Cookies["loggedinUserUname"].ToString();
                ViewBag.loggedinUserId = HttpContext.Request.Cookies["loggedinUserId"].ToString();

                Console.WriteLine("purose --- " + property.Purpose);
                Console.WriteLine("purose --- " + property.Type);


                System.Diagnostics.Debug.WriteLine("outside");
                if (propertyRepo.AddProperty(property, PropertyImages, loggedinAdminId))
                {
                    return RedirectToAction("ListProperties", "Admin");
                    Debug.WriteLine("propety added");
                }
                else
                {
                    Debug.WriteLine("proprty not added");
                }
                return View();
                
            }
        }

        public IActionResult PropertyDetails(int id)
        {
            if (!HttpContext.Request.Cookies.ContainsKey("loggedinUserId"))
            {
                //if cookies have expired
                return RedirectToAction("login", "account");
            }
            else
            {
                ViewBag.loggedinUserRole = HttpContext.Request.Cookies["loggedinUserRole"].ToString();
                ViewBag.loggedinUserUname = HttpContext.Request.Cookies["loggedinUserUname"].ToString();
                ViewBag.loggedinUserId = HttpContext.Request.Cookies["loggedinUserId"].ToString();

                Property p = propertyRepo.ViewProperty(id);
                return View(p);
            }
        }
        [HttpGet]
        public IActionResult EditProperty(int id)
        {
            if (!HttpContext.Request.Cookies.ContainsKey("loggedinUserId"))
            {
                //if cookies have expired
                return RedirectToAction("login", "account");
            }
            else
            {
                ViewBag.loggedinUserRole = HttpContext.Request.Cookies["loggedinUserRole"].ToString();
                ViewBag.loggedinUserUname = HttpContext.Request.Cookies["loggedinUserUname"].ToString();
                ViewBag.loggedinUserId = HttpContext.Request.Cookies["loggedinUserId"].ToString();

                Property p = propertyRepo.ViewProperty(id);
                return View(p);
            }
        }
        [HttpPost]
        public IActionResult EditProperty(Property p, List<IFormFile> PropertyImages, int id, int changerId)
        {
            if (!HttpContext.Request.Cookies.ContainsKey("loggedinUserId"))
            {
                //if cookies have expired
                return RedirectToAction("login", "account");
            }
            else
            {
                ViewBag.loggedinUserRole = HttpContext.Request.Cookies["loggedinUserRole"].ToString();
                ViewBag.loggedinUserUname = HttpContext.Request.Cookies["loggedinUserUname"].ToString();
                ViewBag.loggedinUserId = HttpContext.Request.Cookies["loggedinUserId"].ToString();

                if (propertyRepo.UpdateProperty(p, PropertyImages, id, changerId))
                {
                    return RedirectToAction("ListProperties", "Admin");
                }

                return View();
            }
        }
        public IActionResult RemoveProperty(int pid)
        {
            if (!HttpContext.Request.Cookies.ContainsKey("loggedinUserId"))
            {
                //if cookies have expired
                return RedirectToAction("login", "account");
            }
            else
            {
                ViewBag.loggedinUserRole = HttpContext.Request.Cookies["loggedinUserRole"].ToString();
                ViewBag.loggedinUserUname = HttpContext.Request.Cookies["loggedinUserUname"].ToString();
                ViewBag.loggedinUserId = HttpContext.Request.Cookies["loggedinUserId"].ToString();

                return View();
            }
        }
        //------------------------------------enquiries---------------------------------
        public IActionResult ListEnquiries()
        {
            if (!HttpContext.Request.Cookies.ContainsKey("loggedinUserId"))
            {
                //if cookies have expired
                return RedirectToAction("login", "account");
            }
            else
            {
                ViewBag.loggedinUserRole = HttpContext.Request.Cookies["loggedinUserRole"].ToString();
                ViewBag.loggedinUserUname = HttpContext.Request.Cookies["loggedinUserUname"].ToString();
                ViewBag.loggedinUserId = HttpContext.Request.Cookies["loggedinUserId"].ToString();

                List<Enquiry> enquiries = enquiryRepo.GetAllEnquiries();

                return View(enquiries);
            }
        }
        //------------------------------------contacts---------------------------------
        public IActionResult ListContacts()
        {
            if (!HttpContext.Request.Cookies.ContainsKey("loggedinUserId"))
            {
                //if cookies have expired
                return RedirectToAction("login", "account");
            }
            else
            {
                ViewBag.loggedinUserRole = HttpContext.Request.Cookies["loggedinUserRole"].ToString();
                ViewBag.loggedinUserUname = HttpContext.Request.Cookies["loggedinUserUname"].ToString();
                ViewBag.loggedinUserId = HttpContext.Request.Cookies["loggedinUserId"].ToString();

                List<Contact> contacts = contactRepo.GetAllContacts();

                return View(contacts);
            }
        }
    }
}
