using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DatabaseProject.Models
{
    public class ExamMark
    {
        [Key]
        public int Id { get; set; }
        public int Marks { get; set; }
        public int StudentId { get; set; } // Foreign key
        public Student? Student { get; set; } // Navigation property
        public int SectionId { get; set; } // Foreign key
        public Section? Section { get; set; } // Navigation property
        public int ExamId { get; set; } // Foreign key
        public Exam? Exam { get; set; } // Navigation property
    }
}
