using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TutoringPlatform.Services;
using TutoringPlatform.Shared.Interfaces;
using TutoringPlatform.Shared.Models;

namespace TutoringPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonProgressController : ControllerBase
    {
        private readonly ILessonProgressService lessonProgressService;

        public LessonProgressController(ILessonProgressService lessonProgressService)
        {
            this.lessonProgressService = lessonProgressService;
        }

        [HttpPost("Add-Lesson-Progress")]
        public async Task<ActionResult<IEnumerable<LessonProgress>>> AddLessonProgressAsync(LessonProgress lessonProgress)
        {
            var newProgress = await lessonProgressService.AddLessonProgressRecordAsync(lessonProgress);
            return Ok(newProgress);
        }
    }
}
