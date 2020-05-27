using System.Linq;
using Core.Interface;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class SpecificationEvaluator<T> where T: BaseModel
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec )
        {
            var query = inputQuery;

            if(spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            if(spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }

            if(spec.OrderByDescending != null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }

            if(spec.IsPaginationEnabled == true)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }

            
            query = spec.Incluldes.Aggregate(query,(current,include) => current.Include(include) );
            

            return query;
        }
    }
}