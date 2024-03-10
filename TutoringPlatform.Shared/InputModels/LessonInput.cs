using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutoringPlatform.Shared.InputModels
{
    public class LessonInput
    {
        [Required, MaxLength(50)]
        public string LessonTitle { get; set; }
        [Required]
        public string? LessonDescription { get; set; }
        public int LessonOrder { get; set; }
        public bool IsAutograded { get; set; }
        [Required]
        public string? LessonVideoUrl { get; set; }
        [Required]
        public string? LessonContent { get; set; }
        public bool IsAssessed { get; set; }
    }
}
