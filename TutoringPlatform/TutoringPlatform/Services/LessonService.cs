using Microsoft.EntityFrameworkCore;
using TutoringPlatform.Components.Admin.AdminPages.CourseBuilder;
using TutoringPlatform.Data;
using TutoringPlatform.Shared.Interfaces;
using TutoringPlatform.Shared.Models;

namespace TutoringPlatform.Services
{
    public class LessonService : ILessonService
    {
        private readonly IDbContextFactory<TutoringPlatformContext> _contextFactory;

        public LessonService(IDbContextFactory<TutoringPlatformContext> context)
        {
            _contextFactory = context;
        }

        public async Task<IEnumerable<Lesson>> GetAllLessonsAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Lessons.ToListAsync();
        }

        public async Task<IEnumerable<Lesson>> GetAllLessonsForCourse(int? id)
        {
            if (id == 0) { return null; }
            using var context = _contextFactory.CreateDbContext();
            return await context.Lessons
                .Include(l => l.Quiz)
                .Include(l => l.Assignment)
                .Where(l => l.CourseId == id)
                .OrderBy(l => l.LessonOrder)
                .ToListAsync();
        }

        public async Task<Lesson> AddLessonAsync(Lesson lesson)
        {
            if (lesson == null) { return null; }
            //Check if lesson already exists
            using var context = _contextFactory.CreateDbContext();
            var check = await context.Lessons.FirstOrDefaultAsync(l => l.LessonTitle.ToLower() == lesson.LessonTitle.ToLower());
            if (check != null) { return null; }
            //Set lesson data


            //Add lesson
            var newLesson = context.Lessons.Add(lesson).Entity;
            await context.SaveChangesAsync();
            return newLesson;
        }

        public async Task<Lesson> GetLessonByIdAsync(int id)
        {
            if (id == 0) { return null; }

            using var context = _contextFactory.CreateDbContext();
            var lesson = await context.Lessons
                .Include(l => l.Quiz)
                .Include(l => l.Assignment)
                .FirstOrDefaultAsync(l => l.LessonId == id);
            if (lesson == null) { return null; }
            return lesson;
        }

        public async Task<bool> IsTitleUsedAsync(int id, string title)
        {
            if (title == null) { return true; }
            using var context = _contextFactory.CreateDbContext();
            var check = await context.Lessons.FirstOrDefaultAsync(l => l.LessonTitle.ToLower() == title.ToLower() && l.LessonId != id);
            return check != null;
        }

        public async Task<Lesson> UpdateLessonAsync(Lesson updatedLesson)
        {
            if (updatedLesson == null) { return null; }
            using var context = _contextFactory.CreateDbContext();
            var existingLesson = await context.Lessons
                .Include(l => l.Quiz)
                .Include(l => l.Assignment)
                .FirstOrDefaultAsync(l => l.LessonId == updatedLesson.LessonId);
            if (existingLesson == null) { return null; }

            existingLesson.LessonTitle = updatedLesson.LessonTitle;
            existingLesson.LessonDescription = updatedLesson.LessonDescription;
            existingLesson.IsAutograded = updatedLesson.IsAutograded;
            existingLesson.LessonVideoUrl = updatedLesson.LessonVideoUrl;
            existingLesson.LessonImageUrl = updatedLesson.LessonImageUrl;
            existingLesson.LessonContent = updatedLesson.LessonContent;
            existingLesson.IsAssessed = updatedLesson.IsAssessed;

            context.Lessons.Update(existingLesson);
            await context.SaveChangesAsync();

            return existingLesson;
        }

        public async Task<Lesson> DeleteLessonAsync(int id)
        {
            if (id == 0) { return null; }
            using var context = _contextFactory.CreateDbContext();
            var deletedLesson = await context.Lessons.FindAsync(id);
            if (deletedLesson == null) { return null; }

            //Handle lesson order after delete
            var courseLessons = await context.Lessons.
                Where(l => l.CourseId == deletedLesson.CourseId).
                OrderBy(l => l.LessonOrder).
                ToListAsync();

            var deletedLessonOrder = deletedLesson.LessonOrder;
            foreach (var lesson in courseLessons.Where(l => l.LessonOrder > deletedLessonOrder))
            {
                lesson.LessonOrder -= 1;
            }

            context.Lessons.Remove(deletedLesson);
            await context.SaveChangesAsync();

            return deletedLesson;
        }
    }
}
