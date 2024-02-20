using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutoringPlatform.Shared.InputModels
{
    public class CourseInput
    {
        [Required, MaxLength(80)]
        public string Title { get; set; }
        [Required, Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? AccessLevel { get; set; }
        [Required]
        public string? ImageUrl { get; set; }
    }
}
