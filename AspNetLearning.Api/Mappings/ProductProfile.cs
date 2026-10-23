using AspNetLearning.Api.Dtos;
using AspNetLearning.Api.Models;
using AutoMapper;

namespace AspNetLearning.Api.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ReverseMap();
        }
    }
}