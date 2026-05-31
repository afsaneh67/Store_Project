using Application.Common.Mapping;
using Application.Common.Mapping.Resolvers;
using Application.Dtos.Common;
using AutoMapper;
using Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Products
{
    public class ProductDto: CommandDto, IMapFrom<Product>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }

        public string productBrand { get; set; }
        public string productType { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDto>()
            .ForMember(x => x.productType, c => c.MapFrom(v => v.productType.Title))
            .ForMember(x => x.productType, c => c.MapFrom(v => v.productType.Title))
            .ForMember(x=>x.PictureUrl,c=>c.MapFrom<ProductImageUrlResolver>());
        }

    }
}
