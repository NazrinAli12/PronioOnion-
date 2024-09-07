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
    internal class ProductRepository:Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) { }

    }
}
