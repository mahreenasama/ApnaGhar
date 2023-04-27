using Microsoft.Data.SqlClient;
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


        public List<Property> SearchBar(string city, string size)
        {
            var context = new AccountsDbContext();
            List<Property> propList = new List<Property>();

            int sizee = int.Parse(size);

            var query = context.Properties.Where(p => p.City == city).Where(p => p.Size == sizee);

                     //get all
            foreach (var property in query)
            {
                Property p = new Property();

                p.Id = property.Id;
                p.Purpose = property.Purpose;
                p.Type = property.Type;
                //p.SubType = property.SubType;
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
                //p.UserId = property.UserId;

                propList.Add(p);
            }
            return propList;
        }
        public bool AddProperty(AddPropertyViewModel p, List<IFormFile> PropertyImages, int adderId)
        {
            p.Prop.Purpose = p.Purpose;
            p.Prop.Type = p.Type;
            p.Prop.ImagesCount = PropertyImages.Count();

            var context = new AccountsDbContext();

            /*p.Prop.CreatedBy = 1;
            p.Prop.CreatedDate = System.DateTime.Now;                //adding additive information
            p.Prop.ModifiedBy = 1;
            p.Prop.ModifiedDate = System.DateTime.Now;*/

            //---------save images-----------
            string wwwPath = this.Environment.WebRootPath;
            string path = Path.Combine(wwwPath, "images");
            //-----------Type-----------
            if (p.Prop.Type == "Home")
            {
                path = Path.Combine(path, "properties/Home");    //properties folder
            }
            else if (p.Prop.Type == "Plot")
            {
                path = Path.Combine(path, "properties/Plot");    //properties folder
            }
            else if (p.Prop.Type == "Commercial")
            {
                path = Path.Combine(path, "properties/Commercial");    //properties folder
            }
            //----------------------add in DB--------------
            

            Console.WriteLine("---------------img count: " + p.Prop.ImagesCount);
            context.Properties.Add(p.Prop);

            int n = context.SaveChanges2(adderId);

            if (n > 0)
            {
                //--- now save amenities ----
                var pId = (int)context.Properties.Max(pp => pp.Id);  //maximum id , lastest property added

                /*p.Amen.Id = pId;        //asigning fereign key
                context.Amenities.Add(p.Amen);
                int nn = context.SaveChanges2(adderId);*/

                //if (nn > 0)
                //{
                    //-----------check existance-----------
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    Console.WriteLine("pid : " + pId);
                    Console.WriteLine("list size : " + PropertyImages.Count);

                    int c = 1;
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
                //}
                /*else
                {
                    Console.WriteLine("amenities not save");
                    return false;
                }*/
            }
            else
            {
                Console.WriteLine("property not save");
                return false;
            }
        }
        public bool UpdateProperty(Property newData, List<IFormFile> PropertyImages, int id, int changerId)
        {
            var context = new AccountsDbContext();

            Property p = ViewProperty(id);

            p.Purpose = newData.Purpose;
            p.Address = newData.Address;
            p.Title = newData.Title;
            p.Description = newData.Description;
            p.Price = newData.Price;
            p.PriceUnit = newData.PriceUnit;
            p.Size = newData.Size;
            p.SizeUnit = newData.SizeUnit;
            p.Bedrooms = newData.Bedrooms;
            p.Bathrooms = newData.Bathrooms;

            //----update images if entered new---

            if (PropertyImages != null)
            {
                p.ImagesCount = PropertyImages.Count();
                //---------save images-----------
                string wwwPath = this.Environment.WebRootPath;
                string path = Path.Combine(wwwPath, "images");
                //-----------Type-----------
                if (p.Type == "Home")
                {
                    path = Path.Combine(path, "properties/Home");    //properties folder
                }
                else if (p.Type == "Plot")
                {
                    path = Path.Combine(path, "properties/Plot");    //properties folder
                }
                else if (p.Type == "Commercial")
                {
                    path = Path.Combine(path, "properties/Commercial");    //properties folder
                }
                //-----------check existance-----------
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                Console.WriteLine("pid : " + id);
                Console.WriteLine("list size : " + PropertyImages.Count);

                int c = 1;
                foreach (IFormFile file in PropertyImages)
                {
                    using (FileStream stream = new FileStream(
                        Path.Combine(path, $"{id}_{c}.jpg"), FileMode.CreateNew))
                    {
                        Console.WriteLine("file name : " + $"{id}_{c}.jpg");

                        file.CopyTo(stream);
                    }
                    c += 1;
                }
            }
                context.Properties.Update(p);

            int n = context.SaveChanges2(changerId);
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
                    p.ImagesCount = property.ImagesCount;
                    p.UserId = property.UserId;

                }
                return p;  //returning by converting into property
            }
            return null;
        }

        public List<Property> FilterProperties(string city, string purpose, string type)
        {
            
            List<Property> propList = new List<Property>();

            var context = new AccountsDbContext();

            var query = context.Properties.Where(p => p.Type == "type").ToList();

            List<Property> pls= context.Properties.Where(p => p.IsActive == true).ToList();

            Console.WriteLine("count: " + pls.Count());

            List<Property> pls2 = new List<Property>();

            if (city == null && purpose == null && type == null)
            {
                foreach (Property pp in pls)
                {
                        pls2.Add(pp);
                }
            }
            else if (city != null && purpose != null && type != null)
            {
                foreach (Property pp in pls)
                {
                    if (pp.City == city && pp.Purpose == purpose && pp.Type == type)
                    {
                        pls2.Add(pp);
                    }
                }
            }
            else if (city != null && purpose == null && type == null)
            {
                foreach (Property pp in pls)
                {
                    if (pp.City == city)
                    {
                        pls2.Add(pp);
                    }
                }
            }
            else if (city == null && purpose != null && type == null)
            {
                foreach (Property pp in pls)
                {
                    if (pp.Purpose == purpose)
                    {
                        pls2.Add(pp);
                    }
                }
            }
            else if (city == null && purpose == null && type != null)
            {
                foreach (Property pp in pls)
                {
                    if (pp.Type == type)
                    {
                        pls2.Add(pp);
                    }
                }
            }
            else if (city != null && purpose != null && type == null)
            {
                foreach (Property pp in pls)
                {
                    if (pp.City == city && pp.Purpose == purpose)
                    {
                        pls2.Add(pp);
                    }
                }
            }
            else if (city != null && purpose == null && type != null)
            {
                foreach (Property pp in pls)
                {
                    if (pp.City == city && pp.Type == type)
                    {
                        pls2.Add(pp);
                    }
                }
            }
            else if (city == null && purpose != null && type != null)
            {
                foreach (Property pp in pls)
                {
                    if (pp.Purpose == purpose && pp.Type==type)
                    {
                        pls2.Add(pp);
                    }
                }
            }



            return pls2;
        }
        public List<Property> ViewAllProperties(int num)
        {
            List<Property> propList = new List<Property>();

            var context = new AccountsDbContext();

            if (num == 0)
            {
                var query = context.Properties;      //get all
                foreach (var property in query)
                {
                    Property p = new Property();

                    p.Id = property.Id;
                    p.Purpose = property.Purpose;
                    p.Type = property.Type;
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
                    p.UserId = property.UserId;
                    p.ImagesCount = property.ImagesCount;

                    propList.Add(p);
                }
            }
            if (num == -1)
            {
                var query = context.Properties.Where(p => p.Type == "Home");      //get all
                foreach (var property in query)
                {
                    Property p = new Property();

                    p.Id = property.Id;
                    p.Purpose = property.Purpose;
                    p.Type = property.Type;
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
                    p.UserId = property.UserId;
                    p.ImagesCount = property.ImagesCount;

                    propList.Add(p);
                }
            }
            if (num == -2)
            {
                var query = context.Properties.Where(p => p.Type == "Plot");      //get all
                foreach (var property in query)
                {
                    Property p = new Property();

                    p.Id = property.Id;
                    p.Purpose = property.Purpose;
                    p.Type = property.Type;
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
                    p.UserId = property.UserId;
                    p.ImagesCount = property.ImagesCount;

                    propList.Add(p);
                }
            }
            if (num == -3)
            {
                var query = context.Properties.Where(p => p.Type == "Commercial");      //get all
                foreach (var property in query)
                {
                    Property p = new Property();

                    p.Id = property.Id;
                    p.Purpose = property.Purpose;
                    p.Type = property.Type;
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
                    p.UserId = property.UserId;
                    p.ImagesCount = property.ImagesCount;

                    propList.Add(p);
                }
            }
            return propList;
        }
        
    }
}
