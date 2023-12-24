using DatabaseProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseProject.Controllers
{
    public class ExamController : Controller, IGenericController<Exam>
    {
        AppDbContext _context;

        public ExamController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult View()
        {
            var list = _context.Exams.ToList();
            return View(list);
        }

        public IActionResult Add()
        {
            return View(new Exam());
        }

        [HttpPost]
        public IActionResult Add(Exam entity)
        {
            if (ModelState.IsValid)
            {
                _context.Exams.Add(entity);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Sınav bilgileri başarıyla eklenmiştir.";
                return RedirectToAction("Index");
            }
            return View(entity);
        }

        public IActionResult Update(int id)
        {
            var exam = _context.Exams.FirstOrDefault(x => x.ExamId == id);

            if (exam == null)
            {
                // Eğer exam null ise, hata mesajı veya uygun bir işleme stratejisi uygulayın.
                TempData["ErrorMessage"] = "Belirtilen ID'ye sahip sınav bulunamadı.";
                return RedirectToAction("Index");
            }

            return View(exam);
        }

        [HttpPost]
        public IActionResult Update(Exam entity)
        {
            if (ModelState.IsValid)
            {
                var exam = _context.Exams.FirstOrDefault(x => x.ExamId == entity.ExamId);

                if (exam != null)
                {
                    exam.ExamId = entity.ExamId;
                    exam.Name = entity.Name;
                    exam.Place = entity.Place;
                    exam.Time = entity.Time;
                    exam.ExamMarks = entity.ExamMarks;
                    _context.Exams.Update(exam);
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Sınav bilgileri başarıyla değiştirilmiştir.";
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

        public IActionResult Remove(int id)
        {
            var exam = _context.Exams.FirstOrDefault(x => x.ExamId == id);
            _context.Exams.Remove(exam);
            _context.SaveChanges();
            TempData["Remove"] = exam.ExamId;
            return RedirectToAction("Index");
        }
    }
}
