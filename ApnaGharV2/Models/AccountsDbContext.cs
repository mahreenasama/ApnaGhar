using ApnaGharV2.Models.Classes;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApnaGharV2.Models
{
    public class AccountsDbContext:IdentityDbContext<ApplicationUser>
    {
        //creating new tables
        public DbSet<User> Users { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<Enquiry> Enquiries { get; set; }
        public DbSet<Agency> Agencies { get; set; }


        //constructors
        public AccountsDbContext()
        {
        }
        public AccountsDbContext(DbContextOptions<AccountsDbContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
               .Property(e => e.Role)
               .HasMaxLength(10);                   //admin, user, agent

        }
        //--------------------save changes override-------------
        public override int SaveChanges()
        {
            var tracker = ChangeTracker;
            foreach (var entry in tracker.Entries())
            {
                if (entry.Entity is FullAuditModel)
                {
                    var referenceEntity = entry.Entity as Property;
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            referenceEntity.CreatedDate = DateTime.Now;
                            referenceEntity.CreatedByUserId = "1";//hard coded user id

                            break;
                        case EntityState.Deleted:
                        case EntityState.Modified:
                            referenceEntity.LastModifiedDate = DateTime.Now;
                            referenceEntity.LastModifiedUserId = "1";//hard coded user id
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
