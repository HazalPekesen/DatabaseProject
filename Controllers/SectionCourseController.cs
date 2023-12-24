using DatabaseProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseProject.Controllers
{
    public class SectionCourseController : Controller, IGenericController<SectionCourse>
    {
        AppDbContext _context;

        public SectionCourseController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Add()
        {
            return View(new SectionCourse());
        }

        [HttpPost]
        public IActionResult Add(SectionCourse entity)
        {
            _context.SecCourses.Add(entity);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Section Course bilgileri başarıyla eklenmiştir.";
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult View()
        {
            var list = _context.SecCourses.ToList();
            return View(list);
        }

        public IActionResult Remove(int id)
        {
            throw new NotImplementedException();
        }

        public IActionResult Update(int id)
        {
            throw new NotImplementedException();
        }

        public IActionResult Update(SectionCourse entity)
        {
            throw new NotImplementedException();
        }
    }
}
