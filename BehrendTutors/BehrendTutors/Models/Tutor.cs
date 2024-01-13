using System.ComponentModel.DataAnnotations.Schema;

namespace BehrendTutors.Models
{
    public class Tutor
    {
        public Tutor()
        {
            TutorClasses = new List<TutorClass>();
            SelectedClassIds = new List<int>();
        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        public ICollection<TutorClass>? TutorClasses { get; set; }

        [NotMapped]
        public List<int>? SelectedClassIds { get; set; }

        [NotMapped]
        public int ClassId { get; set; }
    }
}
