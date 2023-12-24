using DatabaseProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseProject.Controllers
{
    public class SectionController : Controller, IGenericController<Section>
    {
        AppDbContext _context;

        public SectionController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Add()
        {
            return View(new Section());
        }

        [HttpPost]
        public IActionResult Add(Section entity)
        {
            if (ModelState.IsValid)
            {
                _context.Sections.Add(entity);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Section bilgileri başarıyla eklenmiştir.";
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
            var list = _context.Sections.ToList();
            return View(list);
        }

        public IActionResult Remove(int id)
        {
            var section = _context.Sections.FirstOrDefault(x => x.SectionId == id);
            _context.Sections.Remove(section);
            _context.SaveChanges();
            TempData["Remove"] = section.SectionId;
            TempData["SuccessMessage"] = "Section başarıyla silindi!";
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var section = _context.Sections.FirstOrDefault(x => x.SectionId == id);

            if (section == null)
            {
                // Eğer exam null ise, hata mesajı veya uygun bir işleme stratejisi uygulayın.
                TempData["ErrorMessage"] = "Belirtilen ID'ye sahip sınav bulunamadı.";
                return RedirectToAction("Index");
            }

            return View(section);
        }

        [HttpPost]
        public IActionResult Update(Section entity)
        {
            if (ModelState.IsValid)
            {
                var section = _context.Sections.FirstOrDefault(x => x.SectionId == entity.SectionId);

                if (section != null)
                {
                    section.SectionId = entity.SectionId;
                    section.Semester = entity.Semester;
                    section.Year = entity.Year;
                    section.ExamMarks = entity.ExamMarks;
                    section.SecCourses = entity.SecCourses;
                    _context.Sections.Update(section);
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Section bilgileri başarıyla değiştirilmiştir.";
                    return RedirectToAction("Index");
                }

            }

            else
            {
                TempData["ErrorMessage"] = "Güncellenmek istenen section bulunamadı.";
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
