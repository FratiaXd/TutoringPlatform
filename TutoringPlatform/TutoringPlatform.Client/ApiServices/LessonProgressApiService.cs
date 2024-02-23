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
    }
}
