using System.ComponentModel.DataAnnotations;

namespace DatabaseProject.Models
{
    public class Exam
    {
        [Key]
        public int ExamId { get; set; }
        public string? Name { get; set; }
        public string? Place { get; set; }
        public DateTime Time { get; set; }
        public List<ExamMark>? ExamMarks { get; set; }
    }
}
