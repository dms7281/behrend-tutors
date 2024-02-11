namespace BehrendTutor.Models
{
    public class Class
    {
        public int Id { get; set; }
        public int SubjectTypeId { get; set; }
        public int CourseNum { get; set; }
        public int SectionNum { get; set; }
        public string? ClassTitle { get; set; }
        public int ClassCode { get; set; }
    }
}
