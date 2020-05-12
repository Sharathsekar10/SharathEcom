using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interface;
using Core.Specification;
using API.DTO;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using API.Error;

namespace API.Controllers
{
   
    public class ProductsController : BaseController
    {
        private readonly IGenericRepository<ProductType> _typeRepo;

        private readonly IGenericRepository<Product> _productRepo;
        
        private readonly IGenericRepository<ProductBrand> _brandRepo;

        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepo,
                                  IGenericRepository<ProductBrand> brandRepo,
                                  IGenericRepository<ProductType> typeRepo,
                                  IMapper mapper
                                  )
        {
            _typeRepo = typeRepo;
            _productRepo = productRepo;
            _brandRepo = brandRepo;
            _mapper = mapper;

        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDTO>>> GetProducts()
        {
            var productSpec = new ProductSpecification();
            var products = await _productRepo.ListAsync(productSpec);

              return Ok( _mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductDTO>>(products));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var productSpecWithId = new ProductSpecification(id);
            var product = await _productRepo.GetEntityWithSpec(productSpecWithId);
            if(product == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return _mapper.Map<Product,ProductDTO>(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductType>>> GetBrands()
        {
            var productBrand = await _brandRepo.GetAllAsyc();

            return Ok(productBrand);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetTypes(int id)
        {
            var productTypes = await _typeRepo.GetAllAsyc();

            return Ok(productTypes);
        }
    }
}