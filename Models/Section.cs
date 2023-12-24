using System.ComponentModel.DataAnnotations;

namespace DatabaseProject.Models
{
    public class Section
    {
        [Key]
        public int SectionId { get; set; }
        [Required(ErrorMessage = "Semester is required")]
        public string Semester { get; set; }
        [Required(ErrorMessage = "Year is required")]
        public int Year { get; set; }
        public List<SectionCourse>? SecCourses { get; set; } // Navigation Property for SecCourses
        public List<ExamMark>? ExamMarks { get; set; } // Navigation Property for Exams
    }
}
