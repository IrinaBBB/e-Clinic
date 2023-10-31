using e_Clinic.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_Clinic.Web.Controllers
{
    [Authorize]
    public class VisitController : BaseController
    {
        public VisitController(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<IActionResult> Add(int patientId)
        {
            var viewModel = await UnitOfWork.Visits.AddVisitOnGetAsync(patientId);
            if (viewModel != null)
            {
                return View(viewModel);
            } else
            {
                return RedirectToAction("Index", "Patient");
            }
        }        
    }
}

