using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Core.Interface;
using Core.Specification;
using API.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using API.Error;
using API.Helper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    public class ProductsController : BaseController
    {
        private readonly IGenericRepository<ProductType> _typeRepo;

        private readonly IGenericRepository<Product> _productRepo;
        
        private readonly IGenericRepository<ProductBrand> _brandRepo;

        private readonly IMapper _mapper;

         private readonly AppDbContext _context;

        public ProductsController(IGenericRepository<Product> productRepo,
                                  IGenericRepository<ProductBrand> brandRepo,
                                  IGenericRepository<ProductType> typeRepo,
                                  IMapper mapper,
                                  AppDbContext context
                                  )
        {
            _typeRepo = typeRepo;
            _productRepo = productRepo;
            _brandRepo = brandRepo;
            _mapper = mapper;
            _context = context;

        }
        [HttpGet]
        public async Task<ActionResult<Pagination<ProductDTO>>> GetProducts([FromQuery] ProductSpecificationParam productsParam)
        {
            var productSpec = new ProductSpecification(productsParam);
            var countSpec = new ProductSpecificationWithCount(productsParam);
            var products = await _productRepo.ListAsync(productSpec);
            var count = await _productRepo.CountAsync(countSpec);
            var data = _mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductDTO>>(products);
              return Ok( new Pagination<ProductDTO>(productsParam.PageSize,productsParam.PageIndex,count,data));
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

        [HttpGet("dummy")]
        public async Task<ActionResult<List<ProductDTO>>> DummyProducts()
        {
            var product = await  _context.Products.ToListAsync();
            return   _mapper.Map<List<Product>,List<ProductDTO>>(product);
        }
    }
}