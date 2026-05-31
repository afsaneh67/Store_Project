using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Specifications
{
    public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Predicate { get; }

        public List<Expression<Func<T, object>>> Include { get; } = new();

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDesc { get; private set; }
        public int Take { get; set; }
        public int Skip { get; set; }
        public bool IsPagingEnabled { get; set; } = true;

       
        public BaseSpecification()
        {
        }

        public BaseSpecification(Expression<Func<T, bool>> predicate)
        {
            Predicate = predicate;
        }
        public void AddInclude(Expression<Func<T, object>> include)
        {
            Include.Add(include);
        }
        public void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }
        public void AddOrderByDesc(Expression<Func<T, object>> orderByExpressionDesc)
        {
            OrderByDesc = orderByExpressionDesc;
        }
        public void ApplyPaging(int skip, int take, bool isPagingEnabled =true)
        {
            Take = take;
            Skip = skip;
            IsPagingEnabled = isPagingEnabled;
        }
    }
}
