using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DatabaseProject.Models
{
    public class ExamMark
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Marks is required")]
        public int Marks { get; set; }

        [Required(ErrorMessage = "Student Id is required")]
        public int StudentId { get; set; } // Foreign key

        [Required(ErrorMessage = "Section Id is required")]
        public int SectionId { get; set; } // Foreign key

        [Required(ErrorMessage = "Exam Id is required")]
        public int ExamId { get; set; } // Foreign key

        public Student? Student { get; set; } // Navigation property
        public Section? Section { get; set; } // Navigation property
        public Exam? Exam { get; set; } // Navigation property
    }
}
