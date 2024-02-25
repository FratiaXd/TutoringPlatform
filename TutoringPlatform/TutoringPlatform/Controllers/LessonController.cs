using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TutoringPlatform.Services;
using TutoringPlatform.Shared.Interfaces;
using TutoringPlatform.Shared.Models;

namespace TutoringPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService lessonService;

        public LessonController(ILessonService lessonService)
        {
            this.lessonService = lessonService;
        }

        [HttpGet("Course-Lessons/{id}/{userId}")]
        public async Task<ActionResult<IEnumerable<Lesson>>> GetLessonsForCourseAsync(int id, string userId)
        {
            var lessons = await lessonService.GetAllCourseLessonsQAndLAsync(id, userId);
            return Ok(lessons);
        }
    }
}
