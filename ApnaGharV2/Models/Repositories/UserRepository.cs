using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ApnaGharV2.Models.Interfaces;

namespace ApnaGharV2.Models
{
    public class UserRepository:IUserRepository
    {
        public static List<User>? users;

        //static string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ApnaGhar_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public bool AddUser(User user)
        {
            var context = new ApnaGharV2_DBContext();

            user.CreatedBy = 1;
            user.CreatedDate = System.DateTime.Now;

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
        public bool UpdateUser(int id, User newData)
        {
            var context = new ApnaGharV2_DBContext();

            var user = (User)context.Users.Where(u => u.UserID == id);  //getting the user

            user.Email = newData.Email;
            user.Password = newData.Password;
            user.ConfirmPassword = newData.ConfirmPassword;
            user.Name = newData.Name;
            user.PhoneNumber = newData.PhoneNumber;
            user.Country = newData.Country;
            user.City = newData.City;
            user.Role = newData.Role;

            user.ModifiedBy = 1;
            user.ModifiedDate = System.DateTime.Now;

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
        public bool DeleteUser(int id)
        {
            var context = new ApnaGharV2_DBContext();

            var user = context.Users.Where(u => u.UserID == id);  //getting the agency

            context.Users.Remove((User)user);

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
        public User SearchUser(int id)
        {
            var context = new ApnaGharV2_DBContext();

            var query = context.Users.Where(u => u.UserID == id);  //getting the agency

            if (query.Count() > 0)     //means agency found
            {
                User u = new User();
                foreach (var user in query)
                {
                    u.UserID = user.UserID;
                    u.Email = user.Email;
                    u.Password = user.Password;
                    u.ConfirmPassword = user.ConfirmPassword;
                    u.Name = user.Name;
                    u.PhoneNumber = user.PhoneNumber;
                    u.Country = user.Country;
                    u.City = user.City;
                    u.Role = user.Role;
                }
                    return u;  //returning by converting into agency
            }
            return null;
        }
        public List<User> GetAllUsers()
        {
            users = new List<User>();

            var context = new ApnaGharV2_DBContext();

            var query = context.Users;      //get all
            foreach (var user in query)
            {
                User u = new User();

                u.UserID = user.UserID;
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
        public bool LoginUser(User user)
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
        public bool UserAlreadyExist(User user)
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
        
    }
}
