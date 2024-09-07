using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnionTest.Application.Abstractions.Repositories;
using ProniaOnionTest.Application.Abstractions.Services;
using ProniaOnionTest.Application.DTOs.Categories;
using ProniaOnionTest.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnionTest.Persistence.Implementations.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ICollection<CategoryItemDto>> GetAllAsync(int page, int take)
        {
            ICollection<Category> categories = await _repository.GetAllWhere(skip: (page - 1) * take, take: take).ToListAsync(); //datani cekdik indi 
            ////indi datani gondermeeliyik controllere:getCateoryDto-nun icine yigmaliyiq sonra:
            //ICollection<CategoryItemDto> dtos = new List<CategoryItemDto>();
            //foreach (var category in categories)
            //{
            //    dtos.Add(new CategoryItemDto(category.Id, category.Name));
            //}
            //return dtos;
            return _mapper.Map<ICollection<CategoryItemDto>>(categories);
        }
      
        public async Task Create(CategoryCreateDto dto)
        {
            await _repository.AddAsync(new Category
            {
                Name = dto.Name,
            });
            await _repository.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(int id)
        {
            Category category = await _repository.GetByIdAsync(id, true);
            if (category is null) throw new Exception("Not Found:))");
            _repository.SoftDelete(category);
            await _repository.SaveChangesAsync();
        }
        //public async Task<GetCategoryDto> GetAsync(int id)
        //{
        //    Category category = await _repository.GetByIdAsync(id);
        //    if (category is null) throw new Exception("Not found");
        //    return new GetCategoryDto
        //    {
        //        Id = category.Id,
        //        Name = category.Name,
        //    };
        //}
    }

}
