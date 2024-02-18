using System.ComponentModel.DataAnnotations;

namespace TutoringPlatform.Shared.Models
{
    public class Lesson
    {
        [Key]
        public int LessonId { get; set; }
        [Required]
        public string LessonTitle { get; set; }
        public string? LessonDescription { get; set; }
        public int LessonOrder { get; set; }
        public bool IsAutograded { get; set; }
        public string? LessonVideoUrl { get; set; }
        public string? LessonImageUrl { get; set; }
        public string? LessonContent { get; set; }
        public bool IsAssessed { get; set; }

        //Relationship
        public int CourseKey { get; set; }
        public Course Course { get; set; }
    }
}
