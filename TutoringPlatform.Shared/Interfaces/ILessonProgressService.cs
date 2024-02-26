using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutoringPlatform.Shared.Models;

namespace TutoringPlatform.Shared.Interfaces
{
    public interface ILessonProgressService
    {
        Task<LessonProgress> AddLessonProgressRecordAsync(LessonProgress lessonProgress);
        Task<LessonProgress> SubmitAssignmentAsync(LessonProgress lessonProgress);
        Task<LessonProgress> SubmitQuizAsync(LessonProgress lessonProgress);
        Task<LessonProgress> FinishLessonAsync(LessonProgress lessonProgress);
    }
}
