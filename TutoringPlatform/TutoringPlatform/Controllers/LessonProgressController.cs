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

        [HttpPost("Submit-Assignment")]
        public async Task<ActionResult<LessonProgress>> SubmitNewAssignmentAsync(LessonProgress lessonProgress)
        {
            var updProgress = await lessonProgressService.SubmitAssignmentAsync(lessonProgress);
            return Ok(updProgress);
        }

        [HttpPost("Submit-Quiz")]
        public async Task<ActionResult<LessonProgress>> SubmitNewQuizAsync(LessonProgress lessonProgress)
        {
            var updProgress = await lessonProgressService.SubmitQuizAsync(lessonProgress);
            return Ok(updProgress);
        }

        [HttpPost("Finish-Lesson")]
        public async Task<ActionResult<LessonProgress>> FinishCurrentLessonAsync(LessonProgress lessonProgress)
        {
            var updProgress = await lessonProgressService.FinishLessonAsync(lessonProgress);
            return Ok(updProgress);
        }
    }
}
