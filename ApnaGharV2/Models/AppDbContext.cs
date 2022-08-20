using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ApnaGharV2.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .Property(e => e.Name)
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(50)
                .IsRequired(true);

            modelBuilder.Entity<ApplicationUser>()
                .Property(e => e.City)
                .HasColumnType("nvarchar(256)")
                .IsRequired(true);

            modelBuilder.Entity<ApplicationUser>()
                .Property(e => e.RegisterAs)
                .HasColumnType("nvarchar(256)")
                .IsRequired(true);

        }
    }


}
