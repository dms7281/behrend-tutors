namespace BehrendTutors.Models
{
    public class Class
    {
        public int id { get; set; }
        public string? Subject { get; set; }
        public int CourseNum { get; set; }
        public int SectionNum { get; set; }
        public string? ClassTitle { get; set; }
        public int ClassNum { get; set; }
        public ICollection<TutorClass>? TutorClasses { get; set; }
    }
}