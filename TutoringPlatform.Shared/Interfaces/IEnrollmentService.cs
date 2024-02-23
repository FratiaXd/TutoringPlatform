using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutoringPlatform.Shared.Models;

namespace TutoringPlatform.Shared.Interfaces
{
    public interface IEnrollmentService
    {
        Task<Enrollment> EnrollUserAsync(Enrollment enrollment);
        Task<IEnumerable<Enrollment>> GetAllUserEnrollmentsAsync(string id);
    }
}
