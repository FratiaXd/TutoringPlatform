using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutoringPlatform.Shared.Models;

namespace TutoringPlatform.Shared.InputModels
{
    public class QuizInput
    {
        [Required]
        public string Question { get; set; }
        [Required]
        public List<QuizOption> Options { get; set; }
    }
}
