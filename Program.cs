using MatriculaU_BolanosKevin.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MatriculaU_BolanosKevin.Models;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllersWithViews();

//// Add ApplicationDbContext with SQL Server connection
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

////// Configure Identity
////builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
////    .AddEntityFrameworkStores<ApplicationDbContext>()
////    .AddDefaultTokenProviders();

//builder.Services.AddDefaultIdentity<ApplicationUser>()
//    .AddRoles<IdentityRole>()
//    .AddEntityFrameworkStores<ApplicationDbContext>();



//// Add MVC services
//builder.Services.AddControllersWithViews();

//var app = builder.Build();

//// Seed Roles and Admin User
//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
//    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
//    await DbInitializer.SeedRolesAndAdmin(userManager, roleManager);
//}

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//}
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthentication(); // Enable Authentication
//app.UseAuthorization();  // Enable Authorization

//app.MapRazorPages();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run();


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add ApplicationDbContext with SQL Server connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure Identity
builder.Services.AddDefaultIdentity<ApplicationUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Add Razor Pages (needed for Identity)
builder.Services.AddRazorPages();

// Add MVC services
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Seed Roles and Admin User
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    await DbInitializer.SeedRolesAndAdmin(userManager, roleManager);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Enable Authentication
app.UseAuthorization();  // Enable Authorization

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
