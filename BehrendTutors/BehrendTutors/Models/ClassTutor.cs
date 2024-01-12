namespace BehrendTutors.Models
{
    public class ClassTutor
    {
        public int ClassId { get; set; }
        public Class? Class { get; set; }

        public int TutorId { get; set; }
        public Tutor? Tutor { get; set; }
    }
}
