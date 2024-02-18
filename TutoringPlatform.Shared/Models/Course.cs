using System.ComponentModel.DataAnnotations;

namespace TutoringPlatform.Shared.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int Duration { get; set; }
        public string? AccessLevel { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsActive { get; set; }

        //Relationship
        public ICollection<Lesson> Lessons { get; } = new List<Lesson>();
    }
}
