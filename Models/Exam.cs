using System.ComponentModel.DataAnnotations;

namespace DatabaseProject.Models
{
    public class Exam
    {
        [Key]
        public int ExamId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Place Name is required")]
        public string Place { get; set; }
        [Required(ErrorMessage = "Time is required")]
        public DateTime Time { get; set; }
        public List<ExamMark>? ExamMarks { get; set; }
    }
}
