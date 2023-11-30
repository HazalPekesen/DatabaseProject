using DatabaseProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseProject.Controllers
{
    public class StudentController : Controller , IGenericController<Student>
    {
        AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Add()
        {
            throw new NotImplementedException();
        }

        public IActionResult Add(Student entity)
        {
            throw new NotImplementedException();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Remove(int id)
        {
            throw new NotImplementedException();
        }

        public IActionResult Update(int id)
        {
            throw new NotImplementedException();
        }

        public IActionResult Update(Student entity)
        {
            throw new NotImplementedException();
        }
    }
}
