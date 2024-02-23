using Microsoft.EntityFrameworkCore;
using TutoringPlatform.Data;
using TutoringPlatform.Shared.Interfaces;
using TutoringPlatform.Shared.Models;

namespace TutoringPlatform.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IDbContextFactory<TutoringPlatformContext> _contextFactory;

        public EnrollmentService(IDbContextFactory<TutoringPlatformContext> context)
        {
            _contextFactory = context;
        }

        public async Task<Enrollment> EnrollUserAsync(Enrollment enrollment)
        {
            if (enrollment == null) return null;
            using var context = _contextFactory.CreateDbContext();

            var existingEnrollment = await context.Enrollments
                .FirstOrDefaultAsync(e => e.UserId == enrollment.UserId && e.CourseId == enrollment.CourseId);

            if (existingEnrollment != null) return null;

            var newEnrollment = context.Enrollments.Add(enrollment).Entity;
            await context.SaveChangesAsync();
            return newEnrollment;
        }

        public async Task<IEnumerable<Enrollment>> GetAllUserEnrollmentsAsync(string id)
        {
            if (id == null) return null;
            using var context = _contextFactory.CreateDbContext();
            return await context.Enrollments.Where(e => e.UserId == id).ToListAsync();
        }

        public async Task<IEnumerable<Enrollment>> GetUserEnrollmentDataAsync(string id)
        {
            if (id == null) return null;
            using var context = _contextFactory.CreateDbContext();
            var enrollments = await context.Enrollments
                .Include(e => e.LatestLesson)
                .Include(e => e.Course)
                .Where(e => e.UserId == id)
                .ToListAsync();
            // Creates a projection to ignore specific properties or relationships
            var serializedEnrollments = enrollments.Select(e => new Enrollment
            {
                EnrollmentId = e.EnrollmentId,
                UserId = e.UserId,
                CourseId = e.CourseId,
                LatestLessonId = e.LatestLessonId,
                EnrollmentStatus = e.EnrollmentStatus,

                Course = new Course
                {
                    CourseId = e.Course?.CourseId ?? 0,
                    Title = e.Course?.Title,
                    Duration = e.Course?.Duration ?? 0
                },
                LatestLesson = new Lesson
                {
                    LessonId = e.LatestLesson?.LessonId ?? 0,
                    LessonOrder = e.LatestLesson?.LessonOrder ?? 0
                }

            });

            return serializedEnrollments;
        }
    }
}
