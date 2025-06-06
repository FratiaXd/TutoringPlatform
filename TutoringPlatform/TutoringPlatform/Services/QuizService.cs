﻿using BlazorBootstrap;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using TutoringPlatform.Data;
using TutoringPlatform.Migrations;
using TutoringPlatform.Shared.Interfaces;
using TutoringPlatform.Shared.Models;

namespace TutoringPlatform.Services
{
    public class QuizService : IQuizService
    {
        private readonly IDbContextFactory<TutoringPlatformContext> _contextFactory;

        public QuizService(IDbContextFactory<TutoringPlatformContext> context)
        {
            _contextFactory = context;
        }

        public async Task<Quiz> AddQuizAsync(Quiz quiz)
        {
            if (quiz == null) { return null; }
            using var context = _contextFactory.CreateDbContext();

            var newQuiz = context.Quizzes.Add(quiz).Entity;
            await context.SaveChangesAsync();
            return newQuiz;
        }

        public async Task<Quiz> DeleteQuizAsync(int id)
        {
            if (id == 0) { return null; }
            using var context = _contextFactory.CreateDbContext();
            var deletedQuiz = await context.Quizzes.FindAsync(id);
            if (deletedQuiz == null) { return null; }

            context.Quizzes.Remove(deletedQuiz);
            await context.SaveChangesAsync();

            return deletedQuiz;
        }

        public async Task<Quiz> UpdateQuizAsync(Quiz quiz)
        {
            if (quiz == null) { return null; }
            using var context = _contextFactory.CreateDbContext();

            var existingQuiz = await context.Quizzes.FindAsync(quiz.QuizId);
            if (existingQuiz == null) { return null; }

            existingQuiz.QuizName = quiz.QuizName;

            await context.SaveChangesAsync();
            return existingQuiz;
        }

        public async Task<Quiz> GetQuizWithQandOAsync(int quizId)
        {
            if (quizId == 0) { return null; }
            using var context = _contextFactory.CreateDbContext();
            var quiz = await context.Quizzes
                .Include(q => q.QuizQuestions)
                    .ThenInclude(qq => qq.QuizOptions)
                .FirstOrDefaultAsync(q => q.QuizId == quizId);
            if (quiz == null) { return null; }
            return quiz;
        }

        public async Task<QuizQuestion> AddQuizQuestionAsync(QuizQuestion question)
        {
            if (question == null) { return null; }
            using var context = _contextFactory.CreateDbContext();

            var newQuestion = context.QuizQuestions.Add(question).Entity;
            await context.SaveChangesAsync();
            return newQuestion;
        }

        public async Task<QuizQuestion> UpdateQuizQuestionAsync(QuizQuestion question)
        {
            if (question == null) { return null; }
            using var context = _contextFactory.CreateDbContext();

            var existingQuestion = await context.QuizQuestions
                .Include(q => q.QuizOptions)
                .FirstOrDefaultAsync(q => q.QuizQuestionId ==  question.QuizQuestionId);
            if (existingQuestion == null) { return null; }

            existingQuestion.Question = question.Question;

            foreach (var option in question.QuizOptions)
            {
                var existingOption = existingQuestion.QuizOptions.FirstOrDefault(o => o.QuizOptionId == option.QuizOptionId);
                if (existingOption != null)
                {
                    existingOption.Option = option.Option;
                    existingOption.IsCorrect = option.IsCorrect;
                }
            }

            await context.SaveChangesAsync();

            return existingQuestion;
        }

        public async Task<QuizQuestion> DeleteQuizQuestionAsync(QuizQuestion question)
        {
            if (question == null) { return null; }
            using var context = _contextFactory.CreateDbContext();

            var deletedQuizQuestion = await context.QuizQuestions.FindAsync(question.QuizQuestionId);
            if (deletedQuizQuestion == null) { return null; }

            context.QuizQuestions.Remove(deletedQuizQuestion);
            await context.SaveChangesAsync();

            return deletedQuizQuestion;
        }

        public async Task<QuizOption> AddQuizOptionAsync(QuizOption option)
        {
            if (option == null) { return null; }
            using var context = _contextFactory.CreateDbContext();

            var newOption = context.QuizOptions.Add(option).Entity;
            await context.SaveChangesAsync();
            return newOption;
        }

        public async Task<QuizOption> DeleteQuizOptionAsync(QuizOption option)
        {
            if (option == null) { return null; }
            using var context = _contextFactory.CreateDbContext();

            var deletedQuizOption = await context.QuizOptions.FindAsync(option.QuizOptionId);
            if (deletedQuizOption == null) { return null; }

            context.QuizOptions.Remove(deletedQuizOption);
            await context.SaveChangesAsync();

            return deletedQuizOption;
        }

        public async Task<bool> AllQuizQuestionsHaveOptionsAsync(int quizId)
        {
            using var context = _contextFactory.CreateDbContext();
            var questionsExist = await context.QuizQuestions.AnyAsync(q => q.QuizId == quizId);

            // If there are no questions at all, return false
            if (!questionsExist) { return false; }

            // Query the database to check if all quiz questions for a lesson have options
            var questionsWithoutOptions = await context.QuizQuestions
            .Where(q => q.QuizId == quizId && !q.QuizOptions.Any())
            .ToListAsync();

            // If there are no questions without options, return true
            return questionsWithoutOptions.Count == 0;
        }

        public async Task<bool> AllQuizQuestionsHaveCorrectAnswerAsync(int quizId)
        {
            using var context = _contextFactory.CreateDbContext();

            // Query the database to check if all quiz questions for a lesson have at least one correct answer
            var questionsWithNoCorrectAnswer = await context.QuizQuestions
                .Where(q => q.QuizId == quizId && !q.QuizOptions.Any(option => option.IsCorrect))
                .ToListAsync();

            // If there are no questions without correct answers, return true
            return questionsWithNoCorrectAnswer.Count == 0;
        }
    }
}
