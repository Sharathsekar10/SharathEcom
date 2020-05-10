using System;
using System.Linq.Expressions;
using Core.Models;

namespace Core.Specification
{
    public class ProductSpecification :Specification<Product>
    {
        public ProductSpecification()
        {
            AddIncludes(p=>p.ProductType);
            AddIncludes(p=>p.ProductBrand);
        }

        public ProductSpecification(int id) : base(p=>p.Id == id)
        {
            AddIncludes(p=>p.ProductType);
            AddIncludes(p=>p.ProductBrand);
        }
    }
}