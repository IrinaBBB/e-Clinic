using e_Clinic.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace e_Clinic.Web.Controllers
{
    public class BaseController : Controller
    {
        public readonly IUnitOfWork UnitOfWork;

        public BaseController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}