using System.ComponentModel.DataAnnotations;

namespace TutoringPlatform.Shared.Models
{
    public class Quiz
    {
        [Key]
        public int QuizId { get; set; }

        //Foreign keys
        public int LessonId { get; set; }

        //Properties
        public string QuizName { get; set; }

        //Relationships
        public Lesson Lesson { get; set; }
        public ICollection<QuizQuestion> QuizQuestions { get; set; } = new List<QuizQuestion>();
    }
}
