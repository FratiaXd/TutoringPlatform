using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutoringPlatform.Shared.Models;

namespace TutoringPlatform.Shared.Interfaces
{
    public interface ILessonService
    {
        Task<IEnumerable<Lesson>> GetAllLessonsAsync();
        Task<IEnumerable<Lesson>> GetAllLessonsForCourseAsync(int? id);
        Task<IEnumerable<Lesson>> GetAllCourseLessonsQAndLAsync(int? id, string userId);
        Task<Lesson> AddLessonAsync(Lesson lesson);
        Task<Lesson> GetLessonByIdAsync(int id);
        Task<bool> IsTitleUsedAsync(int id, string title);
        Task<Lesson> UpdateLessonAsync(Lesson updatedLesson);
        Task<Lesson> DeleteLessonAsync(int id);

    }
}
