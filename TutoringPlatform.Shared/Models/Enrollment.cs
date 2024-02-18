using System.ComponentModel.DataAnnotations;


namespace TutoringPlatform.Shared.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }

        //Foreign keys
        public string UserId { get; set; }
        public int CourseId { get; set; }
        public int? LastestLessonKey { get; set; }

        //Enrollment data
        public string EnrollmentStatus { get; set; }

        //Navigation properties
        public Course Course {  get; set; }
        public Lesson Lesson { get; set; }
    }
}
