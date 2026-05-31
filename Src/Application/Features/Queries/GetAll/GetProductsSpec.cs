using Application.Contracts.Specifications;
using Application.Features.Queries.GetAll;
using Application.Wrappers;
using Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetAll
{
    public class GetProductsSpec:BaseSpecification<Product>
    {
        public GetProductsSpec(GetAllProductsQuery paramsSpec) :
            base(Expression.ExpressionSpec(paramsSpec))
        {
            if (paramsSpec.TypeSort == TypeSort.Desc)
            {
                switch (paramsSpec.Sort)
                {
                    case 1:
                        AddOrderByDesc(x => x.Title);
                        break;
                    case 2:
                        AddOrderByDesc(x => x.productType.Title);
                        break;
                    default:
                        AddOrderByDesc(x => x.Title);
                        break;
                }

            }
            else
            {
                switch (paramsSpec.Sort)
                {
                    case 1:
                        AddOrderBy(x => x.Title);
                        break;
                    case 2:
                        AddOrderBy(x => x.productType.Title);
                        break;
                    default:
                        AddOrderBy(x => x.Title);
                        break;
                }
            }

            ApplyPaging(paramsSpec.PageSize * (paramsSpec.PageIndex - 1), paramsSpec.PageSize, true);

            AddInclude(x => x.productBrand);
            AddInclude(x => x.productType);


        }

        public GetProductsSpec(int id):base(x=>x.Id==id)
        {
            AddInclude(x => x.productBrand);
            AddInclude(x => x.productType);
        }


    }
}

public class ProductsCountSpec : BaseSpecification<Product>
{
    public ProductsCountSpec(GetAllProductsQuery paramsSpec) :
           base(Expression.ExpressionSpec(paramsSpec))
    {
        IsPagingEnabled=false;
    }
}

    public static class Expression
{
    public static Expression<Func<Product, bool>> ExpressionSpec(GetAllProductsQuery paramsSpec)
    {
        return x => (string.IsNullOrEmpty(paramsSpec.Search) || x.Title.ToLower().Contains(paramsSpec.Search.ToLower()))
                    && (!paramsSpec.BrandId.HasValue || x.BrandId == paramsSpec.BrandId) &&
                    (!paramsSpec.TypeId.HasValue || x.TypeId == paramsSpec.TypeId);
    }
}