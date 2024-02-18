using System.ComponentModel.DataAnnotations;

namespace TutoringPlatform.Shared.Models
{
    public class QuizQuestion
    {
        [Key]
        public int QuizQuestionId { get; set; }

        //Foreign keys
        public int QuizId { get; set; }

        //Properties
        public string Question { get; set; }

        //Relationships
        public Quiz Quiz { get; set; }
        public ICollection<QuizOption> QuizOptions { get; set; } = new List<QuizOption>();
    }
}
