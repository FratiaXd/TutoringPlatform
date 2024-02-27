using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutoringPlatform.Shared.Models;

namespace TutoringPlatform.Shared.Interfaces
{
    public interface IAssignmentService
    {
        Task<Assignment> AddAssignmentAsync(Assignment assignment);
        Task<Assignment> DeleteAssignmentAsync(int id);
        Task<Assignment> GetAssignmentByIdAsync(int id);
        Task<Assignment> UpdateAssignmentAsync(Assignment assignment);
        Task<Assignment> GetAssignmentByLessonId(int lessonId);
    }
}
