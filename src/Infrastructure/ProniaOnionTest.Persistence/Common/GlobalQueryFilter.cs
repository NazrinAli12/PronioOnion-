﻿using Microsoft.EntityFrameworkCore;
using ProniaOnionTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnionTest.Persistence.Common
{
    internal static class GlobalQueryFilter
    {
        public static void ApplyFilter<T>(this ModelBuilder builder) where T : BaseEntity, new()
        {
            builder.Entity<T>().HasQueryFilter(x => x.IsDeleted == false);
        }
        public static void ApplyQueryFilters(this ModelBuilder builder)
        {
            builder.ApplyFilter<Product>();
            builder.ApplyFilter<Color>();
            builder.ApplyFilter<Category>();
            builder.ApplyFilter<ProductColor>();
        }

    }
}
