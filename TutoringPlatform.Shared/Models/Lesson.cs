using System.ComponentModel.DataAnnotations;

namespace TutoringPlatform.Shared.Models
{
    public class Lesson
    {
        [Key]
        public int LessonId { get; set; }

        //Properties
        [Required, MaxLength(50)]
        public string LessonTitle { get; set; }
        public string? LessonDescription { get; set; }
        public int LessonOrder { get; set; }
        public bool IsAutograded { get; set; }
        public string? LessonVideoUrl { get; set; }
        public string? LessonImageUrl { get; set; }
        public string? LessonContent { get; set; }
        public bool IsAssessed { get; set; }

        //Relationships
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public Quiz? Quiz { get; set; }
        public Assignment? Assignment { get; set; }
        public ICollection<LessonProgress> LessonProgresses { get; set; } = new List<LessonProgress>();
    }
}
