using API.DTO;
using AutoMapper;
using Core.Models;

namespace API.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product,ProductDTO>()
            .ForMember((p=>p.ProductBrand),o=>o.MapFrom(d=>d.ProductBrand.Name))
            .ForMember((p=>p.ProductType),o=>o.MapFrom(d=>d.ProductType.Name))
            .ForMember((p=>p.ImageUrl),o=>o.MapFrom<ProducturlResolver>());
            
        }
    }
}