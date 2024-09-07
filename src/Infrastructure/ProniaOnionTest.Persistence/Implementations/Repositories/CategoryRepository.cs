using ProniaOnionTest.Application.Abstractions.Repositories;
using ProniaOnionTest.Domain.Entities;
using ProniaOnionTest.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnionTest.Persistence.Implementations.Repositories
{
    internal class CategoryRepository:Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context):base(context)
        {      
        }
    }
}
