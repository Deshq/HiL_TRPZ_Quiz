using HiL_Store.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiL_Store.IntegrationTests.Tests
{
    [TestFixture()]
    public class QuizIntegrationTest
    {
        private readonly HiLDbContext _context;

        public QuizIntegrationTest()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkSqlServer()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<HiLDbContext>();

            builder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=HIL_TEST_DB.MDF;Trusted_Connection=True;");

            _context = new HiLDbContext(builder.Options);
            _context.Database.Migrate();


        }

        [Test]
        public void Quiz_AddQuiz_QuizzesIncreased()
        {

            _context.Quizzes.Add(new Domain.Entities.QuizEntities.Quiz
            {
                Question = "Q1",
                AnswerA = "A",
                AnswerB = "B",
                AnswerC = "C",
                AnswerD = "D",
                CorrectAnswer = "D"
            });

            _context.SaveChanges();

            var a = _context.Quizzes.ToList().FirstOrDefault(x => x.Question == "Q1");

            Assert.IsTrue(a.Question == "Q1");

            Dispose();
            _context.SaveChanges();
        }

        [Test]
        public void Quiz_AddQuizzes_QuizzesIsAdded()
        {

            _context.Quizzes.Add(new Domain.Entities.QuizEntities.Quiz
            {
                Question = "Q1",
                AnswerA = "A",
                AnswerB = "B",
                AnswerC = "C",
                AnswerD = "D",
                CorrectAnswer = "D"
            });

            _context.Quizzes.Add(new Domain.Entities.QuizEntities.Quiz
            {
                Question = "Q2",
                AnswerA = "A",
                AnswerB = "B",
                AnswerC = "C",
                AnswerD = "D",
                CorrectAnswer = "A"
            });

            _context.Quizzes.Add(new Domain.Entities.QuizEntities.Quiz
            {
                Question = "Q3",
                AnswerA = "A",
                AnswerB = "B",
                AnswerC = "C",
                AnswerD = "D",
                CorrectAnswer = "D"
            });

            _context.Quizzes.Add(new Domain.Entities.QuizEntities.Quiz
            {
                Question = "Q4",
                AnswerA = "A",
                AnswerB = "B",
                AnswerC = "C",
                AnswerD = "D",
                CorrectAnswer = "D"
            });

            _context.SaveChanges();

            var count = _context.Quizzes.ToList().Count;

            Assert.IsTrue(count == 4);

            Dispose();

            _context.SaveChanges();

        }


        [Test]
        public void Quiz_DeleteQuiz_OneLessQuiz()
        {

            _context.Quizzes.Add(new Domain.Entities.QuizEntities.Quiz
            {
                Question = "Q1",
                AnswerA = "A",
                AnswerB = "B",
                AnswerC = "C",
                AnswerD = "D",
                CorrectAnswer = "D"
            });

            _context.Quizzes.Add(new Domain.Entities.QuizEntities.Quiz
            {
                Question = "Q2",
                AnswerA = "A",
                AnswerB = "B",
                AnswerC = "C",
                AnswerD = "D",
                CorrectAnswer = "A"
            });

            _context.SaveChanges();

            var countBeforeDelete = _context.Quizzes.ToList().Count;

            var objectForDelete = _context.Quizzes.ToList().FirstOrDefault(x => x.Question == "Q1");

            _context.Quizzes.Remove(objectForDelete);

            _context.SaveChanges();

            var countAfterDelete = _context.Quizzes.ToList().Count;

            Assert.IsTrue(countAfterDelete == countBeforeDelete - 1);

            Dispose();

        }


        [Test]
        public void Quiz_UpdateCorrectAnswerForQuiz_ChangedQuiz()
        {

            _context.Quizzes.Add(new Domain.Entities.QuizEntities.Quiz
            {
                Question = "Q1",
                AnswerA = "A",
                AnswerB = "B",
                AnswerC = "C",
                AnswerD = "D",
                CorrectAnswer = "D"
            });

            _context.SaveChanges();

            var updatedCategory = _context.Quizzes
                .Where(c => c.Question == "Q1")
                .FirstOrDefault();

            updatedCategory.CorrectAnswer = "A";

            _context.SaveChanges();

            Assert.IsTrue(updatedCategory.CorrectAnswer != "D");

            Dispose();

        }


        public void Dispose()
        {
            _context.Database.EnsureDeleted();

            _context.SaveChanges();
        }
    }
}
