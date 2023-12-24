using System.ComponentModel.DataAnnotations;

namespace DatabaseProject.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Department Name is required")]
        public string DeptName { get; set; }
        [Required(ErrorMessage = "Total Credit is required")]
        public int TotCred { get; set; }
        public List<ExamMark>? ExamMarks { get; set; }
    }
}
