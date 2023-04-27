using ApnaGharV2.Models.Interfaces;
using ApnaGharV2.Models.Classes;

namespace ApnaGharV2.Models.Repositories
{
    public class ContactRepository:IContactRepository
    {
        string dbHost;
        string dbName;
        string dbPassword;
        string connectionString;
        public ContactRepository()
        {
             /*dbHost = Environment.GetEnvironmentVariable("DB_HOST");
             dbName = Environment.GetEnvironmentVariable("DB_NAME");
             dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
             connectionString = $"Data Source={dbHost};Initial Catalog={dbName};User ID=sa;Password={dbPassword}";*/
        }

        public bool AddContact(Contact c)
        {
            var context = new AccountsDbContext();

            /*c.CreatedByUserId = "1";
            c.CreatedDate = System.DateTime.Now;*/

            context.Contacts.Add(c);
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
        /*public bool RemoveContact(Contact c)
        {
            var context = new AccountsDbContext();

            *//*c.CreatedByUserId = "1";
            c.CreatedDate = System.DateTime.Now;*//*

            context.Contacts.Add(c);
            int n = context.SaveChanges2(0);
            if (n > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }*/
        public List<Contact> GetAllContacts()
        {
            List<Contact> contacts = new List<Contact>();
            var context = new AccountsDbContext();

            var query = context.Users;      //get all
            foreach (var contact in query)
            {
                Contact c = new Contact();

                c.Name = contact.Name;
                c.Email = contact.Email;
                c.PhoneNumber = contact.PhoneNumber;
                c.Subject = c.Subject;
                c.Message = c.Message;

                contacts.Add(c);
            }
            return contacts;
        }

    }
}
