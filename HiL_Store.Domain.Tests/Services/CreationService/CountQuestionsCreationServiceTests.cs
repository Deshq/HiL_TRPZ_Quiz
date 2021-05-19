using HiL_Store.Domain.Interfaces.CreationService;
using HiL_Store.Domain.Interfaces.Repository;
using HiL_Store.Domain.Services.CreationService;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HiL_Store.Domain.Tests.Services.CreationService
{
    [TestFixture()]
    public class CountQuestionsCreationServiceTests
    {

        private Mock<ICountQuestionsService> _mockCountQuestionsService;

        private CountQuestionsCreationService _countQuestionsCreationService;

        [SetUp]
        public void SetUp()
        {
            _mockCountQuestionsService = new Mock<ICountQuestionsService>();
            _countQuestionsCreationService = new CountQuestionsCreationService(_mockCountQuestionsService.Object);
        }

        [Test]
        public async Task Creation_WithEmptyData_ReturnsEmptyData()
        {
            CreationCountQuestionsResult expected = CreationCountQuestionsResult.EmptyData;

            CreationCountQuestionsResult actual = await _countQuestionsCreationService.Creation(It.IsAny<string>());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task Creation_WithCorrectValue_ReturnsSuccess()
        {
            string count = "5";

            CreationCountQuestionsResult expected = CreationCountQuestionsResult.SuccessCreation;

            CreationCountQuestionsResult actual = await _countQuestionsCreationService.Creation(count);

            Assert.AreEqual(expected, actual);
        }
    }
}