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
        Task<IEnumerable<Lesson>> GetAllLessonsForCourse(int? id);
        Task<Lesson> AddLessonAsync(Lesson lesson);
        Task<Lesson> GetLessonByIdAsync(int id);

    }
}
