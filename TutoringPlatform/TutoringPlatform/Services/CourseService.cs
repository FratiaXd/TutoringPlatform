using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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
            if (course == null) {  return null; }
            //Check if course already exists
            var check = await _context.Courses.FirstOrDefaultAsync(c => c.Title.ToLower() == course.Title.ToLower());
            if (check != null) { return null; }
            //Add course
            var newCourse = _context.Courses.Add(course).Entity;
            await _context.SaveChangesAsync();
            return newCourse;
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            if (id == 0) { return null; }

            var course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseId == id);
            if (course == null) { return null; }
            return course;
        }

        public async Task<Course> UpdateCourseAsync(Course updatedCourse)
        {
            if (updatedCourse == null) { return null; }
            var existingCourse = await _context.Courses.FindAsync(updatedCourse.CourseId);
            if (existingCourse == null) { return null; }
            
            existingCourse.Title = updatedCourse.Title;
            existingCourse.Description = updatedCourse.Description;
            existingCourse.Price = updatedCourse.Price;
            existingCourse.AccessLevel = updatedCourse.AccessLevel;
            existingCourse.ImageUrl = updatedCourse.ImageUrl;
            existingCourse.IsActive = updatedCourse.IsActive;

            _context.Courses.Update(existingCourse);
            await _context.SaveChangesAsync();

            return existingCourse;
        }

        public async Task<Course> DeleteCourseAsync(int id)
        {
            if (id == 0) { return null; }
            var deletedCourse = await _context.Courses.FindAsync(id);
            if (deletedCourse == null) { return null; }
            
            _context.Courses.Remove(deletedCourse);
            await _context.SaveChangesAsync();

            return deletedCourse;
        }

        public async Task<bool> IsTitleUsedAsync(int id, string title)
        {
            if (title == null) { return true; }
            var check = await _context.Courses.FirstOrDefaultAsync(c => c.Title.ToLower() == title.ToLower() && c.CourseId != id);
            return check != null;
        }

        public async Task<Course> PublishCourseAsync(int id)
        {
            if (id == 0) { return null; }
            var existingCourse = await _context.Courses.FindAsync(id);
            if (existingCourse == null) { return null; }

            existingCourse.IsActive = true;
            existingCourse.Status = "Published";

            _context.Courses.Update(existingCourse);
            await _context.SaveChangesAsync();

            return existingCourse;
        }
    }
}
