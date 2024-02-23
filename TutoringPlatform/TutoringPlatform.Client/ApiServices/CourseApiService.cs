using System.Net.Http.Json;
using TutoringPlatform.Shared.Interfaces;
using TutoringPlatform.Shared.Models;

namespace TutoringPlatform.Client.ApiServices
{
    public class CourseApiService : ICourseService
    {
        private readonly HttpClient httpClient;

        public CourseApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public Task<Course> AddCourseAsync(Course course)
        {
            throw new NotImplementedException();
        }

        public Task<Course> DeleteCourseAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            var course = await httpClient.GetAsync($"api/Course/Single-Course/{id}");
            var response = await course.Content.ReadFromJsonAsync<Course>();
            return response;
        }

        public Task<IEnumerable<Course>> GetDraftCoursesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Course>> GetPublishedCoursesAsync()
        {
            var publishedCourses = await httpClient.GetAsync("api/Course/Published-Courses");
            var response = await publishedCourses.Content.ReadFromJsonAsync<IEnumerable<Course>>();
            return response;
        }

        public Task<bool> IsTitleUsedAsync(int id, string title)
        {
            throw new NotImplementedException();
        }

        public Task<Course> PublishCourseAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Course> UnpublishCourseAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Course> UpdateCourseAsync(Course updatedCourse)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetLessonIdForCourseAsync(int courseId, int lessonNum)
        {
            var lessonId = await httpClient.GetAsync($"api/Course/Lesson-Id/{courseId}/{lessonNum}");
            var response = await lessonId.Content.ReadFromJsonAsync<int>();
            return response;
        }
    }
}
