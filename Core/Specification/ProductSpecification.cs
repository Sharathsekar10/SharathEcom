using System;
using System.Linq.Expressions;
using Core.Models;

namespace Core.Specification
{
    public class ProductSpecification :Specification<Product>
    {
        public ProductSpecification( ProductSpecificationParam productsParam) : base(x=>(
                                    (string.IsNullOrEmpty(productsParam.Search) ||x.Name.ToLower().Contains(productsParam.Search)  )&&
                                    (!productsParam.BrandId.HasValue || x.ProductBrandId == productsParam.BrandId)&&
                                    (!productsParam.TypeId.HasValue ||x.ProductTypeId == productsParam.TypeId )
                                    ))
        {
            AddIncludes(p=>p.ProductType);
            AddIncludes(p=>p.ProductBrand);
            AddOrderBy(p=>p.Name);

            if(!string.IsNullOrEmpty(productsParam.Sort))
            {
               switch(productsParam.Sort)
               {
                    case "priceAsc" :
                    AddOrderBy(p=>p.Price);
                    break;

                    case "priceDesc" :
                    AddOrderByDescending(p=>p.Price);
                    break;

                    default:
                    AddOrderBy(p=>p.Name);
                    break;
               }
            }

            AddPagination(productsParam.PageSize * (productsParam.PageIndex -1),productsParam.PageSize);

            
        }

        public ProductSpecification(int id) : base(p=>p.Id == id)
        {
            AddIncludes(p=>p.ProductType);
            AddIncludes(p=>p.ProductBrand);
        }
    }
}