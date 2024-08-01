using e_Clinic.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_Clinic.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = ClinicConstants.ROLE_ADMIN)]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
