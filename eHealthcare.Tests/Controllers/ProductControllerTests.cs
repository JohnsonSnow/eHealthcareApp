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
    public class ProductControllerTests
    {
        private readonly ProductService _sut;
        private readonly Mock<IProductRepository> _productRepositoryMock = new Mock<IProductRepository>();
        private readonly Mock<ILoggingService> _loggerMock = new Mock<ILoggingService>();

        private readonly Mock<IHubContext<BroadcastHub, IHubClient>> _hubContextMock = new Mock<IHubContext<BroadcastHub, IHubClient>>();


        public ProductControllerTests()
        {
            _sut = new ProductService(_productRepositoryMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task GetProductByIdAsync_ShouldReturnProduct_WhenProductExist()
        {
            // Arrange
            var productId = 1;
            var productDto = new Product
            {
                Id = productId,
            };
            _productRepositoryMock.Setup(x => x.GetProductByIdAsync(productId)).ReturnsAsync(productDto);

            // Act
            var product = await _sut.GetProductByIdAsync(productId);

            // Assert
            Assert.Equal(product.Id, productId);
        }

        [Fact]
        public async Task GetProductByIdAsync_ShouldReturnNoProduct_WhenProductDoesNotExist()
        {
            // Arrange
            _productRepositoryMock.Setup(x => x.GetProductByIdAsync(It.IsAny<int>())).ReturnsAsync( () => null);

            // Act
            var product = await _sut.GetProductByIdAsync(0);

            // Assert
            Assert.Null(product);
        }

       [Fact]
       public async Task GetProductsAsync_ShouldReturnListOfProduct_WhenProductExist()
       {
            // Arrange
            var ListOfProducts = new List<Product>();
            _productRepositoryMock.Setup(x => x.GetProductsAsync()).ReturnsAsync(ListOfProducts);

            // Act
            var products = await _sut.GetProductsAsync();

            // Assert
            Assert.NotNull(products);
       }

        [Fact]
        public async Task AddproductAsync_ShouldCreateNewProduct_WhenProductCreationIsSuccessful()
        {
            // Arrange
            var productDto = new ProductDTO
            {
                Id = 1,
            };
            var product = new Product();
            _productRepositoryMock.Setup(x => x.AddproductAsync(productDto)).ReturnsAsync(product);

            // Act
            var result = await _sut.AddproductAsync(productDto);

            // Assert
            Assert.NotNull(result);
        }

    }
}