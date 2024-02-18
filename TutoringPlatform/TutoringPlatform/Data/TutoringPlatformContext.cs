using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TutoringPlatform.Shared.Models;

namespace TutoringPlatform.Data;

public class TutoringPlatformContext : IdentityDbContext<TutoringPlatformUser>
{
    public TutoringPlatformContext(DbContextOptions<TutoringPlatformContext> options)
        : base(options)
    {
    }

    //public DbSet<Course> Courses { get; set; }
    //public DbSet<Lesson> Lessons { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        //builder.Entity<Course>()
        //    .HasMany(c => c.Lessons)
        //    .WithOne(l => l.Course)
        //    .HasForeignKey(l => l.CourseKey)
        //    .IsRequired()
        //    .OnDelete(DeleteBehavior.Cascade);


    }
}
