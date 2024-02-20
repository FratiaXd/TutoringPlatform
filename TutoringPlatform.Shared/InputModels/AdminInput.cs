using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutoringPlatform.Shared.InputModels
{
    public class AdminInput
    {
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";

        [DataType(DataType.Password)]
        public string AdminPassword { get; set; } = "";
    }
}
