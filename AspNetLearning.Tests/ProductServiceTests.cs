using AspNetLearning.Api.Models;
using AspNetLearning.Api.Repositories;
using AspNetLearning.Api.Services;
using Moq;

namespace AspNetLearning.Tests
{
    public class ProductServiceTests
    {
        private static ProductService CreateService()
        {
            Mock<IProductRepository> repositoryMock = new();

            return new ProductService(repositoryMock.Object);
        }

        [Fact]
        public void IsValid_ValidProduct_ReturnsTrue()
        {
            ProductService service = CreateService();

            Product product = new()
            {
                Name = "Klavye",
                Price = 1000m,
                Stock = 5
            };

            bool result = service.IsValid(product);

            Assert.True(result);
        }

        [Fact]
        public void IsValid_NullProduct_ReturnsFalse()
        {
            ProductService service = CreateService();

            bool result = service.IsValid(null);

            Assert.False(result);
        }

        [Theory]
        [InlineData("", 1000, 5)]
        [InlineData("   ", 1000, 5)]
        [InlineData("Klavye", 0, 5)]
        [InlineData("Klavye", -100, 5)]
        [InlineData("Klavye", 1000, -1)]
        public void IsValid_InvalidProduct_ReturnsFalse(
            string name,
            double price,
            int stock)
        {
            ProductService service = CreateService();

            Product product = new()
            {
                Name = name,
                Price = (decimal)price,
                Stock = stock
            };

            bool result = service.IsValid(product);

            Assert.False(result);
        }

        [Fact]
        public async Task GetByIdAsync_ProductExists_ReturnsProduct()
        {
            Mock<IProductRepository> repositoryMock = new();

            Product expectedProduct = new()
            {
                Id = 1,
                Name = "Klavye",
                Price = 1000m,
                Stock = 5
            };

            repositoryMock
                .Setup(repository => repository.GetByIdAsync(1))
                .ReturnsAsync(expectedProduct);

            ProductService service =
                new ProductService(repositoryMock.Object);

            Product? result = await service.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Klavye", result.Name);
            Assert.Equal(1000m, result.Price);
            Assert.Equal(5, result.Stock);

            repositoryMock.Verify(
                repository => repository.GetByIdAsync(1),
                Times.Once);
        }

        [Fact]
        public async Task AddAsync_ValidProduct_AddsAndReturnsProduct()
        {
            Mock<IProductRepository> repositoryMock = new();

            Product product = new()
            {
                Name = "Mouse",
                Price = 500m,
                Stock = 10
            };

            repositoryMock
                .Setup(repository => repository.AddAsync(product))
                .ReturnsAsync(product);

            ProductService service =
                new ProductService(repositoryMock.Object);

            Product? result = await service.AddAsync(product);

            Assert.NotNull(result);
            Assert.Equal("Mouse", result.Name);
            Assert.Equal(500m, result.Price);
            Assert.Equal(10, result.Stock);

            repositoryMock.Verify(
                repository => repository.AddAsync(product),
                Times.Once);
        }

        [Fact]
        public async Task AddAsync_InvalidProduct_DoesNotCallRepository()
        {
            Mock<IProductRepository> repositoryMock = new();

            Product invalidProduct = new()
            {
                Name = "",
                Price = 500m,
                Stock = 10
            };

            ProductService service =
                new ProductService(repositoryMock.Object);

            Product? result = await service.AddAsync(invalidProduct);

            Assert.Null(result);

            repositoryMock.Verify(
                repository => repository.AddAsync(It.IsAny<Product>()),
                Times.Never);
        }
    
    [Fact]
        public async Task UpdateAsync_ValidProduct_ReturnsTrue()
        {
            Mock<IProductRepository> repositoryMock = new();

            Product product = new()
            {
                Id = 1,
                Name = "Güncellenmiş Klavye",
                Price = 1500m,
                Stock = 8
            };

            repositoryMock
                .Setup(repository => repository.UpdateAsync(product))
                .ReturnsAsync(true);

            ProductService service =
                new ProductService(repositoryMock.Object);

            bool result = await service.UpdateAsync(product);

            Assert.True(result);

            repositoryMock.Verify(
                repository => repository.UpdateAsync(product),
                Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_InvalidProduct_DoesNotCallRepository()
        {
            Mock<IProductRepository> repositoryMock = new();

            Product invalidProduct = new()
            {
                Id = 1,
                Name = "",
                Price = 1500m,
                Stock = 8
            };

            ProductService service =
                new ProductService(repositoryMock.Object);

            bool result = await service.UpdateAsync(invalidProduct);

            Assert.False(result);

            repositoryMock.Verify(
                repository => repository.UpdateAsync(It.IsAny<Product>()),
                Times.Never);
        }

        [Fact]
        public async Task DeleteAsync_ValidId_ReturnsTrue()
        {
            Mock<IProductRepository> repositoryMock = new();

            repositoryMock
                .Setup(repository => repository.DeleteAsync(1))
                .ReturnsAsync(true);

            ProductService service =
                new ProductService(repositoryMock.Object);

            bool result = await service.DeleteAsync(1);

            Assert.True(result);

            repositoryMock.Verify(
                repository => repository.DeleteAsync(1),
                Times.Once);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public async Task DeleteAsync_InvalidId_DoesNotCallRepository(int id)
        {
            Mock<IProductRepository> repositoryMock = new();

            ProductService service =
                new ProductService(repositoryMock.Object);

            bool result = await service.DeleteAsync(id);

            Assert.False(result);

            repositoryMock.Verify(
                repository => repository.DeleteAsync(It.IsAny<int>()),
                Times.Never);
        }

    } }
