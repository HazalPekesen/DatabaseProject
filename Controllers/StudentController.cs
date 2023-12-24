using DatabaseProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseProject.Controllers
{
    public class StudentController : Controller , IGenericController<Student>
    {
        AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult View()
        {
            var studentsWithExamMarks = _context.Students
                .Include(s => s.ExamMarks)
                    .ThenInclude(em => em.Section)
                .Include(s => s.ExamMarks)
                    .ThenInclude(em => em.Exam)
                .ToList();

            // ViewModel'e dönüştürme
            var viewModelList = studentsWithExamMarks.Select(student => new StudentViewModel
            {
                StudentId = student.StudentId,
                Name = student.Name,
                DeptName = student.DeptName,
                TotCred = student.TotCred,
                ExamMarks = student.ExamMarks
            }).ToList();

            return View(viewModelList);
        }


        public IActionResult Add()
        {
            return View(new Student());
        }

        [HttpPost]
        public IActionResult Add(Student entity)
        {
            _context.Students.Add(entity);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Öğrenci bilgileri başarıyla eklenmiştir.";
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            var student = _context.Students.FirstOrDefault(x => x.StudentId == id);
            _context.Students.Remove(student);
            _context.SaveChanges();
            TempData["Remove"] = student.StudentId;
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var student = _context.Students.FirstOrDefault(x => x.StudentId == id);

            if (student == null)
            {
                TempData["ErrorMessage"] = "Belirtilen ID'ye sahip öğrenci bulunamadı.";
                return RedirectToAction("Index");
            }

            return View(student);
        }

        [HttpPost]
        public IActionResult Update(Student entity)
        {
            if (ModelState.IsValid)
            {
                var student = _context.Students.FirstOrDefault(x => x.StudentId == entity.StudentId);

                if (student != null)
                {
                    student.StudentId = entity.StudentId;
                    student.Name = entity.Name;
                    student.DeptName = entity.DeptName;
                    student.TotCred = entity.TotCred;
                    student.ExamMarks = entity.ExamMarks;
                    _context.Students.Update(student);
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Öğrenci bilgileri başarıyla değiştirilmiştir.";
                    return RedirectToAction("Index");
                }
            }

            else
            {
                TempData["ErrorMessage"] = "Güncellenmek istenen öğrenci bulunamadı.";
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
