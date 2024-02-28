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
        public int? LatestLessonId { get; set; }
        public DateTime LastAccessed { get; set; }

        //Properties
        [MaxLength(20)]
        public string EnrollmentStatus { get; set; }

        //Relationships
        public TutoringPlatformUser? User { get; set; }
        public Course? Course {  get; set; }
        public Lesson? LatestLesson { get; set; }
    }
}
