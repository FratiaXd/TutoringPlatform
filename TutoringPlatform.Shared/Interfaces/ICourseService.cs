using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutoringPlatform.Shared.Models;

namespace TutoringPlatform.Shared.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<IEnumerable<Course>> GetPublishedCoursesAsync();
        Task<IEnumerable<Course>> GetDraftCoursesAsync();
        Task<Course> AddCourseAsync(Course course);
        Task<Course> GetCourseByIdAsync(int id);
        Task<Course> UpdateCourseAsync(Course updatedCourse);
        Task<Course> DeleteCourseAsync(int id);
        Task<bool> IsTitleUsedAsync(int id, string title);
        Task<Course> PublishCourseAsync(int id);
        Task<Course> UnpublishCourseAsync(int id);
        Task<int> GetLessonIdForCourseAsync(int courseId, int lessonNum);
    }
}
