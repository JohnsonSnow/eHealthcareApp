using eHealthcare.Controllers;
using eHealthcare.Data;
using eHealthcare.Dto;
using eHealthcare.Entities;
using eHealthcare.Repositories;
using eHealthcare.Repositories.Interfaces;
using eHealthcare.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace eHealthcare.Tests.Controllers
{
    public class ActiveIngredientControllerTests
    {
        private readonly ActiveIngredientService _sut;
        private readonly Mock<IActiveIngredientRepository> _activeIngredientRepositoryMock = new Mock<IActiveIngredientRepository>();
        private readonly Mock<ILoggingService> _loggerMock = new Mock<ILoggingService>();

        private readonly Mock<IHubContext<BroadcastHub, IHubClient>> _hubContextMock = new Mock<IHubContext<BroadcastHub, IHubClient>>();


        public ActiveIngredientControllerTests()
        {
            _sut = new ActiveIngredientService(_activeIngredientRepositoryMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task GetProductByIdAsync_ShouldReturnProduct_WhenProductExist()
        {
            // Arrange
            var testId = 1;
            var modelDto = new ActiveIngredient
            {
                ActiveIngredientId = testId,
                Name = "Test",
            };
            _activeIngredientRepositoryMock.Setup(x => x.GetByIdAsync(testId)).ReturnsAsync(modelDto);

            // Act
            var product = await _sut.GetByIdAsync(testId);

            // Assert
            Assert.Equal(modelDto.ActiveIngredientId, testId);
        }

        [Fact]
        public async Task GetActiveIngredientByIdAsync_ShouldReturnNoActiveIngredient_WhenItemDoesNotExist()
        {
            // Arrange
            _activeIngredientRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync( () => null);

            // Act
            var product = await _sut.GetByIdAsync(0);

            // Assert
            Assert.Null(product);
        }

       [Fact]
       public async Task GetActiveIngredientsAsync_ShouldReturnListOfItems_WhenItemExist()
       {
            // Arrange
            var ListOfItems = new List<ActiveIngredient>();
            _activeIngredientRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(ListOfItems);

            // Act
            var result = await _sut.GetAllAsync();

            // Assert
            Assert.NotNull(result);
       }

        [Fact]
        public async Task AddActiveIngredienttAsync_ShouldCreateNewProduct_WhenItemCreationIsSuccessful()
        {
            // Arrange
            var modelDto = new ActiveIngredientDTO
            {
                ActiveIngredientId = 1,
            };
            var model = new ActiveIngredient();
            _activeIngredientRepositoryMock.Setup(x => x.AddAsync(modelDto)).ReturnsAsync(model);

            // Act
            var result = await _sut.AddAsync(modelDto);

            // Assert
            Assert.NotNull(result);
        }

    }
}