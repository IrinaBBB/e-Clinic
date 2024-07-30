using AutoMapper;
using e_Clinic.DataAccess.Entities;
using e_Clinic.Models.ViewModels.StaffViewModels;
using e_Clinic.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using e_Clinic.Models.ViewModels.PatientViewModels;
using Microsoft.AspNetCore.Authorization;
using e_Clinic.Utility;

namespace e_Clinic.Web.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    [Authorize(Roles = ClinicConstants.ROLE_ADMIN)]
    public class StaffController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StaffController(IUnitOfWork unitOfWork, IMapper mapper)
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
            var pageCount = await _unitOfWork.Staff.GetPageCount(pageSize);

            if (pageCount == 0)
            {
                return RedirectToAction("NotFoundMessage");
            }

            // Makes sure that pageNumber is not out of range and won't return an empty list
            if (pageNumber <= 0 || pageNumber > pageCount)
            {
                return RedirectToAction("Index", new { pageNumber = 1 });
            }


            var viewModel = new StaffListViewModel
            {
                StaffMembers = await _unitOfWork.Staff.GetPagedListAsync(pageNumber.Value, pageSize),
                TotalPages = pageCount,
                CurrentPage = pageNumber.Value,
            };

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View(new CreateStaffViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateStaffViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var newUser = _mapper.Map<StaffMember>(viewModel);

                if (viewModel.Password != null)
                {
                    await _unitOfWork.Staff.CreateUserWithIdentityAsync(newUser, viewModel.Password);
                }

                TempData["success"] = "Staff created successfully";
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            var staff = _unitOfWork.Staff.GetFirstOrDefault(p => p.Id == id);
            var viewModel = _mapper.Map<EditStaffViewModel>(staff);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditStaffViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var staff = _mapper.Map<StaffMember>(viewModel);

            var staffFromDb = _unitOfWork.Staff.GetFirstOrDefault(p => p.Id == staff.Id);
            if (staffFromDb == null)
            {
                return NotFound();
            }

            _mapper.Map(viewModel, staffFromDb);

            _unitOfWork.Staff.Update(staffFromDb);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var staff = _unitOfWork.Staff.GetFirstOrDefault(p => p.Id == id);
            var viewModel = _mapper.Map<DeleteStaffViewModel>(staff);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DeleteStaffViewModel viewModel)
        {
            var user = _unitOfWork.Staff.GetFirstOrDefault(u => u.Id == viewModel.Id);
            var result = await _unitOfWork.Staff.RemoveUserWithIdentityAsync(user);
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
