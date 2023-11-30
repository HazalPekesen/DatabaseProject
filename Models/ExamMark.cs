namespace DatabaseProject.Models
{
    public class ExamMark
    {
        public int ExamMarkId { get; set; }
        public int Marks { get; set; }
        public int StudentId { get; set; } // Foreign key
        public Student Student { get; set; } // Navigation property
        public int SectionId { get; set; } // Foreign key
        public Section Section { get; set; } // Navigation property
        public int ExamId { get; set; } // Foreign key
        public Exam Exam { get; set; } // Navigation property
    }
}
