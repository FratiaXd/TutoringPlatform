using System.ComponentModel.DataAnnotations;

namespace TutoringPlatform.Shared.Models
{
    public class LessonProgress
    {
        [Key]
        public int LessonProgressId { get; set; }

        //Foreign keys
        public string UserId { get; set; }
        public int LessonId { get; set; }

        //Properties
        public string? QuizGrade { get; set; }
        public string? SubmittedAssignment { get; set; }
        public string? TutorFeedback { get; set; }
        [MaxLength(20)]
        public string? LessonStatus { get; set; }
        [MaxLength(20)]
        public string? FeedbackStatus { get; set; }
        public DateTime FeedbackTimeStamp { get; set; }

        //Relationships
        public TutoringPlatformUser? User { get; set; }
        public Lesson? Lesson { get; set; }
    }
}
