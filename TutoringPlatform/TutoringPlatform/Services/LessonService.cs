using Microsoft.EntityFrameworkCore;
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
            return await context.Lessons.Where(l => l.CourseId == id).OrderBy(l => l.LessonOrder).ToListAsync();
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
            var lesson = await context.Lessons.FirstOrDefaultAsync(l => l.LessonId == id);
            if (lesson == null) { return null; }
            return lesson;
        }
    }
}
