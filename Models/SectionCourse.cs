using System.ComponentModel.DataAnnotations;

namespace DatabaseProject.Models
{
    public class SectionCourse
    {
        [Key]
        public int SectionId { get; set; } // Composite key
        public Section Section { get; set; } // Navigation property
        public int CourseId { get; set; } // Composite key
        public Course Course { get; set; } // Navigation property
    }
}
