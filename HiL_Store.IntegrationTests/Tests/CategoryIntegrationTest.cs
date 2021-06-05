using HiL_Store.Domain.Entities.QuizEntities;
using HiL_Store.Domain.Interfaces.Repository;
using HiL_Store.EntityFramework;
using HiL_Store.EntityFramework.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HiL_Store.IntegrationTests.Tests
{
    [TestFixture()]
    public class CategoryIntegrationTest
    {

        private readonly HiLDbContext _context;

        public CategoryIntegrationTest()
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
        public void Category_AddCategory_CategoriesIncreased()
        {

            _context.Categories.Add(new Category { Name = "Category1" });
            _context.SaveChanges();

            var a = _context.Categories.ToList().FirstOrDefault(x => x.Name == "Category1");

            Assert.IsTrue(a.Name == "Category1");

            Dispose();
            _context.SaveChanges();
        }

        [Test]
        public void Category_AddCategories_CategoriesIsAdded()
        {

            _context.Categories.Add(new Category { Name = "Category1" });
            _context.Categories.Add(new Category { Name = "Category2" });
            _context.Categories.Add(new Category { Name = "Category3" });
            _context.Categories.Add(new Category { Name = "Category4" });
            _context.SaveChanges();

            var count = _context.Categories.ToList().Count;

            Assert.IsTrue(count == 4);

            Dispose();

            _context.SaveChanges();

        }


        [Test]
        public void Category_DeleteCategory_OneLessCategory()
        {


            _context.Categories.Add(new Category { Name = "Category1" });
            _context.Categories.Add(new Category { Name = "Category2" });

            _context.SaveChanges();

            var countBeforeDelete = _context.Categories.ToList().Count;

            var objectForDelete = _context.Categories.ToList().FirstOrDefault(x => x.Name == "Category1");

            _context.Categories.Remove(objectForDelete);

            _context.SaveChanges();

            var countAfterDelete = _context.Categories.ToList().Count;

            Assert.IsTrue(countAfterDelete == countBeforeDelete - 1);

            Dispose();

        }


        [Test]
        public void Category_UpdateCategory_ChangedCategory()
        {

            _context.Categories.Add(new Category { Name = "Category1" });

            _context.SaveChanges();

            var updatedCategory = _context.Categories
                .Where(c => c.Name == "Category1")
                .FirstOrDefault();

            updatedCategory.Name = "NoCategory1";

            _context.SaveChanges();

            Assert.IsTrue(updatedCategory.Name != "Category1");

            Dispose();

        }


        public void Dispose()
        {
            _context.Database.EnsureDeleted();

            _context.SaveChanges();
        }

    }
}
