using Microsoft.AspNetCore.Mvc;

namespace DatabaseProject.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
