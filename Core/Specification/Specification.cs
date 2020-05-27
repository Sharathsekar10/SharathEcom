using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Interface;

namespace Core.Specification
{
    public class Specification<T> : ISpecification<T>
    {
        public Specification()
        {
            
        }
        public Specification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria {get;}

        public List<Expression<Func<T, object>>> Incluldes {get;} = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy {get; private set;}

        public Expression<Func<T, object>> OrderByDescending {get; private set;}

        public int Skip {get; private set;}

        public int Take {get; private set;}

        public bool IsPaginationEnabled {get; private set;}

        protected void AddIncludes(Expression<Func<T, object>> includeExpression) => Incluldes.Add(includeExpression);

        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression) => OrderBy =orderByExpression;

        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression) => OrderByDescending = orderByDescendingExpression;

        protected void AddPagination(int skip, int take)
        {   
            Skip = skip;
            Take = take;
            IsPaginationEnabled= true;

        }
    }
}