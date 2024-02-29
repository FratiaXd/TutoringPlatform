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
            existingProgress.FeedbackTimeStamp = lessonProgress.FeedbackTimeStamp;

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

        public async Task<IEnumerable<LessonProgress>> GetLessonProgressesForFeedbackAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            var lessonProgresses = await context.LessonProgresses
                                        .Include(lp => lp.User)
                                        .Include(lp => lp.Lesson)
                                        .ThenInclude(l => l.Course)
                                        .Where(lp => lp.FeedbackStatus != null)
                                        .OrderByDescending(lp => lp.FeedbackTimeStamp)
                                        .ToListAsync();
            return lessonProgresses;
        }

        public async Task<LessonProgress> GetLessonProgressByIdAsync(int id)
        {
            if (id == 0) return null;
            using var context = _contextFactory.CreateDbContext();

            var existingProgress = await context.LessonProgresses
                .Include(lp => lp.User)
                .Include(lp => lp.Lesson)
                .ThenInclude(l => l.Course)
                .FirstOrDefaultAsync(lp => lp.LessonProgressId == id);

            if (existingProgress == null) return null;

            return existingProgress;
        }

        public async Task<LessonProgress> SubmitFeedbackAsync(LessonProgress lessonProgress)
        {
            if (lessonProgress == null) return null;
            using var context = _contextFactory.CreateDbContext();

            var existingProgress = await context.LessonProgresses.FirstOrDefaultAsync(lp => lp.LessonProgressId == lessonProgress.LessonProgressId);

            if (existingProgress == null) return null;

            existingProgress.TutorFeedback = lessonProgress.TutorFeedback;
            existingProgress.FeedbackStatus = lessonProgress.FeedbackStatus;
            existingProgress.FeedbackTimeStamp = lessonProgress.FeedbackTimeStamp;
            
            await context.SaveChangesAsync();
            return existingProgress;
        }

        public async Task<IEnumerable<LessonProgress>> GetUserLessonProgressesAssessedAsync(string userId)
        {
            if (userId == null) return null;
            using var context = _contextFactory.CreateDbContext();

            var lessonProgresses = await context.LessonProgresses
                            .Include(lp => lp.User)
                            .Include(lp => lp.Lesson)
                            .ThenInclude(l => l.Course)
                            .Where(lp => lp.UserId == userId && lp.SubmittedAssignment != null)
                            .OrderByDescending(lp => lp.FeedbackTimeStamp)
                            .ToListAsync();

            if (lessonProgresses == null) return null; 
            return lessonProgresses;
        }

        public async Task<IEnumerable<LessonProgress>> GetUserLessonProgressesAsync(string userId)
        {
            if (userId == null) return null;
            using var context = _contextFactory.CreateDbContext();

            var lessonProgresses = await context.LessonProgresses
                            .Include(lp => lp.User)
                            .Include(lp => lp.Lesson)
                            .ThenInclude(l => l.Course)
                            .Where(lp => lp.UserId == userId)
                            .ToListAsync();

            if (lessonProgresses == null) return null;

            var sortedLessonProgresses = lessonProgresses.OrderBy(lp => lp.Lesson.CourseId);

            return sortedLessonProgresses;
        }
    }
}
