using AutoMapper;
using e_Clinic.DataAccess.Entities;
using e_Clinic.Models.ViewModels.DoctorViewModels;
using e_Clinic.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using e_Clinic.Models.ViewModels.Patient;

namespace e_Clinic.Web.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DoctorController(IUnitOfWork unitOfWork, IMapper mapper)
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
            var pageCount = await _unitOfWork.Doctor.GetPageCount(pageSize);

            if (pageCount == 0)
            {
                return RedirectToAction("NotFoundMessage");
            }

            // Makes sure that pageNumber is not out of range and won't return an empty list
            if (pageNumber <= 0 || pageNumber > pageCount)
            {
                return RedirectToAction("Index", new { pageNumber = 1 });
            }

            
            var viewModel = new DoctorListViewModel
            {
                Doctors = await _unitOfWork.Doctor.GetPagedListAsync(pageNumber.Value, pageSize),
                TotalPages = pageCount,
                CurrentPage = pageNumber.Value,
            };

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View(new CreateDoctorViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateDoctorViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var newUser = _mapper.Map<Doctor>(viewModel);

                if (viewModel.Password != null)
                {
                    await _unitOfWork.Doctor.CreateUserWithIdentityAsync(newUser, viewModel.Password);
                }

                TempData["success"] = "Doctor created successfully";
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            var doctor = _unitOfWork.Doctor.GetFirstOrDefault(p => p.Id == id);
            var viewModel = _mapper.Map<EditDoctorViewModel>(doctor);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditDoctorViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var doctor = _mapper.Map<Doctor>(viewModel);

            var doctorFromDb = _unitOfWork.Doctor.GetFirstOrDefault(p => p.Id == doctor.Id);
            if (doctorFromDb == null)
            {
                return NotFound();
            }

            _mapper.Map(viewModel, doctorFromDb);

            _unitOfWork.Doctor.Update(doctorFromDb);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var doctor = _unitOfWork.Doctor.GetFirstOrDefault(p => p.Id == id);
            var viewModel = _mapper.Map<DeleteDoctorViewModel>(doctor);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DeleteDoctorViewModel viewModel)
        {
            var user = _unitOfWork.Doctor.GetFirstOrDefault(u => u.Id == viewModel.Id);
            var result = await _unitOfWork.Doctor.RemoveUserWithIdentityAsync(user);
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
