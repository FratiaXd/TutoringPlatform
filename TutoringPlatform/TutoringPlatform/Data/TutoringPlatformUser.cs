using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TutoringPlatform.Data;

// Add profile data for application users by adding properties to the TutoringPlatformUser class
public class TutoringPlatformUser : IdentityUser
{
    [MaxLength(20), RegularExpression(@"^[a-zA-Z]+$")]
    public string? FirstName { get; set; }
    [MaxLength(20)]
    public string? LastName { get; set; }
}

