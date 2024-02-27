using System.Net.Http.Json;
using TutoringPlatform.Shared.Interfaces;
using TutoringPlatform.Shared.Models;

namespace TutoringPlatform.Client.ApiServices
{
    public class LessonProgressApiService : ILessonProgressService
    {
        private readonly HttpClient httpClient;

        public LessonProgressApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<LessonProgress> AddLessonProgressRecordAsync(LessonProgress lessonProgress)
        {
            var newProgress = await httpClient.PostAsJsonAsync("api/LessonProgress/Add-Lesson-Progress", lessonProgress);
            var response = await newProgress.Content.ReadFromJsonAsync<LessonProgress>();
            return response!;
        }

        public async Task<LessonProgress> SubmitAssignmentAsync(LessonProgress lessonProgress)
        {
            var updProgress = await httpClient.PostAsJsonAsync("api/LessonProgress/Submit-Assignment", lessonProgress);
            var response = await updProgress.Content.ReadFromJsonAsync<LessonProgress>();
            return response!;
        }

        public async Task<LessonProgress> SubmitQuizAsync(LessonProgress lessonProgress)
        {
            var updProgress = await httpClient.PostAsJsonAsync("api/LessonProgress/Submit-Quiz", lessonProgress);
            var response = await updProgress.Content.ReadFromJsonAsync<LessonProgress>();
            return response!;
        }

        public async Task<LessonProgress> FinishLessonAsync(LessonProgress lessonProgress)
        {
            var updProgress = await httpClient.PostAsJsonAsync("api/LessonProgress/Finish-Lesson", lessonProgress);
            var response = await updProgress.Content.ReadFromJsonAsync<LessonProgress>();
            return response!;
        }

        public async Task<IEnumerable<LessonProgress>> GetLessonProgressesForFeedbackAsync()
        {
            throw new NotImplementedException();
        }

        public Task<LessonProgress> GetLessonProgressByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<LessonProgress> SubmitFeedbackAsync(LessonProgress lessonProgress)
        {
            var updProgress = await httpClient.PostAsJsonAsync("api/LessonProgress/Update-Status", lessonProgress);
            var response = await updProgress.Content.ReadFromJsonAsync<LessonProgress>();
            return response!;
        }

        public async Task<IEnumerable<LessonProgress>> GetUserLessonProgressesAssessedAsync(string userId)
        {
            var progresses = await httpClient.GetAsync($"api/LessonProgress/User-Assignments/{userId}");
            var response = await progresses.Content.ReadFromJsonAsync<IEnumerable<LessonProgress>>();
            return response!;
        }
    }
}
