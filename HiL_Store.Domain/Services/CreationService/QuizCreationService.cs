using HiL_Store.Domain.Entities.QuizEntities;
using HiL_Store.Domain.Interfaces.CreationService;
using HiL_Store.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HiL_Store.Domain.Services.CreationService
{
    public class QuizCreationService : IQuizCreationService
    {
        private readonly IQuizService _quizService;

        private readonly ICategoryQuizService _categoryQuizService;

        public QuizCreationService(IQuizService quizService, ICategoryQuizService categoryQuizService)
        {
            _quizService = quizService;
            _categoryQuizService = categoryQuizService;
        }

        public async Task<CreationQuizResult> Creation(string question, string ansA, string ansB,
            string ansC, string ansD, string correctAns, Category category)
        {
            CreationQuizResult result = CreationQuizResult.SuccessCreation;

            if (question == null || ansA == null || ansB == null || ansC == null
                || ansD == null || correctAns == null || category == null)
            {
                result = CreationQuizResult.EmptyData;
            }



            if (correctAns != ansA && correctAns != ansB && correctAns != ansC && correctAns != ansD)
            {
                result = CreationQuizResult.CorrectAnswerDoNotMatch;
            }

            Quiz questionQuiz = await _quizService.GetByQuestion(question);
            if (questionQuiz != null)
            {
                result = CreationQuizResult.QuestionAlreadyExists;
            }

            if (result == CreationQuizResult.SuccessCreation)
            {
                Quiz quiz = new Quiz()
                {
                    Question = question,
                    AnswerA = ansA,
                    AnswerB = ansB,
                    AnswerC = ansC,
                    AnswerD = ansD,
                    CorrectAnswer = correctAns
                };

                await _quizService.Create(quiz);

                CategoryQuiz categoryQuiz = new CategoryQuiz()
                {
                    CategoryID = category.Id,
                    QuizID = quiz.Id
                };

                await _categoryQuizService.Create(categoryQuiz);
            }

            return result;
        }
    }
}
