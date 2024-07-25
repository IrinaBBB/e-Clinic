using AutoMapper;
using e_Clinic.DataAccess;
using e_Clinic.DataAccess.Entities;
using e_Clinic.Models.ViewModels.Patient;
using e_Clinic.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace e_Clinic.Web.Controllers
{
    [Authorize]
    public class PatientController : Controller

    {
        private readonly IUnitOfWork _unitOfWork;
   
        public PatientController(IUnitOfWork unitOfWork, ApplicationDbContext context, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {
            var patients = _unitOfWork.Patient.GetAll();
            return View(patients);
        }
        public IActionResult Create()
        {
            return View(new CreatePatientViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePatientViewModel patientViewModel)
        {
            if (ModelState.IsValid)
            {
                //var newPatientUser = new ApplicationUser
                //{
                //    Email = patientViewModel.Email,
                //    UserName = patientViewModel.Email,
                //    Patient = _mapper.Map<Patient>(patientViewModel)
                //};
                //if (patientViewModel?.Password is not null)
                //{
                //    try
                //    {
                //        var result = await _userManager.CreateAsync(newPatientUser, patientViewModel.Password);
                //        return RedirectToAction("Index");
                //    } catch (Exception ex)
                //    {
                //        Console.Write(ex.Message);
                //    }
                //}
                await _unitOfWork.Patient.CreatePatient(patientViewModel);

                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View(patientViewModel);
        }
    }
}
