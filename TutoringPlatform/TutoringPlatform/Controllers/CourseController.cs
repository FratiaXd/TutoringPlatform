using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TutoringPlatform.Shared.Interfaces;
using TutoringPlatform.Shared.Models;

namespace TutoringPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService courseService;

        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet("Published-Courses")]
        public async Task<ActionResult<IEnumerable<Course>>> GetAllPublishedCoursesAsync()
        {
            var publishedCourses = await courseService.GetPublishedCoursesAsync();
            return Ok(publishedCourses);
        }

        [HttpGet("Single-Course/{id}")]
        public async Task<ActionResult<IEnumerable<Course>>> GetSingleCourseAsync(int id)
        {
            var course = await courseService.GetCourseByIdAsync(id);
            return Ok(course);
        }

        [HttpGet("Lesson-Id/{courseId}/{lessonOrder}")]
        public async Task<ActionResult<IEnumerable<int>>> GetLessonIdByOrderAsync(int courseId, int lessonOrder)
        {
            var lessonIdNum = await courseService.GetLessonIdForCourseAsync(courseId, lessonOrder);
            return Ok(lessonIdNum);
        }
    }
}
