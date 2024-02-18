using System.ComponentModel.DataAnnotations;

namespace TutoringPlatform.Shared.Models
{
    public class Assignment
    {
        [Key]
        public int AssignmentId { get; set; }

        //Foreign keys
        public int LessonId { get; set; }

        //Properties
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }

        //Relationships
        public Lesson Lesson { get; set; }
    }
}
