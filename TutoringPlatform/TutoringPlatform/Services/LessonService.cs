using Microsoft.EntityFrameworkCore;
using TutoringPlatform.Data;
using TutoringPlatform.Shared.Interfaces;
using TutoringPlatform.Shared.Models;

namespace TutoringPlatform.Services
{
    public class LessonService : ILessonService
    {
        private readonly TutoringPlatformContext _context;

        public LessonService(TutoringPlatformContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Lesson>> GetAllLessonsAsync()
        {
            return await _context.Lessons.ToListAsync();
        }

        public async Task<Lesson> AddLessonAsync(Lesson lesson)
        {
            if (lesson == null) { return null; }
            //Check if lesson already exists
            var check = await _context.Lessons.FirstOrDefaultAsync(l => l.LessonTitle.ToLower() == lesson.LessonTitle.ToLower());
            if (check != null) { return null; }
            //Add lesson
            var newLesson = _context.Lessons.Add(lesson).Entity;
            await _context.SaveChangesAsync();
            return newLesson;
        }

        public async Task<Lesson> GetLessonByIdAsync(int id)
        {
            if (id == 0) { return null; }

            var lesson = await _context.Lessons.FirstOrDefaultAsync(l => l.LessonId == id);
            if (lesson == null) { return null; }
            return lesson;
        }
    }
}
