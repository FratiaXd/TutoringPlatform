using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TutoringPlatform.Shared.Interfaces;
using TutoringPlatform.Shared.Models;

namespace TutoringPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService enrollmentService;

        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            this.enrollmentService = enrollmentService;
        }

        [HttpPost("Enroll-User")]
        public async Task<ActionResult<IEnumerable<Enrollment>>> EnrollNewUserAsync(Enrollment enrollment)
        {
            var newEnrollment = await enrollmentService.EnrollUserAsync(enrollment);
            return Ok(newEnrollment);
        }

        [HttpGet("User-Enrollments/{id}")]
        public async Task<ActionResult<IEnumerable<Enrollment>>> GetAllUserEnrolledCoursesAsync(string id)
        {
            var enrollments = await enrollmentService.GetAllUserEnrollmentsAsync(id);
            return Ok(enrollments);
        }
    }
}
