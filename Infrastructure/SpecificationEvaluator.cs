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

            
                query = spec.Incluldes.Aggregate(query,(current,include) => current.Include(include) );
            

            return query;
        }
    }
}