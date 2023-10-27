using e_Clinic.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_Clinic.Web.Controllers
{
    [Authorize]
    public class PatientController : BaseController
    {
        public PatientController(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<IActionResult> Index()
        {
            var patients = await UnitOfWork.Patients.GetPatientListAsync();
            return View(patients);
        }        
    }
}
