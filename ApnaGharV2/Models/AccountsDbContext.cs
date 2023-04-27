using ApnaGharV2.Models.Classes;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace ApnaGharV2.Models
{
    public class AccountsDbContext:IdentityDbContext<ApplicationUser>
    {

       


        //constructors
        public AccountsDbContext()
        {
            //Database.Migrate();
            /*try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreator != null)
                {
                    if (!databaseCreator.CanConnect()) databaseCreator.Create();
                    if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }*/

        }
       
        public AccountsDbContext(DbContextOptions<AccountsDbContext> options) : base(options)
        {
           try
           {
               var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
               if (databaseCreator != null)
               {
                   if (!databaseCreator.CanConnect()) databaseCreator.Create();
                   if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
               }
           }
           catch (Exception ex)
           {
               Console.WriteLine(ex.Message);
           }
        }

        //creating new tables
        public DbSet<User> Users { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Enquiry> Enquiries { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public static int changerId;

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Console.WriteLine("overrided");

            if (!optionsBuilder.IsConfigured)
            {
                var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
                var dbName = Environment.GetEnvironmentVariable("DB_NAME");
                var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
                var connectionString = $"Data Source={dbHost};Initial Catalog={dbName};User ID=sa;Password={dbPassword};Trusted_Connection=True;ConnectRetryCount=0";
                //optionsBuilder.UseSqlServer($"Server = {dbHost}; Database = {dbName}; User = sa; Password = {dbPassword}");

                //optionsBuilder.UseSqlServer(connectionString, options => options.EnableRetryOnFailure());

                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ApnaGharV2_DB_New");
                //optionsBuilder.UseSqlServer(@"Server = apnagharv2db; Database = ApnaGharDockerDB; User = sa; Password = password@12345#;");
                //optionsBuilder.UseSqlServer(@"Server = localhost, 1440; Database = master; User = sa; Password =Docker123!;");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<ApplicationUser>()
               .Property(e => e.Role)
               .HasMaxLength(10);                   //admin, user, agent

        }
        //--------------------save changes override-------------
        public int SaveChanges2(int chngrId)
        {
            changerId = chngrId;
            return SaveChanges() ;               //calling this method here
        }
        public override int SaveChanges()
        {
            var tracker = ChangeTracker;
            foreach (var entry in tracker.Entries())
            {
                if (entry.Entity is FullAuditModel)
                {
                    var UserEntity = entry.Entity as FullAuditModel;
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            UserEntity.CreatedDate = DateTime.Now;
                            UserEntity.CreatedByUserId = changerId.ToString();
                            UserEntity.IsActive = true;

                            break;
                        case EntityState.Deleted:
                        case EntityState.Modified:
                            UserEntity.LastModifiedDate = DateTime.Now;
                            UserEntity.LastModifiedUserId = changerId.ToString();
                            break;
                        default:
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}
