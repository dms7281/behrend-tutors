using BehrendTutors.Migrations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BehrendTutors.Models
{

    public enum TutorSessionType
    {
        Individual,
        DropIns,
        Group
    }

    public class TutorSession
    {
        public int id { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime SessionDateTime { get; set; }
        public Tutor? Tutor { get; set; }
        public Class? Class { get; set; }
        public string? StudentEmail { get; set; }
        public TutorSessionType SessionType { get; set; }

        [NotMapped]
        public int SelectedClassId { get; set; }

        [NotMapped]
        public int TutorIdSession { get; set; }

    }
}
