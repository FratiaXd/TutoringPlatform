using Microsoft.EntityFrameworkCore;
using TutoringPlatform.Data;
using TutoringPlatform.Shared.Interfaces;
using TutoringPlatform.Shared.Models;

namespace TutoringPlatform.Services
{
    public class QuizService : IQuizService
    {
        private readonly IDbContextFactory<TutoringPlatformContext> _contextFactory;

        public QuizService(IDbContextFactory<TutoringPlatformContext> context)
        {
            _contextFactory = context;
        }

        public async Task<Quiz> AddQuizAsync(Quiz quiz)
        {
            if (quiz == null) { return null; }
            using var context = _contextFactory.CreateDbContext();

            var newQuiz = context.Quizzes.Add(quiz).Entity;
            await context.SaveChangesAsync();
            return newQuiz;
        }
    }
}
