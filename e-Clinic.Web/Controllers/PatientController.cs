using AutoMapper;
using e_Clinic.DataAccess;
using e_Clinic.DataAccess.Entities;
using e_Clinic.Models.ViewModels.Patient;
using e_Clinic.Models.ViewModels.PatientViewModels;
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
        private readonly IMapper _mapper;
   
        public PatientController(IUnitOfWork unitOfWork, ApplicationDbContext context, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public IActionResult Info()
        {
            return View();
        }
        
        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            var pageSize = 5;
            var pageCount = await _unitOfWork.Patient.GetPageCount(pageSize);
            if (pageNumber > pageCount || pageNumber <= 0)
            {
                return RedirectToAction("Index", new { pageNumber = 1 });
            }

            var patientListViewModel = new PatientListViewModel
            {
                Patients = await _unitOfWork.Patient.GetPagedListAsync(pageNumber, pageSize),
                TotalPages = pageCount,
                CurrentPage = pageNumber,
            };
            return View(patientListViewModel);
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
               
                await _unitOfWork.Patient.CreatePatient(patientViewModel);

                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View(patientViewModel);
        }

        public IActionResult Edit(int id)
        {
            var patient = _unitOfWork.Patient.GetFirstOrDefault(p => p.Id == id);
            var viewModel = _mapper.Map<EditPatientViewModel>(patient);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditPatientViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var patient = _mapper.Map<Patient>(viewModel);

            var patientFromDb = _unitOfWork.Patient.GetFirstOrDefault(p => p.Id == patient.Id);
            if (patientFromDb == null)
            {
                return NotFound();
            }

            _mapper.Map(viewModel, patientFromDb); 

            _unitOfWork.Patient.Update(patientFromDb);
            _unitOfWork.Save();

            return RedirectToAction("Index"); 
        }
    }
}
