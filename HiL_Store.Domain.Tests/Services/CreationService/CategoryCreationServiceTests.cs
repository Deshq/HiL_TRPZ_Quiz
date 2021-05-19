using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using System.Threading.Tasks;
using HiL_Store.Domain.Interfaces.CreationService;
using HiL_Store.Domain.Interfaces.Repository;
using HiL_Store.Domain.Services.CreationService;

namespace HiL_Store.Domain.Tests.Services.CreationService
{
    [TestFixture()]
    public class CategoryCreationServiceTests
    {
        private Mock<ICategoryService> _mockCategoryService;

        private CategoryCreationService _сategoryCreationService;

        [SetUp]
        public void SetUp()
        {
            _mockCategoryService = new Mock<ICategoryService>();
            _сategoryCreationService = new CategoryCreationService(_mockCategoryService.Object);
        }

        [Test]
        public async Task Creation_WithAlreadyExistingCategory_ReturnsCategoryAlreadyExists()
        {
            string category = "Anime";

            _mockCategoryService.Setup(s => s.GetByCategory(category)).ReturnsAsync(new Entities.QuizEntities.Category());
            CreationCategoryResult expected = CreationCategoryResult.CategoryAlreadyExists;

            CreationCategoryResult actual = await _сategoryCreationService.Creation(category);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task Creation_WithZeroCategory_ReturnsEmptyData()
        {
            CreationCategoryResult expected = CreationCategoryResult.EmptyData;

            CreationCategoryResult actual = await _сategoryCreationService.Creation(It.IsAny<string>());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task Creation_WithNonExistingCategory_ReturnsSuccess()
        {
            string category = "Anime";

            CreationCategoryResult expected = CreationCategoryResult.SuccessCreation;

            CreationCategoryResult actual = await _сategoryCreationService.Creation(category);

            Assert.AreEqual(expected, actual);
        }



    }
}