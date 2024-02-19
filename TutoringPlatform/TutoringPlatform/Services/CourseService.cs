using Microsoft.EntityFrameworkCore;
using TutoringPlatform.Data;
using TutoringPlatform.Shared.Interfaces;
using TutoringPlatform.Shared.Models;

namespace TutoringPlatform.Services
{
    public class CourseService : ICourseService
    {
        private readonly TutoringPlatformContext _context;

        public CourseService(TutoringPlatformContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetDraftCoursesAsync()
        {
            return await _context.Courses.Where(c => !c.IsActive).ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetPublishedCoursesAsync()
        {
            return await _context.Courses.Where(c => c.IsActive).ToListAsync();
        }

        public async Task<Course> AddCourseAsync(Course course)
        {
            if (course == null) 
            { 
                return null; 
            }
            //Check if course already exists
            var check = await _context.Courses.FirstOrDefaultAsync(c => c.Title.ToLower() == course.Title.ToLower());
            if (check != null) 
            {
                return null;
            }
            //Add course
            var newCourse = _context.Courses.Add(course).Entity;
            await _context.SaveChangesAsync();
            return newCourse;
        }
    }
}
