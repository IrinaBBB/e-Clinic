using Microsoft.AspNetCore.Mvc;

namespace e_Clinic.Web.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
