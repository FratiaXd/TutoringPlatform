using System.ComponentModel.DataAnnotations;

namespace TutoringPlatform.Shared.Models
{
    public class QuizOption
    {
        [Key]
        public int QuizOptionId { get; set; }

        //Foreign keys
        public int QuizQuestionId { get; set; }

        //Properties
        public string Option { get; set; }
        public bool IsCorrect { get; set; }

        //Relationships
        public QuizQuestion QuizQuestion { get; set; }
    }
}
