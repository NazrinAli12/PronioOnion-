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
    internal class ColorRepository:Repository<Color>, IColorRepository
    {
        public ColorRepository(AppDbContext context):base(context)
        {                
        }
    }
}
