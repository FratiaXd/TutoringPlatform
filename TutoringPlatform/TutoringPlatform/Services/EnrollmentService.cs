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
    }
}
