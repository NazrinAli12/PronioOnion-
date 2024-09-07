using AutoMapper;
using ProniaOnionTest.Application.DTOs.Categories;
using ProniaOnionTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnionTest.Application.MappingProfiles
{
    internal class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryItemDto>().ReverseMap();
            CreateMap<Category, IncludeCategoryDto>().ReverseMap();
            CreateMap<Category, CategoryCreateDto>();
        }
    }
}
