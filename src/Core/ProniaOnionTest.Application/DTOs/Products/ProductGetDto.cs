using ProniaOnionTest.Application.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnionTest.Application.DTOs.Products
{
    public record ProductGetDto(int Id, string Name, decimal Price, string SKU, string? Describtion, int CategoryId, IncludeCategoryDto Category);
}
