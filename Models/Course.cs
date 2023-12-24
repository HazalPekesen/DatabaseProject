using System.ComponentModel.DataAnnotations;

namespace DatabaseProject.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Credits is required")]
        public int Credits { get; set; }
        public List<SectionCourse>? SecCourses { get; set; } // Navigation Property for SecCourses
    }
}
