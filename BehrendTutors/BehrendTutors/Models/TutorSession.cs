using System.ComponentModel.DataAnnotations;

namespace BehrendTutors.Models
{
    public class TutorSession
    {
        public int id { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime SessionDateTime { get; set; }
        public Class? Class { get; set; }
        public Tutor? Tutor { get; set; }
        public string? StudentEmail { get; set; }

    }
}
