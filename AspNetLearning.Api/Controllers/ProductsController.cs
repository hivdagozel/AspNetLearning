using AspNetLearning.Api.Dtos;
using AspNetLearning.Api.Models;
using AspNetLearning.Api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AspNetLearning.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(
            ProductService productService,
            IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAll()
        {
            List<Product> products =
                await _productService.GetAllAsync();

            List<ProductDto> productDtos =
                _mapper.Map<List<ProductDto>>(products);

            return Ok(productDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            Product? product =
                await _productService.GetByIdAsync(id);

            if (product is null)
            {
                return NotFound();
            }

            ProductDto productDto =
                _mapper.Map<ProductDto>(product);

            return Ok(productDto);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create(
            ProductDto productDto)
        {
            Product product =
                _mapper.Map<Product>(productDto);

            Product? createdProduct =
                await _productService.AddAsync(product);

            if (createdProduct is null)
            {
                return BadRequest("Ürün bilgileri geçersiz.");
            }

            ProductDto createdProductDto =
                _mapper.Map<ProductDto>(createdProduct);

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdProduct.Id },
                createdProductDto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            int id,
            ProductDto productDto)
        {
            if (id <= 0)
            {
                return BadRequest("Geçersiz ürün numarası.");
            }

            productDto.Id = id;

            Product product =
                _mapper.Map<Product>(productDto);

            bool updated =
                await _productService.UpdateAsync(product);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleted =
                await _productService.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}