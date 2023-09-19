using eHealthcare.Controllers;
using eHealthcare.Data;
using eHealthcare.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace eHealthcare.Tests.Controllers
{
    public class ProductControllerTests
    {

        [Fact]
        public async Task test_returns_all_products()
        {
            // Arrange
            var mockContext = new Mock<eHealthcareContext>();
            mockContext.SetupGet(c => c.Product).Returns((DbSet<Product>)null);

            var mockHubContext = new Mock<IHubContext<BroadcastHub, IHubClient>>();

            var controller = new ProductsController(mockContext.Object, mockHubContext.Object);

            // Act
            var result = await controller.GetProduct();

            // Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result.Result);
        }

        //// returns a specific product
        //[Fact]
        //public async Task test_returns_specific_product()
        //{
        //    // Arrange
        //    var productId = 1;
        //    var product = new Product { Id = productId, Name = "Product 1" };
        //    var mockContext = new Mock<eHealthcareContext>();
        //    mockContext.Setup(c => c.Product.FindAsync(productId)).ReturnsAsync(product);
        //    var controller = new ProductsController(mockContext.Object, null);

        //    // Act
        //    var result = await controller.GetProduct(productId);

        //    // Assert
        //    Assert.Equal(product, result.Value);
        //}

        //// updates a product
        //[Fact]
        //public async Task test_updates_product()
        //{
        //    // Arrange
        //    var productId = 1;
        //    var product = new Product { Id = productId, Name = "Product 1" };
        //    var mockContext = new Mock<eHealthcareContext>();
        //    mockContext.Setup(c => c.Product.FindAsync(productId)).ReturnsAsync(product);

        //    var mockHubContext = new Mock<IHubContext<BroadcastHub, IHubClient>>();

        //    var controller = new ProductsController(mockContext.Object, mockHubContext.Object);

        //    // Act
        //    var result = await controller.PutProduct(productId, product);

        //    // Assert
        //    Assert.IsType<NoContentResult>(result);
        //}

        //// returns 404 if no products exist
        //[Fact]
        //public async Task test_returns_404_if_no_products_exist()
        //{
        //    // Arrange
        //    var products = new List<Product>();
        //    var mockContext = new Mock<eHealthcareContext>();
        //    mockContext.Setup(c => c.Product).Returns((DbSet<Product>)null);
        //    var controller = new ProductsController(mockContext.Object, null);

        //    // Act
        //    var result = await controller.GetProduct();

        //    // Assert
        //    Assert.IsType<NotFoundResult>(result.Result);
        //}

        //// returns 404 if product does not exist
        //[Fact]
        //public async Task test_returns_404_if_product_does_not_exist()
        //{
        //    // Arrange
        //    var productId = 1;
        //    var mockContext = new Mock<eHealthcareContext>();
        //    mockContext.Setup(c => c.Product.FindAsync(productId)).ReturnsAsync((Product)null);
        //    var controller = new ProductsController(mockContext.Object, null);

        //    // Act
        //    var result = await controller.GetProduct(productId);

        //    // Assert
        //    Assert.IsType<NotFoundResult>(result.Result);
        //}

        // returns 400 if id in url does not match id in product object
        [Fact]
        public async Task test_returns_400_if_id_mismatch()
        {
            // Arrange
            var productId = 1;
            var product = new Product { Id = 2, Name = "Product 1" };
            var mockContext = new Mock<eHealthcareContext>();
            var controller = new ProductsController(mockContext.Object, null);

            // Act
            var result = await controller.PutProduct(productId, product);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }


        [Fact]
        public async Task GetProduct_ReturnsNotFound_WhenContextIsNull()
        {
            // Arrange
            var mockContext = new Mock<eHealthcareContext>();
            mockContext.SetupGet(c => c.Product).Returns((DbSet<Product>)null);

            var mockHubContext = new Mock<IHubContext<BroadcastHub, IHubClient>>();

            var controller = new ProductsController(mockContext.Object, mockHubContext.Object);

            // Act
            var result = await controller.GetProduct();

            // Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetProductById_ReturnsNotFound_WhenProductNotFound()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1" },
                new Product { Id = 2, Name = "Product 2" }
            }.AsQueryable();

            var mockDbSet = new Mock<DbSet<Product>>();
            mockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            mockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            mockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            mockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<eHealthcareContext>();
            mockContext.Setup(c => c.Product).Returns(mockDbSet.Object);

            var mockHubContext = new Mock<IHubContext<BroadcastHub, IHubClient>>();

            var controller = new ProductsController(mockContext.Object, mockHubContext.Object);

            // Act
            var result = await controller.GetProduct(3); // Product with ID 3 doesn't exist

            // Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task PutProduct_ReturnsBadRequest_WhenIdMismatch()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1" }
            }.AsQueryable();

            var mockDbSet = new Mock<DbSet<Product>>();
            mockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            mockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            mockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            mockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<eHealthcareContext>();
            mockContext.Setup(c => c.Product).Returns(mockDbSet.Object);

            var mockHubContext = new Mock<IHubContext<BroadcastHub, IHubClient>>();

            var controller = new ProductsController(mockContext.Object, mockHubContext.Object);

            // Act
            var result = await controller.PutProduct(2, new Product { Id = 1, Name = "Updated Product" }); // Mismatched IDs

            // Assert
            var badRequestResult = Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task PostProduct_ReturnsCreatedResponse()
        {
            // Arrange
            var products = new List<Product>().AsQueryable();

            var mockDbSet = new Mock<DbSet<Product>>();
            mockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            mockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            mockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            mockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<eHealthcareContext>();
            mockContext.Setup(c => c.Product).Returns(mockDbSet.Object);

            var mockHubContext = new Mock<IHubContext<BroadcastHub, IHubClient>>();

            var controller = new ProductsController(mockContext.Object, mockHubContext.Object);

            // Act
            var result = await controller.PostProduct(new Product { Id = 1, Name = "New Product" });

            // Assert
            var createdResponse = Assert.IsType<CreatedAtActionResult>(result.Result);
        }

        [Fact]
        public async Task DeleteProduct_ReturnsNotFound_WhenProductNotFound()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1" }
            }.AsQueryable();

            var mockDbSet = new Mock<DbSet<Product>>();
            mockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            mockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            mockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            mockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<eHealthcareContext>();
            mockContext.Setup(c => c.Product).Returns(mockDbSet.Object);

            var mockHubContext = new Mock<IHubContext<BroadcastHub, IHubClient>>();

            var controller = new ProductsController(mockContext.Object, mockHubContext.Object);

            // Act
            var result = await controller.DeleteProduct(2); // Product with ID 2 doesn't exist

            // Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
        }

    }
}