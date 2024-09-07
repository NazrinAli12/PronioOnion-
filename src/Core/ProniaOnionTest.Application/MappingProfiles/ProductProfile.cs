using AutoMapper;
using ProniaOnionTest.Application.DTOs.Products;
using ProniaOnionTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnionTest.Application.MappingProfiles
{
    internal class ProductProfile:Profile
    {
        public ProductProfile()
        {
            //ters yazilmalidi ici
            CreateMap<Product, ProductItemDto>().ReverseMap();

            CreateMap<Product,ProductGetDto >().ReverseMap();

            
            CreateMap<Product,  ProductCreateDto>();
            CreateMap<Product,  ProductUpdateDto>().ReverseMap();
        }
    }
}
