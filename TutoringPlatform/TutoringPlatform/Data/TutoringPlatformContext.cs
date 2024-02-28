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

    public DbSet<Course> Courses { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<LessonProgress> LessonProgresses { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<QuizQuestion> QuizQuestions { get; set; }
    public DbSet<QuizOption> QuizOptions { get; set; }
    public DbSet<Assignment> Assignments { get; set; }
    public DbSet<Order> Orders { get; set; }

protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        //Course to Lesson relationship (one to many)
        builder.Entity<Course>()
            .HasMany(c => c.Lessons)
            .WithOne(l => l.Course)
            .HasForeignKey(l => l.CourseId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        //User to Enrollment relationship (one to many)
        builder.Entity<Enrollment>()
            .HasOne(e => e.User)
            .WithMany(u => u.Enrollments)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        //Course to Enrollment relationship (one to many)
        builder.Entity<Enrollment>()
            .HasOne(e => e.Course)
            .WithMany(c => c.Enrollments)
            .HasForeignKey(e => e.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        //Enrollment to Latest lesson relationship
        builder.Entity<Enrollment>()
            .HasOne(e => e.LatestLesson)
            .WithMany()
            .HasForeignKey(e => e.LatestLessonId)
            .OnDelete(DeleteBehavior.SetNull);

        //User to LessonProgress (one to many)
        builder.Entity<LessonProgress>()
            .HasOne(lp => lp.User)
            .WithMany(u => u.LessonProgresses)
            .HasForeignKey(lp => lp.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        //Lesson to LessonProgress (one to many)
        builder.Entity<LessonProgress>()
            .HasOne(lp => lp.Lesson)
            .WithMany(l => l.LessonProgresses)
            .HasForeignKey(lp => lp.LessonId)
            .OnDelete(DeleteBehavior.Cascade);

        //Quiz to Lesson (one to one)
        builder.Entity<Lesson>()
            .HasOne(l => l.Quiz)
            .WithOne(q => q.Lesson)
            .HasForeignKey<Quiz>(q => q.LessonId)
            .OnDelete(DeleteBehavior.Cascade);

        //Assignment to Lesson (one to one)
        builder.Entity<Lesson>()
            .HasOne(l => l.Assignment)
            .WithOne(a => a.Lesson)
            .HasForeignKey<Assignment>(a => a.LessonId)
            .OnDelete(DeleteBehavior.Cascade);

        //Quiz to QuizQuestions (one to many)
        builder.Entity<QuizQuestion>()
            .HasOne(qq => qq.Quiz)
            .WithMany(q => q.QuizQuestions)
            .HasForeignKey(qq => qq.QuizId)
            .OnDelete(DeleteBehavior.Cascade);

        //QuizQuestion to QuizOptions (one to many)
        builder.Entity<QuizOption>()
            .HasOne(qo => qo.QuizQuestion)
            .WithMany(qq => qq.QuizOptions)
            .HasForeignKey(qo => qo.QuizQuestionId)
            .OnDelete(DeleteBehavior.Cascade);

        //Order to User relationship (many to one)
        builder.Entity<Order>()
            .HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        //Order to Course relationship (many to one)
        builder.Entity<Order>()
            .HasOne(o => o.Course)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CourseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
