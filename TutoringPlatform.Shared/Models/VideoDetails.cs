using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutoringPlatform.Shared.Models
{
    public class VideoDetails
    {
        public string? title { get; set; }
        public string? thumbnail { get; set; }
        public DateTimeOffset? publishedAt { get; set; }
    }
}