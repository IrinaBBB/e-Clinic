using AutoMapper;
using e_Clinic.DataAccess.Entities;
using e_Clinic.Models.ViewModels.Patient;
using e_Clinic.Models.ViewModels.PatientViewModels;
using e_Clinic.Repository.IRepository;
using e_Clinic.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_Clinic.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = ClinicConstants.ROLE_ADMIN)]
    public class PatientController : Controller

    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PatientController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int? pageNumber)
        {
            if (pageNumber is null)
            {
                return RedirectToAction("Index", new { pageNumber = 1 });
            }

            var pageSize = 5;
            var pageCount = await _unitOfWork.Patient.GetPageCount(pageSize);

            if (pageCount == 0)
            {
                return RedirectToAction("NotFoundMessage");
            }

            // Makes sure that pageNumber is not out of range and won't return an empty list
            if (pageNumber <= 0 || pageNumber > pageCount)
            {
                return RedirectToAction("Index", new { pageNumber = 1 });
            }


            var viewModel = new PatientListViewModel
            {
                Patients = await _unitOfWork.Patient.GetPagedListAsync(pageNumber.Value, pageSize),
                TotalPages = pageCount,
                CurrentPage = pageNumber.Value,
            };

            return View(viewModel);
        }
        public IActionResult Info()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View(new CreatePatientViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePatientViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var newUser = _mapper.Map<e_Clinic.DataAccess.Entities.Patient>(viewModel);

                if (viewModel.Password != null)
                {
                    await _unitOfWork.Patient.CreateUserWithIdentityAsync(newUser, viewModel.Password);
                }

                TempData["success"] = "Patient created successfully";
                return RedirectToAction("Index");
            }
            return View(viewModel);
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

            var patient = _mapper.Map<e_Clinic.DataAccess.Entities.Patient>(viewModel);

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

        public IActionResult Delete(int id)
        {
            var patient = _unitOfWork.Patient.GetFirstOrDefault(p => p.Id == id);
            var patientViewModel = _mapper.Map<DeletePatientViewModel>(patient);
            return View(patientViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DeletePatientViewModel viewModel)
        {
            var user = _unitOfWork.Patient.GetFirstOrDefault(u => u.Id == viewModel.Id);
            var result = await _unitOfWork.Patient.RemoveUserWithIdentityAsync(user);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public IActionResult NotFoundMessage()
        {
            return View();
        }
    }
}
