using Microsoft.EntityFrameworkCore;
using TutoringPlatform.Data;
using TutoringPlatform.Shared.Interfaces;
using TutoringPlatform.Shared.Models;

namespace TutoringPlatform.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IDbContextFactory<TutoringPlatformContext> _contextFactory;

        public AssignmentService(IDbContextFactory<TutoringPlatformContext> context)
        {
            _contextFactory = context;
        }

        public async Task<Assignment> AddAssignmentAsync(Assignment assignment)
        {
            if (assignment == null) { return null; }
            using var context = _contextFactory.CreateDbContext();

            var newAssignment = context.Assignments.Add(assignment).Entity;
            await context.SaveChangesAsync();
            return newAssignment;
        }

        public async Task<Assignment> DeleteAssignmentAsync(int id)
        {
            if (id == 0) { return null; }
            using var context = _contextFactory.CreateDbContext();
            var deletedAssignment = await context.Assignments.FindAsync(id);
            if (deletedAssignment == null) { return null; }

            context.Assignments.Remove(deletedAssignment);
            await context.SaveChangesAsync();

            return deletedAssignment;
        }
    }
}
