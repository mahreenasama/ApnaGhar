using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ApnaGharV2.Models.Interfaces;
using ApnaGharV2.Models.Classes;

namespace ApnaGharV2.Models.Repositories
{
    public class UserRepository:IUserRepository
    {
        static int changerId;       //who is doing all these changings
        //static string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ApnaGhar_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private IWebHostEnvironment Environment;
        public UserRepository(IWebHostEnvironment _e)
        {
            Environment = _e;       //inject service using constructor
        }

        public User AddUser(User user, IFormFile profileImage, int adderId)
        {
            var context = new AccountsDbContext();

            //---------save images-----------
            string wwwPath = this.Environment.WebRootPath;
            string path = Path.Combine(wwwPath, "images");
            //-----------Type-----------
            if (user.Role=="Admin")
            {
                path = Path.Combine(path, "profiles/Admin");//properties folder
            }
            else if (user.Role == "User")
            {
                path = Path.Combine(path, "profiles/User");    //properties folder
            }
           
            context.Users.Add(user);
            int n = context.SaveChanges2(adderId);
            if (n > 0)
            {
                //-----------check existance, saving its profile image
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                int recentUserId = context.Users.Max(u => u.Id);        //got this user id


                Console.WriteLine("recentUserId : " + recentUserId);
                Console.WriteLine("image data : " + profileImage);
                Console.WriteLine("image string"+ profileImage.ToString());
                Console.WriteLine("image length"+profileImage.Length);


                using (FileStream stream = new FileStream(
                        Path.Combine(path, $"{recentUserId}.jpg"), FileMode.Create))
                {
                    Console.WriteLine("file name : " + $"{recentUserId}.jpg");

                    profileImage.CopyTo(stream);
                }
                
                //--- now get the user to return its info
                var query = context.Users.Where(u => u.Id == recentUserId);

                User u = new User();

                foreach (var uu in query)
                {
                    u.Id = user.Id;
                    u.Email = user.Email;
                    u.Name = user.Name;
                    u.PhoneNumber = user.PhoneNumber;
                    u.City = user.City;
                }

                return u;  //returnig newly created user
            }
            else
            {
                return null;
            }
        }
        public bool UpdateUser(User newData, IFormFile ProfileImage, int id, int changerId)
        {
            Console.WriteLine("update user------------------");

          


            var context = new AccountsDbContext();

            User user = SearchUser(id);  //getting the user

            user.Email = newData.Email;
            user.Name = newData.Name;
            user.PhoneNumber = newData.PhoneNumber;
            user.City = newData.City;
            //user.Role = newData.Role;
            user.IsActive = true;

            Console.WriteLine("new mail: " + user.Email);
            Console.WriteLine("new name: " + user.Name);
            Console.WriteLine("new num: " + user.PhoneNumber);
            Console.WriteLine("new cty: " + user.City);

            //---------save images-----------

            if (ProfileImage != null)
            {
                Console.WriteLine("pic not null------------------");

                string wwwPath = this.Environment.WebRootPath;
                string path = Path.Combine(wwwPath, "images");
                //-----------Type-----------
                if (user.Role == "Admin")
                {
                    path = Path.Combine(path, "profiles/Admin");//properties folder
                }
                else if (user.Role == "User")
                {
                    path = Path.Combine(path, "profiles/User");    //properties folder
                }
                //-----------check existance, saving its profile image
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (FileStream stream = new FileStream(
                           Path.Combine(path, $"{id}.jpg"), FileMode.Create))
                {
                    Console.WriteLine("file name : " + $"{id}.jpg");

                    ProfileImage.CopyTo(stream);
                }
            }

            //----
            context.Users.Update(user);
            int n = context.SaveChanges2(changerId);
          
            if (n > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            return false;
        }
        public bool DeleteUser(int id)
        {
            var context = new AccountsDbContext();

            var user = (User)context.Users.Where(u => u.Id == id);  //getting the user

            user.IsActive = false;

            int n = context.SaveChanges2(0);
            if (n > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public User SearchUser(int id)
        {
            var context = new AccountsDbContext();

            Console.WriteLine("------------ id--------" + id);

            var query = context.Users.Where(u => u.Id == id);  //getting the agency

            Console.WriteLine("------------ q count--------"+query.Count());

            /*User u2 = new User();
            u2.Id = user.Id;
            u2.Name = user.Name;
            u2.Email = user.Email;
            u2.City = user.City;
            u2.PhoneNumber = user.PhoneNumber;

            Console.WriteLine("------------ search user--------");
            return u2;*/

            if (query.Count() > 0)     //means agency found
            {
                User u = new User();
                foreach (var user in query)
                {
                    u.Id = user.Id;
                    u.Email = user.Email;
                    u.Name = user.Name;
                    u.PhoneNumber = user.PhoneNumber;
                    u.City = user.City;
                    u.Role = user.Role;
                }
                Console.WriteLine("------------ search user--------");
                    return u;  //returning by converting into agency
            }
            return null;
        }
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            var context = new AccountsDbContext();

            var query = context.Users.Where(u => u.IsActive == true);      //get all
            foreach (var user in query)
            {
                User u = new User();

                u.Id = user.Id;
                u.Email = user.Email;
                u.Name = user.Name;
                u.PhoneNumber = user.PhoneNumber;
                u.City = user.City;
                u.Role = user.Role;
                u.CreatedByUserId = user.CreatedByUserId;
                u.CreatedDate = user.CreatedDate;
                u.LastModifiedUserId = user.LastModifiedUserId;
                u.LastModifiedDate = user.LastModifiedDate;
                u.IsActive = user.IsActive;

                users.Add(u);
            }
            return users;
        }
        public bool LoginUser(User user)
        {
            /*var context = new AccountsDbContext();

            Func<User,bool> func=(u) =>{
                if(u.Email==user.Email && u.Password == user.Password)
                {
                    return true;
                }
                return false;
            };
            var query = context.Users.Where(func);

            if(query.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }*/
            return false;
        }
        public bool UserAlreadyExist(User user)
        {
            var context = new AccountsDbContext();

            var query = context.Users.Where(u => u.Email == user.Email);


            if (query.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
