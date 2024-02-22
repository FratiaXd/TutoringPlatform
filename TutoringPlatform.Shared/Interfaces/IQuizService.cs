using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutoringPlatform.Shared.Models;

namespace TutoringPlatform.Shared.Interfaces
{
    public interface IQuizService
    {
        Task<Quiz> AddQuizAsync(Quiz quiz);
        Task<Quiz> DeleteQuizAsync(int id);
        Task<Quiz> UpdateQuizAsync(Quiz quiz);
        Task<Quiz> GetQuizWithQandOAsync(int quizId);
        Task<QuizQuestion> AddQuizQuestionAsync(QuizQuestion question);
        Task<QuizQuestion> UpdateQuizQuestionAsync(QuizQuestion question);
        Task<QuizQuestion> DeleteQuizQuestionAsync(QuizQuestion question);
        Task<QuizOption> AddQuizOptionAsync(QuizOption option);
        Task<QuizOption> DeleteQuizOptionAsync(QuizOption option);
        Task<bool> AllQuizQuestionsHaveOptionsAsync(int quizId);
        Task<bool> AllQuizQuestionsHaveCorrectAnswerAsync(int quizId);
    }
}
