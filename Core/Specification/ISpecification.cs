using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Interface
{
    public interface ISpecification<T>
    {
        Expression<Func<T,bool>> Criteria {get;}

        List<Expression<Func<T,object>>> Incluldes {get;}

        Expression<Func<T,object>> OrderBy {get;}

        Expression<Func<T,object>> OrderByDescending {get; }

        int Skip{get;}

        int Take{get;}

        bool IsPaginationEnabled{get;}
    }
}