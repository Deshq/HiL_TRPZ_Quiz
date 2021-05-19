using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using System.Threading.Tasks;
using HiL_Store.Domain.Entities.QuizEntities;
using HiL_Store.Domain.Interfaces.CreationService;
using HiL_Store.Domain.Interfaces.Repository;
using HiL_Store.Domain.Services.CreationService;

namespace HiL_Store.Domain.Tests.Services.CreationService
{
    [TestFixture()]
    public class QuizCreationServiceTests
    {

        private Mock<IQuizService> _mockQuizService;
        private Mock<ICategoryQuizService> _mockCategoryQuizService;

        private QuizCreationService _quizCreationService;

        [SetUp]
        public void SetUp()
        {
            _mockQuizService = new Mock<IQuizService>();
            _mockCategoryQuizService = new Mock<ICategoryQuizService>();
            _quizCreationService = new QuizCreationService(_mockQuizService.Object, _mockCategoryQuizService.Object);
        }

        [Test]
        public async Task Creation_WithAlreadyExistingQuestion_ReturnsQuestionAlreadyExists()
        {
            string question = "My name ?";

            _mockQuizService.Setup(s => s.GetByQuestion(question)).ReturnsAsync(new Quiz());

            CreationQuizResult expected = CreationQuizResult.QuestionAlreadyExists;

            CreationQuizResult actual = await _quizCreationService.Creation(question, It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Category>());

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public async Task Creation_WithEmptyData_ReturnsEmptyData()
        {
            CreationQuizResult expected = CreationQuizResult.EmptyData;

            CreationQuizResult actual = await _quizCreationService.Creation(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Category>());

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public async Task Creation_WithOutCorrectAnswer_ReturnsCorrectAnswerDoNotMatch()
        {
            string correctAns = "testCorrectAns";

            CreationQuizResult expected = CreationQuizResult.CorrectAnswerDoNotMatch;

            CreationQuizResult actual = await _quizCreationService.Creation(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), correctAns, It.IsAny<Category>());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task Creation_WithNonExistingQuestionAndNoEmptyData_ReturnsSuccess()
        {
            string question = "My name ?";
            string correctAns = "testCorrectAns";
            string ansA = "1";
            string ansB = "2";
            string ansC = "3";
            string ansD = "testCorrectAns";

            Category category = new Category();

            CreationQuizResult expected = CreationQuizResult.SuccessCreation;

            CreationQuizResult actual = await _quizCreationService.Creation(question, ansA,
               ansB, ansC, ansD, correctAns, category);

            Assert.AreEqual(expected, actual);
        }

    }
}