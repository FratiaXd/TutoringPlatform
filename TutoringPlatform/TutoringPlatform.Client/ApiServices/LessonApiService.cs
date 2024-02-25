using System.Net.Http.Json;
using TutoringPlatform.Shared.Interfaces;
using TutoringPlatform.Shared.Models;

namespace TutoringPlatform.Client.ApiServices
{
    public class LessonApiService : ILessonService
    {
        private readonly HttpClient httpClient;

        public LessonApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task<Lesson> AddLessonAsync(Lesson lesson)
        {
            throw new NotImplementedException();
        }

        public Task<Lesson> DeleteLessonAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Lesson>> GetAllLessonsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Lesson>> GetAllLessonsForCourseAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Lesson>> GetAllCourseLessonsQAndLAsync(int? id, string userId)
        {
            var lessons = await httpClient.GetAsync($"api/Lesson/Course-Lessons/{id}/{userId}");
            var response = await lessons.Content.ReadFromJsonAsync<IEnumerable<Lesson>>();
            return response!;
        }

        public Task<Lesson> GetLessonByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsTitleUsedAsync(int id, string title)
        {
            throw new NotImplementedException();
        }

        public Task<Lesson> UpdateLessonAsync(Lesson updatedLesson)
        {
            throw new NotImplementedException();
        }
    }
}
