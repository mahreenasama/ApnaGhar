using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ApnaGharV2.Models
{
    public class UserRepository
    {
        public static List<User>? users;

        //static string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ApnaGhar_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public static bool SaveUser(User user)
        {
            var context = new ApnaGharV2_DBContext();
            context.Users.Add(user);
            int n = context.SaveChanges();
            if (n > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool LoginUser(User user)
        {
            var context = new ApnaGharV2_DBContext();

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
            }
        }
        public static bool UserAlreadyExist(User user)
        {
            var context = new ApnaGharV2_DBContext();

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
        public static List<User> GetAllUsers()
        {
            var context = new ApnaGharV2_DBContext();

            users = new List<User>();

            var query = context.Users;      //get all
            foreach(var user in query)
            {
                User u = new User();

                u.Id = user.Id;
                u.Email = user.Email;
                u.Password = user.Password;
                u.ConfirmPassword = user.ConfirmPassword;
                u.Name = user.Name;
                u.PhoneNumber = user.PhoneNumber;
                u.Country = user.Country;
                u.City = user.City;
                u.Role = user.Role;

                users.Add(u);
            }
            
            return users;
        }
    }
}
