namespace BehrendTutors.Models
{
    public class TutorClass
    {
        public int TutorId { get; set; }
        public Tutor? Tutor { get; set; }

        public int ClassId { get; set; }
        public Class? Class { get; set; }
    }
}
