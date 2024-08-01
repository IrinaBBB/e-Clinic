using Microsoft.EntityFrameworkCore;
using e_Clinic.Repository;
using e_Clinic.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using e_Clinic.Repository.Mapping.Resolvers;
using e_Clinic.DataAccess.Entities;
using e_Clinic.DataAccess;
using e_Clinic.DataAccess.DbInitializer;
using e_Clinic.Hubs;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("eClinicDb") ?? throw new InvalidOperationException("Connection string 'eClinicDb' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient<AgeResolver>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddSignalR();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default_with_area",
    pattern: "{area:exists}/{controller}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<UserHub>("/hubs/userCount");
app.MapHub<DeathlyHallowsHub>("/hubs/deathlyhallows");

var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
try
{
    //context.Database.Migrate();
    await DbInitializer.Initialize(context, userManager, roleManager);
} catch (Exception ex)
{
    logger.LogError(ex, "A problem occurred during migration");
}
app.Run();
