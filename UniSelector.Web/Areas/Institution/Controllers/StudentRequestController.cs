using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using UniSelector.DataAccess.Repository.IRepository;
using UniSelector.Models;
using UniSelector.Utility;

namespace UniSelector.Web.Areas.Institution.Controllers
{
    [Area("Institution")]
    [Authorize(Roles = "Institution")]
    public class StudentRequestController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentRequestController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<StudentRequest> objStudentRequestList = _unitOfWork.StudentRequest.GetAll().ToList();
            return View(objStudentRequestList);
        }

        public IActionResult ViewDetails(int? Id)
        {
            StudentRequest studentRequest = _unitOfWork.StudentRequest.Get(u => u.StudentRequestId == Id);
            return View(studentRequest);
        }
        [HttpPost]
        public IActionResult ViewDetails(StudentRequest studentRequest)
        {
            
            return View(studentRequest);
        }
        public IActionResult Accept()
        {

            return View();
        }

        public IActionResult Decline()
        {
            return View();
        }
    }
}
