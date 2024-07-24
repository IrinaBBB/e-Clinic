using Microsoft.EntityFrameworkCore;
using e_Clinic.Repository;
using e_Clinic.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using e_Clinic.Repository.Mapping.Resolvers;
using e_Clinic.DataAccess.Entities;
using e_Clinic.DataAccess;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("IdentityContextConnection") ?? throw new InvalidOperationException("Connection string 'IdentityContextConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient<AgeResolver>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
//try
//{
//    var context = services.GetRequiredService<ApplicationContext>();
//    var logger = services.GetService<ILogger<ApplicationContext>>()!;
//    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
//    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
//    await context.Database.MigrateAsync();
//    await SeedData.SeedAsync(context, logger);
//    //await Seed.SeedUsers(userManager, roleManager);
//}
//catch (Exception ex)
//{
//    var logger = services.GetService<ILogger<Program>>();
//    logger!.LogError(ex, "An error occurred during migration");
//}
app.Run();
