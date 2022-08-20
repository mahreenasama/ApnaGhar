using Microsoft.Data.SqlClient;

namespace ApnaGharV2.Models
{
    public class PropertyRepository
    {
        static string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ApnaGharDB_Final;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public bool AddProperty(Property p)
        {
            SqlConnection conn = new SqlConnection(connStr);

            //---------- saving images -----------


            //--------getting logged-in user id ?------------

            int OwnerID = 1;
            string query = $"insert into Properties values ({p.Purpose},{p.Type},{p.SubType},{p.City},{p.Area},{p.Address},{p.Title},{p.Description},{p.Price}{p.PriceUnit},{p.Size},{p.SizeUnit}{p.Bathrooms},{p.ImagesPath},{OwnerID})";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            int n = cmd.ExecuteNonQuery();


            if (n > 0)
            {
                conn.Close();

                return true;
            }
            conn.Close();

            return false;
        }

        public static List<Property> ViewAllProperties()
        {
            List<Property> ps = new List<Property>();

            SqlConnection conn = new SqlConnection(connStr);
            string query = "select * from Properties";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Property p = new Property();

                p.Id = (int)dr[0];
                p.Purpose = (string)dr[1];
                p.Type = (string)dr[2];
                p.SubType = (string)dr[3];
                p.City = (string)dr[4];
                p.Area = (string)dr[5];
                p.Address = (string)dr[6];
                p.Title = (string)dr[7];
                p.Description = (string)dr[8];
                p.Price = (int)dr[9];
                p.PriceUnit = (string)dr[10];
                p.Size = (int)dr[11];
                p.SizeUnit = (string)dr[12];
                p.Bedrooms = (int)dr[13];
                p.Bathrooms = (int)dr[14];
                p.ImagesPath = (string)dr[15];
                p.OwnerId = (int)dr[16];

                ps.Add(p);
            }
            conn.Close();
            return ps;
        }

    }
}
