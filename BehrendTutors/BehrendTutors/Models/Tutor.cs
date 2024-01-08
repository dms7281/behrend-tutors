namespace BehrendTutors.Models
{
    public class Tutor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public List<Class>? TutoredClasses { get; set; }
    }
}
