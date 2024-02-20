using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutoringPlatform.Shared.InputModels
{
    public class DetailsInput
    {
        [Required, MaxLength(20), RegularExpression(@"^[a-zA-Z]+$")]
        public string? FirstName { get; set; }
        [Required, MaxLength(20), RegularExpression(@"^[a-zA-Z]+$")]
        public string? LastName { get; set; }
        public bool IsAdmin { get; set; }
    }
}
