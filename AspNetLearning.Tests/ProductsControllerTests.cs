using AspNetLearning.Api.Controllers;
using AspNetLearning.Api.Dtos;
using AspNetLearning.Api.Models;
using AspNetLearning.Api.Repositories;
using AspNetLearning.Api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AspNetLearning.Tests
{
    public class ProductsControllerTests
    {
        [Fact]
        public async Task GetById_ProductExists_ReturnsMappedProductDto()
        {
            Mock<IProductRepository> repositoryMock = new();
            Mock<IMapper> mapperMock = new();

            Product product = new()
            {
                Id = 1,
                Name = "Klavye",
                Price = 1000m,
                Stock = 5
            };

            ProductDto productDto = new()
            {
                Id = 1,
                Name = "Klavye",
                Price = 1000m,
                Stock = 5
            };

            repositoryMock
                .Setup(repository => repository.GetByIdAsync(1))
                .ReturnsAsync(product);

            mapperMock
                .Setup(mapper => mapper.Map<ProductDto>(product))
                .Returns(productDto);

            ProductService productService =
                new ProductService(repositoryMock.Object);

            ProductsController controller =
                new ProductsController(
                    productService,
                    mapperMock.Object);

            ActionResult<ProductDto> response =
                await controller.GetById(1);

            OkObjectResult okResult =
                Assert.IsType<OkObjectResult>(response.Result);

            ProductDto result =
                Assert.IsType<ProductDto>(okResult.Value);

            Assert.Equal(1, result.Id);
            Assert.Equal("Klavye", result.Name);
            Assert.Equal(1000m, result.Price);
            Assert.Equal(5, result.Stock);

            repositoryMock.Verify(
                repository => repository.GetByIdAsync(1),
                Times.Once);

            mapperMock.Verify(
                mapper => mapper.Map<ProductDto>(product),
                Times.Once);
        }
    }
}
