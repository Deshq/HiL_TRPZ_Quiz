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
    public class CategoryQuizIntegrationTest
    {
        private readonly HiLDbContext _context;

        public CategoryQuizIntegrationTest()
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
        public void CategoryQuiz_AddIdCategoryToIdQuiz_CategoryQuizIncreased()
        {
            _context.Categories.Add(new Domain.Entities.QuizEntities.Category { Name = "Category1" });

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

            _context.CategoryQuizzes.Add(new Domain.Entities.QuizEntities.CategoryQuiz
            {
               CategoryID = _context.Categories.ToList().FirstOrDefault(x => x.Name == "Category1").Id,
               QuizID = _context.Quizzes.ToList().FirstOrDefault(x => x.Question == "Q1").Id
            });

            _context.SaveChanges();

            var a = _context.CategoryQuizzes.ToList().FirstOrDefault(x => x.Id == 1);

            Assert.IsTrue(a.Category.Name == "Category1");
            Assert.IsTrue(a.Quiz.Question == "Q1");

            Dispose();

        }

        [Test]
        public void CategoryQuiz_AddTwoCategoryQuiz_CategoryQuizzesIsAdded()
        {

            _context.Categories.Add(new Domain.Entities.QuizEntities.Category { Name = "Category1" });

            _context.Quizzes.Add(new Domain.Entities.QuizEntities.Quiz
            {
                Question = "Q1",
                AnswerA = "A",
                AnswerB = "B",
                AnswerC = "C",
                AnswerD = "D",
                CorrectAnswer = "D"
            });

            _context.Categories.Add(new Domain.Entities.QuizEntities.Category { Name = "Category2" });

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

            _context.CategoryQuizzes.Add(new Domain.Entities.QuizEntities.CategoryQuiz
            {
                CategoryID = _context.Categories.ToList().FirstOrDefault(x => x.Name == "Category1").Id,
                QuizID = _context.Quizzes.ToList().FirstOrDefault(x => x.Question == "Q1").Id
            });

            _context.CategoryQuizzes.Add(new Domain.Entities.QuizEntities.CategoryQuiz
            {
                CategoryID = _context.Categories.ToList().FirstOrDefault(x => x.Name == "Category2").Id,
                QuizID = _context.Quizzes.ToList().FirstOrDefault(x => x.Question == "Q2").Id
            });

            _context.SaveChanges();

            var count = _context.CategoryQuizzes.ToList().Count;

            Assert.IsTrue(count == 2);

            Dispose();

        }


        [Test]
        public void CategoryQuiz_DeleteCategoryQuiz_OneLessCategoryQuiz()
        {

            _context.Categories.Add(new Domain.Entities.QuizEntities.Category { Name = "Category1" });

            _context.Quizzes.Add(new Domain.Entities.QuizEntities.Quiz
            {
                Question = "Q1",
                AnswerA = "A",
                AnswerB = "B",
                AnswerC = "C",
                AnswerD = "D",
                CorrectAnswer = "D"
            });

            _context.Categories.Add(new Domain.Entities.QuizEntities.Category { Name = "Category2" });

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

            _context.CategoryQuizzes.Add(new Domain.Entities.QuizEntities.CategoryQuiz
            {
                CategoryID = _context.Categories.ToList().FirstOrDefault(x => x.Name == "Category1").Id,
                QuizID = _context.Quizzes.ToList().FirstOrDefault(x => x.Question == "Q1").Id
            });

            _context.CategoryQuizzes.Add(new Domain.Entities.QuizEntities.CategoryQuiz
            {
                CategoryID = _context.Categories.ToList().FirstOrDefault(x => x.Name == "Category2").Id,
                QuizID = _context.Quizzes.ToList().FirstOrDefault(x => x.Question == "Q2").Id
            });

            _context.SaveChanges();

            var countBeforeDelete = _context.CategoryQuizzes.ToList().Count;

            var objectForDelete = _context.CategoryQuizzes.ToList().FirstOrDefault(x => x.Id == 1);

            _context.CategoryQuizzes.Remove(objectForDelete);

            _context.SaveChanges();

            var countAfterDelete = _context.CategoryQuizzes.ToList().Count;

            Assert.IsTrue(countAfterDelete == countBeforeDelete - 1);

            Dispose();

        }


        [Test]
        public void CategoryQuiz_UpdateCategoryQuiz_ChangedCategoryForQuiz()
        {
            _context.Categories.Add(new Domain.Entities.QuizEntities.Category { Name = "Category1" });

            _context.Categories.Add(new Domain.Entities.QuizEntities.Category { Name = "Category2" });

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

            _context.CategoryQuizzes.Add(new Domain.Entities.QuizEntities.CategoryQuiz
            {
                CategoryID = _context.Categories.ToList().FirstOrDefault(x => x.Name == "Category1").Id,
                QuizID = _context.Quizzes.ToList().FirstOrDefault(x => x.Question == "Q1").Id
            });

            _context.SaveChanges();

            var updatedCategory = _context.CategoryQuizzes
                .Where(c => c.Category.Name == "Category1")
                .FirstOrDefault();

            updatedCategory.CategoryID = _context.Categories.ToList().FirstOrDefault(x => x.Name == "Category2").Id;

            _context.SaveChanges();

            Assert.IsTrue(updatedCategory.Category.Name == "Category2");

            Dispose();
        }


        public void Dispose()
        {
            _context.Database.EnsureDeleted();

            _context.SaveChanges();
        }
    }
}
