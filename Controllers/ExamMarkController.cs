using DatabaseProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseProject.Controllers
{
    public class ExamMarkController : Controller, IGenericController<ExamMark>
    {
        AppDbContext _context;

        public ExamMarkController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Add()
        {
            return View(new ExamMark());
        }

        [HttpPost]
        public IActionResult Add(ExamMark entity)
        {
            // ExamId'nin geçerli bir ExamId'ye karşılık geldiğini kontrol et
            if (!_context.Exams.Any(e => e.ExamId == entity.ExamId))
            {
                ModelState.AddModelError("ExamId", "Invalid ExamId. Please select a valid ExamId.");
                return View(entity);
            }
            if (!_context.Students.Any(e => e.StudentId == entity.StudentId))
            {
                ModelState.AddModelError("StudentId", "Invalid StudentId. Please select a valid StudentId.");
                return View(entity);
            }
            if (!_context.Sections.Any(e => e.SectionId == entity.SectionId))
            {
                ModelState.AddModelError("SectionId", "Invalid SectionId. Please select a valid SectionId.");
                return View(entity);
            }
            if (ModelState.IsValid)
            {
                _context.ExamMarks.Add(entity);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Exam Marks bilgileri başarıyla eklenmiştir.";
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
            var list = _context.ExamMarks.ToList();
            return View(list);
        }

        public IActionResult Remove(int id)
        {
            var examMark = _context.ExamMarks.FirstOrDefault(x => x.Id == id);
            _context.ExamMarks.Remove(examMark);
            _context.SaveChanges();
            TempData["Remove"] = examMark.Id;
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var examMark = _context.ExamMarks.FirstOrDefault(x => x.Id == id);

            if (examMark == null)
            {
                // Eğer exam null ise, hata mesajı veya uygun bir işleme stratejisi uygulayın.
                TempData["ErrorMessage"] = "Belirtilen ID'ye sahip sınav bulunamadı.";
                return RedirectToAction("Index");
            }

            return View(examMark);
        }

        [HttpPost]
        public IActionResult Update(ExamMark entity)
        {
            if (ModelState.IsValid)
            {
                var examMark = _context.ExamMarks.FirstOrDefault(x => x.Id == entity.Id);

                if (examMark != null)
                {
                    examMark.Id = entity.Id;
                    examMark.Marks = entity.Marks;
                    examMark.StudentId = entity.StudentId;
                    examMark.SectionId = entity.SectionId;
                    examMark.ExamId = entity.ExamId;
                    _context.ExamMarks.Update(examMark);
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Exam Mark başarıyla değiştirilmiştir.";
                    return RedirectToAction("Index");
                }

            }

            else
            {
                TempData["ErrorMessage"] = "Güncellenmek istenen sınav bulunamadı.";
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
