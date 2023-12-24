using DatabaseProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseProject.Controllers
{
    public class CourseController : Controller, IGenericController<Course>
    {
        AppDbContext _context;

        public CourseController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Add()
        {
            return View(new Course());
        }

        [HttpPost]
        public IActionResult Add(Course entity)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Add(entity);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Course bilgileri başarıyla eklenmiştir.";
                return RedirectToAction("Index");
            }
            return View(entity);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult View()
        {
            var list = _context.Courses.ToList();
            return View(list);
        }

        public IActionResult Remove(int id)
        {
            var course = _context.Courses.FirstOrDefault(x => x.CourseId == id);
            _context.Courses.Remove(course);
            _context.SaveChanges();
            TempData["Remove"] = course.CourseId;
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var course = _context.Courses.FirstOrDefault(x => x.CourseId == id);

            if (course == null)
            {
                // Eğer exam null ise, hata mesajı veya uygun bir işleme stratejisi uygulayın.
                TempData["ErrorMessage"] = "Belirtilen ID'ye sahip course bulunamadı.";
                return RedirectToAction("Index");
            }

            return View(course);
        }

        [HttpPost]
        public IActionResult Update(Course entity)
        {
            if (ModelState.IsValid)
            {
                var course = _context.Courses.FirstOrDefault(x => x.CourseId == entity.CourseId);

                if (course != null)
                {
                    course.CourseId = entity.CourseId;
                    course.Title = entity.Title;
                    course.Credits = entity.Credits;
                    course.SecCourses = entity.SecCourses;
                    _context.Courses.Update(course);
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Course bilgileri başarıyla değiştirilmiştir.";
                    return RedirectToAction("Index");
                }

            }

            else
            {
                TempData["ErrorMessage"] = "Güncellenmek istenen course bulunamadı.";
            }


            // Hataları ve ModelState'i incele
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                Console.WriteLine($"Error: {error.ErrorMessage}");
            }
            return View(entity);
        }
    }
}
