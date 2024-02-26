using BlazorBootstrap;
using Microsoft.EntityFrameworkCore;
using TutoringPlatform.Data;
using TutoringPlatform.Shared.Interfaces;
using TutoringPlatform.Shared.Models;

namespace TutoringPlatform.Services
{
    public class LessonProgressService : ILessonProgressService
    {
        private readonly IDbContextFactory<TutoringPlatformContext> _contextFactory;

        public LessonProgressService(IDbContextFactory<TutoringPlatformContext> context)
        {
            _contextFactory = context;
        }

        public async Task<LessonProgress> AddLessonProgressRecordAsync(LessonProgress lessonProgress)
        {
            if (lessonProgress == null) return null;
            using var context = _contextFactory.CreateDbContext();

            var existingProgress = await context.LessonProgresses
                .FirstOrDefaultAsync(lp => lp.UserId == lessonProgress.UserId && lp.LessonId == lessonProgress.LessonId);

            if (existingProgress != null) return null;

            var newLessonProgress = context.LessonProgresses.Add(lessonProgress).Entity;
            await context.SaveChangesAsync();
            return newLessonProgress;
        }

        public async Task<LessonProgress> SubmitAssignmentAsync(LessonProgress lessonProgress)
        {
            if (lessonProgress == null) return null;
            using var context = _contextFactory.CreateDbContext();

            var existingProgress = await context.LessonProgresses
                .FirstOrDefaultAsync(lp => lp.UserId == lessonProgress.UserId && lp.LessonId == lessonProgress.LessonId);

            if (existingProgress == null) return null;

            existingProgress.SubmittedAssignment = lessonProgress.SubmittedAssignment;
            existingProgress.FeedbackStatus = lessonProgress.FeedbackStatus;

            await context.SaveChangesAsync();
            return existingProgress;
        }

        public async Task<LessonProgress> SubmitQuizAsync(LessonProgress lessonProgress)
        {
            if (lessonProgress == null) return null;
            using var context = _contextFactory.CreateDbContext();

            var existingProgress = await context.LessonProgresses
                .FirstOrDefaultAsync(lp => lp.UserId == lessonProgress.UserId && lp.LessonId == lessonProgress.LessonId);

            if (existingProgress == null) return null;

            existingProgress.QuizGrade = lessonProgress.QuizGrade;

            await context.SaveChangesAsync();
            return existingProgress;
        }

        public async Task<LessonProgress> FinishLessonAsync(LessonProgress lessonProgress)
        {
            if (lessonProgress == null) return null;
            using var context = _contextFactory.CreateDbContext();

            var existingProgress = await context.LessonProgresses
                .FirstOrDefaultAsync(lp => lp.UserId == lessonProgress.UserId && lp.LessonId == lessonProgress.LessonId);

            if (existingProgress == null) return null;

            existingProgress.LessonStatus = lessonProgress.LessonStatus;

            await context.SaveChangesAsync();
            return existingProgress;
        }
    }
}
