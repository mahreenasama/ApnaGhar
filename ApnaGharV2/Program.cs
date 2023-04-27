using ApnaGharV2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ApnaGharV2.Models.Interfaces;
using ApnaGharV2.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//-------docker--------
/*builder.Host.ConfigureWebHostDefaults(webBuilder =>
{
    webBuilder.UseUrls("http://*:80");
});*/


//------------ database context dependency injection---------------
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
var connectionString = $"Data Source={dbHost};Initial Catalog={dbName};User ID=sa;Password={dbPassword}";
builder.Services.AddDbContext<AccountsDbContext>(options => options.UseSqlServer(connectionString));

//------------------------------- Identity----------------------------

//Getting Connection string
//string connString = builder.Configuration.GetConnectionString("DefaultConnection");
//Getting Assembly Name
var migrationAssembly = typeof(Program).Assembly.GetName().Name;

// Add services to the container.
builder.Services.AddDbContext<AccountsDbContext>(options =>
           options.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationAssembly)));

/*builder.Services.AddDbContext<AccountsDbContext>(options=>
            options.use)*/

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AccountsDbContext>();


// injecting objects
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IPropertyRepository, PropertyRepository>();
builder.Services.AddSingleton<IEnquiryRepository, EnquiryRepository>();
builder.Services.AddSingleton<IContactRepository, ContactRepository>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//------------------------------- sessions----------------------------
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>      //add sessions middle ware
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);     //to expire session after 10 seconds
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

//---------------- auto mappers ----------------
builder.Services.AddAutoMapper(typeof(Program));




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

/*app.MapControllerRoute(
    name: "admin",
    pattern: "{controller=Admin}/{action=Index}/{id}");*/

/*app.MapControllerRoute(
    name: "admin",
    pattern: "{admin}/{index}/{id}",
    defaults: new { controller = "admin", action = "Index" }
);*/
app.Run();
