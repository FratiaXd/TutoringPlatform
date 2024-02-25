using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TutoringPlatform.Services;
using TutoringPlatform.Shared.Interfaces;
using TutoringPlatform.Shared.Models;

namespace TutoringPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService quizService;

        public QuizController(IQuizService quizService)
        {
            this.quizService = quizService;
        }

        [HttpGet("Quiz-Full/{id}")]
        public async Task<ActionResult<Quiz>> GetQuizQandOAsync(int id)
        {
            var quiz = await quizService.GetQuizWithQandOAsync(id);
            return Ok(quiz);
        }
    }
}
