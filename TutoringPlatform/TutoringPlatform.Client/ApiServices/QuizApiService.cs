using System.Net.Http.Json;
using TutoringPlatform.Shared.Interfaces;
using TutoringPlatform.Shared.Models;

namespace TutoringPlatform.Client.ApiServices
{
    public class QuizApiService : IQuizService
    {
        private readonly HttpClient httpClient;

        public QuizApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task<Quiz> AddQuizAsync(Quiz quiz)
        {
            throw new NotImplementedException();
        }

        public Task<QuizOption> AddQuizOptionAsync(QuizOption option)
        {
            throw new NotImplementedException();
        }

        public Task<QuizQuestion> AddQuizQuestionAsync(QuizQuestion question)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AllQuizQuestionsHaveCorrectAnswerAsync(int quizId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AllQuizQuestionsHaveOptionsAsync(int quizId)
        {
            throw new NotImplementedException();
        }

        public Task<Quiz> DeleteQuizAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<QuizOption> DeleteQuizOptionAsync(QuizOption option)
        {
            throw new NotImplementedException();
        }

        public Task<QuizQuestion> DeleteQuizQuestionAsync(QuizQuestion question)
        {
            throw new NotImplementedException();
        }

        public async Task<Quiz> GetQuizWithQandOAsync(int quizId)
        {
            var quiz = await httpClient.GetAsync($"api/Quiz/Quiz-Full/{quizId}");
            var response = await quiz.Content.ReadFromJsonAsync<Quiz>();
            return response!;
        }

        public Task<Quiz> UpdateQuizAsync(Quiz quiz)
        {
            throw new NotImplementedException();
        }

        public Task<QuizQuestion> UpdateQuizQuestionAsync(QuizQuestion question)
        {
            throw new NotImplementedException();
        }
    }
}
