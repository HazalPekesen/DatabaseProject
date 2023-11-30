using System.ComponentModel.DataAnnotations;

namespace DatabaseProject.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public List<SectionCourse> SecCourses { get; set; } // Navigation Property for SecCourses
    }
}
