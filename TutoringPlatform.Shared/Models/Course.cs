using System.ComponentModel.DataAnnotations;

namespace TutoringPlatform.Shared.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        //Properties
        [Required, MaxLength(80)]
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int Duration { get; set; }
        public string? AccessLevel { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsActive { get; set; }
        [MaxLength(20)]
        public string? Status { get; set; }

        //Relationships
        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
