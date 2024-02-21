using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutoringPlatform.Shared.InputModels
{
    public class AssignmentInput
    {
        [Required, MaxLength(35)]
        public string TaskName { get; set; }
        [Required]
        public string TaskDescription { get; set; }
    }
}
