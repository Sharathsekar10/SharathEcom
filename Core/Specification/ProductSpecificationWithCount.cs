using System;
using System.Linq.Expressions;
using Core.Models;

namespace Core.Specification
{
    public class ProductSpecificationWithCount : Specification<Product>
    {
        public ProductSpecificationWithCount(ProductSpecificationParam productsParam) : base(x=>(
                                    (string.IsNullOrEmpty(productsParam.Search) ||x.Name.ToLower().Contains(productsParam.Search)  )&&
                                    (!productsParam.BrandId.HasValue || x.ProductBrandId == productsParam.BrandId)&&
                                    (!productsParam.TypeId.HasValue ||x.ProductTypeId == productsParam.TypeId )
                                    ))
        {
        }
    }
}