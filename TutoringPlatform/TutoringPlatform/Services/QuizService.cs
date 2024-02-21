using BlazorBootstrap;
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

        public async Task<Quiz> DeleteQuizAsync(int id)
        {
            if (id == 0) { return null; }
            using var context = _contextFactory.CreateDbContext();
            var deletedQuiz = await context.Quizzes.FindAsync(id);
            if (deletedQuiz == null) { return null; }

            context.Quizzes.Remove(deletedQuiz);
            await context.SaveChangesAsync();

            return deletedQuiz;
        }

        public async Task<Quiz> UpdateQuizAsync(Quiz quiz)
        {
            if (quiz == null) { return null; }
            using var context = _contextFactory.CreateDbContext();

            var existingQuiz = await context.Quizzes.FindAsync(quiz.QuizId);
            if (existingQuiz == null) { return null; }

            existingQuiz.QuizName = quiz.QuizName;

            await context.SaveChangesAsync();
            return existingQuiz;
        }

        public async Task<Quiz> GetQuizWithQandOAsync(int quizId)
        {
            if (quizId == 0) { return null; }
            using var context = _contextFactory.CreateDbContext();
            var quiz = await context.Quizzes
                .Include(q => q.QuizQuestions)
                    .ThenInclude(qq => qq.QuizOptions)
                .FirstOrDefaultAsync(q => q.QuizId == quizId);
            if (quiz == null) { return null; }
            return quiz;
        }

        public async Task<QuizQuestion> AddQuizQuestionAsync(QuizQuestion question)
        {
            if (question == null) { return null; }
            using var context = _contextFactory.CreateDbContext();

            var newQuestion = context.QuizQuestions.Add(question).Entity;
            await context.SaveChangesAsync();
            return newQuestion;
        }

        public async Task<QuizOption> AddQuizOptionAsync(QuizOption option)
        {
            if (option == null) { return null; }
            using var context = _contextFactory.CreateDbContext();

            var newOption = context.QuizOptions.Add(option).Entity;
            await context.SaveChangesAsync();
            return newOption;
        }
    }
}
