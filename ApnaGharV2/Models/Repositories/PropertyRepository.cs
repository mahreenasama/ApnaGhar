﻿using Microsoft.Data.SqlClient;
using ApnaGharV2.Models.Interfaces;
using ApnaGharV2.Models.ViewModels;
using ApnaGharV2.Models.Classes;

namespace ApnaGharV2.Models.Repositories
{
    public class PropertyRepository:IPropertyRepository
    {
        private IWebHostEnvironment Environment;
        public PropertyRepository(IWebHostEnvironment _e)
        {
            Environment = _e;       //inject service using constructor
        }
        //static string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ApnaGharDB_Final;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public bool AddProperty(PropertyViewModel p, List<IFormFile> PropertyImages)
        {
            var context = new AccountsDbContext();

            /*p.Prop.CreatedBy = 1;
            p.Prop.CreatedDate = System.DateTime.Now;                //adding additive information
            p.Prop.ModifiedBy = 1;
            p.Prop.ModifiedDate = System.DateTime.Now;*/

            //---------save images-----------
            string wwwPath = this.Environment.WebRootPath;
            string path = Path.Combine(wwwPath, "images");
            //-----------Type-----------
            if (p.Prop.Type == "Homes")
            {
                path = Path.Combine(path, "properties/homes");    //properties folder
            }
            else if (p.Prop.Type == "Plots")
            {
                path = Path.Combine(path, "properties/plots");    //properties folder
            }
            else if (p.Prop.Type == "Commercial")
            {
                path = Path.Combine(path, "properties/commercial");    //properties folder
            }
            p.Prop.ImagesPath = path;        //set path
            //----------------------add in DB--------------
            context.Properties.Add(p.Prop);
            context.Amenities.Add(p.Amen);
            int n = context.SaveChanges();

            if (n > 0)
            {
                //-----------check existance-----------
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var pp = p.Prop;
                var pId = (int)context.Properties.Max(pp => pp.Id);  //maximum id , lastest property added

                Console.WriteLine("pid : " + pId);
                Console.WriteLine("list size : " + PropertyImages.Count);

                int c = 0;
                foreach (IFormFile file in PropertyImages)
                {
                    using (FileStream stream = new FileStream(
                        Path.Combine(path, $"{pId}_{c}.jpg"), FileMode.CreateNew))
                    {
                        Console.WriteLine("file name : " + $"{pId}_{c}.jpg");

                        file.CopyTo(stream);
                    }
                    c += 1;
                }
                return true;
            }
            else
            {
                Console.WriteLine("else came");
                return false;
            }
        }
        public bool UpdateProperty(int id, Property newData)
        {
            var context = new AccountsDbContext();

            var property = (Property)context.Properties.Where(p => p.Id == id);

            property.Id = newData.Id;
            property.Purpose = newData.Purpose;
            property.Type = newData.Type;
            property.SubType = newData.SubType;
            property.City = newData.City;
            property.Area = newData.Area;
            property.Address = newData.Address;
            property.Title = newData.Title;
            property.Description = newData.Description;
            property.Price = newData.Price;
            property.PriceUnit = newData.PriceUnit;
            property.Size = newData.Size;
            property.SizeUnit = newData.SizeUnit;
            property.Bedrooms = newData.Bedrooms;
            property.Bathrooms = newData.Bathrooms;
            property.ImagesPath = newData.ImagesPath;

            /*property.ModifiedBy = 1;
            property.ModifiedDate = System.DateTime.Now;*/

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
        public bool DeleteProperty(int id)
        {
            var context = new AccountsDbContext();

            var property = context.Properties.Where(p => p.Id == id);  //getting the property

            context.Properties.Remove((Property)property);

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
        public Property ViewProperty(int id)
        {
            var context = new AccountsDbContext();

            var query = context.Properties.Where(p => p.Id == id);  //getting the property

            if (query.Count() > 0)     //means property found
            {
                Property p = new Property();

                foreach (var property in query)
                {
                    p.Id = property.Id;
                    p.Purpose = property.Purpose;
                    p.Type = property.Type;
                    p.SubType = property.SubType;
                    p.City = property.City;
                    p.Area = property.Area;
                    p.Address = property.Address;
                    p.Title = property.Title;
                    p.Description = property.Description;
                    p.Price = property.Price;
                    p.PriceUnit = property.PriceUnit;
                    p.Size = property.Size;
                    p.SizeUnit = property.SizeUnit;
                    p.Bedrooms = property.Bedrooms;
                    p.Bathrooms = property.Bathrooms;
                    p.ImagesPath = property.ImagesPath;
                    //p.UserId = property.UserId;
                }
                return p;  //returning by converting into property
            }
            return null;
        }
        public List<Property> ViewAllProperties()
        {
            List<Property> propList = new List<Property>();

            var context = new AccountsDbContext();

            var query = context.Properties;      //get all
            foreach (var property in query)
            {
                Property p = new Property();

                p.Id = property.Id;
                p.Purpose = property.Purpose;
                p.Type = property.Type;
                p.SubType = property.SubType;
                p.City = property.City;
                p.Area = property.Area;
                p.Address = property.Address;
                p.Title = property.Title;
                p.Description = property.Description;
                p.Price = property.Price;
                p.PriceUnit = property.PriceUnit;
                p.Size = property.Size;
                p.SizeUnit = property.SizeUnit;
                p.Bedrooms = property.Bedrooms;
                p.Bathrooms = property.Bathrooms;
                p.ImagesPath = property.ImagesPath;
                //p.UserId = property.UserId;

                propList.Add(p);
            }
            return propList;
        }

    }
}
