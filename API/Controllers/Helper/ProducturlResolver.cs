using API.DTO;
using AutoMapper;
using Core.Models;
using Microsoft.Extensions.Configuration;

namespace API.Controllers.Helper
{
    public class ProducturlResolver : IValueResolver<Product, ProductDTO, string>
    {
        private readonly IConfiguration _config;
        public ProducturlResolver(IConfiguration config)
        {
            _config = config;

        }

        public string Resolve(Product source, ProductDTO destination, string destMember, ResolutionContext context)
        {
                return _config["ApiUrl"] + source.ImageUrl;
        }
    }
}