using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TutoringPlatform.Shared.Models;

// Add profile data for application users by adding properties to the TutoringPlatformUser class
public class TutoringPlatformUser : IdentityUser
{
    //Properties
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string RoleName { get; set; }

    //Relationships
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    public ICollection<LessonProgress> LessonProgresses { get; set; } = new List<LessonProgress>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}

