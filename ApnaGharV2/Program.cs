using ApnaGharV2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ApnaGharV2.Models.Interfaces;
using ApnaGharV2.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// injecting objects
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IPropertyRepository, PropertyRepository>();
builder.Services.AddSingleton<IAmenitiesRepository, AmenitiesRepository>();
builder.Services.AddSingleton<IEnquiryRepository, EnquiryRepository>();
builder.Services.AddSingleton<IAgencyRepository, AgencyRepository>();
builder.Services.AddSingleton<IContactRepository, ContactRepository>();


//------------------------------- Identity----------------------------

//Getting Connection string
string connString = builder.Configuration.GetConnectionString("DefaultConnection");
//Getting Assembly Name
var migrationAssembly = typeof(Program).Assembly.GetName().Name;

// Add services to the container.
builder.Services.AddDbContext<AccountsDbContext>(options =>
           options.UseSqlServer(connString, sql => sql.MigrationsAssembly(migrationAssembly)));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AccountsDbContext>();

//------------------------------- sessions----------------------------
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>      //add sessions middle ware
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);     //to expire session after 10 seconds
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();                                       //use sessions

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");




app.Run();
