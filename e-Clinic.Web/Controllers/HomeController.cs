using e_Clinic.DataAccess.Entities;
using e_Clinic.Utility;
using e_Clinic.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace e_Clinic.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            if (User.IsInRole(ClinicConstants.ROLE_ADMIN))
            {
                return RedirectToAction("Index", "Doctor", new { area = "Admin" });
            } 
            else if (User.IsInRole(ClinicConstants.ROLE_STAFF))
            {
                return RedirectToAction("Index", "Home", new { area = "Manager" });
            } 
            else if (User.IsInRole(ClinicConstants.ROLE_DOCTOR))
            {
                return RedirectToAction("Index", "Home", new { area = "Doctor" });
            } 
            else if (User.IsInRole(ClinicConstants.ROLE_PATIENT))
            {
                return RedirectToAction("Index", "Home", new { area = "Patient" });
            } 
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}