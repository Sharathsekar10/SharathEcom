using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interface;

namespace API.Controllers
{
    [ApiController]
    [Route("api/Products")]
    public class ProductsController : ControllerBase
    {
      
        private readonly IProductRepository _ProductRepo;
        public ProductsController(IProductRepository ProductRepo)
        {
            _ProductRepo = ProductRepo;
            

        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _ProductRepo.GetAllProduct();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _ProductRepo.GetProductByIdAsync(id);

            return product;
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<Product>>> GetBrands()
        {
            var productBrand = await _ProductRepo.GetProductBrands();

            return Ok(productBrand);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetTypes(int id)
        {
            var productTypes = await _ProductRepo.GetProductTypes();

            return Ok(productTypes);
        }
    }
}