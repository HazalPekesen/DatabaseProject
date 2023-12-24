namespace DatabaseProject.Models
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string DeptName { get; set; }
        public int? TotCred { get; set; }
        public List<ExamMark> ExamMarks { get; set; }
    }

}
