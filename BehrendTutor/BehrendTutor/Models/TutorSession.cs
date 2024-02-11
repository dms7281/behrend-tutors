namespace BehrendTutor.Models
{
    public class TutorSession
    {
        public int Id { get; set; }
        public int TutorId { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public DateTime SessionDateTime { get; set; }
        public int TutorSessionTypeId { get; set; }
        public int SessionLocationType { get; set; }
    }
}
